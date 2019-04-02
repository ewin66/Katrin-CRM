using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Workspaces;
using Katrin.AppFramework.WinForms;

namespace Katrin.Win.HistoryModule.Commands
{
    public class ShowHistoryCommand : AbstractCommand
    {
        public override void Run()
        {
            

            var detailController = this.Owner as IObjectDetailController;
            if (detailController != null)
            {
                IController controller = this.Owner as IController;
              
                var message = new ActivateViewMessage(controller.WorkSpaceID, "History");
                message.Parameters = new ActionParameters(detailController.ObjectName, detailController.ObjectId, ViewShowType.Show);
                EventAggregationManager.SendMessage(message);
            }
            else
            {
                ObjectController objectController = (ObjectController)this.Owner;
                IObjectSpace objectSpace = new ODataObjectSpace();
                var selectedId = objectSpace.GetObjectId(objectController.ObjectName, objectController.SelectedObject);
                var parameters = new ActionParameters(objectController.ObjectName,selectedId, ViewShowType.Show);
                App.Instance.Invoke("History", "List", parameters);
                //message.Parameters = new ActionParameters(objectController.ObjectName,selectedId, ViewShowType.Show);
                
            }

            
        }
    }
}
