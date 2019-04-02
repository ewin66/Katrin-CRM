using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.ListViewModule.ListViews;
using Katrin.AppFramework.WinForms.Messages;

namespace Katrin.Win.ListViewModule.Commands
{
    public class ViewCommand : DetailCommandBase
    {
        public ViewCommand()
        {
            _workMode = EntityDetailWorkingMode.View;
        }
    }
}
