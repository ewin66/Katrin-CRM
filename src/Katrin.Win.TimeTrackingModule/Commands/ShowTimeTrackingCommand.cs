using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Views;
using DevExpress.XtraBars.Docking;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Workspaces;

namespace Katrin.Win.TimeTrackingModule.Commands
{
    public class ShowTimeTrackingCommand : AbstractCommand
    {
        public override void Run()
        {
            if (this.Owner is IController)
            {
                
                IController controller = this.Owner as IController;
                if (controller is IObjectDetailController)
                {
                    IObjectDetailController detailController = this.Owner as IObjectDetailController;
                    var message = new ActivateViewMessage(controller.WorkSpaceID, "TimeTrackingList");
                    message.Parameters = new ActionParameters(detailController.ObjectName, detailController.ObjectId, ViewShowType.Show);
                    EventAggregationManager.SendMessage(message);
                }
                else
                {
                    Guard.ObjectIsInstanceOfType(Owner, typeof(IObjectAware), "Owner");
                    var objectAware = (IObjectAware)this.Owner;
                    EventAggregationManager.SendMessage(new ToggleVisibilityMessage(objectAware.ObjectName, "TimeTrackingList", controller.WorkSpaceID));
                }
            }
            
        }
    }
}
