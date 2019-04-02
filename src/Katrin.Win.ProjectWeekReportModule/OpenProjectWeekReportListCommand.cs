using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.ProjectWeekReportModule
{
    public class OpenProjectWeekReportListCommand : AbstractCommand
    {
        public override void Run()
        {
            var message = new ShowScreenMessage("/ProjectWeekReport/List", "ProjectWeekReport");
            EventAggregationManager.SendMessage(message);
        }
    }
}
