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
using System.Linq.Dynamic;
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
using DevExpress.XtraGrid.Views.Layout;
using Katrin.AppFramework.ConfigService;
using DevExpress.XtraGrid.Views.Grid;
using Katrin.AppFramework.WinForms.Controls;

namespace Katrin.Win.ListViewModule.ListViews
{
    public partial class ListView : Katrin.AppFramework.WinForms.Views.BaseView, IObjectListView, ILayoutRemember,IListener<ObjectAddedMessage>
    {
        private IConfigService _config = new ConfigService();
        IActionContext actionContext = new ActionContext();
        private ColumnView _gridView;
        private Guid _selectedID = Guid.Empty;
        private BindingSource _comingDataSource;
        
        public new ListViewType ViewType
        {
            get;
            set;
        }
        public DevExpress.XtraBars.PopupMenu PopupMenu
        {
            get;
            set;
        }
        public ListView()
        {
            InitializeComponent();
            EventAggregationManager.AddListener(this);
        }

        private void LeadListForm_Load(object sender, EventArgs e)
        {

            ObjectGridView.InitWithDefaultLayout(ObjectName);
            RegisterEventHandlers();
            
            
            //apply formats.
            if (this.ObjectGridView is GridView)
            {
                FormatRequestMessage msg = new FormatRequestMessage();
                msg.ObjectName = this.ObjectName;
                msg.GridView = this.ObjectGridView;
                EventAggregationManager.SendMessage<FormatRequestMessage>(msg);
            }

        }

        protected override void Dispose(bool disposing)
        {
            this.UnRegisterEventHandlers();
            ODataListSource source = this.bindingSource1.DataSource as ODataListSource;
            if (source != null)
            {
                source.Clear();
                source.Dispose();
                source = null;
            }
            if (this._comingDataSource != null)
            {
                this._comingDataSource.Clear();
                this._comingDataSource.Dispose();
                this._comingDataSource = null;
            }
            
            this.bindingSource1.DataSource = null;
            if (source != null)
            {
                source.Clear();
                source.Dispose();
            }

            if (disposing)
            {
                EventAggregationManager.RemoveListener(this);
                if (components != null)
                {
                    components.Dispose();
                }
            }
            if (this.gridControl1 != null)
            {
                this.gridControl1.DataSource = null;              
                this.gridView1 = null;
                this.gridControl1.Dispose();
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (this.DoubleClickCommand != null)
            {
                this.DoubleClickCommand = null;
            }
            base.Dispose(disposing);
            GC.Collect();
        }

       

        private void RegisterEventHandlers()
        {
            this.ObjectGridView.DataSourceChanged += ObjectGridView_DataSourceChanged;
            bindingSource1.PositionChanged += bindingSource1_PositionChanged;
            ObjectGridView.ColumnFilterChanged += bindingSource1_PositionChanged;
            ObjectGridView.RowCountChanged += bindingSource1_PositionChanged;
            this.ObjectGridView.DoubleClick += EntityGridViewDoubleClick;
            this.ObjectGridView.MouseDown += _gridView_MouseDown;
        }

        private void UnRegisterEventHandlers()
        {
            bindingSource1.PositionChanged -= bindingSource1_PositionChanged;
            ObjectGridView.ColumnFilterChanged -= bindingSource1_PositionChanged;
            ObjectGridView.RowCountChanged -= bindingSource1_PositionChanged;
            this.ObjectGridView.DataSourceChanged -= ObjectGridView_DataSourceChanged;
            this.ObjectGridView.DoubleClick -= EntityGridViewDoubleClick;
            this.ObjectGridView.MouseDown -= _gridView_MouseDown;
        }      

        private int GetDataSourceIndex(IList datas,Guid oldguid)
        {
            IObjectSpace objectSpace = new ODataObjectSpace();

            int index = 0;
            foreach (object obj in datas)
            {
                Guid guid = objectSpace.GetObjectId(this.ObjectName, obj);
                if (guid == oldguid)
                {
                    return index;
                }
                index++;
            }

            return -1;
        }

        

        private void SelectOldRow(Guid oldguid)
        {
            if (this.ObjectGridView.DataSource != null)
            {
                if (bindingSource1.DataSource == null) return;
                object source = this.bindingSource1.DataSource;
                if (source == null) return;
                IList dataList = source as IList;
                if (dataList == null) return;
                int dataRowIndex = this.GetDataSourceIndex(dataList, oldguid);
                if (dataRowIndex >= 0)
                {
                    if (this.ObjectGridView is GridView)
                    {
                        GridView gv = this.ObjectGridView as GridView;
                        int rowIndex = gv.GetRowHandle(dataRowIndex);
                        this.ObjectGridView.FocusedRowHandle = 0;
                        gv.MoveBy(rowIndex);
                        gv.MakeRowVisible(rowIndex);
                    }
                }
            }
        }
        //dataRefresh
        void ObjectGridView_DataSourceChanged(object sender, EventArgs e)
        {
            if (this._selectedID != Guid.Empty)
            {
                this.SelectOldRow(this._selectedID);
                this._selectedID = Guid.Empty;
            }
        }
        public void BindListData(object listData)
        {
            if(this.Context != null)this.Context.BeginProcess();
            if (this._comingDataSource != null)
            {
                this._comingDataSource.Clear();
                this._comingDataSource.DataSourceChanged -= _comingDataSource_DataSourceChanged;
                this._comingDataSource.Dispose();
            }
       
            this._comingDataSource = listData as BindingSource;
            if (this._comingDataSource != null)
            {
                this._comingDataSource.DataSourceChanged += _comingDataSource_DataSourceChanged;
            }
            else
            {
                throw new Exception("Unknown data source");
            }          
           
        }

        void _comingDataSource_DataSourceChanged(object sender, EventArgs e)
        {
            gridControl1.BeginUpdate();

            bindingSource1.DataSource = this._comingDataSource.DataSource;

            gridControl1.EndUpdate();
            if (this.Context != null)this.Context.EndProcess();
        }

        void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            
            var selectedObjectChanged = new SelectedObjectChangedMessage();
            selectedObjectChanged.ObjectName = this.ObjectName;
            selectedObjectChanged.WorkSpaceID = this.WorkSpaceID;
            
            selectedObjectChanged.SelectedObject = ObjectGridView.GetFocusedRow();
            
            EventAggregationManager.SendMessage(selectedObjectChanged);
            System.Diagnostics.Debug.WriteLine(this.ObjectName + " Refreshed");

            var message = new UpdateRibbonItemMessage(this.WorkSpaceID, this.ObjectName);
            EventAggregationManager.SendMessage(message);
        }

