using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.Activation;
using Katrin.Services.DTO;
using System.Data.Entity.Infrastructure;
using System.Data.Metadata.Edm;

namespace Katrin.Services.Metadata
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class MetadataService: IMetadataService
    {
        public List<Entity> GetMetaEntities()
        {
            try
            {
                using (var context = KatrinEntities.CreateInstance())
                {
                    var query = GetMeataEntityQuery(context);
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static IQueryable<Entity> GetMeataEntityQuery(KatrinEntities context)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var query = context.Entities.Include("Attributes");
            query.Include("Attributes.OptionSet");
            query.Include("Attributes.OptionSet.AttributePicklistValues");
            query.Include("Attributes.AttributeLookupValues");
            query.Include("Attributes.AttributeLookupValues.Entity");
            query.Include("Attributes.AttributeType");
            return query;
        }


        public List<LocalizedLabel> GetLocalizedLabels(int languageId)
        {
            using (var context = KatrinEntities.CreateInstance())
            {
                context.Configuration.ProxyCreationEnabled = false;
                return context.LocalizedLabels.ToList();
            }
        }

        public List<EntityRelationshipRole> GetEntityRelationshipRoles()
        {
            using (var context = KatrinEntities.CreateInstance())
            {
                context.Configuration.ProxyCreationEnabled = false;
                var query = context.EntityRelationshipRoles.Include("Entity");
                query.Include("EntityRelationship");
                query.Include("EntityRelationship.EntityRelationshipRelationships");
                query.Include("EntityRelationship.EntityRelationshipRelationships.Relationship.ReferencedAttribute");
                query.Include("EntityRelationship.EntityRelationshipRelationships.Relationship.ReferencingAttribute");
                query.Include("EntityRelationship.EntityRelationshipRelationships.Relationship.ReferencedEntity");
                query.Include("EntityRelationship.EntityRelationshipRelationships.Relationship.ReferencingEntity");

                var result = query.ToList();
                return result;
            }
        }


        public Entity GetMetaEntityById(Guid entityId)
        {
            using (var context = KatrinEntities.CreateInstance())
            {
                var query = GetMeataEntityQuery(context);
                return query.Single(e => e.EntityId == entityId);
            }
        }

        public List<OptionSet> GetOptionSet()
        {
            using (var context = KatrinEntities.CreateInstance())
            {
                context.Configuration.ProxyCreationEnabled = false;
                return context.OptionSets.ToList();
            }
        }

        public List<AttributePicklistValue> GetAttributePicklistValue()
        {
            using (var context = KatrinEntities.CreateInstance())
            {
                context.Configuration.ProxyCreationEnabled = false;
                return context.AttributePicklistValues.ToList();
            }
        }

        public List<AttributeType> GetAttributeType()
        {
            using (var context = KatrinEntities.CreateInstance())
            {
                context.Configuration.ProxyCreationEnabled = false;
                return context.AttributeTypes.ToList();
            }
        }

        private void AddRelationShip(Relationship relationShip,KatrinEntities context,Guid displayId)
        {
            if (relationShip == null) return;

            EntityRelationship entityRelationShip = new EntityRelationship();
            entityRelationShip.EntityRelationshipId = Guid.NewGuid();
            entityRelationShip.SchemaName = relationShip.Name;
            relationShip.Name = "FK_" + relationShip.Name;
            context.EntityRelationships.Add(entityRelationShip);
            context.Relationships.Add(relationShip);

            //AttributeLookupValue lookUpValue = new AttributeLookupValue();
            //lookUpValue.AttributeLookupValueId = Guid.NewGuid();
            //lookUpValue.AttributeId = relationShip.ReferencingAttributeId;
            //lookUpValue.DisplayEntityAttributeId = displayId;
            //lookUpValue.EntityId = relationShip.ReferencedEntityId;
            //context.AttributeLookupValues.AddObject(lookUpValue);

            EntityRelationshipRelationships entityRelationshipRelationships = new EntityRelationshipRelationships();
            entityRelationshipRelationships.EntityRelationshipRelationshipsId = Guid.NewGuid();
            entityRelationshipRelationships.EntityRelationshipId = entityRelationShip.EntityRelationshipId;
            entityRelationshipRelationships.RelationshipId = relationShip.RelationshipId;
            context.EntityRelationshipRelationships.Add(entityRelationshipRelationships);

            EntityRelationshipRole entityRelationshipRole1 = new EntityRelationshipRole();
            entityRelationshipRole1.EntityRelationshipRoleId = Guid.NewGuid();
            entityRelationshipRole1.EntityRelationshipId = entityRelationShip.EntityRelationshipId;
            entityRelationshipRole1.EntityId = relationShip.ReferencingEntityId;
            entityRelationshipRole1.RelationshipRoleType = 1;
            entityRelationshipRole1.NavPanelDisplayOption = 0;
            context.EntityRelationshipRoles.Add(entityRelationshipRole1);

            EntityRelationshipRole entityRelationshipRole2 = new EntityRelationshipRole();
            entityRelationshipRole2.EntityRelationshipRoleId = Guid.NewGuid();
            entityRelationshipRole2.EntityRelationshipId = entityRelationShip.EntityRelationshipId;
            entityRelationshipRole2.EntityId = relationShip.ReferencedEntityId;
            entityRelationshipRole2.RelationshipRoleType = 0;
            entityRelationshipRole2.NavPanelDisplayOption = 0;
            context.EntityRelationshipRoles.Add(entityRelationshipRole2);

        }
        private void DeleteRelationShip(Guid attributeId, KatrinEntities context)
        {
            var relationShip = context.Relationships.FirstOrDefault(c => c.ReferencingAttributeId == attributeId);
            if (relationShip == null) return;
            var entityRelationshipRelationships = context.EntityRelationshipRelationships.FirstOrDefault(c => c.RelationshipId == relationShip.RelationshipId);
            
            if (entityRelationshipRelationships != null)
            {
                var entityRelationShip = context.EntityRelationships.FirstOrDefault(c => c.EntityRelationshipId == entityRelationshipRelationships.EntityRelationshipId);
                context.EntityRelationshipRelationships.Remove(entityRelationshipRelationships);
                if (!context.EntityRelationshipRelationships.Any(c => c.EntityRelationshipId == entityRelationShip.EntityRelationshipId
                                                                      && c.EntityRelationshipRelationshipsId != entityRelationshipRelationships.EntityRelationshipRelationshipsId))
                {
                    context.EntityRelationships.Remove(entityRelationShip);
                }
            }
            var entityRelationshipRole1 = context.EntityRelationshipRoles.FirstOrDefault(c => c.EntityId == relationShip.ReferencingEntityId && c.RelationshipRoleType == 1);
            if (entityRelationshipRole1 != null)
            {
                context.EntityRelationshipRoles.Remove(entityRelationshipRole1);
            }
            var entityRelationshipRole2 = context.EntityRelationshipRoles.FirstOrDefault(c => c.EntityId == relationShip.ReferencedEntityId && c.RelationshipRoleType == 0);
            if (entityRelationshipRole2 != null)
            {
                context.EntityRelationshipRoles.Remove(entityRelationshipRole2);
            }
            context.Relationships.Remove(relationShip);
            var pickUpVale = context.AttributeLookupValues.FirstOrDefault(c => c.AttributeId == attributeId && c.EntityId == relationShip.ReferencedEntityId);
            context.AttributeLookupValues.Remove(pickUpVale);

        }

        public void SaveEntityAttribute(EntityAttribute attribute,Relationship relationShip,bool isAdd)
        {
            Guid displayId = Guid.Empty;
            if (relationShip != null)
            {
                displayId = attribute.OptionSetId ?? Guid.Empty;
                attribute.OptionSetId = null;
            }
            using (var context = KatrinEntities.CreateInstance())
            {
                context.Configuration.ProxyCreationEnabled = false;
                if (isAdd)
                {
                    context.EntityAttributes.Add(attribute);
                    AddRelationShip(relationShip, context, displayId);
                }
                else
                {
                    context.EntityAttributes.Attach(attribute);
                    context.Entry(attribute).State = EntityState.Modified;
                    DeleteRelationShip(attribute.AttributeId, context);
                    AddRelationShip(relationShip, context, displayId);
                }
                context.SaveChanges();
            }
        }

        public EntityAttribute GetEntityAttribute(Guid attributeId)
        {
            using (var context = KatrinEntities.CreateInstance())
            {
                context.Configuration.ProxyCreationEnabled = false;
                return context.EntityAttributes.FirstOrDefault(c => c.AttributeId == attributeId);
            }
        }

        public void DeleteEntityAttribute(Guid attributeId)
        {
            using (var context = KatrinEntities.CreateInstance())
            {
                context.Configuration.ProxyCreationEnabled = false;
                var entityAttribute = GetEntityAttribute(attributeId);
                DeleteRelationShip(attributeId, context);
                context.EntityAttributes.Attach(entityAttribute);
                context.EntityAttributes.Remove(entityAttribute);
                context.SaveChanges();
            }
        }

        public void DeleteEntityView(Guid savedQueryId)
        {
            using (var context = KatrinEntities.CreateInstance())
            {
                context.Configuration.ProxyCreationEnabled = false;
                var savedQueries = context.SavedQueries.FirstOrDefault(c => c.SavedQueryId == savedQueryId); 
                context.SavedQueries.Attach(savedQueries);
                context.SavedQueries.Remove(savedQueries);
                context.SaveChanges();
            }
        }


        public void SaveEntity(Entity entity, bool isAdd)
        {
            using (var context = KatrinEntities.CreateInstance())
            {
                context.Configuration.ProxyCreationEnabled = false;
                if (isAdd)
                {
                    context.Entities.Add(entity);
                }
                else
                {
                    Entity saveEntity = new Entity();
                    saveEntity.EntityId = entity.EntityId;
                    saveEntity.Name = entity.Name;
                    saveEntity.PhysicalName = entity.PhysicalName;
                    saveEntity.LogicalName = entity.LogicalName;
                    saveEntity.TableName = entity.TableName;
                    saveEntity.IsAuditEnabled = entity.IsAuditEnabled;
                    foreach (EntityAttribute att in entity.Attributes)
                    {
                        var attribute = GetEntityAttribute(att.AttributeId);
                        attribute.IsNullable = att.IsNullable;
                        attribute.IsPKAttribute = att.IsPKAttribute;
                        attribute.IsAuditEnabled = att.IsAuditEnabled;
                        SaveEntityAttribute(attribute, null, false);
                    }
                    context.Entities.Attach(saveEntity);
                    context.Entry(saveEntity).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
        }

        public void DeleteEntity(Guid entityId)
        {
            using (var context = KatrinEntities.CreateInstance())
            {
                context.Configuration.ProxyCreationEnabled = false;
                var entity = GetMetaEntityById(entityId);
                entity.Attributes.ToList().ForEach(c => DeleteRelationShip(c.AttributeId, context));
                context.Entities.Attach(entity);
                context.Entities.Remove(entity);
                context.SaveChanges();
            }
           
        }

        public List<OptionSetDTO> GetOptionSetById(Guid optionSetId, int languageId)
        {
            using (var context = KatrinEntities.CreateInstance())
            {
                context.Configuration.ProxyCreationEnabled = false;
                //var query = context.OptionSets
                //    .FetchMany(r=>r.AttributePicklistValues);
                var optionSetQuery = from o in context.OptionSets
                                     join p in context.AttributePicklistValues.OrderBy(c => c.DisplayOrder)
                                     on o.OptionSetId equals p.OptionSetId into pickupList
                                     join local in context.LocalizedLabels.Where(c => c.LanguageId == languageId)
                                     on o.OptionSetId equals local.ObjectId into locals
                                     where o.OptionSetId == optionSetId
                                     select new
                                     {
                                         optionset = o,
                                         pList = pickupList,
                                         localLabls = locals
                                     };
                return optionSetQuery.ToList().Select(r =>
                {
                    var item = new OptionSetDTO();
                    var description = r.localLabls.Where(c => c.ObjectColumnName == "Description").FirstOrDefault();
                    item.Description = description != null ? description.Label : "";
                    var displayName = r.localLabls.Where(c => c.ObjectColumnName == "DisplayName").FirstOrDefault();
                    item.DisplayName = displayName != null ? displayName.Label : "";
                    item.IsCustomizable = r.optionset.IsCustomizable;
                    item.Name = r.optionset.Name;
                    item.OptionSetId = r.optionset.OptionSetId;
                    item.OptionList = new List<OptionDTO>();
                    r.pList.ToList().ForEach(p =>
                    {
                        var option = new OptionDTO();
                        var itemDescription = context.LocalizedLabels.SingleOrDefault(c => c.ObjectId == p.AttributePicklistValueId &&
                            c.ObjectColumnName == "Description" &&
                            c.LanguageId == languageId);
                        option.Description = itemDescription != null ? itemDescription.Label : "";
                        var itemDisplayName = context.LocalizedLabels.Single(c => c.ObjectId == p.AttributePicklistValueId &&
                            c.ObjectColumnName == "DisplayName" &&
                            c.LanguageId == languageId);
                        option.DisplayName = itemDisplayName != null ? itemDisplayName.Label : "";
                        option.DisplayOrder = p.DisplayOrder;
                        option.OptionId = p.AttributePicklistValueId;
                        option.Value = p.Value;
                        item.OptionList.Add(option);
                    });
                    return item;
                }
                ).ToList();
            }
        }

        private void AddOptionSet(OptionSetDTO optionSet, int languageId, KatrinEntities context)
        {
            context.OptionSets.Add(new OptionSet
            {
                IsCustomizable = optionSet.IsCustomizable ?? true,
                Name = optionSet.Name,
                OptionSetId = optionSet.OptionSetId
            });
            AddOptionRelation(optionSet, languageId, context);
        }

        private void AddOptionRelation(OptionSetDTO optionSet, int languageId, KatrinEntities context)
        {
            context.LocalizedLabels.Add(new LocalizedLabel
            {
                LocalizedLabelId = Guid.NewGuid(),
                Label = optionSet.Description,
                LanguageId = languageId,
                ObjectColumnName = "Description",
                ObjectId = optionSet.OptionSetId
            });
            context.LocalizedLabels.Add(new LocalizedLabel
            {
                LocalizedLabelId = Guid.NewGuid(),
                Label = optionSet.DisplayName,
                LanguageId = languageId,
                ObjectColumnName = "DisplayName",
                ObjectId = optionSet.OptionSetId
            });
            foreach (OptionDTO option in optionSet.OptionList)
            {
                context.AttributePicklistValues.Add(new AttributePicklistValue
                {
                    AttributePicklistValueId = option.OptionId,
                    DisplayOrder = option.DisplayOrder,
                    OptionSetId = optionSet.OptionSetId,
                    Value = option.Value
                });
                context.LocalizedLabels.Add(new LocalizedLabel
                {
                    LocalizedLabelId = Guid.NewGuid(),
                    Label = option.Description,
                    LanguageId = languageId,
                    ObjectColumnName = "Description",
                    ObjectId = option.OptionId
                });
                context.LocalizedLabels.Add(new LocalizedLabel
                {
                    LocalizedLabelId = Guid.NewGuid(),
                    Label = option.DisplayName,
                    LanguageId = languageId,
                    ObjectColumnName = "DisplayName",
                    ObjectId = option.OptionId
                });
            }
        }
        private void DeleteOptionRelation(OptionSetDTO optionSet, int languageId, KatrinEntities context)
        {
            var optionLocals = context.LocalizedLabels.Where(c => c.ObjectId == optionSet.OptionSetId &&
                c.LanguageId == languageId).ToList();
            optionLocals.ForEach(l => context.LocalizedLabels.Remove(l));
            var pickUpList = context.AttributePicklistValues.Where(c => c.OptionSetId == optionSet.OptionSetId).ToList();
            pickUpList.ForEach(p =>
            {
                var locals = context.LocalizedLabels.Where(c => c.ObjectId == p.AttributePicklistValueId &&
                    c.LanguageId == languageId).ToList();
                locals.ForEach(l => context.LocalizedLabels.Remove(l));
                context.AttributePicklistValues.Remove(p);
            });

        }

        private void UpdateOptionSet(OptionSetDTO optionSet, int languageId, KatrinEntities context)
        {
            OptionSet coptionSet = context.OptionSets.First(c => c.OptionSetId == optionSet.OptionSetId);
            coptionSet.Name = optionSet.Name;
            context.OptionSets.Attach(coptionSet);
            DeleteOptionRelation(optionSet, languageId, context);
            AddOptionRelation(optionSet, languageId, context);

        }
        public void SaveOptionSet(OptionSetDTO optionSet, int languageId, bool isAdd)
        {
            using (var context = KatrinEntities.CreateInstance())
            {
                context.Configuration.ProxyCreationEnabled = false;
                if (isAdd)
                {
                    AddOptionSet(optionSet, languageId, context);
                }
                else
                {
                    UpdateOptionSet(optionSet, languageId, context);
                }
                context.SaveChanges();
            }
        }

        public List<ColumnMapping> GetColumnMapping(string mappingName,string sourceEntityName,string targetEntityName)
        {
            using (var context = KatrinEntities.CreateInstance())
            {
                context.Configuration.ProxyCreationEnabled = false;
                var mapping = context.ImportMaps.Where(c => c.Name == mappingName).ToList().FirstOrDefault();
                Guid importMapId = Guid.Empty;
                if (mapping != null)
                    importMapId = mapping.ImportMapId;
                var query = context.ColumnMappings.Where(c => c.ImportMapId == importMapId);
                if (sourceEntityName != "")
                {
                    query = query.Where(c => c.SourceEntityName == sourceEntityName);
                }
                if (targetEntityName != "")
                {
                    query = query.Where(c => c.TargetEntityName == targetEntityName);
                }
                return query.ToList();
            }
        }


        public List<SavedQuery> GetSavedQuery(Guid entityId)
        {
            using (var context = KatrinEntities.CreateInstance())
            {
                context.Configuration.ProxyCreationEnabled = false;
                return context.SavedQueries.Where(q => q.ReturnedTypeId == entityId).ToList();
            }
        }


        public void SaveSavedQuery(SavedQuery savedQuery)
        {
            using (var context = KatrinEntities.CreateInstance())
            {
                context.Configuration.ProxyCreationEnabled = false;
                if (savedQuery.SavedQueryId == Guid.Empty)
                {
                    savedQuery.SavedQueryId = Guid.NewGuid();
                    context.SavedQueries.Add(savedQuery);
                }
                else
                {
                    context.SavedQueries.Attach(savedQuery);
                    context.Entry(savedQuery).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
        }

        public List<NotificationProfile> GetNotificationProfiles()
        {
            using (var context = KatrinEntities.CreateInstance())
            {
                context.Configuration.ProxyCreationEnabled = false;
                var query = context.NotificationProfiles.Include("NotificationRecipientAttributes");
                query.Include("NotificationRecipientAttributes.Criterion");
                query.Include("NotificationRecipientAttributes.Criterion.CriteriaNodes");
                query.Include("Criterion");
                query.Include("Criterion.CriteriaNodes");
                query.Include("NotificationTemplate");
                query.Include("SubjectNotificationTemplate");
                query.Include("ProfileVariables");
                query.Include("ProfileVariables.NotificationVariable");
                query.Include("Subscriptions");
                return query.ToList();
            }
        }

        public List<NotificationVariable> GetNotificationVariablesById(Guid rootVariableId)
        {
            using (var context = KatrinEntities.CreateInstance())
            {
                context.Configuration.ProxyCreationEnabled = false;
                var query = context.NotificationVariables.Where(c => c.ParentId == rootVariableId || c.NotificationVariableId == rootVariableId);
                return query.ToList();
            }
        }
    }
}
