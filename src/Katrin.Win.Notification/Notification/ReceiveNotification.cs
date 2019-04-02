using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Services.Client;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.AppFramework;
using Katrin.AppFramework.Security;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.Grid;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.WinForms.Workspaces;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System.Linq.Dynamic;
using ICSharpCode.Core;

namespace Katrin.Win.Common.Notification
{

    public class ReceiveNotification : IReceiveNotification
    {
        private delegate void ShowNotificationDelegate(IList notificationInfos, RibbonForm form);
        private static RibbonForm _ribbonForm;
        public  void StartReceiveNotification(RibbonForm ribbonForm)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 18000;
            timer.Elapsed += timer_Elapsed;
            _ribbonForm = ribbonForm;
            timer.Enabled = true;
            timer_Elapsed(null, null);
            timer.Start();
            
        }


        static void ReduceMemory()
        {
            try
            {
                Process A = Process.GetCurrentProcess();
                A.MaxWorkingSet = Process.GetCurrentProcess().MaxWorkingSet;
                A.Dispose();
            }
            catch
            {

            }
        }

        static  List<NotificationDTO> GetListData(IObjectSpace objectSpace)
        {
            List<NotificationDTO> notificationList = new List<NotificationDTO>();
            var query = (DataServiceQuery<Katrin.Domain.Impl.NotificationRecipient>)objectSpace.GetObjectQuery("NotificationRecipient");
            var result = query.Where(n => n.RecipientId == AuthorizationManager.CurrentUserId);
            var recipients = result.ToList();

            var notificationQuery = (DataServiceQuery<Katrin.Domain.Impl.Notification>)objectSpace.GetObjectQuery("Notification");
            notificationQuery = notificationQuery.Expand("CreatedBy");
            var notificationResult = notificationQuery.Where(n => n.NotificationRecipients.Any(r => r.RecipientId == AuthorizationManager.CurrentUserId)).ToList();

            foreach (var item in notificationResult)
            {
                NotificationDTO dto = new NotificationDTO();
                dto.Body = item.Body;
                dto.CreatedBy_p_FullName = item.CreatedBy.FullName;
                dto.NotificationId = item.NotificationId;
                var recipient = recipients.First(c => c.NotificationId == item.NotificationId);
                dto.NotificationRecipientId = recipient.NotificationRecipientId;
                dto.NotificationStatusName = recipient.NotificationStatus;
                dto.NotificationStatus = recipient.NotificationStatus != "Readed" ? 1 : 0;
                string objectType = item.ObjectType;
                
                if (objectType.Contains("-"))
                {
                    string[] arrType = objectType.Split(new char[] { '-' });
                    dto.ObjectTypeEn = arrType[1];
                    objectType = ResourceService.GetString(arrType[1]);
                }
                else
                {
                    dto.ObjectTypeEn = objectType;
                    objectType = ResourceService.GetString(objectType);
                }
                dto.ObjectType = objectType;
                dto.RecipientId = recipient.RecipientId??Guid.Empty;
                dto.Subject = item.Subject;
                dto.NotificationUrl = item.NotificationUrl;
                dto.CreatedOn = item.CreatedOn;
                notificationList.Add(dto);
            }
            return notificationList;
        }