        public ColumnView ObjectGridView
        {
            get 
            {
                if (_gridView == null)
                {
                    if (ViewType == ListViewType.LayoutView)
                    {
                        _gridView = new LayoutView();
                        if (_gridView.GridControl == null)
                        {
                            gridControl1.MainView = _gridView;
                            gridControl1.ViewCollection.Add(_gridView);
                            gridControl1.DataSource = bindingSource1;
                            _gridView.GridControl = gridControl1;
                          
                        }
                    }
                    else
                    {
                        _gridView = gridView1;
                        
                    }
                  
                }
                return _gridView; 
            }
        }
        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.PopupMenu == null) return;
            this.PopupMenu.Manager.SetPopupContextMenu(this, null);
        }
        void _gridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.PopupMenu == null) return;
            bool shouldShow = false;
            var mPoint = gridControl1.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            if (ObjectGridView is GridView)
            {
                if (((GridView)ObjectGridView).CalcHitInfo(mPoint).InRow)
                {
                    shouldShow = true;
                }
                else
                {
                    shouldShow = false;
                }
            }
            else if (ObjectGridView is LayoutView)
            {
                if (((LayoutView)ObjectGridView).CalcHitInfo(mPoint).InCard)
                {
                    shouldShow = true;
                }
                else
                {
                    shouldShow = false;
                }
            }
            if (shouldShow)
            {
                this.PopupMenu.Manager.SetPopupContextMenu(this, this.PopupMenu);
            }
            else
            {
                this.PopupMenu.Manager.SetPopupContextMenu(this, null);
            }
        }


        public ICommand DoubleClickCommand
        {
            get;
            set;
        }

        
        private void EntityGridViewDoubleClick(object sender, EventArgs e)
        {
            if (DoubleClickCommand == null) return;
            var mPoint = gridControl1.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            if (ObjectGridView is GridView)
            {
                if (!((GridView)ObjectGridView).CalcHitInfo(mPoint).InRow)
                    return;
            }
            else if(ObjectGridView is LayoutView)
            {
                if (!((LayoutView)ObjectGridView).CalcHitInfo(mPoint).InCard)
                    return;
            }
            DoubleClickCommand.Run();
        }

        public object SelectedObject
        {
            get
            {
                return ObjectGridView.GetFocusedRow();
            }
        }

        public string ObjectName
        {
            get;
            set;
        }

        public string ControllerId
        {
            get;
            set;
        }


        public void ClearData()
        {
            UnRegisterEventHandlers();
            if (bindingSource1.List != null) bindingSource1.List.Clear();
            RegisterEventHandlers();
        }

     

        #region ILayoutRemember
        public void SaveLayout()
        {
            this._config.SaveColumnViewLayout(this._gridView, "GridView_" + this.ObjectName);
        }

        public void RestoreLayout()
        {
            this._config.SaveColumnViewLayout(this.ObjectGridView, "Default_GridView_" + this.ObjectName);
            this._config.RestoreColumnViewLayout(this.ObjectGridView, "GridView_" + this.ObjectName);
        }


        public void RestoreDefaultLayout()
        {
            this._config.RestoreColumnViewLayout(this.ObjectGridView, "Default_GridView_" + this.ObjectName);
        }

        public void SaveDefaultLayout()
        {
            this._config.SaveColumnViewLayout(this.ObjectGridView, "Default_GridView_" + this.ObjectName);
        }
        #endregion

        #region IListener<ObjectAddedMessage>
        public new void Handle(ObjectAddedMessage message)
        {
          
            this._selectedID = message.ObjectID;
        }
        #endregion

        public BindingSource BindingSource
        {
            get { return this.bindingSource1; }
        }

        public override void OnDeactivated()
        {
            if (gridView1.CustomizationForm == null) return;
            gridView1.CustomizationForm.Visible = false;
        }

        public override void OnActivated()
        {
            if (gridView1.CustomizationForm == null) return;
            gridView1.CustomizationForm.Visible = true;
        }

       
      
    }
}
