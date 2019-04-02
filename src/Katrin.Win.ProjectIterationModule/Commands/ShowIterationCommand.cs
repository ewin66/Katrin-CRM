using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.Views;
using Katrin.Win.DetailViewModule;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms.MVC;

namespace Katrin.Win.ProjectIterationModule.Commands
{
    public class ShowIterationCommand : AbstractCommand
    {
        public override void Run()
        {
            if (this.Owner is ListController)
            {
                ListController controller = this.Owner as ListController;
                Guard.ObjectIsInstanceOfType(Owner, typeof(IObjectAware), "Owner");
                var objectAware = (IObjectAware)this.Owner;
                EventAggregationManager.SendMessage(new ToggleVisibilityMessage(objectAware.ObjectName, "ProjectIterationList", controller.WorkSpaceID));
            }
            else if (this.Owner is ObjectDetailController)
            {
                IController controller = this.Owner as IController;
              
                ActivateViewMessage message = new ActivateViewMessage(controller.WorkSpaceID, "ProjectIteration");
                EventAggregationManager.SendMessage(message);

                ObjectDetailController detailController = (ObjectDetailController)this.Owner;
                var selectedObjectChanged = new SelectedObjectChangedMessage { ObjectName = detailController.ObjectName };
                selectedObjectChanged.SelectedObject = detailController.SelectedObject;
                EventAggregationManager.SendMessage(selectedObjectChanged);
                
            }

        }
    }
}
