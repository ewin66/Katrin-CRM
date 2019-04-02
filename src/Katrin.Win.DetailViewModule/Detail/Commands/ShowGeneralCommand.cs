using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework;
using Katrin.AppFramework.WinForms.MVC;

namespace Katrin.Win.DetailViewModule.Commands
{
    public class ShowGeneralCommand : ObjectAwareCommand
    {
        public override void Run()
        {
            IController controller = this.Owner as IController;
            if (controller != null)
            {               
                ActivateViewMessage message = new ActivateViewMessage(controller.WorkSpaceID, "DefaultDetailView");

                EventAggregationManager.SendMessage(message);
            }
        }
    }
}
