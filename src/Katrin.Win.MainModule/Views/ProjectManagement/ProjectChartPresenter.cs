using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Text;
using Katrin.Win.Common;
using Katrin.Win.Common.Constants;
using Katrin.Win.Common.Core;
using Katrin.Win.Infrastructure;
using DevExpress.Data.Filtering;
using Microsoft.Practices.CompositeUI.EventBroker;

namespace Katrin.Win.MainModule.Views.ProjectManagement
{

    public class SchedulerResource
    {
        public int ResourceId { get; set; }
        public int ParentId { get; set; }
        public string Caption { get; set; }
        public Color ResourceColor { get; set; }
        public string TargetName { get; set; }
    }
    public class SchedulerData
    {
        public bool AllDay { get; set; }
        public string Description { get; set; }
        public DateTime End { get; set; }
        public float PercentComplete { get; set; }
        public int ResourceId { get; set; }
        public DateTime Start { get; set; }
        public int Status { get; set; }
        public string Subject { get; set; }
        public int Lable { get; set; }
    }

    public class BurnDownData
    {
        public DateTime currentDate { get; set; }
        public double IdealRemainderTime { get; set; }
        public double RemainderTime { get; set; }
    }

    public class ProjectChartPresenter : Presenter<IProjectChartView>
    {
        private IList _users;
        private IDynamicDataServiceContext _dynamicDataServiceContext;

        protected IDynamicDataServiceContext DynamicDataServiceContext
        {
            get { return _dynamicDataServiceContext ?? (_dynamicDataServiceContext = new DynamicDataServiceContext()); }
        }


        protected override void OnViewSet()
        {
            base.OnViewSet();
            _users = DynamicDataServiceContext.GetObjects("User");
            View.CurrentChanged += View_CurrentChanged;
            View.ContextChanged += View_ContextChanged;
            View.OnIterationChange += View_IterationChange;
        }



        void View_ContextChanged(object sender, EventArgs e)
        {
            BindSummaryData();
        }

        void View_CurrentChanged(object sender, EventArgs e)
        {
            BindSummaryData();
        }

        private void SumEntity(ProjectSummary item, IList projectTasks)
        {
            item.SumQuoteWorkHours = projectTasks.AsQueryable().Select("QuoteWorkHours").Cast<double?>().Sum();
            item.SumActualWorkHours = projectTasks.AsQueryable().Select("ActualWorkHours").Cast<double?>().Sum();
            item.SumActualInput = projectTasks.AsQueryable().Select("ActualInput").Cast<double?>().Sum();
            item.SumEffort = projectTasks.AsQueryable().Select("Effort").Cast<double?>().Sum();
            item.SumOvertime = projectTasks.AsQueryable().Select("Overtime").Cast<double?>().Sum();
            item.SumRemainderTime = item.SumActualWorkHours - item.SumEffort;
            if (item.SumActualInput > 0)
                item.SumInputEffortRate = item.SumEffort / item.SumActualInput ?? 0d;
            else
                item.SumActualInput = 0d;
            if (item.SumActualWorkHours > 0)
                item.SumEvaluateExactlyRate = item.SumQuoteWorkHours / item.SumActualWorkHours ?? 0d;
            else
                item.SumActualWorkHours = 0d;
        }

        #region summary
        private void BindSummaryData()
        {
            var prjectId = Guid.Empty;
            if (View.Context.CurrentObject != null)
                prjectId = View.Context.CurrentObject.AsDyanmic().ProjectId;
            var entity = DynamicDataServiceContext.GetOrNew("Project", prjectId, "Manager,SaleService,ProjectTasks,ProjectIterations");
            ProjectSummary projectSummaryEntity = new ProjectSummary();
            IList projectTasks = entity.AsDyanmic().ProjectTasks;
            projectTasks = projectTasks.AsQueryable().Where("IsDeleted=@0", false).ToArrayList();
            SumEntity(projectSummaryEntity, projectTasks);

            //
            Type entityType = entity.GetType();
            Type listGenericType = typeof(List<>);
            Type listType = listGenericType.MakeGenericType(entityType);
            var list = (IList)Activator.CreateInstance(listType);
            list.Add(entity);
            View.BindSummaryData(list, new List<ProjectSummary>() { projectSummaryEntity });

            BindMemberGrid(projectTasks);

            IList projectIterations = entity.AsDyanmic().ProjectIterations;
            BindIterationGrid(projectTasks, projectIterations);

            BindIterationScheduler(projectTasks, projectIterations);
        }
        #endregion

        #region member
        private void BindMemberGrid(IList projectTasks)
        {
            IList taskOwnerList = projectTasks.AsQueryable().Where("OwnerId !=null").Select("OwnerId").Cast<Guid>().Distinct().ToArrayList();
            List<ProjectSummary> memberSummaryList = new List<ProjectSummary>();
            foreach (var ownerId in taskOwnerList)
            {
                ProjectSummary memberItem = new ProjectSummary();
                memberItem.Name = _users.AsQueryable().Where("userid=@0", ownerId).Select("FullName").Cast<string>().First();
                IList taskList = projectTasks.AsQueryable().Where("OwnerId=@0", ownerId).ToArrayList();
                SumEntity(memberItem, taskList);
                memberSummaryList.Add(memberItem);
            }
            View.BindMemberGrid(memberSummaryList);
        }
        #endregion

