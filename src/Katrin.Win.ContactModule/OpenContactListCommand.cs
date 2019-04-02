using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.Win.ContactModule.Detail;

namespace Katrin.Win.ContactModule
{
    public class OpenContactListCommand : AbstractCommand
    {
        public override void Run()
        {
            var message = new ShowScreenMessage("/Contact/List", "Contact");
            EventAggregationManager.SendMessage(message);
        }
    }
}
