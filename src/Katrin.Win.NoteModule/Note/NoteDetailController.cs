using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework;
using Katrin.AppFramework.Metadata;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.Security;

namespace Katrin.Win.NoteModule.Note
{
    public class NoteDetailController : ObjectDetailController
    {
        private INoteDetailForm _noteView;
        private string _noteSubject = string.Empty;
        private string _parentObjectName = string.Empty;
        public override string ObjectName
        {
            get
            {
                return "Note";
            }
        }

        public override IActionResult Execute(ActionParameters parameters)
        {
            return NoteAction(parameters);
        }

        public IActionResult NoteAction(ActionParameters parameters)
        {
            string noteSubject = string.Empty;
            if(parameters.ContainsKey("NoteSubject"))
                _noteSubject = parameters.Get<string>("NoteSubject");
            if (parameters.ContainsKey("ParentObjectName"))
                _parentObjectName = parameters.Get<string>("ParentObjectName");
            if (parameters.ObjectName == "Note")
            {
                NoteId = parameters.ObjectId;
            }
            else
            {
                ObjectType = parameters.ObjectName;
                this.ObjectId = parameters.ObjectId;
            }
            var detailView = ViewFactory.CreateView("DefaultNoteDetailView") as INoteDetailForm;
            _detailView = detailView;
            _noteView = detailView;
            if (parameters.ContainsKey("PutNoteEnable"))
            {
                string putNoteEnable = string.Empty;
                putNoteEnable = parameters.Get<string>("PutNoteEnable");
                if (putNoteEnable.Equals("false"))
                {
                    _noteView.SetDescriptionVisible(false);
                }
            }
            OnViewSet();
            return new ModalViewResult(detailView);
        }


        public Guid NoteId { get; set; }

        public string ObjectType { get; set; }

        public override EntityDetailWorkingMode WorkingMode { get; set; }

        protected override object GetEntity()
        {
            var entity = (Katrin.Domain.Impl.Note)_objectSpace.GetOrNew(ObjectName, NoteId, null);
            if (NoteId != Guid.Empty)
            {
                ObjectType = entity.ObjectType;
                ObjectId = entity.ObjectId ?? Guid.Empty;
            }
            else
            {
                entity.Subject = _noteSubject;
            }
            return entity;
        }

        protected override void RefreshEntityId(object entity)
        {
            if (WorkingMode == EntityDetailWorkingMode.Add)
                NoteId = _objectSpace.GetObjectId(ObjectName, entity);
        }

        protected override void OnViewSet()
        {
            base.OnViewSet();
            _noteView.Saved += ViewSaved;
            Type parentType = _objectSpace.ResolveType(ObjectType);
            if (parentType.GetProperty("Description") == null)
            {
                _noteView.SetDescriptionVisible(false);
            }
            if (parentType.GetProperty("LatestFeedbackOn") == null)
            {
                _noteView.SetModifyEditVisible(false);
            }
        }

        void ViewSaved(object sender, EventArgs e)
        {
            if(!OnSave()) return;
            ObjectSetChangedMessage message = new ObjectSetChangedMessage();
            message.ObjectName = ObjectType;
            if (!string.IsNullOrEmpty(_parentObjectName))
            {
                message.ParentObjectName = _parentObjectName;
            }
            EventAggregationManager.SendMessage(message);
        }

        protected override bool OnSaving()
        {
            
            SetProperValue(ObjectId, ObjectEntity, "ObjectId");
            SetProperValue(ObjectType, ObjectEntity, "ObjectType");

            var parentEntity = _objectSpace.GetOrNew(ObjectType, ObjectId, null);
            SetProperValue(AuthorizationManager.CurrentUserId, parentEntity, "ModifiedById");
            SetProperValue(DateTime.Now, parentEntity, "ModifiedOn");
            if (_noteView.AppandDescription)
            {
                var descriptionPro = parentEntity.GetType().GetProperty("Description");
                var note = (Katrin.Domain.Impl.Note)ObjectEntity;
                if (descriptionPro != null)
                {
                    object description = descriptionPro.GetValue(parentEntity,null);
                    string appandedDescription = description != null
                                                    ? description.ToString() + Environment.NewLine + note.NoteText
                                                    : note.NoteText;
                    descriptionPro.SetValue(parentEntity, appandedDescription,null);
                    _objectSpace.UpdateObject(parentEntity);
                }
            }
            if (_noteView.UpdateLatestFeadback)
            {
                var latestFeedbackOnPro = parentEntity.GetType().GetProperty("LatestFeedbackOn");
                if (latestFeedbackOnPro != null)
                {
                    latestFeedbackOnPro.SetValue(parentEntity, DateTime.Now,null);
                    _objectSpace.UpdateObject(parentEntity);
                }
            }
            return base.OnSaving(); 
        }

        protected override void OnSaved()
        {
            EventAggregationManager.SendMessage(new ObjectSetChangedMessage { ObjectName = ObjectName });
            _noteView.CloseView();
        }
    }
}
