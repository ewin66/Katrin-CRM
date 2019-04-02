using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Context;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;
using Katrin.Win.ProjectModule.Detail;

namespace Katrin.Win.ProjectModule.Chart
{
    public interface IProjectChartView : IView
    {
        void BindSummaryData(object dataSource, List<ProjectSummary> statisticNumberList);
        void BindIterationGrid(List<ProjectSummary> dataSource);
        void BindMemberGrid(List<ProjectSummary> dataSource);
        void BindScheduler(List<SchedulerData> schedulerDataSource, List<SchedulerResource> resourceDataSource);
        event EventHandler<EventArgs<Guid>> OnIterationChange;
        //event EventHandler RemoveListener;
        void BindBurnDownData(List<BurnDownData> dataSource);
        bool IsEliminateWeekend();
        ActionContext Context{get;}
        void BindProjects();
    }
}
