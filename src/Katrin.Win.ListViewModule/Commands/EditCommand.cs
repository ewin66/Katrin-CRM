using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.Win.ListViewModule.ListViews;

namespace Katrin.Win.ListViewModule.Commands
{
    public class EditCommand : DetailCommandBase
    {
        public EditCommand()
        {
            _workMode = EntityDetailWorkingMode.Edit;
        }
    }
}
