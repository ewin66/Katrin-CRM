using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Views
{
    public interface IObjectAware
    {
        string ObjectName { get; set; }
        string ControllerId { get; set; }
    }
}
