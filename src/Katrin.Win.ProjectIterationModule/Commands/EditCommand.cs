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
using Katrin.AppFramework.WinForms.Workspaces;
using Katrin.AppFramework.WinForms;

namespace Katrin.Win.ProjectIterationModule.Commands
{
    public class EditCommand : BaseCommand
    {
        public override void Run()
        {
            objectName = string.Empty;
            workMode = EntityDetailWorkingMode.Edit;
            base.Run();
        }
    }
}
