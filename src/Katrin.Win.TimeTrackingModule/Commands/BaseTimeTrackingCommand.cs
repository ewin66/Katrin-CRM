using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.Workspaces;

namespace Katrin.Win.TimeTrackingModule.Commands
{
    public class BaseTimeTrackingCommand : AbstractCommand
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
            App.Instance.Invoke("TimeTrackingDetail", "TimeTrackingAction", parameters);
        }
    }
}
