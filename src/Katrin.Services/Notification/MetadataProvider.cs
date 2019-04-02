using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using Katrin.Services.Metadata;

namespace Katrin.Services.Notification
{
    public class MetadataProvider
    {
        private static MetadataProvider _instance;
        private readonly MetadataService _metadataServiceClient;

        public static MetadataProvider Instance
        {
            get { return _instance ?? (_instance = new MetadataProvider()); }
        }

        public MetadataProvider()
        {
            _metadataServiceClient = new MetadataService();
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

        public MetadataService MetadataServiceClient
        {
            get
            {
                return _metadataServiceClient;
            }
        }

        private List<LocalizedLabel> _localizedLabels;
        public ReadOnlyCollection<LocalizedLabel> LocalizedLabels
        {
            get
            {
                if (_localizedLabels == null)
                {
                    int language = 2052;
                    _localizedLabels = _metadataServiceClient.GetLocalizedLabels(language);
                }
                return _localizedLabels.AsReadOnly();
            }
        }

      
        private List<NotificationProfile> _notificationProfileList;
        public List<NotificationProfile> NotificationProfileList
        {
            get
            {
                if (_notificationProfileList == null)
                {
                    _notificationProfileList = _metadataServiceClient.GetNotificationProfiles();
                }
                return _notificationProfileList;
            }
        }
    }
}
