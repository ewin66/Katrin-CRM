using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Workspaces;
using Katrin.AppFramework.WinForms.Messages;

namespace Katrin.Win.NoteModule.Commands
{
    public class BaseNoteCommand : AbstractCommand
    {
        public override void Run()
        {
            if (!(Owner is ObjectController)) return;
            ObjectController objectController = (ObjectController)Owner;
            string objectName = objectController.ObjectName;
            Guid selectedId = Guid.Empty;
            IObjectSpace objectSpace = new ODataObjectSpace();
            selectedId = objectSpace.GetObjectId(objectName, objectController.SelectedObject);
            var parameters = new ActionParameters(objectName, selectedId, ViewShowType.Show);
            if (Owner is NoteController)
            {
                parameters.Add("ParentObjectName", ((NoteController)Owner).ParentObjectName);
            }
            App.Instance.Invoke("NoteDetail", "NoteAction", parameters);
        }
    }
}
