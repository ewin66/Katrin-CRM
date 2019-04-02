using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.Core;

namespace Katrin.Win.NotificationModule.Commands
{
    public class SetReaded : AbstractCommand
    {
        public override void Run()
        {
            if (!(this.Owner is NotificationRecipientController)) return;
            var notificationController = this.Owner as NotificationRecipientController;
            notificationController.SetReaded(false);
        }
    }
}
