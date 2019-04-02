using Katrin.AppFramework;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Workspaces;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.TimeTrackingModule.Commands
{
    public class DeleteTimeTrackingCommand : AbstractCommand
    {
        public override void Run()
        {
            if (!(Owner is TimeTrackingController)) return;

            TimeTrackingController controller = this.Owner as TimeTrackingController;
            controller.Delete();
         
        }
    }
}
