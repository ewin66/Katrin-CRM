using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.Common.Core
{
    public class ListFilterItem
    {
        public string FilterName { get; set; }
        public string Name { get; set; }
        public string FilterString { get; set; }
        public bool IsSystemView { get; set; }
        public int Order { get; set; }
    }
}
