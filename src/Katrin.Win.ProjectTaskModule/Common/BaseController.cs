using DevExpress.Data.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Katrin.Win.Common;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.Win.ProjectTaskModule.Common;
using Katrin.AppFramework.WinForms.Context;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.Security;
using Katrin.AppFramework.WinForms.Extensions;
using ICSharpCode.Core;
using Katrin.AppFramework;
using Katrin.Win.ProjectTaskModule.Chart;
using Katrin.AppFramework.Data;
using System.Collections;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.MVC;
using System.Windows.Forms;
namespace Katrin.Win.MainModule.Views.ProjectTask
{
    public class BaseController : TaskListController
    {
        protected IProejctTaskFilter _projectTaskFilterView;
        private bool _sendMessaage = false;

        public override IActionResult Execute(ActionParameters parameters)
        {
            var result = new PartialViewResult();
            _projectTaskFilterView = ViewFactory.CreateView("DefaultTaskFilterView") as IProejctTaskFilter;
            result.View = _projectTaskFilterView;
            this._projectTaskFilterView.ObjectName = "ProjectTask";
            this._projectTaskFilterView.ReadFilterConfig();
            _sendMessaage = true;
            OnViewSet();
            return result;
        }

        protected virtual void OnViewSet()
        {
            if (_projectTaskFilterView == null) return;
            _projectTaskFilterView.UpdateContextFilters += _projectTaskFilterView_UpdateContextFilters;
            _projectTaskFilterView.OnProjectChanged += _projectTaskFilterView_OnProjectChanged;
            _projectTaskFilterView.InitProjectTaskFilters += _projectTaskFilterView_InitProjectTaskFilters;
            InitFilters();
        }

        void _projectTaskFilterView_InitProjectTaskFilters(object sender, EventArgs e)
        {
            InitFilters();
        }

        void _projectTaskFilterView_OnProjectChanged(object sender, AppFramework.Utils.EventArgs<Guid?> e)
        {
            OnProjectChanged(e.Data);
        }

        void _projectTaskFilterView_UpdateContextFilters(object sender, EventArgs e)
        {
            UpdateContextFilters();
        }

        //update when filter changed because outing modifyed
        public override void OnRecevieObjectSetChanged(ObjectSetChangedMessage message)
        {
            this.InitFilters();
        }

        public void InitFilters()
        {
            var projectId = ParseBinaryRightValue(_projectTaskFilterView.Context.GetFilter("ProjectId"));
            var projectIterationId = ParseBinaryRightValue(_projectTaskFilterView.Context.GetFilter("ProjectIterationId"));
            var memberId = ParseBinaryRightValue(_projectTaskFilterView.Context.GetFilter("MemberId"));

            BindProjects(projectId);
            BindProjectIterations(_projectTaskFilterView.ProjectId, projectIterationId);
            BindProjectMembers(_projectTaskFilterView.ProjectId, memberId);
            UpdateContextFilters();
        }

        public void OnProjectChanged(Guid? projectId)
        {
            BindProjectIterations(_projectTaskFilterView.ProjectId, null);
            BindProjectMembers(_projectTaskFilterView.ProjectId, null);
        }

        private Guid? ParseBinaryRightValue(CriteriaOperator filter)
        {
            BinaryOperator binary = filter as BinaryOperator;
            if ((object)binary != null)
            {
                var operandValue = binary.RightOperand as OperandValue;
                if ((object)operandValue != null)
                {
                    var value = operandValue.Value;
                    if (typeof(Guid?).IsInstanceOfType(value))
                        return (Guid?)value;
                    return Guid.Empty;
                }
            }
            UnaryOperator unary = filter as UnaryOperator;
            if ((object)unary != null) return GuidExtension.UnassignedGuid;
            FunctionOperator noneFunction = filter as FunctionOperator;
            if ((object)noneFunction != null) return Guid.Empty;
            return null;
        }

