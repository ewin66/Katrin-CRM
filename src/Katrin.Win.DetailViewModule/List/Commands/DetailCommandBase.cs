using Katrin.AppFramework;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.Views;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Workspaces;

namespace Katrin.Win.ListViewModule.Commands
{
    public class DetailCommandBase : AbstractCommand
    {
        protected EntityDetailWorkingMode _workMode;

        public override void Run()
        {
            Guard.ObjectIsInstanceOfType(Owner, typeof(ISelection), "Owner");
            Guard.ObjectIsInstanceOfType(Owner, typeof(IObjectAware), "Owner");
            var selection = (ISelection)Owner;
            var objectAware = (IObjectAware)Owner;

            IObjectSpace objectSpace = new ODataObjectSpace();
            Guid selectedId = Guid.Empty;
            if (_workMode != EntityDetailWorkingMode.Add)
            {
                selectedId = objectSpace.GetObjectId(objectAware.ObjectName, selection.SelectedObject);
            }
            var parameters = new ActionParameters(objectAware.ObjectName, selectedId, ViewShowType.Show){
                    {"WorkingMode",_workMode}
                };
            var controllerName = objectAware.ObjectName;
            App.Instance.Invoke(controllerName, "Detail", parameters);
        }
    }
}