        #region iteration
        void View_IterationChange(object sender, EventArgs<Guid> e)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties.Add("ProjectIteration", "ProjectIteration");
            var iterationTasks = DynamicDataServiceContext.GetObjects("ProjectTask", new BinaryOperator("ProjectIterationId", e.Data), properties);
            List<BurnDownData> burnDownDataList = new List<BurnDownData>();
            if (iterationTasks.Count > 0)
            {
                List<object> taskHistorys = new List<object>();
                foreach (var task in iterationTasks)
                {
                    var taskitemHistorys = DynamicDataServiceContext.GetObjects("TaskTimeHistory", new BinaryOperator("TaskId", task.AsDyanmic().TaskId), null);
                    if (taskitemHistorys.Count <= 0) continue;
                    taskHistorys.AddRange(taskitemHistorys.Cast<object>());
                }
                DateTime beginDate = iterationTasks._First().AsDyanmic().ProjectIteration.StartDate;
                DateTime endDate = iterationTasks._First().AsDyanmic().ProjectIteration.Deadline;

                double? sumActualWorkHours = iterationTasks.AsQueryable().Select("ActualWorkHours").Cast<double?>().Sum();
                for (DateTime firstDate = beginDate; firstDate <= endDate; firstDate = firstDate.AddDays(1))
                {
                    BurnDownData itemData = new BurnDownData();
                    itemData.currentDate = firstDate;
                    var subTaskHistory = taskHistorys.Where(c => c.AsDyanmic().RecordOn <= firstDate);
                    double? sumEffort = subTaskHistory.Select(c => c.AsDyanmic().Effort).Cast<double?>().Sum();
                    itemData.RemainderTime = (sumActualWorkHours ?? 0) - (sumEffort ?? 0);
                    itemData.IdealRemainderTime = 0d;
                    if (View.IsEliminateWeekend())
                        if (firstDate.DayOfWeek == DayOfWeek.Sunday || firstDate.DayOfWeek == DayOfWeek.Saturday)
                            continue;
                    burnDownDataList.Add(itemData);
                }
                int spanDays = burnDownDataList.Count;
                double avgIdealRemainderTime = (sumActualWorkHours ?? 0) / spanDays;
                foreach (var burnDown in burnDownDataList)
                {
                    burnDown.IdealRemainderTime = avgIdealRemainderTime * spanDays;
                    spanDays--;
                }
            }
            View.BindBurnDownData(burnDownDataList);
        }

        private void BindIterationScheduler(IList projectTasks, IList projectIterations)
        {
            List<SchedulerData> schedulerDataList = new List<SchedulerData>();
            IList taskIterationList = projectTasks.AsQueryable().Where("ProjectIterationId != null").Select("ProjectIterationId").Cast<Guid>().Distinct().ToArrayList();
            List<SchedulerResource> resourceDataList = new List<SchedulerResource>();

            int lableIndex = 1;
            foreach (var iterationId in taskIterationList)
            {
                IList iterationTaskList = projectTasks.AsQueryable().Where("ProjectIterationId=@0", iterationId).ToArrayList();
                var iterationItem = projectIterations.AsQueryable().Where("ProjectIterationId=@0", iterationId)._First().AsDyanmic();


                SchedulerResource resource = new SchedulerResource();

                resource.Caption = iterationItem.Name;
                resource.ParentId = 0;
                resource.ResourceId = lableIndex;
                resourceDataList.Add(resource);


                SchedulerData schedulerData = new SchedulerData();
                schedulerData.AllDay = true;
                schedulerData.Lable = lableIndex % 10;
                schedulerData.Description = iterationItem.Objective;
                schedulerData.End = iterationItem.Deadline;
                double sumEffort = iterationTaskList.AsQueryable().Select("Effort").Cast<double?>().Sum() ?? 0d;
                double sumActualInput = iterationTaskList.AsQueryable().Select("ActualInput").Cast<double?>().Sum() ?? 0d;
                double rate = sumActualInput == 0 ? 0 : sumEffort * 100 / sumActualInput;
                schedulerData.PercentComplete = float.Parse(rate.ToString());
                schedulerData.ResourceId = lableIndex;
                schedulerData.Start = iterationItem.StartDate;
                schedulerData.Status = 0;
                schedulerData.Subject = Properties.Resources.colSumEffort + ":" + sumEffort;
                schedulerDataList.Add(schedulerData);
                lableIndex++;
            }
            View.BindScheduler(schedulerDataList, resourceDataList);

        }
        private void BindIterationGrid(IList projectTasks, IList projectIterations)
        {
            IList taskIterationList = projectTasks.AsQueryable().Where("ProjectIterationId != null").Select("ProjectIterationId").Cast<Guid>().Distinct().ToArrayList();
            List<ProjectSummary> IterationSummaryList = new List<ProjectSummary>();
            var displayNameFormat = "{0} ({1:yy/MM/dd} - {2:yy/MM/dd})";
            foreach (var iterationId in taskIterationList)
            {
                IList iterationList = projectIterations.AsQueryable().Where("ProjectIterationId=@0", iterationId).ToArrayList();
                IList iterationNameList = iterationList.AsQueryable().Select("Name").Cast<string>().ToArrayList();
                if (iterationNameList.Count <= 0) continue;
                ProjectSummary iterationItem = new ProjectSummary();
                iterationItem.Name = iterationNameList[0].ToString();
                IList taskList = projectTasks.AsQueryable().Where("ProjectIterationId=@0", iterationId).ToArrayList();
                SumEntity(iterationItem, taskList);
                iterationItem.Id = (Guid)iterationId;
                iterationItem.NameAndDate = string.Format(displayNameFormat, iterationItem.Name, iterationList._First().AsDyanmic().StartDate, iterationList._First().AsDyanmic().Deadline);
                iterationItem.StartDate = iterationList._First().AsDyanmic().StartDate;
                IterationSummaryList.Add(iterationItem);
            }
            IterationSummaryList = IterationSummaryList.AsQueryable().OrderBy("StartDate desc ").ToList();
            View.BindIterationGrid(IterationSummaryList);
        }
        #endregion
    }
}
