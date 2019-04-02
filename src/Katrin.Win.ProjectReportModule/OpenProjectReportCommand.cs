using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.ProjectReportModule
{
    public class OpenProjectReportCommand : AbstractCommand
    {
        public override void Run()
        {
            var message = new ShowScreenMessage("/ProjectReport/List", "ProjectReport");
            EventAggregationManager.SendMessage(message);
        }
    }
}
