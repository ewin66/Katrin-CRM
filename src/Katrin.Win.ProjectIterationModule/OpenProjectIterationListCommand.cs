using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.ProjectIterationModule
{
    public class OpenProjectListCommand: AbstractCommand
    {
        public override void Run()
        {
            var message = new ShowScreenMessage("/ProjectIteration/List", "ProjectIteration");
            EventAggregationManager.SendMessage(message);
        }
    }
}