        public static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //ReduceMemory();
            IObjectSpace objectSpace = new ODataObjectSpace();
            AuthorizationManager.NotificationList.DataSource = GetListData(objectSpace);
            var notificationInfos = ((List<NotificationDTO>)AuthorizationManager.NotificationList.List).Where(c => c.NotificationStatusName == "NotSend").ToList(); //objectSpace.GetObjects("NotificationRecipient", filter, additionProperties);
            if (notificationInfos.Count <= 0) return;
            RibbonForm form = _ribbonForm;
            if (form == null) return;
            ShowNotificationDelegate s = new ShowNotificationDelegate(ShowNotifications);
            form.BeginInvoke(s, notificationInfos, form);
        }

        private static void DelButtonClick(object sender, AlertButtonClickEventArgs e)
        {
            var notifcation = e.AlertForm.AlertInfo.Tag as NotificationDTO;
            if (notifcation == null) return;
            if (notifcation.NotificationRecipientId == Guid.Empty) return;
            IObjectSpace objectSpace = new ODataObjectSpace();
            if (e.ButtonName == "DelNotification")
            {
                e.Button.Name = "Deleted";
                var recipent = objectSpace.GetOrNew("NotificationRecipient", notifcation.NotificationRecipientId, null);
                objectSpace.DeleteObject("NotificationRecipient", recipent);
                objectSpace.SaveChanges();
                notifcation.NotificationRecipientId = Guid.Empty;
                timer_Elapsed(null, null);
            }
            else if (e.ButtonName == "MarkReaded")
            {
                e.Button.Name = "Marked";
                MarkReaded(objectSpace, notifcation);
                e.Button.Image = new Bitmap(WinFormsResourceService.GetBitmap("sendsysmsg"), new Size(16, 16));
                timer_Elapsed(null, null);
            }
            
        }

        private static void MarkReaded(IObjectSpace objectSpace,NotificationDTO data)
        {
            var notificationUser = (Katrin.Domain.Impl.NotificationRecipient)objectSpace.GetOrNew("NotificationRecipient", data.NotificationRecipientId, null);
            notificationUser.NotificationStatus = "Readed";
            notificationUser.ReadedOn = DateTime.Now;
            objectSpace.SaveChanges();
        }

        private static void ShowNotifications(IList notificationInfos, RibbonForm form)
        {
            IObjectSpace objectSpace = new ODataObjectSpace();
            AlertControl alertControl = new AlertControl();
            alertControl.AutoHeight = true;
            AlertButton setReaded = new AlertButton(new Bitmap(WinFormsResourceService.GetBitmap("notification"), new Size(16, 16)));
            setReaded.Style = AlertButtonStyle.CheckButton;
            setReaded.Down = false;
            setReaded.Hint = "Mark Readed";
            setReaded.Name = "MarkReaded";
            alertControl.Buttons.Add(setReaded);
            AlertButton deleteBtn = new AlertButton(new Bitmap(WinFormsResourceService.GetBitmap("overlay_delete"), new Size(16, 16)));
            deleteBtn.Style = AlertButtonStyle.CheckButton;
            deleteBtn.Down = false;
            deleteBtn.Hint = "Delete Notification";
            deleteBtn.Name = "DelNotification";
            alertControl.Buttons.Add(deleteBtn);
            alertControl.ButtonClick += new AlertButtonClickEventHandler(DelButtonClick);
            alertControl.BeforeFormShow += (sender, e) =>
                {
                    e.AlertForm.BackgroundImage = WinFormsResourceService.GetBitmap("nback");
                    e.AlertForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    
                    int l = 1;
                    while (e.AlertForm.AlertInfo.Text.Length > 12 * l)
                    {
                        e.AlertForm.AlertInfo.Text = e.AlertForm.AlertInfo.Text.Insert(12 * l, " ");
                        l++;
                    }
                    e.AlertForm.Size = new System.Drawing.Size(320, 300);
                };
            alertControl.AlertClick += (sender, e) =>
            {
                NotificationDTO data = (NotificationDTO)e.Info.Tag;
                MarkReaded(objectSpace, data);
                e.AlertForm.Tag = data;
                e.AlertForm.Disposed += AlertForm_Disposed;
                e.AlertForm.Close();
            };

            AlertManage manager = new AlertManage(alertControl, form);
            foreach (var notificationInfo in notificationInfos)
            {
                var pro = notificationInfo.GetType().GetProperty("NotificationRecipientId");
                if (pro == null) continue;
                Guid notificationRecipientId = (Guid)pro.GetValue(notificationInfo,null);
                var notificationUser = (Katrin.Domain.Impl.NotificationRecipient)objectSpace.GetOrNew("NotificationRecipient", notificationRecipientId,null);
                notificationUser.NotificationStatus = "Opened";
                manager.ShowAlert((NotificationDTO)notificationInfo);
            }
            objectSpace.SaveChanges();
        }



        static void AlertForm_Disposed(object sender, EventArgs e)
        {
            if (!(sender is AlertFormCore)) return;
            var data = (NotificationDTO)((AlertFormCore)sender).Tag;
            if (!string.IsNullOrEmpty(data.NotificationUrl))
            {
                string[] notificationInfo = data.NotificationUrl.Split(new char[] { '#' });
                ActionParameters parameters = new ActionParameters(notificationInfo[0], Guid.Parse(notificationInfo[1]), ViewShowType.Show)
                    {
                        {"WorkingMode",EntityDetailWorkingMode.View}
                    };
                App.Instance.Invoke(notificationInfo[0], "Detail", parameters);
            }
            else
            {
                ActionParameters parameters = new ActionParameters("Notification", Guid.Empty, ViewShowType.Show);
                App.Instance.Invoke("Notification", "List", parameters);
            }
        }

        
    }
}
