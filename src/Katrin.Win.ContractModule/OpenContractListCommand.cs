using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.Win.ContractModule.Detail;

namespace Katrin.Win.ContractModule
{
    public class OpenContractListCommand : AbstractCommand
    {
        public override void Run()
        {
            var message = new ShowScreenMessage("/Contract/List", "Contract");
            EventAggregationManager.SendMessage(message);
        }
    }
}
