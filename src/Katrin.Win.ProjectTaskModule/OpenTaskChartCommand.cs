using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.ProjectTaskModule
{
    public class OpenTaskChartCommand : AbstractCommand
    {
        public override void Run()
        {
            var message = new ShowScreenMessage("/ProjectTaskChart/List", "ProjectTaskChart");
            EventAggregationManager.SendMessage(message);
        }
    }
}
