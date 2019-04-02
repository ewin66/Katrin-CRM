using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using System.ComponentModel;
using DevExpress.XtraEditors.Popup;
using System.Collections;
using System.Windows.Forms;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using System.Text;
using System;
using DevExpress.XtraEditors;
using System.Drawing;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils.Drawing;

namespace Katrin.Win.Common.Controls
{
    public class GridCheckMarksSelection
    {
        public const string CheckMarkFieldName = "CheckMarkSelection";

        protected GridView _view;
        protected ArrayList selection;
        GridColumn column;
        RepositoryItemCheckEdit edit;
        const int CheckboxIndent = 4;
        GridLookUpEdit _gridLookUpEdit;

        public GridCheckMarksSelection(GridLookUpEdit control)
            : this()
        { View = control.Properties.View; _gridLookUpEdit = control; }

        public GridCheckMarksSelection(GridView view)
            : this()
        { View = view; }

        public GridView View
        {
            get { return _view; }
            set
            {
                if (_view != value)
                {
                    Detach();
                    Attach(value);
                }
            }
        }

        public GridColumn CheckMarkColumn { get { return column; } }

        public GridCheckMarksSelection()
        {
            selection = new ArrayList();
            this.OnSelectionChanged();
        }

        public ArrayList Selection
        {
            get { return selection; }
            set { selection = value; }
        }

        public int SelectedCount { get { return selection.Count; } }
        public object GetSelectedRow(int index)
        { return selection[index]; }

        public int GetSelectedIndex(object row)
        { return selection.IndexOf(row); }

        public GridLookUpEdit GridCheckLookUpEdit
        {
            get { return _gridLookUpEdit; }
        }

        public void ClearSelection()
        {
            selection.Clear();
            Invalidate();
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
                this.OnSelectionChanged();
            }
            else
            {
                for (int i = 0; i < _view.DataRowCount; i++)
                    selection.Add(_view.GetRow(i));
            }
            Invalidate();
        }
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
        public void SelectGroup(int rowHandle, bool select)
        {
            if (IsGroupRowSelected(rowHandle) && select) return;
            for (int i = 0; i < _view.GetChildRowCount(rowHandle); i++)
            {
                int childRowHandle = _view.GetChildRowHandle(rowHandle, i);
                if (_view.IsGroupRow(childRowHandle))
                    SelectGroup(childRowHandle, select);
                else
                    SelectRow(childRowHandle, select, false);
            }
            Invalidate();
        }
        public void SelectRow(int rowHandle, bool select)
        { SelectRow(rowHandle, select, true); }

        public void InvertRowSelection(int rowHandle)
        {
            if (View.IsDataRow(rowHandle))
                SelectRow(rowHandle, !IsRowSelected(rowHandle));
            if (View.IsGroupRow(rowHandle))
                SelectGroup(rowHandle, !IsGroupRowSelected(rowHandle));
        }
        public bool IsGroupRowSelected(int rowHandle)
        {
            for (int i = 0; i < _view.GetChildRowCount(rowHandle); i++)
            {
                int row = _view.GetChildRowHandle(rowHandle, i);
                if (_view.IsGroupRow(row))
                {
                    if (!IsGroupRowSelected(row)) return false;
                }
                else
                    if (!IsRowSelected(row)) return false;
            }
            return true;
        }
        public bool IsRowSelected(int rowHandle)
        {
            if (_view.IsGroupRow(rowHandle))
                return IsGroupRowSelected(rowHandle);

            object row = _view.GetRow(rowHandle);
            return GetSelectedIndex(row) != -1;
        }

        protected virtual void Attach(GridView view)
        {
            if (view == null) return;
            selection.Clear();
            this._view = view;
            view.BeginUpdate();
            try
            {
                edit = view.GridControl.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;

                column = view.Columns.Add();
                column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                column.Visible = true;
                column.VisibleIndex = 0;
                column.FieldName = CheckMarkFieldName;
                column.Caption = "Mark";
                column.OptionsColumn.ShowCaption = false;
                column.OptionsColumn.AllowEdit = false;
                column.OptionsColumn.AllowSize = false;
                column.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
                column.Width = GetCheckBoxWidth();
                column.ColumnEdit = edit;

                view.Click += new EventHandler(View_Click);
                view.CustomDrawColumnHeader += new ColumnHeaderCustomDrawEventHandler(View_CustomDrawColumnHeader);
                view.CustomDrawGroupRow += new RowObjectCustomDrawEventHandler(View_CustomDrawGroupRow);
                view.CustomUnboundColumnData += new CustomColumnDataEventHandler(view_CustomUnboundColumnData);
                view.KeyDown += new KeyEventHandler(view_KeyDown);
            }
            finally
            {
                view.EndUpdate();
            }
        }

