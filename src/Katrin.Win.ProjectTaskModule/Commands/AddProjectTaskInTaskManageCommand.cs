using Katrin.AppFramework;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.WinForms.Workspaces;
using Katrin.Win.MainModule.Views.ProjectTask;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.ProjectTaskModule.Commands
{
    class AddProjectTaskInTaskManageCommand : AbstractCommand
    {
        protected EntityDetailWorkingMode _workMode =  EntityDetailWorkingMode.Add;

        public override void Run()
        {
            Guard.ObjectIsInstanceOfType(Owner, typeof(ISelection), "Owner");
            Guard.ObjectIsInstanceOfType(Owner, typeof(IObjectAware), "Owner");
            var selection = (ISelection)Owner;
            var objectAware = (IObjectAware)Owner;
            ObjectController objectController = (ObjectController)this.Owner;
          
            Guid selectedId = Guid.Empty;     
            var parameters = new ActionParameters(objectAware.ObjectName, selectedId, ViewShowType.Show){
                    {"WorkingMode",_workMode}
                };
            var controllerName = objectAware.ObjectName;
            BaseController filterController = 
                objectController.Context.ControllerFinder.FindController<BaseController>("BaseControllerList");
            if (filterController != null)
            {
                Guid? projectId = filterController.GetSelectedFilterProjectId();
                Guid? memberId = filterController.GetSelectedMemberId();
                Guid? iterationId = filterController.GetSelectedIterationId();
                parameters.Add("ProjectId", projectId);
                parameters.Add("MemberId", memberId);
                parameters.Add("IterationId", iterationId);
            }
            App.Instance.Invoke(controllerName, "Detail", parameters);
        }
    }
}
