using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CABDevExpress.Workspaces;
using Katrin.Win.Common.Constants;
using Katrin.Win.Common.Security;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraBars.Ribbon;
using Microsoft.Practices.CompositeUI;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;

namespace Katrin.Win.Common.Notification
{
    public class ReceiveNotification
    {
        private delegate void ShowNotificationDelegate(IList notificationInfos, RibbonForm form);
        private static WorkItem _workItem;
        public static void StartReceiveNotification(WorkItem workItem)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 6000;
            timer.Elapsed += timer_Elapsed;
            _workItem = workItem;
            timer.Enabled = true;
            timer.Start();
        }

        static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            
            DynamicDataServiceContext dbcontext = new DynamicDataServiceContext();
            Dictionary<string, string> additionProperties = new Dictionary<string, string>();
            additionProperties.Add("Notification", "Notification");
            CriteriaOperator filter = new BinaryOperator("RecipientId", AuthorizationManager.CurrentUserId, BinaryOperatorType.Equal)
            & new BinaryOperator("NotificationStatus", "NotSend", BinaryOperatorType.Equal);
            var notificationInfos = dbcontext.GetObjects("NotificationRecipient", filter, additionProperties);
            if (notificationInfos.ToArrayList().Count <= 0) return;
            if (_workItem == null) return;
            WorkItem workItem = _workItem;
            RibbonWindowWorkspace workSpace = workItem.RootWorkItem.Items[WorkspaceNames.RibbonWindows] as RibbonWindowWorkspace;
            if (workSpace == null) return;
            RibbonForm form = workSpace.OwnerForm as RibbonForm;
            if (form == null) return;
            ShowNotificationDelegate s = new ShowNotificationDelegate(ShowNotifications);
            form.BeginInvoke(s, notificationInfos, form);
        }

        private static void ShowNotifications(IList notificationInfos, RibbonForm form)
        {
            DynamicDataServiceContext dbcontext = new DynamicDataServiceContext();
            AlertControl alertControl = new AlertControl();
            alertControl.AutoHeight = true;
            
            alertControl.AlertClick += (sender, e) =>
            {
                NotificationData data = (NotificationData)e.Info.Tag;
                var notificationUser = dbcontext.GetOrNew("NotificationRecipient", data.NotificationRecipientId);
                notificationUser.AsDyanmic().NotificationStatus = "Readed";
                notificationUser.AsDyanmic().ReadedOn = DateTime.Now;
                dbcontext.SaveChanges();
                e.AlertForm.Hide();
            };

            AlertManage manager = new AlertManage(alertControl, form);
            foreach (var notificationInfo in notificationInfos)
            {
                var notificationUser = dbcontext.GetOrNew("NotificationRecipient", notificationInfo.AsDyanmic().NotificationRecipientId);
                notificationUser.NotificationStatus = "Opened";
                manager.ShowAlert(notificationInfo);
            }
            dbcontext.SaveChanges();
        }

        
    }
}
