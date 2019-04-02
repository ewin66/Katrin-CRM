using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Katrin.Services.DTO;
//using Katrin.Services.Metadata;
using System.Data.Metadata.Edm;

namespace Katrin.Services.Metadata
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMetadataService" in both code and config file together.
    [ServiceContract]
    public interface IMetadataService
    {
        [OperationContract]
        List<Entity> GetMetaEntities();

        [OperationContract]
        Entity GetMetaEntityById(Guid entityId);

        [OperationContract]
        List<LocalizedLabel> GetLocalizedLabels(int languageId);

        [OperationContract]
        List<EntityRelationshipRole> GetEntityRelationshipRoles();

        [OperationContract]
        List<OptionSet> GetOptionSet();

        [OperationContract]
        List<AttributePicklistValue> GetAttributePicklistValue();

        [OperationContract]
        List<AttributeType> GetAttributeType();

        [OperationContract]
        void SaveEntityAttribute(EntityAttribute attribute, Relationship relationShip, bool isAdd);

        [OperationContract]
        EntityAttribute GetEntityAttribute(Guid attributeId);

        [OperationContract]
        void DeleteEntityAttribute(Guid attributeId);

        [OperationContract]
        void DeleteEntityView(Guid savedQueryId);

        [OperationContract]
        void SaveEntity(Entity entity, bool isAdd);

        [OperationContract]
        void DeleteEntity(Guid entityId);

        [OperationContract]
        List<OptionSetDTO> GetOptionSetById(Guid optionSetId, int languageId);

        [OperationContract]
        void SaveOptionSet(OptionSetDTO optionSet, int languageId, bool isAdd);

        [OperationContract]
        List<ColumnMapping> GetColumnMapping(string mappingName, string sourceEntityName, string targetEntityName);

        [OperationContract]
        List<SavedQuery> GetSavedQuery(Guid entityId);

        [OperationContract]
        void SaveSavedQuery(SavedQuery savedQuery);

        [OperationContract]
        List<NotificationProfile> GetNotificationProfiles();

        [OperationContract]
        List<NotificationVariable> GetNotificationVariablesById(Guid rootVariableId);
    }
}
