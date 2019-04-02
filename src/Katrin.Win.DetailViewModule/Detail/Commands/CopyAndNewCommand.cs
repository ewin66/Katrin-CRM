using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.ViewInterface;
using Katrin.AppFramework.WinForms.Views;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework;

namespace Katrin.Win.DetailViewModule.Commands
{
    public class CopyAndNewCommand : ObjectAwareCommand
    {
        public override void Run()
        {
            if (!(this.Owner is IObjectDetailController)) return;
            IObjectDetailController detailController = (IObjectDetailController)this.Owner;
            if (!detailController.CopyAndNew()) return;

            SendMessage("CopyAndNew");
        }
    }
}
