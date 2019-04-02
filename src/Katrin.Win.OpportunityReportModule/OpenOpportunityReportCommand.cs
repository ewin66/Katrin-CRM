using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.OpportunityReportModule
{
    public class OpenOpportunityReportCommand : AbstractCommand
    {
        public override void Run()
        {
            var message = new ShowScreenMessage("/OpportunityReport/List", "OpportunityReport");
            EventAggregationManager.SendMessage(message);
        }
    }
}
