using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.Messages;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Workspaces;
using Katrin.Win.ProjectTaskModule.EditEffort;

namespace Katrin.Win.ProjectTaskModule.Commands
{
    public class RefreshEditEffort : AbstractCommand
    {
        public override void Run()
        {
            if (!(this.Owner is ManageEffortDetailController)) return;
            var manageController = this.Owner as ManageEffortDetailController;
            manageController.Refresh();
        }
    }
}
