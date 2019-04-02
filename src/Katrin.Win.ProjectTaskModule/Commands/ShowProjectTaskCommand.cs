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

namespace Katrin.Win.ProjectTaskModule.Commands
{
    public class ShowProjectTaskCommand: AbstractCommand
    {
        public override void Run()
        {
            if (!(this.Owner is ObjectController)) return;
            ObjectController detailController = (ObjectController)this.Owner;

            IController controller = this.Owner as IController;
           
            ActivateViewMessage message = new ActivateViewMessage(controller.WorkSpaceID, "ProjectTask");            
            EventAggregationManager.SendMessage(message);

            var selectedObjectChanged = new SelectedObjectChangedMessage { ObjectName = detailController.ObjectName };
            selectedObjectChanged.SelectedObject = detailController.SelectedObject;
            EventAggregationManager.SendMessage(selectedObjectChanged);
        }
    }
}
