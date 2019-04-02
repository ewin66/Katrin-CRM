using Katrin.AppFramework;
using Katrin.AppFramework.Metadata;
using Katrin.AppFramework.Security;
using Katrin.AppFramework.WinForms.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.RelatedModule
{
    /// <summary>
    /// RelatedService 
    /// author:hecq
    /// date:2012-11-10
    /// </summary>
    class RelatedService : IModuleService, IListener<NotifyRelatedMessage>
    {
        private string _moduleName;
        public string moduleName
        {
            get { return _moduleName; }
        }

        public RelatedService()
        {
            EventAggregationManager.AddListener(this);
        }
        /// <summary>
        /// Hanled the message when object was changed.
        /// then send this message to its related modules. 
        /// </summary>
        /// <param name="message"></param>
        public void Handle(NotifyRelatedMessage message)
        {
            IList<string> relatedEntityNames = this.GetRelatedEntityNames(message.ObjectName, message.ObjectName);

            foreach (string entityName in relatedEntityNames)
            {
                EventAggregationManager.SendMessage(new ObjectSetChangedMessage { ObjectName = entityName });
                EventAggregationManager.SendMessage(new UpdateDetailEntityMessage { ObjectName = entityName });
            }

            //addCustomRelation.
            IList<string> customrelatedEntityNames = this.GetCustomRelatedEntityNames(message.ObjectName);
            foreach (string entityName in customrelatedEntityNames)
            {
                EventAggregationManager.SendMessage(new ObjectSetChangedMessage { ObjectName = entityName });
                EventAggregationManager.SendMessage(new UpdateDetailEntityMessage { ObjectName = entityName });
            }
        }

        //notify relatedModule in relatinoshiproles config.
        private IList<string> GetRelatedEntityNames(string entityName, string senderEntityName)
        {
            List<string> re = new List<string>();
            if (string.IsNullOrEmpty(entityName)) return re;

            var allRelationshipRoles = MetadataRepository.EntityRelationshipRoles;
            var relationshipRoles = allRelationshipRoles.Where(role => role.Entity.PhysicalName == entityName &&
                role.NavPanelDisplayOption == 1);
            if (relationshipRoles.Any())
            {
                foreach (var relationshipRole in relationshipRoles)
                {

                    var entityRelation = relationshipRole.EntityRelationship;
                    var relatedRole = entityRelation.EntityRelationshipRoles
                        .FirstOrDefault(r => r != relationshipRole
                            && r.RelationshipRoleType != (int)RelationshipRoleType.Relationship);
                    if (relatedRole != null && relatedRole.Entity.Name != senderEntityName)
                    {
                        re.Add(relatedRole.Entity.Name);
                    }
                }
            }
            return re;
        }

        //define relationship between module.
        private IList<string> GetCustomRelatedEntityNames(string entityName)
        {
            List<string> re = new List<string>();

            switch (entityName)
            {
                case "Account":
                    re.Add("Lead");
                    break;
                case "Contact":
                     re.Add("Lead");
                    break;
                case "EditEffort":
                    re.Add("ProjectTask");
                    break;
                case "ProjectTaskEffort":
                    re.Add("ProjectTask");
                    break;
                case "NewProjectTaskEffort":
                    re.Add("ProjectTask");
                    break;
                case "ProjectIteration":
                    re.Add("ProjectTask");
                    break;
                case "Project":
                    re.Add("ProjectTask");
                    re.Add("ProjectChart");
                    break;
            }
            return re;
        }
    }
}