        protected virtual void Detach()
        {
            if (_view == null) return;
            if (column != null)
                column.Dispose();
            if (edit != null)
            {
                _view.GridControl.RepositoryItems.Remove(edit);
                edit.Dispose();
            }
            _view.Click -= new EventHandler(View_Click);
            _view.CustomDrawColumnHeader -= new ColumnHeaderCustomDrawEventHandler(View_CustomDrawColumnHeader);
            _view.CustomDrawGroupRow -= new RowObjectCustomDrawEventHandler(View_CustomDrawGroupRow);
            _view.CustomUnboundColumnData -= new CustomColumnDataEventHandler(view_CustomUnboundColumnData);
            _view.KeyDown -= new KeyEventHandler(view_KeyDown);
            _view = null;
        }
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
        void Invalidate()
        {
            _view.BeginUpdate();
            _view.EndUpdate();
        }
        void SelectRow(int rowHandle, bool select, bool invalidate)
        {
            if (IsRowSelected(rowHandle) == select) return;
            object row = _view.GetRow(rowHandle);
            if (select)
                selection.Add(row);
            else
                selection.Remove(row);
            if (invalidate)
                Invalidate();
            //OnSelectionChanged();
        }
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
        void view_KeyDown(object sender, KeyEventArgs e)
        {
            if (View.FocusedColumn != column || e.KeyCode != Keys.Space) return;
            InvertRowSelection(View.FocusedRowHandle);
        }
        void View_Click(object sender, EventArgs e)
        {
            GridHitInfo info;
            Point pt = _view.GridControl.PointToClient(Control.MousePosition);
            info = _view.CalcHitInfo(pt);

            if (info.Column == column)
            {
                if (info.InColumn)
                {
                    if (SelectedCount == _view.DataRowCount)
                        ClearSelection();
                    else
                        SelectAll();
                }
                if (info.InRowCell)
                    InvertRowSelection(info.RowHandle);
            }
            if (info.InRow && _view.IsGroupRow(info.RowHandle) && info.HitTest != GridHitTest.RowGroupButton)
                InvertRowSelection(info.RowHandle);
        }
        void View_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == column)
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e.Graphics, e.Bounds, SelectedCount == _view.DataRowCount);
                e.Handled = true;
            }
        }
        void View_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo info;
            info = e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo;

            info.GroupText = "         " + info.GroupText.TrimStart();
            e.Info.Paint.FillRectangle(e.Graphics, e.Appearance.GetBackBrush(e.Cache), e.Bounds);
            e.Painter.DrawObject(e.Info);

            Rectangle r = info.ButtonBounds;
            r.Offset(r.Width + CheckboxIndent * 2 - 1, 0);
            DrawCheckBox(e.Graphics, r, IsGroupRowSelected(e.RowHandle));
            e.Handled = true;
        }
    }

    [UserRepositoryItem("RegisterMyRepositoryItemGridLookUpEdit")]
    public class MyRepositoryItemGridLookUpEdit : RepositoryItemGridLookUpEdit
    {
        //The static constructor which calls the registration method
        static MyRepositoryItemGridLookUpEdit() { RegisterMyRepositoryItemGridLookUpEdit(); }


        internal GridCheckMarksSelection gridSelection_;
        public GridCheckMarksSelection GridSelection
        {
            get { return gridSelection_; }
            set
            {
                if (gridSelection_ != null)
                {
                    gridSelection_.SelectionChanged -= new GridCheckMarksSelection.SelectionChangedEventHandler(gridSelection__SelectionChanged);
                }
                gridSelection_ = value;
                gridSelection_.SelectionChanged += new GridCheckMarksSelection.SelectionChangedEventHandler(gridSelection__SelectionChanged);
            }
        }

        void gridSelection__SelectionChanged(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            PropertyDescriptorCollection collection = ListBindingHelper.GetListItemProperties(GridSelection.Selection);
            PropertyDescriptor desc = collection[DisplayMember];
            foreach (object rv in GridSelection.Selection)
            {
                if (sb.ToString().Length > 0) { sb.Append(", "); }
                sb.Append(desc.GetValue(rv).ToString());
            }
            if (OwnerEdit != null)
            {
                OwnerEdit.Text = sb.ToString();
            }
        }

        //Initialize new properties
        public MyRepositoryItemGridLookUpEdit()
        {
            GridSelection = new GridCheckMarksSelection();
        }

        //The unique name for the custom editor
        public const string CustomEditName = "MyGridLookUpEdit";

        //Return the unique name
        public override string EditorTypeName { get { return CustomEditName; } }

        //Register the editor
        public static void RegisterMyRepositoryItemGridLookUpEdit()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(
                CustomEditName,
                typeof(MyGridLookUpEdit),
                typeof(MyRepositoryItemGridLookUpEdit),
                typeof(GridLookUpEditBaseViewInfo),
                new ButtonEditPainter(), true, null));
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                MyRepositoryItemGridLookUpEdit source = item as MyRepositoryItemGridLookUpEdit;
                if (source == null) return;
                GridSelection = source.GridSelection;
            }
            finally
            {
                EndUpdate();
            }
        }
    }

    public class MyGridLookUpEdit : GridLookUpEdit
    {
        //The static constructor which calls the registration method
        static MyGridLookUpEdit() { MyRepositoryItemGridLookUpEdit.RegisterMyRepositoryItemGridLookUpEdit(); }

        //Initialize the new instance
        public MyGridLookUpEdit()
        {
            //...
            CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(MyGridLookUpEdit_CustomDisplayText);
            QueryPopUp += new CancelEventHandler(MyGridLookUpEdit_QueryPopUp);
        }

        void MyGridLookUpEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit editor = (GridLookUpEdit)sender;
            RepositoryItemGridLookUpEdit properties = editor.Properties;
            properties.PopupFormSize = new Size(editor.Width - 4, properties.PopupFormSize.Height);
        }

        void MyGridLookUpEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            PropertyDescriptorCollection collection = ListBindingHelper.GetListItemProperties(Properties.GridSelection.Selection);
            PropertyDescriptor desc = collection[Properties.DisplayMember];
            foreach (object rv in Properties.GridSelection.Selection)
            {
                if (sb.ToString().Length > 0) { sb.Append(", "); }
                sb.Append(desc.GetValue(rv).ToString());
            }
            e.DisplayText = sb.ToString();
        }

        //Return the unique name
        public override string EditorTypeName
        {
            get
            {
                return MyRepositoryItemGridLookUpEdit.CustomEditName;
            }
        }

        //Override the Properties property
        //Simply type-cast the object to the custom repository item type
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new MyRepositoryItemGridLookUpEdit Properties
        {
            get { return base.Properties as MyRepositoryItemGridLookUpEdit; }
        }

        protected override DevExpress.XtraEditors.Popup.PopupBaseForm CreatePopupForm()
        {
            return new MyPopupGridLookUpEditForm(this);
        }

        protected override void OnPopupShown()
        {
            base.OnPopupShown();
        }
    }

    public class MyPopupGridLookUpEditForm : PopupGridLookUpEditForm
    {
        public MyPopupGridLookUpEditForm(GridLookUpEdit edit) : base(edit) { }

        ArrayList tempSelection = new ArrayList();

        protected override void SetupButtons()
        {
            this.fShowOkButton = true;
            this.fCloseButtonStyle = BlobCloseButtonStyle.Caption;
        }

        protected override void OnCloseButtonClick()
        {
            base.OnCloseButtonClick();
            RedefineSelection(tempSelection, (OwnerEdit as MyGridLookUpEdit).Properties.GridSelection.Selection);
        }

        protected override void OnOkButtonClick()
        {
            base.OnOkButtonClick();
            (OwnerEdit as MyGridLookUpEdit).Properties.GridSelection.OnSelectionChanged();
        }

        protected override void OnBeforeShowPopup()
        {
            base.OnBeforeShowPopup();
            RedefineSelection((OwnerEdit as MyGridLookUpEdit).Properties.GridSelection.Selection, tempSelection);
        }

        internal void RedefineSelection(ArrayList listSource, ArrayList listDestination)
        {
            listDestination.Clear();
            foreach (var item in listSource)
                listDestination.Add(item);
        }

        protected override PopupBaseFormViewInfo CreateViewInfo()
        {
            return new MyCustomBlobPopupFormViewInfo(this);
        }
    }

    public class MyCustomBlobPopupFormViewInfo : CustomBlobPopupFormViewInfo
    {
        public MyCustomBlobPopupFormViewInfo(PopupBaseForm form) : base(form) { }

        // recalculate buttons sizes if needed
        protected override void CalcContentRect(System.Drawing.Rectangle bounds)
        {
            base.CalcContentRect(bounds);
            // recalculate buttons bounds if needed
            this.fOkButtonRect = new System.Drawing.Rectangle(this.fOkButtonRect.X, this.fOkButtonRect.Y + 1, this.fOkButtonRect.Width, this.fOkButtonRect.Height - 2);
            this.fCloseButtonRect = new System.Drawing.Rectangle(this.fCloseButtonRect.X, this.fCloseButtonRect.Y + 1, this.fCloseButtonRect.Width, this.fCloseButtonRect.Height - 2);

            // recalculate footer bounds if needed
            this.SizeBarRect = new System.Drawing.Rectangle(this.SizeBarRect.X, this.SizeBarRect.Y - 20, this.SizeBarRect.Width, this.SizeBarRect.Height + 20);
            this.fContentRect = new System.Drawing.Rectangle(this.fContentRect.X, this.fContentRect.Y, this.fContentRect.Width, this.fContentRect.Height - 20);
            this.fOkButtonRect = new System.Drawing.Rectangle(this.fOkButtonRect.X, this.fOkButtonRect.Y - 10, this.fOkButtonRect.Width, this.fOkButtonRect.Height);
            this.fCloseButtonRect = new System.Drawing.Rectangle(this.fCloseButtonRect.X, this.fCloseButtonRect.Y - 10, this.fCloseButtonRect.Width, this.fCloseButtonRect.Height);
        }
    }
}
