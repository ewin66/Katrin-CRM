using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Constants;
using Microsoft.Practices.CompositeUI;

namespace Katrin.Win.MainModule.Views.Reports
{
    public class OpportunityReportController : WorkItem
    {
        protected override void OnRunStarted()
        {
            var key = "OpportunityReportView";
            var view = Items.Get<OpportunityReportView>(key);
            if(view == null)
            {
                view = Items.AddNew<OpportunityReportView>(key);
            }
            Workspaces[WorkspaceNames.ShellContentWorkspace].Show(view);
        }
    }
}
