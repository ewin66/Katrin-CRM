using Katrin.AppFramework;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.WinForms.CommandManage;
using Katrin.Win.MainModule.Views.ProjectTask;
using DevExpress.Data.Filtering;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.ProjectTaskModule.Commands
{
    class AddMemberMenuCommand : AbstractCommand
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
            IEnumerable<LookupListItem<Guid?>> members = mainController.GetProjectMembersForMemu(projectId);
           
            foreach (var member in members)
            {
                GiveTaskToMemberCommand action = new GiveTaskToMemberCommand();
                action.Parameter = member.Value.ToString();
                cmdRegister.AddRunTimeCommand(groupName, member.DisplayName, string.Empty, action,member.IsDeafult);
            }

        }        
    }
   

}
