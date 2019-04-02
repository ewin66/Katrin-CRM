using System;
using System.Collections.Generic;

namespace Katrin.Win.MainModule.Views.Role
{
    public class EntityViewModel
    {
        public Guid EntityId { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public List<PrivilegeViewModel> Privileges { get; set; }
        public EntityViewModel()
        {
            Privileges = new List<PrivilegeViewModel>();
        }
    }
}
