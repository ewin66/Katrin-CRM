using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Messages;


namespace Katrin.Win.OpportunityModule
{
    public class OpenOpportunityListCommand : AbstractCommand
    {
        public override void Run()
        {
            var message = new ShowScreenMessage("/Opportunity/List", "Opportunity");
            EventAggregationManager.SendMessage(message);
        }
    }
}
