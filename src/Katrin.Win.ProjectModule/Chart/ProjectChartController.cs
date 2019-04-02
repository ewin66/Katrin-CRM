using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Text;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.Win.Common;
using Katrin.Win.ProjectModule.Detail;
using DevExpress.Data.Filtering;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.Data;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Workspaces;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework;
using Katrin.AppFramework.WinForms.Messages;
using System.ComponentModel;
namespace Katrin.Win.ProjectModule.Chart
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

    public class ProjectChartController : ObjectController, IListener<FilterChangedMessage>, IListener<ObjectSetChangedMessage>
    {

        private IProjectChartView _chartView;
        private List<Katrin.Domain.Impl.User> _users;

        public ProjectChartController()
        {
            ObjectName = "ProjectChart";
            ControllerId = "Project";
            EventAggregationManager.AddListener(this);
        }

        protected void OnViewSet()
        {
            _users = (List<Katrin.Domain.Impl.User>)_objectSpace.GetObjects("User");
            _chartView.Context.BindingSource.CurrentChanged += View_CurrentChanged;
            _chartView.OnIterationChange += View_IterationChange;
            //_chartView.RemoveListener += _chartView_RemoveListener;
            _chartView.BindProjects();

            List<Katrin.Domain.Impl.Project> projectList = new List<Domain.Impl.Project>();
            projectList.Add(new Katrin.Domain.Impl.Project());
            _chartView.BindSummaryData(projectList, new List<ProjectSummary>() { new ProjectSummary() });

            BindSummaryData();
        }
        public override void Dispose()
        {
            if (_users != null)
            {
                _users.Clear();
                _users = null;
            }
            if (_chartView != null)
            {
                _chartView.Context.BindingSource.CurrentChanged -= View_CurrentChanged;
                _chartView.OnIterationChange -= View_IterationChange;
                _chartView.Context.BindingSource.Clear();
                _chartView = null;
            }
            base.Dispose();
        }
      

        //void _chartView_RemoveListener(object sender, EventArgs e)
        //{
        //    EventAggregationManager.RemoveListener(this);
        //    _chartView = null;
        //}

        public override IActionResult Execute(ActionParameters parameters)
        {
            _chartView = ViewFactory.CreateView("DefaultProjectChartView") as IProjectChartView;
            OnViewSet();
            var result = new PartialViewResult();
            result.View = _chartView;
            return result;
        }


        void View_ContextChanged(object sender, EventArgs e)
        {
            BindSummaryData();
        }

        void View_CurrentChanged(object sender, EventArgs e)
        {

            BindSummaryData();
        }

        private void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BindResult bindResult = (BindResult)e.Result;
            _chartView.BindSummaryData(bindResult.ProjectEntity, bindResult.projectSummaryEntity);
            _chartView.BindMemberGrid(bindResult.memberSummaryList);
            _chartView.BindScheduler(bindResult.schedulerDataList, bindResult.resourceDataList);
            _chartView.BindIterationGrid(bindResult.IterationSummaryList);
        }

        private void SumEntity(ProjectSummary item, IList projectTasks)
        {
            item.SumQuoteWorkHours = projectTasks.AsQueryable().Select("QuoteWorkHours").Cast<double?>().Sum() ?? 0;
            item.SumActualWorkHours = projectTasks.AsQueryable().Select("ActualWorkHours").Cast<double?>().Sum() ?? 0;
            item.SumActualInput = projectTasks.AsQueryable().Select("ActualInput").Cast<double?>().Sum() ?? 0;
            item.SumEffort = projectTasks.AsQueryable().Select("Effort").Cast<double?>().Sum() ?? 0;
            item.SumOvertime = projectTasks.AsQueryable().Select("Overtime").Cast<double?>().Sum() ?? 0;
            item.SumRemainderTime = item.SumActualWorkHours - item.SumEffort;
            if (item.SumActualInput > 0)
            {
                item.SumInputEffortRate = item.SumEffort / item.SumActualInput;
                item.SumInputEffortRate = double.Parse(item.SumInputEffortRate.ToString("0.00"));
            }
            else
                item.SumActualInput = 0d;
            if (item.SumActualWorkHours > 0)
            {
                item.SumEvaluateExactlyRate = item.SumQuoteWorkHours / item.SumActualWorkHours;
                item.SumEvaluateExactlyRate = double.Parse(item.SumEvaluateExactlyRate.ToString("0.00"));
            }
            else
                item.SumActualWorkHours = 0d;
        }

        #region summary
        class BindResult
        {
            public object ProjectEntity { get; set; }
            public List<ProjectSummary> projectSummaryEntity { get; set; }
            public List<ProjectSummary> memberSummaryList { get; set; }
            public List<SchedulerData> schedulerDataList { get; set; }
            public List<SchedulerResource> resourceDataList { get; set; }
            public List<ProjectSummary> IterationSummaryList { get; set; }
        }
        private void BindSummaryData()
        {
            var prjectId = Guid.Empty;
            if (_chartView == null) return;
            if (_chartView.Context.CurrentObject != null)
                prjectId = ConvertData.Convert<Katrin.Domain.Impl.Project>(_chartView.Context.CurrentObject).ProjectId;

            var worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += (s, ex) =>
            {

                var entity = (Katrin.Domain.Impl.Project)_objectSpace.GetOrNew("Project", prjectId, "Manager,SaleService,ProjectTasks,ProjectIterations");

                ProjectSummary projectSummaryEntity = new ProjectSummary();
                var projectTasks = entity.ProjectTasks.ToList();
                projectTasks = projectTasks.Where(c => c.IsDeleted == false).ToList();
                SumEntity(projectSummaryEntity, projectTasks);

                //
                Type entityType = entity.GetType();
                Type listGenericType = typeof(List<>);
                Type listType = listGenericType.MakeGenericType(entityType);
                var list = (IList)Activator.CreateInstance(listType);
                list.Add(entity);
                BindResult bindResult = new BindResult();
                bindResult.ProjectEntity = list;
                bindResult.projectSummaryEntity = new List<ProjectSummary>() { projectSummaryEntity };


                BindMemberGrid(projectTasks, bindResult);

                IList projectIterations = entity.ProjectIterations.ToList();
                BindIterationGrid(projectTasks, projectIterations, bindResult);

                BindIterationScheduler(projectTasks, projectIterations, bindResult);
                ex.Result = bindResult;
            };
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
            worker.RunWorkerAsync();


        }
        #endregion

        #region member
        private void BindMemberGrid(IList projectTasks, BindResult bindResult)
        {
            IList taskOwnerList = projectTasks.AsQueryable().Where("OwnerId !=null").Select("OwnerId").Cast<Guid>().Distinct().ToArrayList();
            List<ProjectSummary> memberSummaryList = new List<ProjectSummary>();
            foreach (var ownerId in taskOwnerList)
            {
                ProjectSummary memberItem = new ProjectSummary();
                var userName = _users.AsQueryable().Where("userid=@0", ownerId).Select("FullName")._First();
                if (userName == null) continue;
                memberItem.Name = userName.ToString();
                IList taskList = projectTasks.AsQueryable().Where("OwnerId=@0", ownerId).ToArrayList();
                SumEntity(memberItem, taskList);
                memberSummaryList.Add(memberItem);
            }
            bindResult.memberSummaryList = memberSummaryList;
        }
        #endregion

        #region iteration
        void View_IterationChange(object sender, EventArgs<Guid> e)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties.Add("ProjectIteration", "ProjectIteration");
            var iterationTasks = _objectSpace.GetObjects("ProjectTask", new BinaryOperator("ProjectIterationId", e.Data), properties);
            List<BurnDownData> burnDownDataList = new List<BurnDownData>();
            if (iterationTasks.Count > 0)
            {
                List<Katrin.Domain.Impl.TaskTimeHistory> taskHistorys = new List<Katrin.Domain.Impl.TaskTimeHistory>();
                foreach (var task in iterationTasks)
                {
                    var taskEntity = ConvertData.Convert<Katrin.Domain.Impl.ProjectTask>(task);
                    var taskitemHistorys = _objectSpace.GetObjects("TaskTimeHistory", new BinaryOperator("TaskId", taskEntity.TaskId), null);
                    if (taskitemHistorys.Count <= 0) continue;
                    taskHistorys.AddRange(taskitemHistorys.Cast<Katrin.Domain.Impl.TaskTimeHistory>());
                }
                var iterationTask = ConvertData.Convert<Katrin.Domain.Impl.ProjectTask>(iterationTasks[0]);
                DateTime beginDate = iterationTask.ProjectIteration.StartDate ?? DateTime.Today;
                DateTime endDate = iterationTask.ProjectIteration.Deadline ?? DateTime.Today;

                double? sumActualWorkHours = iterationTasks.AsQueryable().Select("ActualWorkHours").Cast<double?>().Sum();
                for (DateTime firstDate = beginDate; firstDate <= endDate; firstDate = firstDate.AddDays(1))
                {
                    BurnDownData itemData = new BurnDownData();
                    itemData.currentDate = firstDate;
                    var subTaskHistory = taskHistorys.Where(c => c.RecordOn <= firstDate);
                    double? sumEffort = subTaskHistory.Select(c => c.Effort).Cast<double?>().Sum();
                    itemData.RemainderTime = (sumActualWorkHours ?? 0) - (sumEffort ?? 0);
                    itemData.IdealRemainderTime = 0d;
                    if (_chartView.IsEliminateWeekend())
                        if (firstDate.DayOfWeek == DayOfWeek.Sunday || firstDate.DayOfWeek == DayOfWeek.Saturday)
                            continue;
                    burnDownDataList.Add(itemData);
                }
                int spanDays = burnDownDataList.Count;
                double avgIdealRemainderTime = (sumActualWorkHours ?? 0) / spanDays;
                avgIdealRemainderTime = double.Parse(avgIdealRemainderTime.ToString("0.00"));
                foreach (var burnDown in burnDownDataList)
                {
                    burnDown.IdealRemainderTime = avgIdealRemainderTime * spanDays;
                    spanDays--;
                }
            }
            _chartView.BindBurnDownData(burnDownDataList);
        }

        private void BindIterationScheduler(IList projectTasks, IList projectIterations, BindResult bindResult)
        {
            List<SchedulerData> schedulerDataList = new List<SchedulerData>();
            IList taskIterationList = projectTasks.AsQueryable().Where("ProjectIterationId != null").Select("ProjectIterationId").Cast<Guid>().Distinct().ToArrayList();
            List<SchedulerResource> resourceDataList = new List<SchedulerResource>();

            int lableIndex = 1;
            foreach (var iterationId in taskIterationList)
            {
                IList iterationTaskList = projectTasks.AsQueryable().Where("ProjectIterationId=@0", iterationId).ToArrayList();
                var iterationItemList = projectIterations.AsQueryable().Where("ProjectIterationId=@0", iterationId).ToArrayList();
                if (iterationItemList.Count <= 0) continue;
                var iterationItem = (Katrin.Domain.Impl.ProjectIteration)iterationItemList[0];

                SchedulerResource resource = new SchedulerResource();

                resource.Caption = iterationItem.Name;
                resource.ParentId = 0;
                resource.ResourceId = lableIndex;
                resourceDataList.Add(resource);


                SchedulerData schedulerData = new SchedulerData();
                schedulerData.AllDay = true;
                schedulerData.Lable = lableIndex % 10;
                schedulerData.Description = iterationItem.Objective;
                schedulerData.End = iterationItem.Deadline ?? DateTime.Today;
                double sumEffort = iterationTaskList.AsQueryable().Select("Effort").Cast<double?>().Sum() ?? 0d;
                double sumActualInput = iterationTaskList.AsQueryable().Select("ActualInput").Cast<double?>().Sum() ?? 0d;
                double rate = sumActualInput == 0 ? 0 : sumEffort * 100 / sumActualInput;
                rate = double.Parse(rate.ToString("0.00"));
                schedulerData.PercentComplete = float.Parse(rate.ToString());
                schedulerData.ResourceId = lableIndex;
                schedulerData.Start = iterationItem.StartDate ?? DateTime.Today;
                schedulerData.Status = 0;
                schedulerData.Subject = StringParser.Parse("colSumEffort") + ":" + sumEffort;
                schedulerDataList.Add(schedulerData);
                lableIndex++;
            }
            bindResult.schedulerDataList = schedulerDataList;
            bindResult.resourceDataList = resourceDataList;
        }

        private void BindIterationGrid(IList projectTasks, IList projectIterations, BindResult bindResult)
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
                var iteration = ConvertData.Convert<Katrin.Domain.Impl.ProjectIteration>(iterationList[0]);
                iterationItem.NameAndDate = string.Format(displayNameFormat, iterationItem.Name, iteration.StartDate, iteration.Deadline);
                iterationItem.StartDate = iteration.StartDate ?? DateTime.Today;
                IterationSummaryList.Add(iterationItem);
            }
            IterationSummaryList = IterationSummaryList.AsQueryable().OrderBy("StartDate desc ").ToList();
            bindResult.IterationSummaryList = IterationSummaryList;
        }
        #endregion

        #region no user

        public override object SelectedObject
        {
            get { return null; }
        }

        #endregion

        void IListener<FilterChangedMessage>.Handle(FilterChangedMessage message)
        {
            if (message.ObjectName != ObjectName) return;
            IObjectSpace objectSpace = new ODataObjectSpace();
            _chartView.Context.BindingSource.DataSource = objectSpace.GetObjects("Project", message.Filter, null);
        }

        void IListener<ObjectSetChangedMessage>.Handle(ObjectSetChangedMessage message)
        {
            if (message.ObjectName != ObjectName) return;
            IObjectSpace objectSpace = new ODataObjectSpace();
            _chartView.Context.BindingSource.DataSource = objectSpace.GetObjects("Project").AsQueryable().OrderBy("name asc").ToArrayList();
        }
    }
}
