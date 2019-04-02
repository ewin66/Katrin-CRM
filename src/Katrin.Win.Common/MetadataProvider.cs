using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using Katrin.Win.Common.MetadataServiceReference;
using Katrin.Win.Common.Security;

namespace Katrin.Win.Common
{
    public class MetadataProvider
    {
        private static MetadataProvider _instance;
        private readonly MetadataServiceClient _metadataServiceClient;

        public static MetadataProvider Instance
        {
            get { return _instance ?? (_instance = new MetadataProvider()); }
        }

        public MetadataProvider()
        {
            _metadataServiceClient = CreateServiceClient();
        }

        private List<Entity> _entityMetadata; 
        public ReadOnlyCollection<Entity> EntiyMetadata
        {
            get
            {
                if(_entityMetadata == null)
                {
                    _entityMetadata = _metadataServiceClient.GetMetaEntities();
                }
                return _entityMetadata.AsReadOnly();
            }
        }

        private List<LocalizedLabel> _localizedLabels;
        public ReadOnlyCollection<LocalizedLabel> LocalizedLabels
        {
            get
            {
                if (_localizedLabels == null)
                {
                    int language=CultureManager.CurrentCulture.LCID;
                    _localizedLabels = _metadataServiceClient.GetLocalizedLabels(language);
                }
                return _localizedLabels.AsReadOnly();
            }
        }

        private List<EntityRelationshipRole> _entityRelationshipRole;
        public ReadOnlyCollection<EntityRelationshipRole> EntityRelationshipRoles
        {
            get
            {
                if (_entityRelationshipRole == null)
                {
                    _entityRelationshipRole = _metadataServiceClient.GetEntityRelationshipRoles();
                }
                return _entityRelationshipRole.AsReadOnly();
            }
        }

        private List<ColumnMapping> _mappingList;
        public ReadOnlyCollection<ColumnMapping> MappingList
        {
            get
            {
                if (_mappingList == null)
                {
                    _mappingList = _metadataServiceClient.GetColumnMapping("KatrinCRM", "", "");
                }
                return _mappingList.AsReadOnly();
            }
        }

        public void CreateCommonNotification(Guid entityId, string entityName, string aboutEntityName)
        {
            _metadataServiceClient.CreateCommonNotification(entityId, entityName, aboutEntityName, AuthorizationManager.CurrentUserId);
        }

        public static MetadataServiceClient CreateServiceClient()
        {
            var client = new MetadataServiceClient("MetadataServiceEndPoint", ServerUrl);
            return client;
        }

        private static string ServerUrl
        {
            get { return ConfigurationManager.AppSettings["ServerUrl"] + "/MetadataService.svc"; }
        }
    }
}
