using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Messages;


namespace Katrin.Win.InvoiceModule
{
    public class OpenInvoiceListCommand : AbstractCommand
    {
        public override void Run()
        {
            var message = new ShowScreenMessage("/Invoice/List", "Invoice");
            EventAggregationManager.SendMessage(message);
        }
    }
}
