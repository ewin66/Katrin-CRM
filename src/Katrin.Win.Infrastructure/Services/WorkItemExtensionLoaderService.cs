using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.CompositeUI.Services;

namespace Katrin.Win.Infrastructure.Services
{
    public class WorkItemExtensionLoaderService
    {
        public string[] GetLoadOrder(List<WorkItemExtensionMetadata> extensions)
        {
            var solver = new ModuleDependencySolver();
            foreach (var extension in extensions)
            {
                solver.AddModule(extension.Name);
                if (!string.IsNullOrEmpty(extension.Dependency))
                    solver.AddDependency(extension.Name, extension.Dependency);
            }

            return solver.Solve();
        }
    }
}
