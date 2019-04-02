using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.Views;
using DevExpress.XtraReports.Native;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.ListViewModule.Commands
{
    public class DeleteCommand : AbstractCommand
    {
        public override void Run()
        {
            Guard.ObjectIsInstanceOfType(Owner, typeof(ListController), "Owner");
            var controller = (ListController)this.Owner;
            bool result = controller.Delete();
            if (result)
            {
                NotifyRelatedMessage relatedMsg = new NotifyRelatedMessage();
                relatedMsg.ObjectName = controller.ObjectName;
                
                EventAggregationManager.SendMessage<NotifyRelatedMessage>(relatedMsg);
            }
        }
    }
}
