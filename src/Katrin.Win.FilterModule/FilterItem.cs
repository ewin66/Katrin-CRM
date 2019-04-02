using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.FilterModule
{
    [Serializable]
    public class FilterItem
    {
        public string DisplayName { get; set; }
        public string FileName { get; set; }
        public string FilterString { get; set; }
        public bool Editable { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
