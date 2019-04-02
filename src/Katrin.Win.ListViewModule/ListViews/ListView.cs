using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using DevExpress.XtraGrid.Views.Base;
using Katrin.AppFramework.WinForms;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.Context;
using Katrin.AppFramework.WinForms.Grid;
using Katrin.AppFramework.WinForms.Views;
using DevExpress.XtraBars.Docking;

namespace Katrin.Win.ListViewModule.ListViews
{
    public partial class ListView : Katrin.AppFramework.WinForms.Views.BaseView, IObjectListView
    {
        IActionContext actionContext = new ActionContext(); 
        public ListView()
        {
            InitializeComponent();
        }

        private void LeadListForm_Load(object sender, EventArgs e)
        {
            bindingSource1.PositionChanged += bindingSource1_PositionChanged;
            gridView1.ColumnFilterChanged += bindingSource1_PositionChanged;
            gridView1.RowCountChanged += bindingSource1_PositionChanged;

            var layout = PropertyService.Get("Document.Layout");
            //if (!string.IsNullOrEmpty(layout))
            //{
            //    System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //    System.IO.StreamWriter writer = new System.IO.StreamWriter(ms);
            //    writer.AutoFlush = true;
            //    writer.Write(layout);
            //    ms.Position = 0;
            //    dockManager1.RestoreLayoutFromStream(ms);
            //}
            //else
            //{
                //DockPanelManager.CreatePanels(dockManager1, this, "/Workspace/DockPanels/"+ObjectName);
            //}

        }

        public void BindListData(object listData)
        {
            gridControl1.BeginUpdate();
            gridView1.InitWithDefaultLayout(ObjectName);
            bindingSource1.DataSource = listData;
            gridControl1.EndUpdate();
        }

        void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            var message = new ItemMessage("", "", ObjectName, false);
            EventAggregationManager.SendMessage(message);
        }

        public ColumnView ObjectGridView
        {
            get { return gridView1; }
        }

        public object SelectedObject
        {
            get
            {
                return gridView1.GetFocusedRow();
            }
        }

        public string ObjectName
        {
            get;
            set;
        }
    }
}
