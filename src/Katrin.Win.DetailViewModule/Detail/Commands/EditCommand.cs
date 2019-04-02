using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.ViewInterface;
using Katrin.AppFramework.WinForms.Views;
using ICSharpCode.Core;

namespace Katrin.Win.DetailViewModule.Commands
{
    public class EditCommand : ObjectAwareCommand
    {
        public override void Run()
        {
            if (!(this.Owner is IObjectDetailController)) return;
            IObjectDetailController detailPresenter = (IObjectDetailController)this.Owner;
            detailPresenter.WorkingMode = EntityDetailWorkingMode.Edit;
            detailPresenter.SetEditorStatus();
            SendMessage(null);
        }
    }
}
