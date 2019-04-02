using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework;
using Katrin.AppFramework.Security;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;

namespace Katrin.Win.Common.Notification
{
    public class SysMessageData
    {
        public string Subject { get; set; }
        public string Body { get; set; }
    }
    public class SendSysNotificationController : ObjectController
    {
        private SysMessageData _sysMessageData;
        private ISendSysNotification _sendView;


        public override string ObjectName
        {
            get
            {
                return "Notification";
            }
        }
        public override IActionResult Execute(ActionParameters parameters)
        {
            var objectName = parameters.ObjectName;
            _sendView = ViewFactory.CreateView("DefaultNotificationView") as ISendSysNotification;
            OnViewSet();
            return new ModalViewResult(_sendView);
        }
        public IActionResult NotificationAction(ActionParameters parameters)
        {
            var objectName = parameters.ObjectName;
            _sendView = ViewFactory.CreateView("DefaultNotificationView") as ISendSysNotification;
            OnViewSet();
            return new ModalViewResult(_sendView);
        }

        protected  void OnViewSet()
        {
            _sysMessageData = new SysMessageData();
            _sendView.OnSendSysMessage += View_OnSendSysMessage;
            _sysMessageData.Subject = string.Empty;
            _sysMessageData.Body = string.Empty;
            _sendView.BindData(new List<SysMessageData>() { _sysMessageData });
        }

        void View_OnSendSysMessage(object sender, EventArgs e)
        {
            IObjectSpace  objectSpace = new ODataObjectSpace();
            var notification = (Katrin.Domain.Impl.Notification)objectSpace.GetOrNew("Notification", Guid.Empty, "NotificationRecipients");
            Guid notificationId = notification.NotificationId;
            notification.ObjectType = "sysMsg";
            notification.Subject = _sysMessageData.Subject;
            notification.Body = _sysMessageData.Body;
            var recipients = notification.NotificationRecipients;
            //Type recipientType = DynamicTypeBuilder.Instance.GetDynamicType("NotificationRecipient");
            foreach (Guid receiverId in _sendView.GetReceiverList())
            {
                if (receiverId == AuthorizationManager.CurrentUserId) continue;
                var recipient = new Katrin.Domain.Impl.NotificationRecipient();
                recipient.NotificationRecipientId = Guid.NewGuid();
                recipient.NotificationId = notificationId;
                recipient.RecipientId = receiverId;
                recipient.NotificationStatus = "NotSend";
                recipients.Add(recipient);
            }
            objectSpace.SaveChanges();
            _sendView.CloseView();
        }

        public override object SelectedObject
        {
            get { return null; }
        }
    }
}
