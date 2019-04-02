using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;
using Katrin.Win.MainModule.Views.Opportunity;

namespace Katrin.Win.MainModule.Views.ProjectWeekReport
{
    public class ProjectWeekReportController : EntityListController<ProjectWeekReportListView, ProjectWeekReportDetailView>
    {
        protected override string EntityName
        {
            get { return "ProjectWeekReport"; }
        }
    }
}
