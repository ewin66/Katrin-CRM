
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.Messages;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraGrid.Views.Base;
using ICSharpCode.Core;
using DevExpress.XtraBars;
using Katrin.AppFramework.WinForms.Controls;

namespace Katrin.AppFramework.WinForms.Views
{
    public enum ListViewType
    {
        GridView,
        LayoutView
    }

    public interface IObjectListView : IObjectView, ISelection
    {
        ListViewType ViewType { get; set; }
        ColumnView ObjectGridView { get; }
        void BindListData(object listData);
        void ClearData();
        ICommand DoubleClickCommand { get; set; }
        PopupMenu PopupMenu { get; set; }
        /// <summary>
        /// Use this method before delete Row.
        /// </summary>
        //void SetNextFocusRowId();
     
    }
}
