using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.SaleReportModule
{
    public class OpenSaleReportCommand : AbstractCommand
    {
        public override void Run()
        {
            var message = new ShowScreenMessage("/SaleReport/List", "SaleReport");
            EventAggregationManager.SendMessage(message);
        }
    }
}
