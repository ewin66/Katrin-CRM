using System.Linq;
using System.Security.Principal;

namespace Katrin.Win.Common.Security
{
    public class CustomPrincipal : GenericPrincipal
    {
        private readonly Privilege[] _privileges;

        public CustomPrincipal(CustomIdentity identity, Privilege[] privileges)
            : base(identity, null)
        {
            _privileges = privileges;
        }

        public new CustomIdentity Identity
        {
            get { return (CustomIdentity) base.Identity; }
        }

        public bool CheckAccess(string resource, string permission)
        {
            return _privileges != null && _privileges.Any(p => p.EntityName == resource && p.Name == permission);
        }
    }
}
