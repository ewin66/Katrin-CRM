using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.Win.AccountModule.Detail;

namespace Katrin.Win.AccountModule
{
    public class OpenAccountListCommand : AbstractCommand
    {
        public override void Run()
        {
            var message = new ShowScreenMessage("/Account/List", "Account");
            EventAggregationManager.SendMessage(message);
        }
    }
}
