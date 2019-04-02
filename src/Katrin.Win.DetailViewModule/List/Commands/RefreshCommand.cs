using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.ListViewModule.Commands
{
    public class RefreshCommand : AbstractCommand
    {
        public override void Run()
        {
            Guard.ObjectIsInstanceOfType(Owner, typeof(IObjectAware), "Owner");
             Guard.ObjectIsInstanceOfType(Owner, typeof(IController), "Owner");
            var objectAware = (IObjectAware)this.Owner;
            var controller = (IController)this.Owner;
            var message = new ObjectSetChangedMessage { ObjectName = objectAware.ObjectName ,WorkSpaceID = controller.WorkSpaceID};
            EventAggregationManager.SendMessage(message);
        }
    }
}
