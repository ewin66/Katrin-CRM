using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.ProjectTaskModule.Commands
{
    class GiveTaskToMemberCommand : AbstractCommand
    {
        public override void Run()
        {
            Guid? memerId = null;
            if (!string.IsNullOrEmpty(this.Parameter))
            {
                memerId = Guid.Parse(Parameter);
            }
            ProjectTaskController controller = this.Owner as ProjectTaskController;
            controller.GiveTaskToMember(memerId);
        }
    }
}
