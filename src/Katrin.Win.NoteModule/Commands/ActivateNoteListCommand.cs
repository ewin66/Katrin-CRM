using Katrin.AppFramework;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Workspaces;

namespace Katrin.Win.NoteModule.Commands
{
    public class ActivateNoteListCommand : AbstractCommand
    {
        public override void Run()
        {

            Guard.ObjectIsInstanceOfType(Owner, typeof(IObjectDetailController), "Owner");
            var detailController = (IObjectDetailController)this.Owner;
            IController controller = this.Owner as IController;           
            var message = new ActivateViewMessage(controller.WorkSpaceID, "NoteList");
            message.Parameters = new ActionParameters(detailController.ObjectName, detailController.ObjectId, ViewShowType.Show);
            EventAggregationManager.SendMessage(message);
        }
    }
}
