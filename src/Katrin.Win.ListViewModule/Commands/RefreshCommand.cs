using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.Views;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.ListViewModule.Commands
{
    public class RefreshCommand : AbstractCommand
    {
        public override void Run()
        {
            Guard.ObjectIsInstanceOfType(Owner, typeof(ListController), "Owner");
            var controller = (ListController)this.Owner;
            controller.Refresh();
        }
    }
}
