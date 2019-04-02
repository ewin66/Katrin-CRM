using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.Win.ProductModule.Detail;

namespace Katrin.Win.ProductModule
{
    public class OpenProductListCommand : AbstractCommand
    {
        public override void Run()
        {
            var message = new ShowScreenMessage("/Product/List", "Product");
            EventAggregationManager.SendMessage(message);
        }
    }
}
