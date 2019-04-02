using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars.Alerter;

namespace Katrin.Win.Common.Notification
{
    public class NotificationData
    {
        object _notificationInfo;
        public NotificationData(object notificationInfo)
        {
            this._notificationInfo = notificationInfo;
        }
        public Guid NotificationRecipientId { get { return _notificationInfo.AsDyanmic().NotificationRecipientId; } }
        public string Subject { get { return string.Format("{0}", _notificationInfo.AsDyanmic().Notification.Subject); } }
        public string Content { get { return string.Format("{0}", _notificationInfo.AsDyanmic().Notification.Body); } } 
    }

    public class AlertManage
    {
        AlertControl control;
        Form form;
        ImageCollection images32;
        public AlertManage(AlertControl control, Form form)
        {
            this.control = control;
            this.form = form;
        }

        ImageCollection Images32 {
            get {
                if(images32 == null)
                    images32 = DevExpress.Utils.Controls.ImageHelper.CreateImageCollectionFromResources("Katrin.Win.Common.Resources.notification.png", typeof(AlertManage).Assembly, new Size(32, 32));
                return images32;
            }
        }

        Image GetMailImage(NotificationData data)
        {
            return Images32.Images[0];
        }


        public void ShowAlert(object notificationInfo)
        {
            NotificationData data = new NotificationData(notificationInfo);
            InitButtonsStyle(data);
            control.Show(form, data.Subject, data.Content, null, GetMailImage(data), data);
        }

        void InitButtonsStyle(NotificationData data)
        {

        }
    }
}
