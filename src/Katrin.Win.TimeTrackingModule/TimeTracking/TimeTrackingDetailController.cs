using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.Security;

namespace Katrin.Win.TimeTrackingModule.TimeTracking
{
    public class TimeTrackingDetailController : ObjectDetailController
    {
        private ITimeTrackingDetail _timeTrackingView;
        public override string ObjectName
        {
            get
            {
                return "TimeTracking";
            }
        }

        public override IActionResult Execute(ActionParameters parameters)
        {
            return TimeTrackingAction(parameters);
        }

        public IActionResult TimeTrackingAction(ActionParameters parameters)
        {
            _timeTrackingView = ViewFactory.CreateView("DefaultTimeTrackingView") as ITimeTrackingDetail;
            _detailView = _timeTrackingView;
            if (parameters.ObjectName == ObjectName)
            {
                TimeTrackingId = parameters.ObjectId;
            }
            else
            {
                this.ObjectId = parameters.ObjectId;
            }
            OnViewSet();
            return new ModalViewResult(_timeTrackingView);
        }


        public override EntityDetailWorkingMode WorkingMode { get; set; }

        public Guid TimeTrackingId { get; set; }

        protected override object GetEntity()
        {
            var entity = (Katrin.Domain.Impl.TimeTracking)_objectSpace.GetOrNew(ObjectName, TimeTrackingId,null);
            if (TimeTrackingId != Guid.Empty)
            {
                this.ObjectId = entity.OpportunityId??Guid.Empty;
            }
            return entity;
        }

        protected override void RefreshEntityId(object entity)
        {
            if (WorkingMode == EntityDetailWorkingMode.Add)
                TimeTrackingId = _objectSpace.GetObjectId(ObjectName, entity);
        }

        protected override void OnViewSet()
        {
            base.OnViewSet();
            _timeTrackingView.Saved += ViewSaved;
        }

        void ViewSaved(object sender, EventArgs e)
        {
            OnSave();
        }

        protected override void OnSaved()
        {
            base.OnSaved();
            _timeTrackingView.Close(DialogResult.OK);
        }

        protected override bool OnSaving()
        {
            
            var timingTracking = (Katrin.Domain.Impl.TimeTracking)ObjectEntity;
            timingTracking.OpportunityId = ObjectId;
            timingTracking.RecordById = AuthorizationManager.CurrentUserId;
            if (timingTracking.RecordOn == null)
                timingTracking.RecordOn = DateTime.Now;
            return base.OnSaving();
        }
    }
}
