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
using Katrin.AppFramework;
namespace Katrin.Win.ProjectTaskModule.Commands
{
    public class SplitProjectTaskCommand : AbstractCommand
    {
        public override void Run()
        {
            if (!(this.Owner is ListController)) return;
            ListController listController = (ListController)this.Owner;
            IObjectSpace objectSpace = new ODataObjectSpace();
            var selectedId = objectSpace.GetObjectId(listController.ObjectName, listController.SelectedObject);
            var parameters = new ActionParameters("SplitProjectTask", selectedId, ViewShowType.Show){
                    {"WorkingMode",EntityDetailWorkingMode.Edit}
                };
            App.Instance.Invoke("SplitProjectTask", "Detail", parameters);
        }
    }
}
