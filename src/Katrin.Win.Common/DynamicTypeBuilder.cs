using System;
using System.ComponentModel;
using System.Data.Services.Client;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using Microsoft.Data.Edm;
using System.Data.Services.Common;
using Microsoft.Data.Edm.Library;

namespace Katrin.Win.Common
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
                myDomain.DefineDynamicAssembly(myAsmName,
                    AssemblyBuilderAccess.RunAndSave);

            myModule =
                myAssembly.DefineDynamicModule(myAsmName.Name,
                    myAsmName.Name + ".dll");
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

        public void BuildDynamicType(IEnumerable<IEdmEntityType> entityTypes)
        {
            foreach (var entity in entityTypes)
            {
                TypeBuilder typeBuilder =
                    myModule.DefineType("Katrin." + entity.Name, TypeAttributes.Public);
                typeBuilders.Add(entity.Name, typeBuilder);
            }
            entityTypes.ToList().ForEach(entity => CreateType(entity));
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

        private Type CreateType(IEdmEntityType entityType)
        {
            // public class Address
            TypeBuilder typeBuilder = typeBuilders[entityType.Name];

            var raisePropertyChanged = ImplementateNotifyPropertyChanged(typeBuilder);

            ConstructorBuilder constructor = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes);

            ILGenerator constructorIL = constructor.GetILGenerator();
            constructorIL.Emit(OpCodes.Ldarg_0);
            ConstructorInfo superConstructor = typeof(Object).GetConstructor(new Type[0]);
            constructorIL.Emit(OpCodes.Call, superConstructor);

            object[] keys = entityType.Key().Select(p => p.Name).ToArray();
            var dataServiceKeyBuilder = new CustomAttributeBuilder(typeof(DataServiceKeyAttribute).GetConstructor(new[] { typeof(string) }), keys);
            typeBuilder.SetCustomAttribute(dataServiceKeyBuilder);

            //var entitySetName = entityType.Name.InflectTo().Pluralized;
            //var entitySetBuilder = new CustomAttributeBuilder(typeof(EntitySetAttribute).GetConstructor(new[] { typeof(string) }), new object[] { entitySetName });
            //typeBuilder.SetCustomAttribute(entitySetBuilder);

            // Define fields and properties
            List<PropertyBuilder> propertyBuilders = new List<PropertyBuilder>();
            foreach (var property in entityType.Properties())
            {
                Type fieldType = null;
                var typeKind = property.Type.TypeKind();
                switch (typeKind)
                {
                    case EdmTypeKind.Primitive:
                        fieldType = GetClrEquivalentType(property.Type);
                        break;
                    case EdmTypeKind.Entity:
                        {
                            string typeName = property.Type.AsEntity().EntityDefinition().Name;
                            fieldType = typeBuilders[typeName];

                        }
                        break;
                    case EdmTypeKind.Collection:
                        {
                            string typeName =
                                property.Type.AsCollection().ElementType().AsEntity().EntityDefinition().Name;
                            var elementType = typeBuilders[typeName];
                            fieldType = typeof (DataServiceCollection<>).MakeGenericType(elementType);
                        }
                        break;

                }
                FieldBuilder field = typeBuilder.DefineField(property.Name, fieldType, FieldAttributes.Private);

                if (typeKind == EdmTypeKind.Collection)
                {
                    constructorIL.Emit(OpCodes.Ldarg_0);
                    ConstructorInfo ctorPrep =
                        typeof (DataServiceCollection<>).GetConstructors().Single(c => c.GetParameters().Length == 2);
                    ConstructorInfo ctor = TypeBuilder.GetConstructor(fieldType, ctorPrep);
                    constructorIL.Emit(OpCodes.Ldnull);
                    constructorIL.Emit(OpCodes.Ldc_I4_0);
                    constructorIL.Emit(OpCodes.Newobj, ctor);
                    constructorIL.Emit(OpCodes.Stfld, field);
                }

                propertyBuilders.Add(CreateProperty(typeBuilder, property.Name, field, raisePropertyChanged));
            }

            constructorIL.Emit(OpCodes.Ret);

            // Override ToString
            OverrideToString(typeBuilder, propertyBuilders.ToArray());

            return typeBuilder;
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

        private static PropertyBuilder CreateProperty(TypeBuilder typeBuilder, string propertyName, FieldBuilder backingField, MethodBuilder raisePropertyChanged)
        {
            Type propertyType = backingField.FieldType;
            PropertyBuilder property = typeBuilder.DefineProperty(propertyName, PropertyAttributes.None, propertyType,
                                                                  Type.EmptyTypes);

            //CustomAttributeBuilder dataMemberAttribute = new CustomAttributeBuilder(
            //    typeof(DataMemberAttribute).GetConstructor(Type.EmptyTypes),
            //    new object[0]);
            //property.SetCustomAttribute(dataMemberAttribute);

            MethodAttributes getSetAttr = MethodAttributes.Public | MethodAttributes.SpecialName |
                                          MethodAttributes.HideBySig;

            MethodBuilder getMethod = typeBuilder.DefineMethod("get_" + propertyName, getSetAttr, propertyType,
                                                               Type.EmptyTypes);
            MethodBuilder setMethod = typeBuilder.DefineMethod("set_" + propertyName, getSetAttr, null,
                                                               new Type[] {propertyType});

            ILGenerator getIL = getMethod.GetILGenerator();
            getIL.Emit(OpCodes.Ldarg_0);
            getIL.Emit(OpCodes.Ldfld, backingField);
            getIL.Emit(OpCodes.Ret);

            ILGenerator setIL = setMethod.GetILGenerator();
            setIL.Emit(OpCodes.Ldarg_0);
            setIL.Emit(OpCodes.Ldarg_1);
            setIL.Emit(OpCodes.Stfld, backingField);

            // RaisePropertyChanged("[PropertyName]");
            setIL.Emit(OpCodes.Ldarg_0);
            setIL.Emit(OpCodes.Ldstr, propertyName);
            setIL.EmitCall(OpCodes.Call, raisePropertyChanged, null);

            setIL.Emit(OpCodes.Ret);

            property.SetSetMethod(setMethod);
            property.SetGetMethod(getMethod);

            return property;
        }

        public static MethodBuilder ImplementateNotifyPropertyChanged(TypeBuilder typeBuilder)
        {
            typeBuilder.AddInterfaceImplementation(typeof(INotifyPropertyChanged));

            FieldBuilder eventField = CreatePropertyChangedEvent(typeBuilder);

            var raisePropertyChanged = CreateRaisePropertyChanged(typeBuilder, eventField);
            return raisePropertyChanged;
        }

        private static FieldBuilder CreatePropertyChangedEvent(TypeBuilder typeBuilder)
        {
            // public event PropertyChangedEventHandler PropertyChanged;

            FieldBuilder eventField =
                typeBuilder.DefineField("PropertyChanged", typeof (PropertyChangedEventHandler), FieldAttributes.Private);
            EventBuilder eventBuilder = typeBuilder.DefineEvent("PropertyChanged", EventAttributes.None,
                                                                typeof (PropertyChangedEventHandler));

            eventBuilder.SetAddOnMethod(CreateAddRemoveMethod(typeBuilder, eventField, true));
            eventBuilder.SetRemoveOnMethod(CreateAddRemoveMethod(typeBuilder, eventField, false));

            return eventField;
        }

        private static MethodBuilder CreateAddRemoveMethod(TypeBuilder typeBuilder, FieldBuilder eventField, bool isAdd)
        {
            string prefix = "remove_";
            string delegateAction = "Remove";
            if (isAdd)
            {
                prefix = "add_";
                delegateAction = "Combine";
            }
            MethodBuilder addremoveMethod = typeBuilder.DefineMethod(prefix + "PropertyChanged",
                                                                     MethodAttributes.Public |
                                                                     MethodAttributes.SpecialName |
                                                                     MethodAttributes.NewSlot |
                                                                     MethodAttributes.HideBySig |
                                                                     MethodAttributes.Virtual |
                                                                     MethodAttributes.Final,
                                                                     null,
                                                                     new[] {typeof (PropertyChangedEventHandler)});
            MethodImplAttributes eventMethodFlags = MethodImplAttributes.Managed | MethodImplAttributes.Synchronized;
            addremoveMethod.SetImplementationFlags(eventMethodFlags);

            ILGenerator ilGen = addremoveMethod.GetILGenerator();

            // PropertyChanged += value; // PropertyChanged -= value;
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Ldfld, eventField);
            ilGen.Emit(OpCodes.Ldarg_1);
            ilGen.EmitCall(OpCodes.Call,
                           typeof (Delegate).GetMethod(delegateAction, new[] {typeof (Delegate), typeof (Delegate)}),
                           null);
            ilGen.Emit(OpCodes.Castclass, typeof (PropertyChangedEventHandler));
            ilGen.Emit(OpCodes.Stfld, eventField);
            ilGen.Emit(OpCodes.Ret);

            MethodInfo intAddRemoveMethod = typeof (INotifyPropertyChanged).GetMethod(prefix + "PropertyChanged");
            typeBuilder.DefineMethodOverride(addremoveMethod, intAddRemoveMethod);

            return addremoveMethod;
        }

        private static MethodBuilder CreateRaisePropertyChanged(TypeBuilder typeBuilder, FieldBuilder eventField)
        {
            MethodBuilder raisePropertyChangedBuilder =
                typeBuilder.DefineMethod("RaisePropertyChanged",MethodAttributes.Family | MethodAttributes.Virtual,
                    null, new Type[] {typeof (string)});

            ILGenerator raisePropertyChangedIl =
                raisePropertyChangedBuilder.GetILGenerator();
            Label labelExit = raisePropertyChangedIl.DefineLabel();

            // if (PropertyChanged == null)
            // {
            //      return;
            // }
            raisePropertyChangedIl.Emit(OpCodes.Ldarg_0);
            raisePropertyChangedIl.Emit(OpCodes.Ldfld, eventField);
            raisePropertyChangedIl.Emit(OpCodes.Ldnull);
            raisePropertyChangedIl.Emit(OpCodes.Ceq);
            raisePropertyChangedIl.Emit(OpCodes.Brtrue, labelExit);

            // this.PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            raisePropertyChangedIl.Emit(OpCodes.Ldarg_0);
            raisePropertyChangedIl.Emit(OpCodes.Ldfld, eventField);
            raisePropertyChangedIl.Emit(OpCodes.Ldarg_0);
            raisePropertyChangedIl.Emit(OpCodes.Ldarg_1);
            raisePropertyChangedIl.Emit(OpCodes.Newobj,
                                        typeof (PropertyChangedEventArgs).GetConstructor(new[] {typeof (string)}));
            raisePropertyChangedIl.EmitCall(OpCodes.Callvirt, typeof (PropertyChangedEventHandler).GetMethod("Invoke"),
                                            null);

            // return;
            raisePropertyChangedIl.MarkLabel(labelExit);
            raisePropertyChangedIl.Emit(OpCodes.Ret);

            return raisePropertyChangedBuilder;
        }

        private static void WrapMethod(PropertyInfo item, MethodBuilder raisePropertyChanged, TypeBuilder typeBuilder)
        {
            MethodInfo setMethod = item.GetSetMethod();

            //get an array of the parameter types.
            var types = from t in setMethod.GetParameters()
                        select t.ParameterType;

            MethodBuilder setMethodBuilder = typeBuilder.DefineMethod(setMethod.Name, setMethod.Attributes,
                                                                      setMethod.ReturnType, types.ToArray());
            typeBuilder.DefineMethodOverride(setMethodBuilder, setMethod);
            ILGenerator setMethodWrapperIl = setMethodBuilder.GetILGenerator();

            // base.[PropertyName] = value;
            setMethodWrapperIl.Emit(OpCodes.Ldarg_0);
            setMethodWrapperIl.Emit(OpCodes.Ldarg_1);
            setMethodWrapperIl.EmitCall(OpCodes.Call, setMethod, null);

            // RaisePropertyChanged("[PropertyName]");
            setMethodWrapperIl.Emit(OpCodes.Ldarg_0);
            setMethodWrapperIl.Emit(OpCodes.Ldstr, item.Name);
            setMethodWrapperIl.EmitCall(OpCodes.Call, raisePropertyChanged, null);

            // return;
            setMethodWrapperIl.Emit(OpCodes.Ret);
        }



        private static Type GetClrEquivalentType(IEdmTypeReference type)
        {
            switch (type.PrimitiveKind())
            {
                case EdmPrimitiveTypeKind.Binary:
                    return typeof(byte[]);
                case EdmPrimitiveTypeKind.Boolean:
                    return GetPrimitiveType<bool>(type.IsNullable);
                case EdmPrimitiveTypeKind.Byte:
                    return GetPrimitiveType<byte>(type.IsNullable);
                case EdmPrimitiveTypeKind.DateTime:
                    return GetPrimitiveType<DateTime>(type.IsNullable);
                case EdmPrimitiveTypeKind.Time:
                    return GetPrimitiveType<TimeSpan>(type.IsNullable);
                case EdmPrimitiveTypeKind.DateTimeOffset:
                    return GetPrimitiveType<DateTimeOffset>(type.IsNullable);
                case EdmPrimitiveTypeKind.Decimal:
                    return GetPrimitiveType<decimal>(type.IsNullable);
                case EdmPrimitiveTypeKind.Double:
                    return GetPrimitiveType<double>(type.IsNullable);
                case EdmPrimitiveTypeKind.Guid:
                    return GetPrimitiveType<Guid>(type.IsNullable);
                case EdmPrimitiveTypeKind.Single:
                    return GetPrimitiveType<Single>(type.IsNullable);
                case EdmPrimitiveTypeKind.SByte:
                    return GetPrimitiveType<sbyte>(type.IsNullable);
                case EdmPrimitiveTypeKind.Int16:
                    return GetPrimitiveType<short>(type.IsNullable);
                case EdmPrimitiveTypeKind.Int32:
                    return GetPrimitiveType<int>(type.IsNullable);
                case EdmPrimitiveTypeKind.Int64:
                    return GetPrimitiveType<long>(type.IsNullable);
                case EdmPrimitiveTypeKind.String:
                    return typeof(string);
            }

            return null;
        }

        private static Type GetPrimitiveType<T>(bool isNullable) where T : struct
        {
            return isNullable ? typeof(Nullable<T>) : typeof(T);
        }
    }
}
