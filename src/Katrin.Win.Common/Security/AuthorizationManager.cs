using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Katrin.Win.Common.Security
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
                var principal = (CustomPrincipal)Thread.CurrentPrincipal;
                return principal.Identity.UserId;
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

}