        private static CriteriaOperator CreateFilter(string propertyName, object value)
        {
            CriteriaOperator criteria = null;
            if (value == null) return null;
            else if (typeof(Guid).IsInstanceOfType(value))
            {
                if ((Guid)value == GuidExtension.UnassignedGuid)
                    criteria = new UnaryOperator(UnaryOperatorType.IsNull, propertyName);
                else if ((Guid)value == Guid.Empty)
                    criteria = new BinaryOperator(new OperandValue(true), new OperandValue(true), BinaryOperatorType.Equal);
                else
                    criteria = new BinaryOperator(propertyName, value);
            }
            else
                criteria = new BinaryOperator(propertyName, value);
            return criteria;
        }

        public static void UpdateContextFilters(IActionContext context, Guid? projectId, Guid? projectIterationId, Guid? memberId)
        {
            context.SetFilter("ProjectId", CreateFilter("ProjectId", projectId));
            context.SetFilter("ProjectIterationId", CreateFilter("ProjectIterationId", projectIterationId));
            context.SetFilter("MemberId", CreateFilter("OwnerId", memberId));
        }

        public virtual void UpdateContextFilters()
        {
            UpdateContextFilters(_projectTaskFilterView.Context, _projectTaskFilterView.ProjectId, _projectTaskFilterView.ProjectIterationId, _projectTaskFilterView.MemberId);
            if(_sendMessaage)
            EventAggregationManager.SendMessage(new UpdateContextFilterMessage { FixedFilter = _projectTaskFilterView.Context.GetFilters() });
        }

        private void BindProjects(Guid? defaultProjectId)
        {
            var projects = GetProjects().ToList();
            _projectTaskFilterView.BindProjectLookUp(projects);
            if (defaultProjectId == null)
            {
                defaultProjectId = projects.Count > 1 ? projects[1].Value : projects[0].Value;
            }
            _projectTaskFilterView.ProjectId = defaultProjectId;
        }

        private void BindProjectIterations(Guid? projectId, Guid? defaultIterationId)
        {
            var iterationItems = GetProjectIterations(projectId).ToList();
            _projectTaskFilterView.BindIterationLookUp(iterationItems);
            if (defaultIterationId == null)
            {
                var defaultIteration = iterationItems.FirstOrDefault(i => i.IsDeafult);
                if (defaultIteration != null) defaultIterationId = defaultIteration.Value;
            }
            _projectTaskFilterView.ProjectIterationId = defaultIterationId;
        }

        private void BindProjectMembers(Guid? projectId, Guid? defaultMemberId)
        {
            var userList = GetProjectMembers(projectId).ToList();
            _projectTaskFilterView.BindMemberLookUp(userList);
            if (defaultMemberId == null)
            {
                defaultMemberId = userList.Count > 1 ? userList[1].Value : userList[0].Value;
            }
            _projectTaskFilterView.MemberId = defaultMemberId;
        }

        private IEnumerable<LookupListItem<Guid?>> GetProjects()
        {
            CriteriaOperator filter = new BinaryOperator("ManagerId", AuthorizationManager.CurrentUserId);
            var memberList = _objectSpace.GetObjects("ProjectMember", new BinaryOperator("MemberId", AuthorizationManager.CurrentUserId), null);
            List<object> projectIds = new List<object>();
            foreach (var memberItem in memberList)
            {
                var projectMember = (Katrin.Domain.Impl.ProjectMember)memberItem;
                projectIds.Add(projectMember.ProjectId);
            }
            if (projectIds.Any()) filter |= new InOperator("ProjectId", projectIds);
            var projectList = _objectSpace.GetObjects("Project", filter, null);
            if (!projectList.AsQueryable().Any())
                projectList = _objectSpace.GetObjects("Project");
            projectList = projectList.AsQueryable().OrderBy("Name asc ").ToArrayList();

            yield return new LookupListItem<Guid?>
            {
                Value = Guid.Empty,
                DisplayName = StringParser.Parse("${res:All}")
            };

            foreach (var projectObj in projectList)
            {
                var project = (Katrin.Domain.Impl.Project)projectObj;
                yield return new LookupListItem<Guid?>
                {
                    Value = project.ProjectId,
                    DisplayName = project.Name
                };
            }
        }

