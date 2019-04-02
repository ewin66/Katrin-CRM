using Katrin.AppFramework;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Workspaces;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.NoteModule.Commands
{
   public class DeleteNoteCommand : AbstractCommand
    {
        public override void Run()
        {
            if (!(Owner is NoteController)) return;

            NoteController controller = this.Owner as NoteController;
            bool result = controller.Delete();
            if (result)
            {
                ObjectSetChangedMessage message = new ObjectSetChangedMessage();
                message.ObjectName = controller.ObjectName;
                message.ParentObjectName = controller.ParentObjectName;
                EventAggregationManager.SendMessage(message);
            }
         
        }
    }
}
