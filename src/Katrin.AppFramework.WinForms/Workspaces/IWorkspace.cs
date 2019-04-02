using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraBars.Ribbon;

namespace Katrin.AppFramework.WinForms.Workspaces
{
    public interface IWorkspace
    {
        IEventAggregator EventAggregator { get; }
        void Show(Control view, ViewShowType showType);
        TabbedView TabbedView { get; }
        void RestoreAllViewDefaultLayout();
    }
}
