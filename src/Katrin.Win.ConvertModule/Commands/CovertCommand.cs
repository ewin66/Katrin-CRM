using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.AppFramework.Metadata;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.Security;
using Katrin.AppFramework.WinForms.Workspaces;

namespace Katrin.Win.ConvertModule.Commands
{
    public class CovertCommand : AbstractCommand
    {
        public override void Run()
        {
            if (!(this.Owner is ObjectController)) return;
            if (string.IsNullOrEmpty(this.Parameter)) return;
            ObjectController objectController = (ObjectController)this.Owner;
            var targetObject = ConvertEntity(objectController.SelectedObject, objectController.ObjectName, this.Parameter);
            ActionParameters parameters = new ActionParameters(this.Parameter, Guid.Empty, ViewShowType.Show)
            {
                {"ObjectEntity",targetObject},
                {"WorkingMode",EntityDetailWorkingMode.Add}
            };
            App.Instance.Invoke(this.Parameter, "Detail", parameters);
        }

        private List<ColumnMapping> GetMappingList(string sourceOjbectName, string targetObjectName)
        {
            List<ColumnMapping> mappingList = MetadataRepository.MappingList.Where(c => c.SourceEntityName == sourceOjbectName
                && c.TargetEntityName == targetObjectName).ToList();
            return mappingList;
        }


        private object ConvertEntity(object soruceObject, string sourceOjbectName, string targetObjectName)
        {
            IObjectSpace obojectSpace = new ODataObjectSpace();
            var targetType = obojectSpace.ResolveType(targetObjectName);
            var targetObject = Activator.CreateInstance(targetType);
            obojectSpace.SetEntityId(targetObjectName, targetObject, Guid.NewGuid());
            var mappingList = GetMappingList(sourceOjbectName, targetObjectName);
            foreach (var mappingItem in mappingList)
            {
                SetProperValue(soruceObject, mappingItem.SourceAttributeName, targetObject, mappingItem.TargetAttributeName);
            }
            string convertPath = "/ConvertObject/" + targetObjectName;
            if (AddInTree.ExistsTreeNode(convertPath))
            {
                var descriptor = AddInTree.BuildItems<IObjectConvert>(convertPath, null);
                if (descriptor != null && descriptor.Count() > 0) descriptor.First().ConvertObject(soruceObject, targetObject);
            }
            SetFieldValue(targetObject, "CreatedOn", DateTime.Now);
            SetFieldValue(targetObject, "CreatedById", AuthorizationManager.CurrentUserId);
            SetFieldValue(targetObject, "OwnerId", AuthorizationManager.CurrentUserId);
            SetFieldValue(targetObject, "ModifiedOn", DateTime.Now);
            SetFieldValue(targetObject, "ModifiedById", AuthorizationManager.CurrentUserId);
            return targetObject;
        }

        private void SetFieldValue(object entity, string fieldName, object fieldValue)
        {
            var fieldInfo = entity.GetType().GetProperty(fieldName);
            if (fieldInfo != null)
            {
                fieldInfo.SetValue(entity, fieldValue,null);
            }
        }

        private void SetProperValue(object sourceObject, string sourceAttributeName, object targetObject, string targetAttributeName)
        {
            PropertyInfo sourceProperty = sourceObject.GetType().GetProperty(sourceAttributeName);
            PropertyInfo targetProperty = targetObject.GetType().GetProperty(targetAttributeName);
            if (sourceProperty != null && targetProperty != null
                && targetProperty.PropertyType.FullName.Contains(sourceProperty.PropertyType.FullName))
            {
                targetProperty.SetValue(targetObject, sourceProperty.GetValue(sourceObject, null), null);
            }
        }
    }
}
