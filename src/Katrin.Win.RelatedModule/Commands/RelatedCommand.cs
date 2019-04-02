using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.MetadataServiceReference;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.Metadata;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.Workspaces;
namespace Katrin.Win.RelatedModule.Commands
{
    public enum EntityRelationshipType
    {
        OneToMany = 0,
        ManyToMany = 1
    }

    public class RelatedCommand : AbstractCommand
    {
        public override void Run()
        {
            if (!(this.Owner is ObjectController)) return;
            if (string.IsNullOrEmpty(this.Parameter)) return;
            ObjectController objectController = (ObjectController)this.Owner;
            ShowRelatedView(this.Parameter, objectController.ObjectName, objectController.SelectedObject);
        }

        private string GetLocationCaption(string name)
        {
            return StringParser.Parse("${res:" + name + "}");
        }

        private void ShowRelatedView(string relatedObjectName, string objectName, object selectedEntity)
        {
            var relationshipRoles = MetadataRepository.EntityRelationshipRoles.Where(role => role.Entity.PhysicalName == objectName && role.NavPanelDisplayOption == 1);
            EntityRelationship entityRelationship = relationshipRoles.Where(c => 
                c.EntityRelationship.EntityRelationshipRoles
                .FirstOrDefault(r => r != c 
                    && r.RelationshipRoleType != (int)RelationshipRoleType.Relationship 
                    && r.Entity.PhysicalName == relatedObjectName) != null).FirstOrDefault().EntityRelationship;
            EntityRelationshipType relationshipType = (EntityRelationshipType)entityRelationship.EntityRelationshipType;
            IObjectSpace objectSpace = new ODataObjectSpace();
            var currentEntityRelationRole = entityRelationship.EntityRelationshipRoles.Single(r => r.Entity.PhysicalName == objectName);
            string relationTitle = GetLocationCaption(currentEntityRelationRole.Entity.PhysicalName) + "-";
            if (relationshipType == EntityRelationshipType.OneToMany)
            {
                var roleType = (RelationshipRoleType)currentEntityRelationRole.RelationshipRoleType;
                var relationship = entityRelationship.EntityRelationshipRelationships.Single().Relationship;
                if (roleType == RelationshipRoleType.OneToMany)
                {
                    var desiredEntityName = relationship.ReferencingEntity.PhysicalName;
                    var entityId = objectSpace.GetObjectId(objectName, selectedEntity);
                    CriteriaOperator filter = new BinaryOperator(relationship.ReferencingAttribute.Name, entityId, BinaryOperatorType.Equal);
                    var result = objectSpace.GetObjects(desiredEntityName, filter, null);
                    if (result.Count > 0)
                    {
                        var parameters = new ActionParameters(relatedObjectName, Guid.Empty, ViewShowType.Show)
                        { { "FixedFilter", filter }};
                        App.Instance.Invoke(relatedObjectName, "List", parameters);
                    }
                    else
                    {
                        XtraMessageBox.Show(GetLocationCaption("NoRelatedData"), GetLocationCaption("Katrin"),
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    var entityName = relationship.ReferencedEntity.PhysicalName;
                    string desiredPropertyName = relationship.ReferencingAttribute.PhysicalName;
                    Guid currentId = objectSpace.GetObjectId(objectName, selectedEntity);
                    var currentObject = objectSpace.GetOrNew(objectName, currentId, null);
                    var propertyInfo = currentObject.GetType().GetProperty(desiredPropertyName);
                    var id = propertyInfo.GetValue(currentObject, null);
                    if (id != null)
                    {
                        var relatedObject = objectSpace.GetOrNew(this.Parameter, (Guid)id,string.Empty);
                        if (relatedObject == null)
                        {
                            MessageService.ShowMessage(GetLocationCaption("NoRelatedData"));
                            return;
                        }
                        string detail = "Detail";
                        var parameters = new ActionParameters(relatedObjectName, (Guid)id, ViewShowType.Show)
                        {
                           {"WorkingMode",EntityDetailWorkingMode.View}
                        };
                        App.Instance.Invoke(relatedObjectName, detail, parameters);
                    }
                    else
                    {
                        XtraMessageBox.Show(GetLocationCaption("NoRelatedData"),
                        GetLocationCaption("Katrin"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                var relationshipRole = entityRelationship.EntityRelationshipRoles
                    .Single(r => (RelationshipRoleType)r.RelationshipRoleType == RelationshipRoleType.Relationship);
                var desiredEntityRole = entityRelationship.EntityRelationshipRoles
                    .Single(r => r != relationshipRole && r != currentEntityRelationRole);
                var desiredEntityPropertyName =
                    entityRelationship.EntityRelationshipRelationships.Select(r => r.Relationship)
                        .Single(r => r.ReferencedEntity.EntityId == desiredEntityRole.Entity.EntityId).
                        ReferencedAttribute.PhysicalName;
                var knownPropertyName = entityRelationship.EntityRelationshipRelationships.Select(r => r.Relationship)
                    .Single(r => r.ReferencedEntity.EntityId == currentEntityRelationRole.Entity.EntityId).
                    ReferencedAttribute.PhysicalName;

                CriteriaOperator filter = new BinaryOperator(knownPropertyName,objectSpace.GetObjectId(objectName,selectedEntity));
                var relationships = objectSpace.GetObjects(relationshipRole.Entity.PhysicalName, filter, null);

                List<object> desiredEntityIds = new List<object>();
                CriteriaOperator relatedFilter = null;
                for (int index = 0; index < relationships.Count; index++)
                {
                    var relatedObject = relationships[index];
                    var propertyInfo = relatedObject.GetType().GetProperty(desiredEntityPropertyName);
                    var desiredEntityId = propertyInfo.GetValue(relatedObject, null);
                    desiredEntityIds.Add(desiredEntityId);
                    relatedFilter |= new BinaryOperator(desiredEntityPropertyName, desiredEntityId);
                }
                if (desiredEntityIds.Any())
                {
                    if (desiredEntityIds.Count == 1)
                    {
                        string detail = "Detail";
                        var parameters = new ActionParameters(relatedObjectName, (Guid)desiredEntityIds[0], ViewShowType.Show)
                        {
                            {"WorkingMode",EntityDetailWorkingMode.View}
                        };
                        App.Instance.Invoke(desiredEntityRole.Entity.PhysicalName, detail, parameters);
                    }
                    else
                    {
                        var parameters = new ActionParameters(desiredEntityRole.Entity.PhysicalName, Guid.Empty, ViewShowType.Show) 
                        { 
                            { "FixedFilter", relatedFilter }
                        };
                        App.Instance.Invoke(desiredEntityRole.Entity.PhysicalName, "List", parameters);
                    }
                }
                else
                {
                    XtraMessageBox.Show(GetLocationCaption("NoRelatedData"),
                    GetLocationCaption("Katrin"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
