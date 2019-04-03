using Katrin.AppFramework.WinForms.CommandManage;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.ContextMenu
{
    /// <summary>
    /// IBarItemFinder
    /// date:2012-11-7
    /// </summary>
    interface IBarItemFinder
    {
        BarItem GetBarItem(string cmdId);
        List<BarItem> GetDynamicBarItems(string groupId);
        IUICommand GetDynamicContainer(string groupId);
    }
}
