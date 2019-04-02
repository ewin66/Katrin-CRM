using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.Win.LeadModule.Detail;

namespace Katrin.Win.LeadModule
{
    public class OpenLeadListCommand : AbstractCommand
    {
        public override void Run()
        {
            var message = new ShowScreenMessage("/Lead/List", "Lead");
            EventAggregationManager.SendMessage(message);
        }
    }
}
