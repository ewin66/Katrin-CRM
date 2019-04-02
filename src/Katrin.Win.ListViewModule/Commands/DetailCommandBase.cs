using Katrin.AppFramework;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.Views;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katrin.AppFramework.WinForms.Controller;

namespace Katrin.Win.ListViewModule.Commands
{
    public class DetailCommandBase : AbstractCommand
    {
        protected EntityDetailWorkingMode _workMode;

        public override void Run()
        {
            Guard.ObjectIsInstanceOfType(Owner, typeof(ListController), "Owner");
            var listController = (ListController)Owner;
            listController.ShowDetailView(_workMode);
        }
    }
}
