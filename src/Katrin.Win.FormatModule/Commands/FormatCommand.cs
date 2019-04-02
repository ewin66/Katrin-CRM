using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Workspaces;

namespace Katrin.Win.FormatModule.Commands
{
    public class FormatCommand : AbstractCommand
    {
        public override void Run()
        {
            if (!(this.Owner is ListController)) return;
            ListController listControl = (ListController)this.Owner;
            var parameters = new ActionParameters(listControl.ObjectName, Guid.Empty, ViewShowType.Show){
                    {"GridView",listControl.ObjectGridView}
                };
            App.Instance.Invoke("Format", null, parameters);
        }
    }
}
