using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.Messages;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Workspaces;

namespace Katrin.Win.ProjectIterationModule.Commands
{
    public class AddModuleCommand : BaseCommand
    {
        public override void Run()
        {
            objectName = "ProjectModule";
            workMode = EntityDetailWorkingMode.Add;
            base.Run();
        }
    }
}
