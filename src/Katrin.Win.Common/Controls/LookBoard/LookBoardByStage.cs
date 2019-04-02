using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Katrin.Win.Infrastructure;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using DevExpress.XtraLayout;

namespace Katrin.Win.Common.Controls {

    public partial class LookBoardByStage : DevExpress.XtraEditors.XtraUserControl {
        #region Constructor
        private Dictionary<int, LookBoardColumn> _boardsList = new Dictionary<int, LookBoardColumn>();
        private Dictionary<string,int> _tagStatusCodeList = new Dictionary<string,int>();
        private string _filterColumnName;
        public LookBoardByStage()
        {
            InitializeComponent();
        }

        public void CreateBoards(List<LookupListItem<int>> columnTagList, string filterColumnName,Stream stream)
        {
            _filterColumnName = filterColumnName;
            tableLayoutPanelRoot.ColumnCount = columnTagList.Count;
            float percent = 100 / columnTagList.Count;
            tableLayoutPanelRoot.ColumnStyles.Clear();
            for (int tableColIndex = 0; tableColIndex < columnTagList.Count; tableColIndex++)
            {
                tableLayoutPanelRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, percent));
            }
            _boardsList.Clear();
            _tagStatusCodeList.Clear();
            for (int colIndex = 0; colIndex < columnTagList.Count; colIndex++)
            {
                stream.Position = 0;
                LookBoardColumn col = new LookBoardColumn(stream);
                col.AllowDrop = true;
                col.Appearance.Options.UseBackColor = true;
                col.Dock = System.Windows.Forms.DockStyle.Fill;
                col.Location = new System.Drawing.Point(856, 1);
                col.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
                col.Name = columnTagList[colIndex] + "Proposed";
                col.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
                col.Size = new System.Drawing.Size(287, 522);
                col.Tag = "";
                tableLayoutPanelRoot.Controls.Add(col, colIndex, 0);
                string filter = "[" + _filterColumnName + "] = " + columnTagList[colIndex].Value;
                ConfigureOppCol(col, columnTagList[colIndex].DisplayName, filter);
                _tagStatusCodeList.Add(columnTagList[colIndex].DisplayName,columnTagList[colIndex].Value);
                _boardsList.Add(columnTagList[colIndex].Value, col);
            }
        }

        void ConfigureOppCol(LookBoardColumn col, string tag, string filter)
        {
            col.LayoutView.ActiveFilterString = filter;

            col.LayoutView.MouseDown += new MouseEventHandler(layoutView_MouseDown);
            col.LayoutView.MouseMove += new MouseEventHandler(layoutView_MouseMove);
            //col.LayoutView.MouseUp += new MouseEventHandler(layoutView_MouseUp);
            col.LayoutView.DoubleClick += (sender, e) =>
                {
                    LayoutView layoutView = sender as LayoutView;
                    if (layoutView == null) return;
                    if (layoutView.FocusedRowHandle < 0) return;
                    if(OnEditItem != null)
                        OnEditItem(sender, new EventArgs<object>(layoutView.GetRow(layoutView.FocusedRowHandle)));
                };
            col.GridControl.DragDrop += new DragEventHandler(gridControl_DragDrop);
            col.GridControl.DragOver += new DragEventHandler(gridControl_DragOver);
            col.GridControl.DragLeave += new EventHandler(gridControl_DragLeave);
            col.GridControl.GiveFeedback += new GiveFeedbackEventHandler(gridControl_GiveFeedback);
            col.GridControl.QueryContinueDrag += new QueryContinueDragEventHandler(gridControl_QueryContinueDrag);
            col.GridControl.Tag = tag;
        }

        private GridControl GetLookBoardGrid(object statusCodeObject)
        {
            int statusCode = int.Parse(statusCodeObject.ToString());
            if(_boardsList.Keys.Contains(statusCode))
            return _boardsList[statusCode].GridControl;
            return _boardsList.First().Value.GridControl;
        }

        #endregion

        #region OpportunitiesDataTable property

        public event EventHandler<EventArgs<object,int,int>> OnStatusCodeChange;
        public event EventHandler<EventArgs<object>> OnEditItem;
        public event EventHandler<EventArgs<object>> OnCurrentChange;
        public event Func<object,int,bool> OnValidataStatus;

        public BindingList<object> BoardDataList
        {
            get { return this.boardDataList; }
            set {
                this.boardDataList = value;
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = this.boardDataList;
                foreach (var board in _boardsList)
                {
                    board.Value.GridControl.DataSource = bindingSource;
                    board.Value.GridControl.RefreshDataSource();
                }
                bindingSource.CurrentItemChanged += (sender, e) =>
                {
                    if (OnCurrentChange != null)
                        OnCurrentChange(sender, new EventArgs<object>(bindingSource.Current));
                };
            }
        }
        #endregion

        #region Private Event handlers
        private void layoutView_MouseDown(object sender, MouseEventArgs e) {
            this.dragBoundsRectangle = null;

            if (e.Button == MouseButtons.Left) {
                var view = sender as LayoutView;
                var hitInfo = view.CalcHitInfo(e.Location);

                // If the clicked point belongs to a card caption...
                if (hitInfo.HitCard != null) {
                    this.dragBoundsRectangle = CalculateRectangle(e.Location, SystemInformation.DragSize);
                    // StartCardDrag(view, e.Location, hitInfo.RowHandle, hitInfo.HitCard.Bounds);
                }
            }
        }

        public  Bitmap CropBitmap(Bitmap bitmap, Rectangle rectangle)
        {
            var croppedBitmap = new Bitmap(rectangle.Width, rectangle.Height);
            var graphics = Graphics.FromImage(croppedBitmap);
            graphics.DrawImage(bitmap, 0, 0, rectangle, GraphicsUnit.Pixel);
            return croppedBitmap;
        }

        private void StartCardDrag(LayoutView view, Point clickLocation, int rowHandle, Rectangle rowBounds) {
            string id = view.GetRowCellValue(rowHandle, view.Columns["TaskId"]).ToString();

            // Create a cursor from the card bitmap.
            using (var gridBitmap = new Bitmap(view.GridControl.Width, view.GridControl.Height)) {
                view.GridControl.DrawToBitmap(gridBitmap,
                                              new Rectangle(0, 0, view.GridControl.Width,
                                                            view.GridControl.Height));
                using (var cardBitmap = CropBitmap(gridBitmap,rowBounds))
                {
                    this.customCursorWrapper =
                        CustomCursorWrapper.CreateFromBitmap(cardBitmap,
                                                             Point.Subtract(clickLocation, new Size(rowBounds.Location)));
                }
            }

            // Start drag and drop
            view.GridControl.DoDragDrop(id, DragDropEffects.Move);
            
        }

        private void layoutView_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left && this.dragBoundsRectangle.HasValue) {
                // Outside bounds... drag has officially started
                if (!this.dragBoundsRectangle.Value.Contains(e.Location)) {
                    var view = sender as LayoutView;
                    var hitInfo = view.CalcHitInfo(e.Location);

                    // If the move point belongs to a card caption...
                    if (hitInfo.HitCard != null) {
                        StartCardDrag(view, e.Location, hitInfo.RowHandle, hitInfo.HitCard.Bounds);
                    }
                    this.dragBoundsRectangle = null;
                }
            }
        }

        private void layoutView_MouseUp(object sender, MouseEventArgs e) {
        }

        private void gridControl_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;

            var gridControl = sender as GridControl;
            string dragData = e.Data.GetData(DataFormats.Text).ToString();

            // Lookup dragged row with dragged ID in source table.
            var rowDropped = this.boardDataList.AsEnumerable().FirstOrDefault(row => row.AsDyanmic().TaskId.ToString() == dragData);
            if (rowDropped == null) return;

            bool validataResult = true;
            if (OnValidataStatus != null)
                validataResult = OnValidataStatus(rowDropped, GetSatusCode(gridControl.Tag.ToString()));
            if (!validataResult) return;

            // Obtain the view over which the card is being dragged.
            Point point = gridControl.PointToClient(new Point(e.X, e.Y));
            LayoutView view = gridControl.GetViewAt(point) as LayoutView;

            // Valid drop location if over a LayoutView
            if (view != null)
            {
                SetColumnHoverColor(gridControl, true);

                e.Effect = DragDropEffects.Move;
                if (null != this.customCursorWrapper && Cursor.Current != this.customCursorWrapper.Cursor)
                {
                    Cursor.Current = this.customCursorWrapper.Cursor;
                    Cursor.Position.Offset(point);
                    Debug.WriteLine("Set cursor to custom icon.");
                }
                Debug.WriteLine("Dragging over " + gridControl.Name + " " + e.Effect);
            }
        }

        void gridControl_DragLeave(object sender, EventArgs e) {
            var gridControl = sender as GridControl;

            SetColumnHoverColor(gridControl, false);
        }

        void SetColumnHoverColor(GridControl gridControl, bool hovering) {
            LayoutView view = (LayoutView)gridControl.MainView;
            LookBoardColumn oppCol = (LookBoardColumn)gridControl.Parent;

            if (hovering) {
                Color backColor = Color.FromArgb(242, 242, 242);
                view.Appearance.ViewBackground.BackColor = backColor;// Color.FromArgb(61, 61, 61);
                oppCol.BackColor = backColor;// Color.FromArgb(61, 61, 61);
            } else {
                Color activeColor = Color.FromArgb(204, 204, 204);
                view.Appearance.ViewBackground.BackColor = activeColor;// Color.FromArgb(51, 51, 51);
                oppCol.BackColor = activeColor;// Color.FromArgb(51, 51, 51);
            }
        }

        public int GetSatusCode(string tag) 
        {
            foreach (var item in _tagStatusCodeList)
            {
                if (item.Key == tag)
                    return item.Value;
            }
            return _tagStatusCodeList.First().Value;
        }

        private void gridControl_DragDrop(object sender, DragEventArgs e) {
            string dragData = e.Data.GetData(DataFormats.Text).ToString();

            // Lookup dragged row with dragged ID in source table.
            var rowDropped = this.boardDataList.AsEnumerable().FirstOrDefault(row => row.AsDyanmic().TaskId.ToString() == dragData);
            if (rowDropped == null) return;
            GridControl gridControl = sender as GridControl;

            PropertyInfo propertyInfo =  rowDropped.GetType().GetProperty(_filterColumnName);
            if (propertyInfo != null)
            {
                GridControl preGridControl = GetLookBoardGrid(propertyInfo.GetValue(rowDropped,null));
                int newStatus = GetSatusCode(gridControl.Tag.ToString());
                int originalStatus = rowDropped.AsDyanmic().StatusCode;
                propertyInfo.SetValue(rowDropped, newStatus, null);
                preGridControl.RefreshDataSource();
                SetColumnHoverColor(preGridControl, true);
                gridControl.MainView.RefreshData();
                ReleaseCursor();
                SetColumnHoverColor(gridControl, false);
                SetColumnHoverColor(preGridControl, false);

                if (OnStatusCodeChange != null)
                    OnStatusCodeChange(this, new EventArgs<object, int, int>(rowDropped, originalStatus,GetSatusCode(gridControl.Tag.ToString())));
            }
        }

        private void gridControl_GiveFeedback(object sender, GiveFeedbackEventArgs e) {
            e.UseDefaultCursors = e.Effect != DragDropEffects.Move;
            Debug.WriteLine("GiveFeedback " + ((Control)sender).Name + " " + e.UseDefaultCursors);
        }

        private void gridControl_QueryContinueDrag(object sender, QueryContinueDragEventArgs e) {
            Debug.WriteLine("QueryContinueDrag " + ((Control)sender).Name);
            if (!IsLeftMouseButtonDown(e.KeyState)) {
                ReleaseCursor();        // Left mouse button has been released - drag cancelled, release resources
            }
        }

        // This is required to customize the border color of the TableLayoutPanel
        private void tableLayoutPanelRoot_CellPaint(object sender, TableLayoutCellPaintEventArgs e) {
            Graphics g = e.Graphics;
            Rectangle r = e.CellBounds;
            Color penColor = Color.FromArgb(244, 244, 244);
            using (Pen pen = new Pen(penColor, 0))//
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                if (e.Row == (tableLayoutPanelRoot.RowCount - 1)) {
                    r.Height -= 1;
                }

                if (e.Column == (tableLayoutPanelRoot.ColumnCount - 1)) {
                    r.Width -= 1;
                }

                e.Graphics.DrawRectangle(pen, r);
            }
        }

        public event NavRequestEventHandler NavRequest;

        protected void OnNavRequest(NavRequestEventArgs args) {
            if (NavRequest != null)
                NavRequest(this, args);
        }
        #endregion

        #region Helper methods
        private static Rectangle CalculateRectangle(Point centerPoint, Size size) {
            var x = centerPoint.X - (size.Width / 2);
            var y = centerPoint.Y - (size.Height / 2);
            return new Rectangle(x, y, size.Width, size.Height);
        }

        private static bool IsLeftMouseButtonDown(int keyState) {
            return (keyState & 1) != 0;
        }

        private void ReleaseCursor() {
            if (this.customCursorWrapper != null) {
                Debug.WriteLine("Releasing cursor.");
                this.customCursorWrapper.Dispose();
                this.customCursorWrapper = null;
            }
        }
        #endregion

        #region Private Data
        private BindingList<object> boardDataList;
        private CustomCursorWrapper customCursorWrapper = null;
        private Rectangle? dragBoundsRectangle = null;
        #endregion
    }

    public struct IconInfo
    {
        public bool fIcon;
        public int xHotspot;
        public int yHotspot;
        public IntPtr hbmMask;
        public IntPtr hbmColor;
    }

    /// <summary>
    /// Wraps a custom cursor created from a bitmap.  Disposable to clean up unmanaged resource.
    /// </summary>
    public class CustomCursorWrapper : IDisposable
    {
        #region Private constructor
        private CustomCursorWrapper(IntPtr cursorPointer)
        {
            this.CursorPointer = cursorPointer;
            this.Cursor = new Cursor(cursorPointer);
        }
        #endregion

        #region Public members
        public Cursor Cursor { get; private set; }

        public static CustomCursorWrapper CreateFromBitmap(Bitmap bitmap, Point point)
        {
            if (bitmap != null)
            {
                Graphics canvas = Graphics.FromImage(bitmap);
                canvas.Save();

                IconInfo iconInfo = new IconInfo();
                IntPtr pointer = bitmap.GetHicon();
                GetIconInfo(pointer, ref iconInfo);
                var cursorPointer = CreateIconIndirect(ref iconInfo);

                // Clean up intermediary unmanaged resources
                //
                if (iconInfo.hbmColor != IntPtr.Zero)
                {
                    DeleteObject(iconInfo.hbmColor);
                }
                if (iconInfo.hbmMask != IntPtr.Zero)
                {
                    DeleteObject(iconInfo.hbmMask);
                }
                return new CustomCursorWrapper(cursorPointer);
            }
            return null;
        }

        private static Bitmap ArrowCursorImage
        {
            get
            {
                if (_arrowCursorImage == null)
                {
                    Assembly myAssembly = Assembly.GetExecutingAssembly();
                    using (Stream stream = myAssembly.GetManifestResourceStream(typeof(CustomCursorWrapper).Namespace + ".base_cursor.png"))
                    {
                        _arrowCursorImage = new Bitmap(stream);
                    }
                }
                return _arrowCursorImage;
            }
        }
        private static Bitmap _arrowCursorImage = null;
        #endregion

        #region PInvoke methods
        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr handle);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static bool DestroyIcon(IntPtr handle);

        private IntPtr CursorPointer { get; set; }
        #endregion

        #region IDisposable implementation
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                if (CursorPointer != IntPtr.Zero)
                {
                    DestroyIcon(CursorPointer);
                    CursorPointer = IntPtr.Zero;
                    this.Cursor = null;
                }
                disposed = true;
            }
        }

        ~CustomCursorWrapper()
        {
            Dispose(false);
        }
        #endregion
    }
}
