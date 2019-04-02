using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Katrin.Services.Security
{
    public class CustomServicePrincipal : GenericPrincipal
    {
        private IIdentity _identity;

        public CustomServicePrincipal(IIdentity identity)
            : base(identity, new string[] { })
        {
            _identity = identity;
            UserPermissionSet = GetUserPermissionSet();
        }

        public Permission UserPermissionSet { get; set; }
        private Permission GetUserPermissionSet()
        {
            try
            {
                return Permission.None;
                //var query = from up in _context.UserPermissions
                //            where up.User.UserName == this.Identity.Name
                //            select up.Permission;

                //Permission flags = 0;
                //foreach (var userPermission in query)
                //{
                //    flags |= (Permission)userPermission.ID;
                //}
                //return flags;

            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("could not get permissionset for current user{0}", this.Identity.Name), ex.InnerException);
            }

        }

    }


}
