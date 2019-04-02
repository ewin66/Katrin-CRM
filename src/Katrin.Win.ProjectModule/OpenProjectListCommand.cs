using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.ProjectModule
{
    public class OpenProjectListCommand: AbstractCommand
    {
        public override void Run()
        {
            var message = new ShowScreenMessage("/Project/List", "Project");
            EventAggregationManager.SendMessage(message);
        }
    }
}
