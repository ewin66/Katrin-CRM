using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.Common.Security;
using Katrin.Win.Infrastructure;
using System.Collections;
using Katrin.Win.Common;
using Microsoft.Practices.CompositeUI;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.MetadataServiceReference;

namespace Katrin.Win.MainModule.Views.TimeTracking
{
    public class TimeTrackingDetailPresenter : EntityDetailPresenter<ITimeTrackingDetail>
    {
        public TimeTrackingDetailPresenter()
        {
            EntityName = "TimeTracking";
        }

        public override EntityDetailWorkingMode WorkingMode { get; set; }

        public Guid TimeTrackingId { get; set; }

        protected override object GetEntity()
        {
            var entity = DynamicDataServiceContext.GetOrNew(EntityName, TimeTrackingId);
            return entity;
        }

        protected override void RefreshEntityId(object entity)
        {
            if (WorkingMode == EntityDetailWorkingMode.Add)
                TimeTrackingId = DynamicDataServiceContext.GetObjectId(EntityName, entity);
        }

        protected override void OnViewSet()
        {
            base.OnViewSet();
            View.Saved += ViewSaved;
        }

        void ViewSaved(object sender, EventArgs e)
        {
            OnSave(sender, e);
        }

        protected override void OnSaved()
        {
            base.OnSaved();
            View.Close(DialogResult.OK);
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            DynamicEntity.OpportunityId = EntityId;
            DynamicEntity.RecordById = AuthorizationManager.CurrentUserId;
            if (DynamicEntity.RecordOn==null)
            DynamicEntity.RecordOn = DateTime.Now;
        }
    }
}
