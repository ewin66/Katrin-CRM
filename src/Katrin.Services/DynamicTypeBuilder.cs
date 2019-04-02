using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using Katrin.Services.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katrin.Services
{
    public class DynamicTypeBuilder
    {
        internal const string AssemblyName = "ReflectionEmitAssembly";
        private static DynamicTypeBuilder instance;
        private static ModuleBuilder myModule;

        private Dictionary<string, Type> typeCache = new Dictionary<string, Type>();
        private Dictionary<string, TypeBuilder> typeBuilders = new Dictionary<string, TypeBuilder>();

        static DynamicTypeBuilder()
        {
            AppDomain myDomain = AppDomain.CurrentDomain;
            AssemblyName myAsmName = new AssemblyName(AssemblyName);
            AssemblyBuilder myAssembly =
                myDomain.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.RunAndSave);

            myModule = myAssembly.DefineDynamicModule(myAsmName.Name, myAsmName.Name + ".dll");
        }

        private DynamicTypeBuilder()
        {
        }

        public static DynamicTypeBuilder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DynamicTypeBuilder();
                }

                return instance;
            }
        }

        public void BuildDynamicType(IEnumerable<Entity> entities)
        {
            foreach (var entity in entities)
            {
                TypeBuilder typeBuilder =
                myModule.DefineType("Katrin." + entity.PhysicalName, TypeAttributes.Public);
                typeBuilders.Add(entity.PhysicalName, typeBuilder);
            }
            entities.ToList().ForEach(entity => CreateType(entity));
            foreach (var typeBuilder in typeBuilders)
            {
                this.typeCache[typeBuilder.Key] = typeBuilder.Value.CreateType();
            }
        }

        public IEnumerable<Type> DynamicTypes
        {
            get { return typeCache.Values; }
        }


        public Type GetDynamicType(string typeName)
        {
            if (this.typeCache.ContainsKey(typeName))
            {
                return this.typeCache[typeName];
            }

            throw new ApplicationException(string.Format("the type is {0} not build, please build the types first", typeName));
        }

        private void CreateType(Entity entityType)
        {
            // public class Address
            TypeBuilder typeBuilder = typeBuilders[entityType.PhysicalName];

            // Add [DataContract] to the type
            //CustomAttributeBuilder dataContractBuilder = new CustomAttributeBuilder(
            //    typeof(DataContractAttribute).GetConstructor(Type.EmptyTypes),
            //    new object[0]);
            //typeBuilder.SetCustomAttribute(dataContractBuilder);

            // Define fields and properties
            List<PropertyBuilder> propertyBuilders = new List<PropertyBuilder>();
            foreach (var attribute in entityType.Attributes)
            {
                FieldBuilder field =
                    typeBuilder.DefineField(
                        attribute.PhysicalName,
                        GetEquivalentClrType(attribute),
                        FieldAttributes.Private);

                var property = CreateProperty(typeBuilder, attribute.PhysicalName, field);
                propertyBuilders.Add(property);
                if (attribute.IsPKAttribute == true)
                {
                    // Add [Key] to the property
                    var keyAttributeBuilder = new CustomAttributeBuilder(
                        typeof(KeyAttribute).GetConstructor(Type.EmptyTypes), new object[0]);
                    property.SetCustomAttribute(keyAttributeBuilder);
                }
            }

            CreateNavigationProperty(entityType, typeBuilder, propertyBuilders);

            // Override ToString
            OverrideToString(typeBuilder, propertyBuilders.ToArray());
            //return typeBuilder.CreateType();
        }

        private void CreateNavigationProperty(Entity entityType, TypeBuilder typeBuilder, List<PropertyBuilder> propertyBuilders)
        {
            ConstructorBuilder constructor = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes);

            ILGenerator constructorIL = constructor.GetILGenerator();
            constructorIL.Emit(OpCodes.Ldarg_0);
            ConstructorInfo superConstructor = typeof(Object).GetConstructor(new Type[0]);
            constructorIL.Emit(OpCodes.Call, superConstructor);

            foreach (var role in entityType.RelationshipRoles)
            {
                if (role.EntityRelationship.EntityRelationshipType == 0) // one to many
                {
                    if (role.RelationshipRoleType == 1) // the many side
                    {
                        var relationship = role.EntityRelationship.EntityRelationshipRelationships.Single().Relationship;
                        var referencingAttributeName = relationship.ReferencingAttribute.PhysicalName;
                        var propertyName = referencingAttributeName.Replace("Id", string.Empty);
                        var propertyType = typeBuilders[relationship.ReferencedEntity.PhysicalName];
                        FieldBuilder field = typeBuilder.DefineField(propertyName, propertyType, FieldAttributes.Private);

                        var propertyBuilder = CreateProperty(typeBuilder, propertyName, field);
                        var foreignKeyAttributeBuilder = new CustomAttributeBuilder(
                            typeof (ForeignKeyAttribute).GetConstructor(new[] {typeof (string)}),
                            new object[] {referencingAttributeName});
                        propertyBuilder.SetCustomAttribute(foreignKeyAttributeBuilder);
                        AttachAssociationAttribute(relationship, propertyName, propertyBuilder);
                        propertyBuilders.Add(propertyBuilder);
                    }
                    else
                    {
                        var relationship = role.EntityRelationship.EntityRelationshipRelationships.Single().Relationship;
                        CreateNavigationCollectionProperty(typeBuilder, propertyBuilders, constructorIL, relationship);
                    }
                }
                else // many to many
                {
                    if (role.RelationshipRoleType == 2) // one of the main table of the manty-to-many
                    {
                        var relationship = role.EntityRelationship.EntityRelationshipRelationships
                            .Single(r => r.Relationship.ReferencedEntity.PhysicalName == entityType.PhysicalName)
                            .Relationship;
                        CreateNavigationCollectionProperty(typeBuilder, propertyBuilders, constructorIL, relationship);
                    }
                    else // the relationship table of the manty-to-many
                    {
                        foreach (var relationshipRelationship in role.EntityRelationship.EntityRelationshipRelationships)
                        {
                            var relationship = relationshipRelationship.Relationship;
                            var propertyName = relationship.ReferencingAttribute.PhysicalName.Replace("Id", string.Empty);
                            var propertyType = typeBuilders[relationship.ReferencedEntity.PhysicalName];
                            FieldBuilder field = typeBuilder.DefineField(propertyName, propertyType, FieldAttributes.Private);

                            var propertyBuilder = CreateProperty(typeBuilder, propertyName, field);
                            AttachAssociationAttribute(relationship, propertyName, propertyBuilder);
                            propertyBuilders.Add(propertyBuilder);
                        }
                    }
                }
            }

            constructorIL.Emit(OpCodes.Ret);
        }

        private void CreateNavigationCollectionProperty(TypeBuilder typeBuilder, List<PropertyBuilder> propertyBuilders,
                                                        ILGenerator constructorIL, Relationship relationship)
        {
            string entityName = relationship.ReferencingEntity.PhysicalName;
            //var associationAttribute = new AssociationAttribute
            //{
            //    KeyMembers = relationship.ReferencedAttribute.PhysicalName,
            //    RelatedEntityID = relationship.ReferencingEntity.PhysicalName,
            //    RelatedKeyMembers = relationship.ReferencingAttribute.PhysicalName
            //};

            //associationAttribute.Member = propertyName;
            var propertyName = entityName.InflectTo().Pluralized;
            var propertyType = typeBuilders[entityName];
            var listType = typeof(List<>).MakeGenericType(propertyType);
            FieldBuilder field = typeBuilder.DefineField(propertyName, listType, FieldAttributes.Private);

            var propertyBuilder = CreateProperty(typeBuilder, propertyName, field);


            ////[Association(Member = "Orders", KeyMembers = "CustomerID", RelatedEntityID = "Orders", RelatedKeyMembers = "CustomerID")]
            //PropertyInfo memberInfo = typeof(AssociationAttribute).GetProperty("Member");
            //PropertyInfo keyMembersInfo = typeof(AssociationAttribute).GetProperty("KeyMembers");
            //PropertyInfo relatedEntityIDInfo = typeof(AssociationAttribute).GetProperty("RelatedEntityID");
            //PropertyInfo relatedKeyMembers = typeof(AssociationAttribute).GetProperty("RelatedKeyMembers");
            //var associationBuilder = new CustomAttributeBuilder(
            //    typeof(AssociationAttribute).GetConstructor(Type.EmptyTypes),
            //    new object[0], new[] { memberInfo, keyMembersInfo, relatedEntityIDInfo, relatedKeyMembers },
            //    new object[]
            //        {
            //            associationAttribute.Member, associationAttribute.KeyMembers,
            //            associationAttribute.RelatedEntityID, associationAttribute.RelatedKeyMembers
            //        });
            //propertyBuilder.SetCustomAttribute(associationBuilder);

            propertyBuilders.Add(propertyBuilder);

            constructorIL.Emit(OpCodes.Ldarg_0);
            ConstructorInfo ctorPrep = typeof(List<>).GetConstructor(Type.EmptyTypes);
            ConstructorInfo ctor = TypeBuilder.GetConstructor(listType, ctorPrep);
            constructorIL.Emit(OpCodes.Newobj, ctor);
            constructorIL.Emit(OpCodes.Stfld, field);
        }

        private static void AttachAssociationAttribute(Relationship relationship, string propertyName, PropertyBuilder propertyBuilder)
        {
            ////[Association(Member = "Orders", KeyMembers = "CustomerID", RelatedEntityID = "Orders", RelatedKeyMembers = "CustomerID")]
            //PropertyInfo memberInfo = typeof(AssociationAttribute).GetProperty("Member");
            //PropertyInfo keyMembersInfo = typeof(AssociationAttribute).GetProperty("KeyMembers");
            //PropertyInfo relatedEntityIDInfo = typeof(AssociationAttribute).GetProperty("RelatedEntityID");
            //PropertyInfo relatedKeyMembers = typeof(AssociationAttribute).GetProperty("RelatedKeyMembers");
            //CustomAttributeBuilder associationBuilder = new CustomAttributeBuilder(
            //    typeof(AssociationAttribute).GetConstructor(Type.EmptyTypes),
            //    new object[0], new[] { memberInfo, keyMembersInfo, relatedEntityIDInfo, relatedKeyMembers },
            //    new object[]
            //                {
            //                    propertyName, relationship.ReferencingAttribute.PhysicalName,
            //                    relationship.ReferencedEntity.PhysicalName, relationship.ReferencedAttribute.PhysicalName
            //                });
            //propertyBuilder.SetCustomAttribute(associationBuilder);
        }

        private static void OverrideToString(TypeBuilder typeBuilder, params PropertyBuilder[] properties)
        {
            //if (properties == null || properties.Length < 1 || properties.Length > 3)
            //{
            //    throw new NotImplementedException("Only implemented for types with 1-3 properties");
            //}

            MethodBuilder toString = typeBuilder.DefineMethod(
                "ToString",
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Virtual,
                typeof(string),
                Type.EmptyTypes);

            List<Type> stringFormatArgs = new List<Type>();
            stringFormatArgs.Add(typeof(string));
            for (int i = 0; i < properties.Length; i++)
            {
                stringFormatArgs.Add(typeof(object));
            }
            var stringFormat = typeof(string).GetMethods(BindingFlags.Static | BindingFlags.Public)
                .First(m => m.Name == "Format" && m.GetParameters().Any(p => p.IsDefined(typeof(ParamArrayAttribute), false)));

            ILGenerator toStringIL = toString.GetILGenerator();
            StringBuilder sbFormat = new StringBuilder();
            sbFormat.Append(typeBuilder.Name);
            sbFormat.Append('[');
            for (int i = 0; i < properties.Length; i++)
            {
                if (i > 0)
                {
                    sbFormat.Append(',');
                }

                sbFormat.Append(properties[i].Name);
                sbFormat.Append("={");
                sbFormat.Append(i);
                sbFormat.Append("}");
            }

            sbFormat.Append(']');

            toStringIL.Emit(OpCodes.Ldstr, sbFormat.ToString());
            foreach (var property in properties)
            {
                toStringIL.Emit(OpCodes.Ldarg_0);
                toStringIL.Emit(OpCodes.Call, property.GetGetMethod());
                if (property.PropertyType.IsValueType)
                {
                    toStringIL.Emit(OpCodes.Box, property.PropertyType);
                }
            }

            toStringIL.Emit(OpCodes.Call, stringFormat);
            toStringIL.Emit(OpCodes.Ret);
        }

        private static PropertyBuilder CreateProperty(TypeBuilder typeBuilder, string propertyName, FieldBuilder backingField)
        {
            Type propertyType = backingField.FieldType;
            PropertyBuilder property = typeBuilder.DefineProperty(
                propertyName,
                PropertyAttributes.None,
                propertyType,
                Type.EmptyTypes);

            //CustomAttributeBuilder dataMemberAttribute = new CustomAttributeBuilder(
            //    typeof(DataMemberAttribute).GetConstructor(Type.EmptyTypes),
            //    new object[0]);
            //property.SetCustomAttribute(dataMemberAttribute);

            MethodAttributes getSetAttr = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;

            MethodBuilder getMethod = typeBuilder.DefineMethod("get_" + propertyName, getSetAttr, propertyType, Type.EmptyTypes);
            MethodBuilder setMethod = typeBuilder.DefineMethod("set_" + propertyName, getSetAttr, null, new Type[] { propertyType });

            ILGenerator getIL = getMethod.GetILGenerator();
            getIL.Emit(OpCodes.Ldarg_0);
            getIL.Emit(OpCodes.Ldfld, backingField);
            getIL.Emit(OpCodes.Ret);

            ILGenerator setIL = setMethod.GetILGenerator();
            setIL.Emit(OpCodes.Ldarg_0);
            setIL.Emit(OpCodes.Ldarg_1);
            setIL.Emit(OpCodes.Stfld, backingField);
            setIL.Emit(OpCodes.Ret);

            property.SetSetMethod(setMethod);
            property.SetGetMethod(getMethod);

            return property;
        }

        private static Type GetEquivalentClrType(dynamic attribute)
        {
            string typeDescription = attribute.AttributeType.Description;

            bool isNullable = attribute.IsNullable;
            switch (typeDescription.ToLower())
            {
                case "bit":
                    return GetNullableType<bool>(isNullable);
                case "datetime":
                    return GetNullableType<DateTime>(isNullable);
                case "decimal":
                    return GetNullableType<decimal>(isNullable);
                case "float":
                    return GetNullableType<Double>(isNullable);
                case "int":
                case "picklist":
                    return GetNullableType<int>(isNullable);
                case "money":
                    return GetNullableType<decimal>(isNullable);
                case "nvarchar":
                case "nchar":
                case "varchar":
                    return typeof(string);
                case "lookup":
                case "uniqueidentifier":
                    return GetNullableType<Guid>(isNullable);
                case "binary":
                case "varbinary":
                case "timestamp":
                    return typeof(byte[]);
                default:
                    return typeof(string);
                //throw new Exception();
            }
        }

        private static Type GetNullableType<T>(bool isNullable) where T : struct
        {
            return isNullable ? typeof(Nullable<T>) : typeof(T);
        }
    }
}
