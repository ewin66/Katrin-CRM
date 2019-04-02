using Katrin.Win.Common.Security;
using Katrin.Win.Infrastructure;
using DevExpress.Data.Filtering;
using System;
using System.Linq.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common;
using Katrin.Win.Infrastructure.Services;
using Katrin.Win.Common.Core;

namespace Katrin.Win.MainModule.Views.ProjectTask
{
    public class ProjectTaskFilterPresenter<T> : Presenter<T> where T : IProejctTaskFilter
    {
        private IDynamicDataServiceContext _dynamicDataServiceContext;

        protected IDynamicDataServiceContext DynamicDataServiceContext
        {
            get { return _dynamicDataServiceContext ?? (_dynamicDataServiceContext = new DynamicDataServiceContext()); }
        }

        public void InitFilters()
        {
            var projectId = ParseBinaryRightValue(View.Context.GetFilter("ProjectId"));
            var projectIterationId = ParseBinaryRightValue(View.Context.GetFilter("ProjectIterationId"));
            var memberId = ParseBinaryRightValue(View.Context.GetFilter("MemberId"));

            BindProjects(projectId);
            BindProjectIterations(View.ProjectId, projectIterationId);
            BindProjectMembers(View.ProjectId, memberId);
            UpdateContextFilters();
        }

        public void OnProjectChanged(Guid? projectId)
        {
            BindProjectIterations(View.ProjectId, null);
            BindProjectMembers(View.ProjectId, null);
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

        public void UpdateContextFilters()
        {
            UpdateContextFilters(View.Context, View.ProjectId, View.ProjectIterationId, View.MemberId);
        }

        private void BindProjects(Guid? defaultProjectId)
        {
            var projects = GetProjects().ToList();
            View.BindProjectLookUp(projects);
            if (defaultProjectId == null)
            {
                defaultProjectId = projects.Count > 1 ? projects[1].Value : projects[0].Value;
            }
            View.ProjectId = defaultProjectId;
        }

        private void BindProjectIterations(Guid? projectId, Guid? defaultIterationId)
        {
            var iterationItems = GetProjectIterations(projectId).ToList();
            View.BindIterationLookUp(iterationItems);
            if (defaultIterationId == null)
            {
                var defaultIteration = iterationItems.FirstOrDefault(i => i.IsDeafult);
                if (defaultIteration != null) defaultIterationId = defaultIteration.Value;
            }
            View.ProjectIterationId = defaultIterationId;
        }

        private void BindProjectMembers(Guid? projectId, Guid? defaultMemberId)
        {
            var userList = GetProjectMembers(projectId).ToList();
            View.BindMemberLookUp(userList);
            if (defaultMemberId == null)
            {
                defaultMemberId = userList.Count > 1 ? userList[1].Value : userList[0].Value;
            }
            View.MemberId = defaultMemberId;
        }

        private IEnumerable<LookupListItem<Guid?>> GetProjects()
        {
            CriteriaOperator filter = new BinaryOperator("ManagerId", AuthorizationManager.CurrentUserId);
            var memberList = DynamicDataServiceContext.GetObjects("ProjectMember", new BinaryOperator("MemberId", AuthorizationManager.CurrentUserId), null);
            List<object> projectIds = new List<object>();
            foreach (var memberItem in memberList)
            {
                projectIds.Add(memberItem.AsDyanmic().ProjectId);
            }
            if (projectIds.Any()) filter |= new InOperator("ProjectId", projectIds);
            var projectList = DynamicDataServiceContext.GetObjects("Project", filter, null);
            if (!projectList.AsQueryable().Any())
                projectList = DynamicDataServiceContext.GetObjects("Project");

            yield return new LookupListItem<Guid?>
            {
                Value = Guid.Empty,
                DisplayName = Properties.Resources.All
            };

            foreach (var project in projectList)
            {
                dynamic it = project.AsDyanmic();
                yield return new LookupListItem<Guid?>
                {
                    Value = it.ProjectId,
                    DisplayName = it.Name
                };
            }
        }

        private IEnumerable<LookupListItem<Guid?>> GetProjectIterations(Guid? projectId)
        {
            yield return new LookupListItem<Guid?>
            {
                Value = Guid.Empty,
                DisplayName = Properties.Resources.All
            };
            if (projectId != null)
            {
                yield return new LookupListItem<Guid?>
                {
                    Value = GuidExtension.UnassignedGuid,
                    DisplayName = Properties.Resources.Unassigned
                };

                Dictionary<string, string> additonProperty = new Dictionary<string, string>();
                additonProperty["IterationNameAndTime"] = "null";
                CriteriaOperator filter = new BinaryOperator("ProjectId", projectId);
                var iterationList = DynamicDataServiceContext.GetObjects("ProjectIteration", filter, additonProperty)
                    .AsQueryable().OrderBy("StartDate desc");

                Guid defaultIterationId = GetDefaultIterationId(iterationList);

                var displayNameFormat = "{0} ({1:yy/MM/dd} - {2:yy/MM/dd})";
                foreach (var iteration in iterationList)
                {
                    dynamic it = iteration.AsDyanmic();
                    Guid projectIterationId = it.ProjectIterationId;
                    bool isDefault = projectIterationId == defaultIterationId;
                    yield return new LookupListItem<Guid?>
                    {
                        Value = projectIterationId,
                        IsDeafult = isDefault,
                        DisplayName = string.Format(displayNameFormat, it.Name, it.StartDate, it.Deadline)
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
                    defaultIterationId = currentIteration._First().AsDyanmic().ProjectIterationId;
                else
                    defaultIterationId = iterationList._First().AsDyanmic().ProjectIterationId;
            }
            return defaultIterationId;
        }

        private IEnumerable<LookupListItem<Guid?>> GetProjectMembers(Guid? projectId)
        {
            yield return new LookupListItem<Guid?>
            {
                Value = Guid.Empty,
                DisplayName = Properties.Resources.All
            };

            if (projectId != null)
            {
                Dictionary<string, string> additonProperty = new Dictionary<string, string>();
                additonProperty["Member"] = "Member";

                CriteriaOperator filter = new BinaryOperator("ProjectId", projectId);
                var memberList = DynamicDataServiceContext.GetObjects("ProjectMember", filter, additonProperty);

                foreach (var member in memberList)
                {
                    dynamic it = member.AsDyanmic();
                    yield return new LookupListItem<Guid?>
                    {
                        Value = it.Member.UserId,
                        DisplayName = it.Member.FullName
                    };
                }
            }
        }
    }
}
