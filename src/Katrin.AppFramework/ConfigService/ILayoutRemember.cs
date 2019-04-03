using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.ConfigService
{
    /// <summary>
    /// ILayoutRemember
    /// date:2012-11-7
    /// </summary>
    public interface ILayoutRemember
    {
        void SaveLayout();
        void RestoreLayout();
        void SaveDefaultLayout();
        void RestoreDefaultLayout();
    }
}
