using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Controller;
using ICSharpCode.Core;

namespace Katrin.Win.ListViewModule.Commands
{
    public class ImportCommand : AbstractCommand
    {
        public override void Run()
        {
            Guard.ObjectIsInstanceOfType(Owner, typeof(ListController), "Owner");
            var controller = (ListController)this.Owner;
            controller.ImportData();
        }
    }
}
