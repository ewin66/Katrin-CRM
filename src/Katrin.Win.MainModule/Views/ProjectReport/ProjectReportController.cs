using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Constants;
using Microsoft.Practices.CompositeUI;

namespace Katrin.Win.MainModule.Views.ProjectReport
{
    public class ProjectReportController : WorkItem
    {
        protected override void OnRunStarted()
        {
            var key = "ProjectReportView";
            var view = Items.Get<ProjectReportView>(key);
            if(view == null)
            {
                view = Items.AddNew<ProjectReportView>(key);
            }
            Workspaces[WorkspaceNames.ShellContentWorkspace].Show(view);
        }
    }
}
