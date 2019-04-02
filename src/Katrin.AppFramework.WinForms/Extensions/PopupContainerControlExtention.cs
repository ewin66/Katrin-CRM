using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using DevExpress.XtraEditors;
using System.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using System.Windows.Forms;
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Collections;
using System.Data;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using Microsoft.Data.Edm;
using Microsoft.Data.Edm.Validation;
using Microsoft.Data.Edm.Csdl;
using DevExpress.Data.Filtering;
using Katrin.AppFramework.WinForms.Context;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.Metadata;
using ICSharpCode.Core;
using System.Threading;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Grid;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Messages;

namespace Katrin.AppFramework.WinForms.Extensions
{
    public class PopupContainerControlExtention :  PopupContainerControl
    {
        protected ArrayList selection;
        GridColumn column;
        RepositoryItemCheckEdit edit;
        const int CheckboxIndent = 4;
        private string _layoutEntityName = string.Empty;
        private bool _isMarkCheck = true;
        private bool _isInitName = false;
        private string _filterKeyName = string.Empty;
        private string _layoutEntityDisplayName = string.Empty;
        private IActionContext _context;
        private int _initRowHandle = -1;
        private PanelControl panelControl2;
        private SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl popupContainerGrid;
        private GridView popupContainerView;
        private CriteriaOperator _baseFilter = null;

        private IObjectSpace objectSpace;

        protected IObjectSpace ObjectSpace
        {
            get { return objectSpace ?? (objectSpace = new ODataObjectSpace()); }
        }

        public PopupContainerControlExtention(List<GridColumn> columns, object dataSource,string displayName, bool isMarkCheck)
        {
            _context = new ActionContext();
            _layoutEntityDisplayName = displayName;
            InitializeComponent();
            popupContainerGrid.DataSource = _context.BindingSource;
            _isMarkCheck = isMarkCheck;
            InitPickUp(string.Empty);
            InitColumn(columns);
            
            
        }

        public PopupContainerControlExtention(string layoutEntityName, string filterEntityName, bool isMarkCheck, CriteriaOperator filter)
        {
            _context = new ActionContext();
            InitializeComponent();

            popupContainerGrid.DataSource = _context.BindingSource;
            _layoutEntityName = layoutEntityName;
            _isMarkCheck = isMarkCheck;
            _baseFilter = filter;
            InitPickUp(filterEntityName);
            InitColumn(null);
        }

        #region LayoutEntity info
        public string LayOutEntityKey
        {
            get
            {
                var entityType = ObjectSpace.GetTypeDefinition(_layoutEntityName);
                return entityType.Key().First().Name;
            }
        }

