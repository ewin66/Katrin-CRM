using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.Core;

namespace Katrin.Win.ProjectTaskModule.Commands
{
    public class DayReportCommand : AbstractCommand
    {
        public override void Run()
        {
            if (!(this.Owner is ProjectTaskController)) return;
            ProjectTaskController projectTaskController = (ProjectTaskController)this.Owner;
            projectTaskController.GenerateDayReport();
        }
    }
}
