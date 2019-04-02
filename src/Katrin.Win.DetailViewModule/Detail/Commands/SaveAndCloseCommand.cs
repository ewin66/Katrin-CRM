using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.ViewInterface;
using Katrin.AppFramework.WinForms.Views;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework;

namespace Katrin.Win.DetailViewModule.Commands
{
    public class SaveAndCloseCommand : ObjectAwareCommand
    {
        public override void Run()
        {
            if (!(this.Owner is IObjectDetailController)) return;
            IObjectDetailController detailPresenter = (IObjectDetailController)this.Owner;
            if (!detailPresenter.SaveAndClose()) return;
         

            //notify listview focus added row
            ObjectAddedMessage msg = new ObjectAddedMessage();
            msg.ObjectID = detailPresenter.ObjectId;
            msg.ObjectName = detailPresenter.ObjectName;
            EventAggregationManager.SendMessage<ObjectAddedMessage>(msg);

            //notify related Module to Refresh.
            NotifyRelatedMessage relatedMsg = new NotifyRelatedMessage();
            relatedMsg.ObjectName = detailPresenter.ObjectName;
            EventAggregationManager.SendMessage<NotifyRelatedMessage>(relatedMsg);
        }
    }
}
