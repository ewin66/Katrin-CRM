using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.ProjectTaskModule.Commands
{
    class MoveTaskToIterationCommand : AbstractCommand
    {
        public override void Run()
        {
            Guid? iterationId = null;
            if (!string.IsNullOrEmpty(this.Parameter))
            {
                iterationId = Guid.Parse(this.Parameter);
            }
            ProjectTaskController controller = this.Owner as ProjectTaskController;
            controller.MoveTaskToIteration(iterationId);
        }
    }
}
