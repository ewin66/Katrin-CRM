using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Katrin.AppFramework.Security
{
    public class AuthorizationManager
    {
        public static bool CheckAccess(string entityName, string action)
        {
            var principal = (CustomPrincipal) Thread.CurrentPrincipal;
            if (principal == null) return false;
            else return principal.CheckAccess(entityName, action);
        }

        public static Guid CurrentUserId
        {
            get
            {
                if (Thread.CurrentPrincipal is CustomPrincipal)
                {
                    var principal = (CustomPrincipal)Thread.CurrentPrincipal;
                    return principal.Identity.UserId;
                }
                else
                {
                    return Guid.Empty;
                }
            }
        }

        private static BindingSource _notificationList;
       
        public static BindingSource NotificationList
        {
            get
            {
                if (_notificationList == null)
                {
                    _notificationList = new BindingSource();
                    NotificationDTO nc = new NotificationDTO();
                    _notificationList.DataSource = new List<NotificationDTO>() { nc };
                }
                return _notificationList;
            }
        }
        
        public static string FullName
        {
            get
            {
                var principal = (CustomPrincipal)Thread.CurrentPrincipal;
                if (principal == null) return "";
                else return principal.Identity.FullName;
            }
        }
    }


    public class NotificationDTO
    {
        public Guid NotificationRecipientId { get; set; }
        public Guid NotificationId { get; set; }
        public Guid RecipientId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string NotificationStatusName { get; set; }
        public int NotificationStatus { get; set; }
        public string ObjectType { get; set; }
        public string ObjectTypeEn { get; set; }
        public string NotificationUrl { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string CreatedBy_p_FullName { get; set; }
    }
}
