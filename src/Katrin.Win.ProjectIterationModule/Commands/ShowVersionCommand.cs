using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.Win.DetailViewModule;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms.MVC;

namespace Katrin.Win.ProjectIterationModule.Commands
{
    public class ShowVersionCommand : AbstractCommand
    {
        public override void Run()
        {
            IController controller = this.Owner as IController;
            //ActivateViewMessage message = new ActivateViewMessage { ViewName = "ProjectVersion" };
            ActivateViewMessage message = new ActivateViewMessage(controller.WorkSpaceID, "ProjectVersion");
            EventAggregationManager.SendMessage(message);

            ObjectDetailController detailController = (ObjectDetailController)this.Owner;
            var selectedObjectChanged = new SelectedObjectChangedMessage { ObjectName = detailController.ObjectName };
            selectedObjectChanged.SelectedObject = detailController.SelectedObject;
            EventAggregationManager.SendMessage(selectedObjectChanged);
        }
    }
}