        public string LayoutEntityDisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(_layoutEntityDisplayName))
                {
                    var layoutEntity = MetadataRepository.Entities.Where(c => c.PhysicalName == _layoutEntityName).FirstOrDefault();
                    bool isFind = false;
                    foreach (var displayEntity in MetadataRepository.Entities)
                    {
                        if (isFind) break;
                        foreach(var att in displayEntity.Attributes)
                        {
                            var lookup = att.AttributeLookupValues.Where(c=>c.EntityId == layoutEntity.EntityId);
                            if(lookup.Count() > 0)
                            {
                                var displayAttributeId = lookup.First().DisplayEntityAttributeId;
                                _layoutEntityDisplayName = layoutEntity.Attributes.Where(c=>c.AttributeId == displayAttributeId).First().PhysicalName;
                                isFind = true;
                                break;
                            }
                        }
                    }
                }
                return _layoutEntityDisplayName;
            }
        }
        #endregion

        #region lookup
        protected string GetLocalizedCaption(string name)
        {
            name = "${res:" + name + "}";
            return StringParser.Parse(name);
        }

        private void BindLookUpData(string attributeName, string layoutEntityName)
        {
            var entityMetadata = MetadataRepository.Entities.First(e => e.TableName == layoutEntityName);
            lookUpEdit1.BindLookupList(entityMetadata,false);
            List<LookupListItem<Guid?>> items = lookUpEdit1.Properties.DataSource as List<LookupListItem<Guid?>>;
            if (items == null) items = new List<LookupListItem<Guid?>>();
            items.Insert(0, new LookupListItem<Guid?>() { DisplayName = GetLocalizedCaption("None"), Value = Guid.Empty });
            lookUpEdit1.Properties.DataSource = items;
        }

        public void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
           
            if (lookUpEdit1.EditValue == null) return;
            Guid filterId = Guid.Parse(lookUpEdit1.EditValue.ToString());
            lookUpEdit1.EditValue = filterId;
            if (string.IsNullOrEmpty(lookUpEdit1.EditValue.ToString()) || filterId == Guid.Empty)
            {
                BindData(_baseFilter);
            }
            else
            {
                if (filterId == Guid.Empty) return;
                CriteriaOperator filter = new BinaryOperator(_filterKeyName, filterId, BinaryOperatorType.Equal);
                if ((object)_baseFilter != null)
                    filter &= _baseFilter;
                BindData(filter);
            }
        }


        private void InitPickUp(string filterEntityName)
        {
            if (string.IsNullOrEmpty(filterEntityName)) { panelControl1.Visible = false; return; }
            var entityType = ObjectSpace.GetTypeDefinition(filterEntityName);
            _filterKeyName = entityType.Key().First().Name;
            this.lookUpEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.LookUpBindingSource, _filterKeyName, true));
            BindLookUpData(_filterKeyName, _layoutEntityName);
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn(_filterKeyName));
            DataRow row = dt.NewRow();
            row[_filterKeyName] = Guid.Empty;
            dt.Rows.Add(row);
            LookUpBindingSource.DataSource = dt;
        }

        #endregion

        #region grid info 
        private void InitColumn(List<GridColumn> columns)
        {
            this.popupContainerView.BeginUpdate();
            if(!string.IsNullOrEmpty(_layoutEntityName))
                this.popupContainerView.InitWithDefaultLayout(_layoutEntityName);
            else if (columns != null)
            {
                popupContainerView.Columns.AddRange(columns.ToArray());
            }

            selection = new ArrayList();
            this.OnSelectionChanged();
            View = this.popupContainerView;
            this.popupContainerView.EndUpdate();
        }

        public bool IsMarkCheck
        {
            get { return _isMarkCheck; }
        }

        class GetDataContext
        {
            public Func<IList> GetData { get; set; }
            public SynchronizationContext Context { get; set; }
        }

        private void AsBindData(IAsyncResult ar)
        {
            var context = (GetDataContext)ar.AsyncState;

            IList result = context.GetData.EndInvoke(ar);
            Action<object> action = new Action<object>(list =>
            {
                _context.BindingSource.DataSource = list;
                LoadUserData();
            });
            context.Context.Post(new SendOrPostCallback(action), result);

        }

        private IList GetData()
        {
            var projections = GridViewExtension.GetColumnProjections(_layoutEntityName);
            var fetchColumns = projections.Select(p => string.Format("{0} AS {1}", p.QueryExpression, p.Projection)).ToArray();
            var selector = string.Format("new({0})", string.Join(",", fetchColumns));
            var criteria = _context.GetFilters();
            return ObjectSpace.GetObjectQuery(_layoutEntityName, selector, criteria).ToList();
        }

        public void BindData(CriteriaOperator filter)
        {
            _context.SetFilter("DepartFilter", filter);
            var context = new GetDataContext { GetData = GetData, Context = SynchronizationContext.Current };
            context.GetData.BeginInvoke(new AsyncCallback(AsBindData), context);
        }

        public void BindData(object dataSource)
        {
            _context.BindingSource.DataSource = dataSource;
        }

        public void LoadUserData()
        {

            if (this.PopupContainerProperties != null && this.PopupContainerProperties.ShowPopupCloseButton)
                this.PopupContainerProperties.ShowPopupCloseButton = false;
            

            if (_isInitName)
            {
                if (selection.Count > 0 && this.popupContainerView.FocusedRowHandle >= 0)
                {
                    _initRowHandle = this.popupContainerView.FocusedRowHandle;
                    this.popupContainerView.MakeRowVisible(_initRowHandle);
                }
                return;
            }

            
            

            PopupContainerEdit edit = this.Tag as PopupContainerEdit;
            if (edit == null) return;
            var selectedValue = edit.EditValue;
            if (selectedValue == null) return;
            if (_context.BindingSource.List.Count == 0) return;
            Guid userId;
            if (!Guid.TryParse(selectedValue.ToString(), out userId)) return;
            var selectedEntityList =
                _context.BindingSource.List.AsQueryable().Where("" + LayOutEntityKey + " = @0", userId).ToArrayList();
            if (selectedEntityList == null || selectedEntityList.Count <= 0) return;
            _initRowHandle = _context.BindingSource.List.IndexOf(selectedEntityList[0]);
            SelectRow(_initRowHandle, true);
            edit.Refresh();
            _isInitName = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ClearSelection();
        }

        #endregion

        #region INit veiw
        public GridView View
        {
            get { return this.popupContainerView; }
            set
            {
                if (this.popupContainerView == null)
                {
                    this.popupContainerView = new GridView();
                    this.popupContainerView.GridControl = this.popupContainerGrid;
                }
                Detach();
                Attach(this.popupContainerView);
            }
        }

        protected virtual void Attach(GridView view)
        {
            if (view == null) return;
            selection.Clear();
            view.BeginUpdate();
            try
            {
                view.Click += new EventHandler(View_Click);
                if (_isMarkCheck)
                {
                    edit = view.GridControl.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
                    column = view.Columns.Add();
                    column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    column.Visible = true;
                    column.VisibleIndex = 0;
                    column.FieldName = "CheckMarkSelection";
                    column.Caption = "Mark";
                    column.OptionsColumn.ShowCaption = false;
                    column.OptionsColumn.AllowEdit = false;
                    column.OptionsColumn.AllowSize = false;
                    column.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
                    column.Width = GetCheckBoxWidth();
                    column.ColumnEdit = edit;
                    view.CustomDrawColumnHeader += new ColumnHeaderCustomDrawEventHandler(View_CustomDrawColumnHeader);
                    view.CustomUnboundColumnData += new CustomColumnDataEventHandler(view_CustomUnboundColumnData);
                }
            }
            finally
            {
                view.EndUpdate();
            }
        }
        protected virtual void Detach()
        {
            if (this.popupContainerView == null) return;
            if (column != null)
                column.Dispose();
            if (edit != null)
            {
                this.popupContainerView.GridControl.RepositoryItems.Remove(edit);
                edit.Dispose();
            }
            this.popupContainerView.Click -= new EventHandler(View_Click);
            this.popupContainerView.CustomDrawColumnHeader -= new ColumnHeaderCustomDrawEventHandler(View_CustomDrawColumnHeader);
            this.popupContainerView.CustomUnboundColumnData -= new CustomColumnDataEventHandler(view_CustomUnboundColumnData);

        }
        #endregion

        #region init check
        public GridColumn CheckMarkColumn { get { return column; } }
        protected int GetCheckBoxWidth()
        {
            DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info = edit.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;
            int width = 0;
            GraphicsInfo.Default.AddGraphics(null);
            try
            {
                width = info.CalcBestFit(GraphicsInfo.Default.Graphics).Width;
            }
            finally
            {
                GraphicsInfo.Default.ReleaseGraphics();
            }
            return width + CheckboxIndent * 2;
        }

        protected void DrawCheckBox(Graphics g, Rectangle r, bool Checked)
        {
            DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
            DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
            DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;
            info = edit.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;
            painter = edit.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
            info.EditValue = Checked;
            info.Bounds = r;
            info.CalcViewInfo(g);
            args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
            painter.Draw(args);
            args.Cache.Dispose();
        }
        #endregion


        #region select row focus 
        public void SetRowFocus()
        {
            if (_initRowHandle >= 0)
            {
                _context.BindingSource.Position = _initRowHandle;
                this.popupContainerView.MakeRowVisible(_initRowHandle);
            }
        }
        #endregion
        #region check manage
        public delegate void SelectionChangedEventHandler(object sender, EventArgs e);
        public event SelectionChangedEventHandler SelectionChanged;
        public void OnSelectionChanged()
        {
            if (SelectionChanged != null)
            {
                EventArgs e = new EventArgs();
                SelectionChanged(this, e);
            }
        }

        public ArrayList Selection
        {
            get { return selection; }
            set { selection = value; }
        }

        public int SelectedCount { get { return selection.Count; } }


        public bool IsRowSelected(int rowHandle)
        {
            object row = View.GetRow(rowHandle);
            return GetSelectedIndex(row) != -1;
        }

        public object GetSelectedRow(int index)
        { return selection[index]; }


        public int GetSelectedIndex(object row)
        { return selection.IndexOf(row); }

        public void ClearSelection()
        {
            selection.Clear();
            Invalidate();
            OnSelectionChanged();
        }

        public void SelectAll()
        { SelectAll(null); }

       

        public void SelectAll(object dataSource)
        {
            selection.Clear();
            if (dataSource != null)
            {
                if (dataSource is ICollection)
                    selection.AddRange(((ICollection)dataSource));
            }
            else
            {
                for (int i = 0; i < View.DataRowCount; i++)
                    selection.Add(View.GetRow(i));
            }
            Invalidate();
            this.OnSelectionChanged();
        }

       

        public void SelectRow(int rowHandle, bool select)
        { SelectRow(rowHandle, select, true); }

        void SelectRow(int rowHandle, bool select, bool invalidate)
        {
            if (IsRowSelected(rowHandle) == select) return;
            object row = View.GetRow(rowHandle);
            if (row == null) row = _context.BindingSource.List[rowHandle];
            if (select)
                selection.Add(row);
            else
                selection.Remove(row);
            if (invalidate)
                Invalidate();
            OnSelectionChanged();
        }


        public void InvertRowSelection(int rowHandle)
        {
            if (View.IsDataRow(rowHandle))
                SelectRow(rowHandle, !IsRowSelected(rowHandle));
        }

        void Invalidate()
        {
            View.BeginUpdate();
            View.EndUpdate();
        }
        #endregion

        #region view action
        void view_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column == CheckMarkColumn)
            {
                if (e.IsGetData)
                    e.Value = IsRowSelected(View.GetRowHandle(e.ListSourceRowIndex));
                else
                    SelectRow(View.GetRowHandle(e.ListSourceRowIndex), (bool)e.Value);
            }
        }

        void View_Click(object sender, EventArgs e)
        {
            GridHitInfo info;
            Point pt = View.GridControl.PointToClient(Control.MousePosition);
            info = View.CalcHitInfo(pt);
            if (info.Column == column && _isMarkCheck)
            {
                if (info.InColumn)
                {
                    if (SelectedCount == View.DataRowCount)
                        ClearSelection();
                    else
                        SelectAll();
                }
                if (info.InRowCell)
                    InvertRowSelection(info.RowHandle);
            }
            else if (!_isMarkCheck && info.InRowCell)
            {
                selection.Clear();
                InvertRowSelection(info.RowHandle);
                this.OwnerEdit.ClosePopup();
            }
            if (info.InRow && View.IsGroupRow(info.RowHandle) && info.HitTest != GridHitTest.RowGroupButton)
                InvertRowSelection(info.RowHandle);
        }

        void View_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == column)
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e.Graphics, e.Bounds, SelectedCount == View.DataRowCount);
                e.Handled = true;
            }
        }
        #endregion


       
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            if (disposing)
            {
                if(this.popupContainerGrid != null)
                {
                    this.popupContainerGrid.MainView = null;
                    this.popupContainerView = null;
                    
                }
            }
            base.Dispose(disposing);
            GC.Collect();
            GC.SuppressFinalize(this);
        }

        #region Component Designer generated code
       

        


        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.EntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LookUpBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.popupContainerGrid = new DevExpress.XtraGrid.GridControl();
            this.popupContainerView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerView)).BeginInit();
            this.SuspendLayout();
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(5, 5);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Size = new System.Drawing.Size(273, 20);
            this.lookUpEdit1.TabIndex = 0;
            this.lookUpEdit1.EditValueChanged += new System.EventHandler(this.lookUpEdit1_EditValueChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lookUpEdit1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(559, 49);
            this.panelControl1.TabIndex = 2;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 262);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(559, 29);
            this.panelControl2.TabIndex = 3;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(440, 3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(96, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Clear";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // popupContainerGrid
            // 
            this.popupContainerGrid.DataSource = this.EntityBindingSource;
            this.popupContainerGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popupContainerGrid.Location = new System.Drawing.Point(0, 49);
            this.popupContainerGrid.MainView = this.popupContainerView;
            this.popupContainerGrid.Name = "popupContainerGrid";
            this.popupContainerGrid.Size = new System.Drawing.Size(559, 213);
            this.popupContainerGrid.TabIndex = 4;
            this.popupContainerGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.popupContainerView});
            // 
            // popupContainerView
            // 
            this.popupContainerView.GridControl = this.popupContainerGrid;
            this.popupContainerView.OptionsView.ShowFooter = false;
            this.popupContainerView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;

            this.popupContainerView.Name = "popupContainerView";
            // 
            // PopupContainerControlExtention
            // 
            this.Controls.Add(this.popupContainerGrid);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "PopupContainerControlExtention";
            this.Size = new System.Drawing.Size(559, 291);
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.BindingSource EntityBindingSource;
        protected System.Windows.Forms.BindingSource LookUpBindingSource;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private PanelControl panelControl1;

       

        
    }

    public static class RepositoryItemPopupContainerControlEditExtention
    {
        public static void InitEdit(this RepositoryItemPopupContainerEdit edit, string layoutEntityName, string filterEntityName, bool isMarkCheck)
        {
            edit.InitEdit(layoutEntityName, filterEntityName, isMarkCheck, null);
        }
        public static void InitEdit(this RepositoryItemPopupContainerEdit edit, string layoutEntityName, string filterEntityName, bool isMarkCheck,CriteriaOperator filter)
        {

            edit.QueryResultValue += edit_QueryResultValue;
            edit.EditValueChanged += edit_EditValueChanged;

            edit.QueryDisplayText += edit_QueryDisplayText;
            PopupContainerControlExtention sample = new PopupContainerControlExtention(layoutEntityName, filterEntityName, isMarkCheck, filter);
            sample.Tag = edit;
            edit.Properties.PopupControl = sample;
            sample.BindData(null);
        }

        public static void InitEdit(this RepositoryItemPopupContainerEdit edit,List<GridColumn> columns,object dataSource,string displayName, bool isMarkCheck)
        {

            edit.QueryResultValue += edit_QueryResultValue;
            edit.EditValueChanged += edit_EditValueChanged;
            edit.QueryDisplayText += edit_QueryDisplayText;
            PopupContainerControlExtention sample = new PopupContainerControlExtention(columns, dataSource,displayName, isMarkCheck);
            sample.Tag = edit;
            edit.Properties.PopupControl = sample;
            sample.BindData(dataSource);
        }


        static void edit_QueryDisplayText(object sender, QueryDisplayTextEventArgs e)
        {
            RepositoryItemPopupContainerEdit editValue = sender as RepositoryItemPopupContainerEdit;
            if (editValue == null) return;
            PopupContainerControlExtention popupSample = editValue.Properties.PopupControl as PopupContainerControlExtention;
            if (popupSample == null) return;
            e.DisplayText = GetPopupEditText(popupSample);
        }

        static void edit_EditValueChanged(object sender, EventArgs e)
        {
            RepositoryItemPopupContainerEdit editValue = sender as RepositoryItemPopupContainerEdit;
            if (editValue == null) return;
            PopupContainerControlExtention popupSample = editValue.Properties.PopupControl as PopupContainerControlExtention;
            if (popupSample == null) return;
            popupSample.LoadUserData();
        }

        static void edit_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            RepositoryItemPopupContainerEdit editValue = sender as RepositoryItemPopupContainerEdit;
            if (editValue == null) return;
            PopupContainerControlExtention popupSample = editValue.Properties.PopupControl as PopupContainerControlExtention;
            if (popupSample == null) return;
            var selectedList = editValue.GetSelection();
            if (selectedList.Count > 0)
                e.Value = selectedList[0];
        }

        



        public static List<Guid> GetSelection(this RepositoryItemPopupContainerEdit edit)
        {
            PopupContainerControlExtention sample = edit.Properties.PopupControl as PopupContainerControlExtention;
            List<Guid> result = new List<Guid>();
            if (sample == null) return result;
            if (sample.Selection.Count <= 0) return result;
            for (int rIndex = 0; rIndex < sample.Selection.Count; rIndex++)
            {
                var selectItem = sample.Selection[rIndex];
                var selectValue = selectItem.GetType().GetProperty(sample.LayOutEntityKey).GetValue(selectItem, null);
                result.Add((Guid)selectValue);
            }
            return result;
        }


        public static ArrayList GetSelectionObjects(this RepositoryItemPopupContainerEdit edit)
        {
            PopupContainerControlExtention sample = edit.Properties.PopupControl as PopupContainerControlExtention;
            ArrayList result = new ArrayList();
            if (sample == null) return result;
            if (sample.Selection.Count <= 0) return result;
            for (int rIndex = 0; rIndex < sample.Selection.Count; rIndex++)
            {
                result.Add(sample.Selection[rIndex]);
            }
            return result;
        }



        private static string GetPopupEditText(PopupContainerControlExtention gridCheckMarks)
        {
            if (gridCheckMarks == null) return string.Empty;
            StringBuilder sb = new StringBuilder();
            string displayName = gridCheckMarks.LayoutEntityDisplayName;
            for (int rIndex = 0; rIndex < gridCheckMarks.Selection.Count; rIndex++)
            {
                if (sb.ToString().Length > 0) { sb.Append(","); }
                var selectItem = gridCheckMarks.Selection[rIndex];
                string str = selectItem.GetType().GetProperty(displayName).GetValue(selectItem, null).ToString();
                sb.Append(str);
            }
            return sb.ToString();
        }
    }

    public static class PopupContainerControlEditExtention
    {
        public static void InitEdit(this PopupContainerEdit edit, string layoutEntityName, string filterEntityName, bool isMarkCheck)
        {
            edit.InitEdit(layoutEntityName, filterEntityName, isMarkCheck, null);
        }
        public static void InitEdit(this PopupContainerEdit edit, string layoutEntityName, string filterEntityName, bool isMarkCheck,CriteriaOperator filter)
        {
            if (!isMarkCheck)
            {
                edit.Popup += (sender, e) =>
                    {
                        PopupContainerEdit editValue = sender as PopupContainerEdit;
                        if (editValue == null) return;
                        PopupContainerControlExtention popupSample = editValue.Properties.PopupControl as PopupContainerControlExtention;
                        if (popupSample == null) return;
                        popupSample.SetRowFocus();
                    };
                edit.QueryResultValue += (sender, e) =>
                {
                    PopupContainerEdit editValue = sender as PopupContainerEdit;
                    if (editValue == null) return;
                    PopupContainerControlExtention popupSample = editValue.Properties.PopupControl as PopupContainerControlExtention;
                    if (popupSample == null) return;
                    var selectedList = editValue.GetSelection();
                    if (selectedList.Count > 0)
                        e.Value = selectedList[0];
                };
                edit.EditValueChanged += (sender, e) =>
                {
                    PopupContainerEdit editValue = sender as PopupContainerEdit;
                    if (editValue == null) return;
                    PopupContainerControlExtention popupSample = editValue.Properties.PopupControl as PopupContainerControlExtention;
                    if (popupSample == null) return;
                    popupSample.LoadUserData();
                };

                edit.QueryDisplayText += (sender, e) =>
                {
                    PopupContainerEdit editValue = sender as PopupContainerEdit;
                    if (editValue == null) return;
                    PopupContainerControlExtention popupSample = editValue.Properties.PopupControl as PopupContainerControlExtention;
                    if (popupSample == null) return;
                    e.DisplayText = GetPopupEditText(popupSample);
                };
            }
            PopupContainerControlExtention sample = new PopupContainerControlExtention(layoutEntityName, filterEntityName, isMarkCheck, filter);
            sample.SelectionChanged += new PopupContainerControlExtention.SelectionChangedEventHandler(SelectionChanged);
            sample.Tag = edit;
            edit.Properties.PopupControl = sample;
            sample.BindData(null);
        }


        public static void AddDetailButton(this PopupContainerEdit edit, string entityName)
        {
            edit.Properties.Buttons.Add(new EditorButton());
            edit.ButtonClick += (sender, e) =>
            {
                if (edit.EditValue == null
                    || e.Button.Kind != ButtonPredefines.Ellipsis
                    || edit.EditValue == DBNull.Value)
                    return;
                var entityId = (Guid)edit.EditValue;
                var parameters = new ActionParameters(entityName, entityId, Workspaces.ViewShowType.Show){
                    {"WorkingMode",EntityDetailWorkingMode.View}
                };
                App.Instance.Invoke(entityName, "Detail", parameters);
            };
        }

        public static List<Guid> GetSelection(this PopupContainerEdit edit)
        {
            PopupContainerControlExtention sample = edit.Properties.PopupControl as PopupContainerControlExtention;
            List<Guid> result = new List<Guid>();
            if (sample == null) return result;
            if (sample.Selection.Count <= 0) return result;
            for (int rIndex = 0; rIndex < sample.Selection.Count; rIndex++)
            {
                var selectItem = sample.Selection[rIndex];

                var selectValue = selectItem.GetType().GetProperty(sample.LayOutEntityKey).GetValue(selectItem, null);
                result.Add((Guid)selectValue);
            }
            return result;
        }

        public static void SelectionChanged(object sender, EventArgs e)
        {
            PopupContainerControlExtention gridCheckMarks = (PopupContainerControlExtention)sender;
            if (!gridCheckMarks.IsMarkCheck) return;
            var edit = gridCheckMarks.Tag as PopupContainerEdit;
            if (edit == null) return;
            edit.Text = GetPopupEditText(gridCheckMarks);
        }

        private static string GetPopupEditText(PopupContainerControlExtention gridCheckMarks)
        {
            if (gridCheckMarks == null) return string.Empty;
            StringBuilder sb = new StringBuilder();
            string displayName = gridCheckMarks.LayoutEntityDisplayName;
            for (int rIndex = 0; rIndex < gridCheckMarks.Selection.Count; rIndex++)
            {
                if (sb.ToString().Length > 0) { sb.Append(","); }
                var selectItem = gridCheckMarks.Selection[rIndex];
                string str = selectItem.GetType().GetProperty(displayName).GetValue(selectItem, null).ToString();
                sb.Append(str);
            }
            return sb.ToString();
        }
    }
}
