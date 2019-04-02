using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Collections;
using DevExpress.Data.Filtering;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.Extensions;
namespace Katrin.Win.ProjectModule.Detail
{
    public class ProjectSummary
    {
        public string Name { get; set; }
        public string NameAndDate { get; set; }
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public double SumQuoteWorkHours
        {
            get;
            set;
        }
        public double SumActualWorkHours
        {
            get;
            set;
        }
        public double SumActualInput
        {
            get;
            set;
        }
        public double SumEffort
        {
            get;
            set;
        }
        public double SumOvertime
        {
            get;
            set;
        }
        public double SumRemainderTime
        {
            get;
            set;
        }

        public double SumInputEffortRate
        {
            get;
            set;
        }

        public double SumEvaluateExactlyRate
        {
            get;
            set;
        }

    }

    public class ProjectDetailController : ObjectDetailController
    {
        private ProjectSummary _projectSummaryEntity;
        private IProjectDetailView _projectDetailView;
        public override string ObjectName
        {
            get
            {
                return "Project";
            }
        }

        protected override bool OnSaving()
        {
           
            SetProjectMember();
            return base.OnSaving();
        }

        private void SetProjectMember()
        {
            if (_projectDetailView.SelectedProjectMember != null)
            {
                var project = (Katrin.Domain.Impl.Project)ObjectEntity;
                var projectMembers = project.ProjectMembers;
                while (projectMembers.Count > 0)
                {
                    projectMembers.RemoveAt(0);
                }
                foreach (var selectedProjectMember in _projectDetailView.SelectedProjectMember)
                {
                    var projectMember = new Katrin.Domain.Impl.ProjectMember();
                    projectMember.ProjectMemberId = Guid.NewGuid();
                    projectMember.ProjectId = ObjectId;
                    projectMember.MemberId = (Guid)selectedProjectMember.GetType().GetProperty("UserId").GetValue(selectedProjectMember,null);
                    projectMembers.Add(projectMember);
                }
            }
        }

        protected override object GetEntity()
        {
            Dictionary<string, string> extraColumns = new Dictionary<string, string>();
            var entity = _objectSpace.GetOrNew(ObjectName,ObjectId, "CreatedBy,ModifiedBy,ProjectTasks,ProjectMembers");
            return entity;
        }

        protected override void OnViewSet()
        {
            base.OnViewSet();
            if (!(_detailView is IProjectDetailView)) return;
            _projectDetailView = (IProjectDetailView)_detailView;
            _projectDetailView.ContractEditValueChanged += OnContractEditValueChanged;

            _projectSummaryEntity = new ProjectSummary();
            var project = (Katrin.Domain.Impl.Project)ObjectEntity;
            var projectTasks = project.ProjectTasks;
            _projectSummaryEntity.SumQuoteWorkHours = projectTasks.AsQueryable().Select("QuoteWorkHours").Cast<double?>().Sum() ?? 0;
            _projectSummaryEntity.SumActualWorkHours = projectTasks.AsQueryable().Select("ActualWorkHours").Cast<double?>().Sum() ?? 0;
            _projectSummaryEntity.SumActualInput = projectTasks.AsQueryable().Select("ActualInput").Cast<double?>().Sum() ?? 0;
            _projectSummaryEntity.SumEffort = projectTasks.AsQueryable().Select("Effort").Cast<double?>().Sum() ?? 0;
            _projectSummaryEntity.SumOvertime = projectTasks.AsQueryable().Select("Overtime").Cast<double?>().Sum() ?? 0;
            _projectSummaryEntity.SumRemainderTime = _projectSummaryEntity.SumActualWorkHours - _projectSummaryEntity.SumEffort;
            _projectDetailView.BindStatisticNumber(new List<ProjectSummary>() { _projectSummaryEntity });

         
            var projectMembers = project.ProjectMembers;
            var selectedProjectMember = new List<Guid>();
            if (projectMembers != null)
            {
                foreach (var projectMember in projectMembers)
                {
                    Guid memberId = projectMember.MemberId;
                    selectedProjectMember.Add(memberId);
                }
            }
            _projectDetailView.BindProjectMember(selectedProjectMember);
        }

        private void OnContractEditValueChanged(object sender, EventArgs<Guid> e)
        {
            var contract = (Katrin.Domain.Impl.Contract)_objectSpace.GetOrNew("Contract", e.Data, "Opportunity");
            bool isAdd = WorkingMode == EntityDetailWorkingMode.Add;
            var opportunity = contract.Opportunity;
            if (opportunity != null)
            {
                var project = (Katrin.Domain.Impl.Project)ObjectEntity;
                project.ContractId = e.Data;
                project.CustomerId = isAdd ? opportunity.CustomerId : project.CustomerId ?? opportunity.CustomerId;
                project.ProjectTypeCode = isAdd ? opportunity.ProjectTypeCode : project.ProjectTypeCode ?? opportunity.ProjectTypeCode;
                project.TechnologyCode = isAdd ? opportunity.TechnologyCode : project.TechnologyCode ?? opportunity.TechnologyCode;
            }
        }

    }
}