        private IEnumerable<LookupListItem<Guid?>> GetProjectIterations(Guid? projectId)
        {
            yield return new LookupListItem<Guid?>
            {
                Value = Guid.Empty,
                DisplayName = StringParser.Parse("${res:All}")
            };
            if (projectId != null)
            {
                yield return new LookupListItem<Guid?>
                {
                    Value = GuidExtension.UnassignedGuid,
                    DisplayName = StringParser.Parse("${res:Unassigned}")
                };

                Dictionary<string, string> additonProperty = new Dictionary<string, string>();
                additonProperty["IterationNameAndTime"] = "null";
                CriteriaOperator filter = new BinaryOperator("ProjectId", projectId);
                filter &= new BinaryOperator("StatusCode", 2, BinaryOperatorType.NotEqual);
                var iterationList = _objectSpace.GetObjects("ProjectIteration", filter, additonProperty)
                    .AsQueryable().OrderBy("StartDate desc");

                Guid defaultIterationId = GetDefaultIterationId(iterationList);

                var displayNameFormat = "{0} ({1:yy/MM/dd} - {2:yy/MM/dd})";
                foreach (var iterationObj in iterationList)
                {
                    var iteration = ConvertData.Convert<Katrin.Domain.Impl.ProjectIteration>(iterationObj);
                    Guid projectIterationId = iteration.ProjectIterationId;
                    bool isDefault = projectIterationId == defaultIterationId;
                    yield return new LookupListItem<Guid?>
                    {
                        Value = projectIterationId,
                        IsDeafult = isDefault,
                        DisplayName = string.Format(displayNameFormat, iteration.Name, iteration.StartDate, iteration.Deadline)
                    };
                }
            }
        }

        private static Guid GetDefaultIterationId(IQueryable iterationList)
        {
            Guid defaultIterationId = Guid.Empty;
            if (iterationList.AsQueryable().Any())
            {
                var currentIteration = iterationList.AsQueryable().Where("StartDate<=@0 && Deadline >=@0", DateTime.Today);
                if (currentIteration.Count() > 0)
                {
                    var projectIteration = ConvertData.Convert < Katrin.Domain.Impl.ProjectIteration > (currentIteration._First());
                    defaultIterationId = projectIteration.ProjectIterationId;
                }
                else
                {
                    var projectIteration = ConvertData.Convert<Katrin.Domain.Impl.ProjectIteration>(iterationList._First());
                    defaultIterationId = projectIteration.ProjectIterationId;
                }
                    
            }
            return defaultIterationId;
        }

        public IEnumerable<LookupListItem<Guid?>> GetProjectMembers(Guid? projectId)
        {
            yield return new LookupListItem<Guid?>
            {
                Value = Guid.Empty,
                DisplayName = StringParser.Parse("${res:All}")
            };

            if (projectId != null)
            {
                Dictionary<string, string> additonProperty = new Dictionary<string, string>();
                additonProperty["Member"] = "Member";

                CriteriaOperator filter = new BinaryOperator("ProjectId", projectId);
                var memberList = _objectSpace.GetObjects("ProjectMember", filter, additonProperty);

                foreach (var member in memberList)
                {
                    var projectMemeber = ConvertData.Convert<Katrin.Domain.Impl.ProjectMember>(member);
                    yield return new LookupListItem<Guid?>
                    {
                        Value = projectMemeber.Member.UserId,
                        DisplayName = projectMemeber.Member.FullName
                    };
                }
            }
        }
        public Guid? GetSelectedProjectId()
        {
            Guid? projectId = ParseBinaryRightValue(_projectTaskFilterView.Context.GetFilter("ProjectId"));
            if (projectId == Guid.Empty)
            {
                Guid projectTaskId = this._objectSpace.GetObjectId(this.ObjectName, this.SelectedObject);
                object projectTask = this._objectSpace.GetOrNew(this.ObjectName, projectTaskId, null);
                Katrin.Domain.Impl.ProjectTask task = projectTask as Katrin.Domain.Impl.ProjectTask;
                return task.ProjectId;
            }
            else
            {
                return projectId;
            }
        }

        public Guid? GetSelectedFilterProjectId()
        {
            return this._projectTaskFilterView.ProjectId;
        }

        public Guid? GetSelectedIterationId()
        {
            return this._projectTaskFilterView.ProjectIterationId;
        }

        public Guid? GetSelectedMemberId()
        {
            return this._projectTaskFilterView.MemberId;
        }
        
    }
}
