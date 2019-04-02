using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.Messages;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework;
using Katrin.AppFramework.WinForms.Workspaces;

namespace Katrin.Win.ProjectTaskModule.Commands
{
    public class AddEffortCommand : AbstractCommand
    {
        public override void Run()
        {
            if (!(this.Owner is ListController)) return;
            ListController listController = (ListController)this.Owner;
            IObjectSpace objectSpace = new ODataObjectSpace();
            var selectedId = objectSpace.GetObjectId(listController.ObjectName, listController.SelectedObject);
            var parameters = new ActionParameters("ProjectTaskEffort", selectedId, ViewShowType.Show){
                    {"WorkingMode",EntityDetailWorkingMode.Edit}
                };
            App.Instance.Invoke("ProjectTaskEffort", "Detail", parameters);
        }
    }
}
