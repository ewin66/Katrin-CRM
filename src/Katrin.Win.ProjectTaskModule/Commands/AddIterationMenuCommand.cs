using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.WinForms.CommandManage;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.MainModule.Views.ProjectTask;

namespace Katrin.Win.ProjectTaskModule.Commands
{
    class AddIterationMenuCommand : AbstractCommand
    {

        public override void Run()
        {
            IRunTimeCommandRigister cmdRegister = this.Owner as IRunTimeCommandRigister;
            ProjectTaskController mainController = cmdRegister.ControllerFinder.FindController<ProjectTaskController>(string.Empty);
            if (mainController.SelectedObject == null) return;

            cmdRegister.ClearOldCommand(this.Parameter);
            string groupName = this.Parameter;

            BaseController baseController = cmdRegister.ControllerFinder.FindController<BaseController>("BaseControllerList");
            Guid? projectId = baseController.GetSelectedProjectId();
            IEnumerable<LookupListItem<Guid?>> iterations = mainController.GetProjectIterationsForMenu(projectId);

           
            foreach (var iteration in iterations)
            {
                MoveTaskToIterationCommand action = new MoveTaskToIterationCommand();
                action.Parameter = iteration.Value.ToString();
                cmdRegister.AddRunTimeCommand(groupName, iteration.DisplayName, string.Empty, action,iteration.IsDeafult);
            }

        }        
    }
}
