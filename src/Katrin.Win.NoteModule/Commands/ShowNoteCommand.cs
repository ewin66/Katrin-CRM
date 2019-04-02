using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Views;
using DevExpress.XtraBars.Docking;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.MVC;

namespace Katrin.Win.NoteModule.Commands
{
    public class ShowNoteCommand : AbstractCommand
    {
        public override void Run()
        {
            if (this.Owner is IController)
            {
                IController controller = this.Owner as IController;
                Guard.ObjectIsInstanceOfType(Owner, typeof(IObjectAware), "Owner");
                var objectAware = (IObjectAware)this.Owner;
                EventAggregationManager.SendMessage(new ToggleVisibilityMessage(objectAware.ObjectName, "NoteList",controller.WorkSpaceID));
            }
            else
            {
                throw new Exception("Note owner is not IController");
            }
        }
    }
}
