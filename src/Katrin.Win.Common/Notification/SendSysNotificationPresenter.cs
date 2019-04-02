using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Security;
using Katrin.Win.Infrastructure;
using Katrin.Win.Common;
using Katrin.Win.Common.Core;

namespace Katrin.Win.Common.Notification
{
    public class SysMessageData
    {
        public string Subject { get; set; }
        public string Body { get; set; }
    }
    public class SendSysNotificationPresenter : Presenter<ISendSysNotification>
    {
        private SysMessageData _sysMessageData;
        protected override void OnViewSet()
        {
            base.OnViewSet();
            _sysMessageData = new SysMessageData();
            View.OnSendSysMessage += View_OnSendSysMessage;
            _sysMessageData.Subject = string.Empty;
            _sysMessageData.Body = string.Empty;
            View.BindData(new List<SysMessageData>() { _sysMessageData });
        }

        void View_OnSendSysMessage(object sender, EventArgs e)
        {
            DynamicDataServiceContext context = new DynamicDataServiceContext();
            var notification = context.GetOrNew("Notification", Guid.Empty, "NotificationRecipients");
            var notificationDyanmic = notification.AsDyanmic();
            Guid notificationId = notificationDyanmic.NotificationId;
            notificationDyanmic.ObjectType = "sysMsg";
            notificationDyanmic.Subject = _sysMessageData.Subject;
            notificationDyanmic.Body = _sysMessageData.Body;
            IList recipients = notificationDyanmic.NotificationRecipients as IList;
            Type recipientType = DynamicTypeBuilder.Instance.GetDynamicType("NotificationRecipient");
            foreach (Guid receiverId in View.GetReceiverList())
            {
                if (receiverId == AuthorizationManager.CurrentUserId) continue;
                var recipient = Activator.CreateInstance(recipientType);
                var recipientDynamic = recipient.AsDyanmic();
                recipientDynamic.NotificationRecipientId = Guid.NewGuid();
                recipientDynamic.NotificationId = notificationId;
                recipientDynamic.RecipientId = receiverId;
                recipientDynamic.NotificationStatus = "NotSend";
                recipients.Add(recipient);
            }
            context.SaveChanges();
            View.CloseView();
        }
    }
}
