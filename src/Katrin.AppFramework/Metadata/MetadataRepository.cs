using Katrin.AppFramework.MetadataServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Katrin.AppFramework.Security;
using System.Configuration;

namespace Katrin.AppFramework.Metadata
{
    public class MetadataRepository
    {
        private static readonly MetadataServiceClient _metadataServiceClient;

        static MetadataRepository()
        {
            _metadataServiceClient = new MetadataServiceClient("MetadataServiceEndPoint", ServerUrl);
        }

        private static string ServerUrl
        {
            get { return ConfigurationManager.AppSettings["ServerUrl"] + "/MetadataService.svc"; }
        }

        public static void Initialize()
        {
            _entities = _metadataServiceClient.GetMetaEntities().ToList();
            _localizedLabels = _metadataServiceClient.GetLocalizedLabels(1033).ToList();
        }

        private static List<Entity> _entities;
        public static ReadOnlyCollection<Entity> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _metadataServiceClient.GetMetaEntities().ToList();
                }
                return _entities.AsReadOnly();
            }
        }

        public static List<SavedQuery> GetSavedQuery(Guid entityId)
        {
            try
            {
                return _metadataServiceClient.GetSavedQuery(entityId).ToList();
            }
            catch
            {
                throw;
            }
        }


        private static List<ColumnMapping> _mappingList;
        public static ReadOnlyCollection<ColumnMapping> MappingList
        {
            get
            {
                if (_mappingList == null)
                {
                    _mappingList = _metadataServiceClient.GetColumnMapping("KatrinCRM", "", "").ToList();
                }
                return _mappingList.AsReadOnly();
            }
        }

        private static List<EntityRelationshipRole> _entityRelationshipRole;
        public static ReadOnlyCollection<EntityRelationshipRole> EntityRelationshipRoles
        {
            get
            {
                if (_entityRelationshipRole == null)
                {
                    _entityRelationshipRole = _metadataServiceClient.GetEntityRelationshipRoles().ToList();
                }
                return _entityRelationshipRole.AsReadOnly();
            }
        }


        private static List<LocalizedLabel> _localizedLabels;
        public static ReadOnlyCollection<LocalizedLabel> LocalizedLabels
        {
            get
            {
                if (_localizedLabels == null)
                {
                    int language = CultureManager.CurrentCulture.LCID;
                    _localizedLabels = _metadataServiceClient.GetLocalizedLabels(language).ToList();
                }
                return _localizedLabels.AsReadOnly();
            }
        }
    }
}
