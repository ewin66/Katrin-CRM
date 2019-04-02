using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.Win.UserModule.Detail;

namespace Katrin.Win.UserModule
{
    public class OpenUserListCommand : AbstractCommand
    {
        public override void Run()
        {
            var message = new ShowScreenMessage("/User/List", "User");
            EventAggregationManager.SendMessage(message);
        }
    }
}
