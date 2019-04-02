using System;
using System.Security.Principal;
using System.Net;
using System.Threading;
using System.Web.ClientServices;

namespace Katrin.Win.Common.Security
{
    public class CustomIdentity : GenericIdentity
    {
        public CookieContainer AuthenticationCookies { get; private set; }
        public CustomIdentity(Guid userId,string name,string fullName):base(name)
        {
            AuthenticationCookies = ((ClientFormsIdentity)Thread.CurrentPrincipal.Identity).AuthenticationCookies;
            UserId = userId;
            FullName = fullName;
        }

        //public CustomIdentity(string userId,string name, string type):base(name,type)
        //{
        //    UserId = userId;
        //}

        public Guid UserId { get; private set; }
        public string FullName { get;private set;}
    }
}
