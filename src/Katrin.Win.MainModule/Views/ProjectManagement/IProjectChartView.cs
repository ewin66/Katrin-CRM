using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Infrastructure;
using Katrin.Win.Common.Core;

namespace Katrin.Win.MainModule.Views.ProjectManagement
{
    public interface IProjectChartView : IView
    {
        void BindSummaryData(object dataSource, List<ProjectSummary> statisticNumberList);
        void BindIterationGrid(List<ProjectSummary> dataSource);
        void BindMemberGrid(List<ProjectSummary> dataSource);
        void BindScheduler(List<SchedulerData> schedulerDataSource, List<SchedulerResource> resourceDataSource);
        event EventHandler<EventArgs<Guid>> OnIterationChange;
        void BindBurnDownData(List<BurnDownData> dataSource);
        bool IsEliminateWeekend();
    }
}
