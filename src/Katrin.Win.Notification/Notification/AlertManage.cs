using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.AppFramework.Security;
using Katrin.AppFramework.WinForms;
using DevExpress.Utils;
using DevExpress.XtraBars.Alerter;

namespace Katrin.Win.Common.Notification
{
   
    public class AlertManage
    {
        AlertControl control;
        Form form;
        public AlertManage(AlertControl control, Form form)
        {
            this.control = control;
            this.form = form;
        }

        public void ShowAlert(NotificationDTO data)
        {
            
            InitButtonsStyle(data);
            control.Show(form, data.Subject, data.Body, null, new Bitmap(WinFormsResourceService.GetBitmap("sendsysmsg"), new Size(48, 48)), data);
        }

        void InitButtonsStyle(NotificationDTO data)
        {

        }
    }
}
