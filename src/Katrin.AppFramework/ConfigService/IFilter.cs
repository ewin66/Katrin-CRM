using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.ConfigService
{
    /// <summary>
    /// Filter Gallery group interface.
    /// </summary>
    public interface IFilter
    {
          string GetSelectedFilterName();
          void SetItemChecked(string filterName);
    }
}
