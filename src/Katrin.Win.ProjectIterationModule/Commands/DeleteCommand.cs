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

namespace Katrin.Win.ProjectIterationModule.Commands
{
   public class DeleteCommand : AbstractCommand
    {
        public override void Run()
        {
            if (!(Owner is ListController)) return;
            ListController controller = this.Owner as ListController;
            controller.Delete();
        }
    }
}
