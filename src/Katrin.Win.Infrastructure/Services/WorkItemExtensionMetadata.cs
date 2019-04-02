using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.Infrastructure.Services
{
    public class WorkItemExtensionMetadata
    {
        public string Name { get; set; }
        public string Dependency { get; set; }
        public Type ExtensionType { get; set; }
        public Type WorkItemType { get; set; }
    }
}
