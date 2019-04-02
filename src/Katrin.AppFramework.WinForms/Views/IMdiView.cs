using Katrin.AppFramework.WinForms.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Katrin.AppFramework.WinForms.Views
{
    public interface IMdiView : IView
    {
        string Name { get; set; }
        Form MdiParent { get; set; }
    }
}
