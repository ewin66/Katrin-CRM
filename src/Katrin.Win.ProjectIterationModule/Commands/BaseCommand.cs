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

namespace Katrin.Win.ProjectIterationModule.Commands
{
    public class BaseCommand : AbstractCommand
    {
        protected string objectName = string.Empty;
        protected EntityDetailWorkingMode workMode = EntityDetailWorkingMode.Add;
        public override void Run()
        {
            if (!(this.Owner is ObjectController)) return;
            ObjectController objectController = (ObjectController)this.Owner;
            IObjectSpace objectSpace = new ODataObjectSpace();
            var selectedId = objectSpace.GetObjectId(objectController.ObjectName, objectController.SelectedObject);
            var parameters = new ActionParameters(objectName, Guid.Empty, ViewShowType.Show){
                    {"ProjectId",selectedId},
                    {"WorkingMode",workMode}
                };
            if (string.IsNullOrEmpty(objectName))
            {
                objectName = objectController.ObjectName;
                parameters = new ActionParameters(objectName, selectedId, ViewShowType.Show){
                    {"WorkingMode",workMode}
                };
            }
            App.Instance.Invoke(objectName, "Detail", parameters);
        }
    }
}
