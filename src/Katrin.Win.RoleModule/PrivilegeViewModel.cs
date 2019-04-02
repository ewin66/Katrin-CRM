using System;

namespace Katrin.Win.RoleModule
{
    public class PrivilegeViewModel
    {
        public Guid PrivilegeId { get; set; }
        public string PrivilegeName { get; set; }
        public bool Selected { get; set; }
    }
}
