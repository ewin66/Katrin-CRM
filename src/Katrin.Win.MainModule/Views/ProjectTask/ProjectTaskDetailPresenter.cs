using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;
using Microsoft.Practices.CompositeUI.EventBroker;
using Katrin.Win.Common.Constants;
using Katrin.Win.Infrastructure;
using Katrin.Win.Common.Controls;
using DevExpress.Data.Filtering;

namespace Katrin.Win.MainModule.Views.ProjectTask
{
    public class ProjectTaskDetailPresenter : EntityDetailPresenter<IProjectTaskDetailView>
    {
        public ProjectTaskDetailPresenter()
        {
            EntityName = "ProjectTask";
        }

        [EventPublication(EventTopicNames.RefreshProjectTask, PublicationScope.Global)]
        public event EventHandler OnRefreshProjectTask;

        protected override void OnSaving()
        {
            base.OnSaving();
            if (DynamicEntity.ActualWorkHours == null || DynamicEntity.ActualWorkHours == 0)
            {
                DynamicEntity.ActualWorkHours = DynamicEntity.QuoteWorkHours;
            }
        }

        protected override void OnSaved()
        {
            base.OnSaved();
            EventHandler handler = OnRefreshProjectTask;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        protected override object GetEntity()
        {
            var entity =  base.GetEntity();
            var dyanmic = entity.AsDyanmic();
            if (WorkingMode == EntityDetailWorkingMode.Add)
            {
                dyanmic.ActualInput = 0d;
                dyanmic.Effort = 0d;
                dyanmic.OwnerId = null;
                dyanmic.StatusCode = 1;
            }
            dyanmic.RemainderTime = Convert.ToDouble(dyanmic.ActualWorkHours ?? 0) - Convert.ToDouble(dyanmic.Effort ?? 0);
            return entity;
        }

        protected override void OnViewSet()
        {
            View.OnProjectChange += OnProjectChange;
            base.OnViewSet();
        }

        private void OnProjectChange(object sender,EventArgs<Guid> e)
        {
            WcfSearchLookUpEdit ownerIdLookUpEdit = sender as WcfSearchLookUpEdit;
            if (ownerIdLookUpEdit == null) return;
            Guid projectId = e.Data;
            var projectMemberList = DynamicDataServiceContext.GetObjects("ProjectMember", new BinaryOperator("ProjectId", projectId), null);
            var userIds = new List<object>();
            foreach (var projectMember in projectMemberList)
            {
                userIds.Add(projectMember.AsDyanmic().MemberId);
            }

            if (userIds.Count > 0)
                ownerIdLookUpEdit.ReloadData(new InOperator("UserId", userIds));
            else ownerIdLookUpEdit.ReloadData(null);
        }

        protected override void BindData(object data)
        {
            var projectId = WorkItem.State["ProjectId"];
            var fromProject = WorkItem.State["FromProject"];
            if (projectId != null)
            {
                DynamicEntity.ProjectId = projectId;
                if (fromProject != null)
                {
                    View.SetProjectEable(false);
                }
            }
            base.BindData(data);
        }
    }
}
