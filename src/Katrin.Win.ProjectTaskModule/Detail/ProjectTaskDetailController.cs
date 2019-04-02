using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Controls;
using DevExpress.Data.Filtering;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.Utils;
using DevExpress.XtraEditors;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.Data;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.Domain.Impl;
namespace Katrin.Win.ProjectTaskModule.Detail
{
    public class ProjectTaskDetailController : ObjectDetailController
    {

        private IProjectTaskDetailView _projectTaskView;
        private Guid _projectId = Guid.Empty;
        public override string ObjectName
        {
            get
            {
                return "ProjectTask";
            }
        }

        //[EventPublication(EventTopicNames.RefreshProjectTask, PublicationScope.Global)]
        //public event EventHandler OnRefreshProjectTask;

        protected override bool OnSaving()
        {
            var task = (Katrin.Domain.Impl.ProjectTask)ObjectEntity;
            if (task.ActualWorkHours == null || task.ActualWorkHours == 0)
            {
                task.ActualWorkHours = task.QuoteWorkHours;
            }
            if (task.StatusCode > 1 && task.StartDate == null)
                task.StartDate = DateTime.Today;
            if (task.StatusCode > 2 && task.EndDate == null)
                task.EndDate = DateTime.Today;
            if (task.StatusCode <= 2 && task.EndDate != null && task.EndDate < DateTime.Today)
                task.EndDate = null;
            return base.OnSaving();
        }

        public override IActionResult Execute(ActionParameters parameters)
        {
            if (parameters.ContainsKey("ProjectId"))
                _projectId = parameters.Get<Guid>("ProjectId");
            //var view = Detail(objectName, objectId, workMode);
            return base.Execute(parameters);
        }


        protected override void OnSaved()
        {
            base.OnSaved();
            //EventHandler handler = OnRefreshProjectTask;
            //if (handler != null)
            //{
            //    handler(this, new EventArgs());
            //}
        }

        protected override object GetEntity()
        {
            var entity =  (Katrin.Domain.Impl.ProjectTask)base.GetEntity();
            if (WorkingMode == EntityDetailWorkingMode.Add)
            {
                entity.ActualInput = 0d;
                entity.Effort = 0d;
                entity.OwnerId = null;
                entity.StatusCode = 1;
                this.ApplyParameters(entity);
            }
            entity.RemainderTime = Convert.ToDouble(entity.ActualWorkHours ?? 0) - Convert.ToDouble(entity.Effort ?? 0);
            return entity;
        }

        private void ApplyParameters(ProjectTask task)
        {
            ActionParameters parameters = this.Context.ActionParameter;
            if (!parameters.ContainsKey("ProjectId")) return;
            if (!parameters.ContainsKey("MemberId")) return;
            if (!parameters.ContainsKey("IterationId")) return;
            Guid? projectId = (Guid?)parameters["ProjectId"];
            if (projectId != null) task.ProjectId = (Guid)projectId;
            task.OwnerId = (Guid?)parameters["MemberId"];
            task.ProjectIterationId = (Guid?)parameters["IterationId"];
        }

        protected override void OnViewSet()
        {
            if(!(_detailView is IProjectTaskDetailView)) return;
            _projectTaskView = (IProjectTaskDetailView)_detailView;
            _projectTaskView.OnProjectChange += OnProjectChange;
            base.OnViewSet();
        }

        private void OnProjectChange(object sender,EventArgs<Guid> e)
        {
            SearchLookUpEdit ownerIdLookUpEdit = sender as SearchLookUpEdit;
            if (ownerIdLookUpEdit == null) return;
            Guid projectId = e.Data;
            var projectMemberList = _objectSpace.GetObjects("ProjectMember", new BinaryOperator("ProjectId", projectId), null);
            var userIds = new List<object>();
            foreach (var projectObj in projectMemberList)
            {
                var projectMember = ConvertData.Convert<Katrin.Domain.Impl.ProjectMember>(projectObj);
                userIds.Add(projectMember.MemberId);
            }

            if (userIds.Count > 0)
                ownerIdLookUpEdit.ReLoadData(new InOperator("UserId", userIds),"User");
            else ownerIdLookUpEdit.ReLoadData(null, "User");
        }

        protected override void BindData(object objectInfo)
        {
  
            var task = (Katrin.Domain.Impl.ProjectTask)ObjectEntity;
            if (_projectId != Guid.Empty)
                task.ProjectId = _projectId;
            else
                _projectId = task.ProjectId;
            if (_projectId != Guid.Empty)
            {
                _projectTaskView.SetProjectEable(false);
            }
            base.BindData(objectInfo);
        }

        

        public void UpdateIteration(Guid? iterationId)
        {
            Katrin.Domain.Impl.ProjectTask detaiTask = this.ObjectEntity as Katrin.Domain.Impl.ProjectTask;
            detaiTask.ProjectIterationId = iterationId;
        }

        public void UpdateOwerId(Guid? ownerId)
        {
            Katrin.Domain.Impl.ProjectTask detaiTask = this.ObjectEntity as Katrin.Domain.Impl.ProjectTask;
            detaiTask.OwnerId = ownerId;
        }
    }
}
