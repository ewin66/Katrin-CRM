using System;
using System.Collections.Generic;
using System.Linq;

namespace Katrin.Win.MainModule.Views.Role
{
    public class RoleViewModel
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public List<EntityViewModel> SelectedEntities { get; private set; }
        public IEnumerable<PrivilegeViewModel> SelectedPrivileges
        {
            get
            {
                return SelectedEntities.SelectMany(e => e.Privileges.Where(p => p.Selected));
            }
        }

        public RoleViewModel()
        {
            SelectedEntities = new List<EntityViewModel>();
        }
    }
}
