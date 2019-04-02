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
    public class ShowModuleCommand : AbstractCommand
    {
        public override void Run()
        {
            //ActivateViewMessage message = new ActivateViewMessage { ViewName = "ProjectModule" };
            IController controller = this.Owner as IController;
            ActivateViewMessage message = new ActivateViewMessage(controller.WorkSpaceID,"ProjectModule");
            EventAggregationManager.SendMessage(message);

            ObjectDetailController detailController = (ObjectDetailController)this.Owner;
            var selectedObjectChanged = new SelectedObjectChangedMessage { ObjectName = detailController.ObjectName };
            selectedObjectChanged.SelectedObject = detailController.SelectedObject;
            EventAggregationManager.SendMessage(selectedObjectChanged);
        }
    }
}
