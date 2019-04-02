using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.Common.Security;
using Katrin.Win.Infrastructure;
using Microsoft.Practices.CompositeUI;
using Katrin.Win.Common.Core;
using Microsoft.Practices.CompositeUI.Commands;
using Katrin.Win.Common;
using System.Collections;

namespace Katrin.Win.MainModule.Views.Note
{
    public class NoteDetailPresenter : EntityDetailPresenter<INoteDetailForm>
    {
        public NoteDetailPresenter()
        {
            EntityName = "Note";
        }

        public Guid NoteId { get; set; }

        public string ObjectType { get; set; }

        public override EntityDetailWorkingMode WorkingMode { get; set; }

        protected override object GetEntity()
        {
            var entity = DynamicDataServiceContext.GetOrNew(EntityName, NoteId);
            return entity;
        }

        protected override void RefreshEntityId(object entity)
        {
            if (WorkingMode == EntityDetailWorkingMode.Add)
                NoteId = DynamicDataServiceContext.GetObjectId(EntityName, entity);
        }

        protected override void OnViewSet()
        {
            base.OnViewSet();
            View.Saved += ViewSaved;
            Type parentType = DynamicTypeBuilder.Instance.GetDynamicType(ObjectType);
            if (parentType.GetProperty("Description") == null)
            {
                View.SetDescriptionVisible(false);
            }
            if (parentType.GetProperty("LatestFeedbackOn") == null)
            {
                View.SetModifyEditVisible(false);
            }
        }

        void ViewSaved(object sender, EventArgs e)
        {
            OnSave(sender,e);
        }

        protected override void OnSaving()
        {
            if (WorkItem.State == null) return;
            base.OnSaving();
            DynamicEntity.ObjectId = EntityId;
            DynamicEntity.ObjectType = ObjectType;
            var parentEntity = DynamicDataServiceContext.GetOrNew(ObjectType, EntityId);
            var dynamicEntity = new SysBits.Reflection.ReflectionProxy(parentEntity);
            dynamicEntity.TrySetProperty("ModifiedById", AuthorizationManager.CurrentUserId);
            dynamicEntity.TrySetProperty("ModifiedOn", DateTime.Now);
            if (View.AppandDescription)
            {
                object description;
                if (dynamicEntity.TryGetProperty("Description", out description))
                {
                    string appandedDescription = description != null
                                                    ? description.ToString() + DynamicEntity.NoteText
                                                    : DynamicEntity.NoteText;
                    dynamicEntity.SetProperty("Description", appandedDescription);
                    DynamicDataServiceContext.UpdateObject(parentEntity);
                }
            }
            if (View.UpdateLatestFeadback)
            {
                object latestFeedbackOn;
                if (dynamicEntity.TryGetProperty("LatestFeedbackOn", out latestFeedbackOn))
                {
                    dynamicEntity.SetProperty("LatestFeedbackOn", DateTime.Now);
                    DynamicDataServiceContext.UpdateObject(parentEntity);
                }
            }
        }

        protected override void OnSaved()
        {
            //base.OnSaved();
            MetadataProvider.Instance.CreateCommonNotification(DynamicEntity.NoteId, EntityName, ObjectType);
            View.Close(DialogResult.OK);
        }
    }
}
