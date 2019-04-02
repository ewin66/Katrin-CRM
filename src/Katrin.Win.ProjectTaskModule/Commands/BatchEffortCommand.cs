using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.Messages;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Workspaces;

namespace Katrin.Win.ProjectTaskModule.Commands
{
    public class BatchEffortCommand : AbstractCommand
    {
        public override void Run()
        {
            if (!(this.Owner is ListController)) return;
            ListController listController = (ListController)this.Owner;
            var parameters = new ActionParameters("NewProjectTaskEffort", Guid.Empty, ViewShowType.Show){
                    {"WorkingMode",EntityDetailWorkingMode.Edit}
                };
            App.Instance.Invoke("NewProjectTaskEffort", "Detail", parameters);
        }
    }
}
