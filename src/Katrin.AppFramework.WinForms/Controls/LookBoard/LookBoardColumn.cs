using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Layout;
using System.Diagnostics;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using DevExpress.XtraGrid.Columns;
using System.IO;
using System.Reflection;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Card;

namespace Katrin.Win.Common.Controls {

    public partial class LookBoardColumn : DevExpress.XtraEditors.XtraUserControl {
        public LookBoardColumn(Stream stream)
        {
            InitializeComponent();
            
            if (stream != null)
                layoutView.RestoreLayoutFromStream(stream);
            
            foreach (GridColumn col in layoutView.Columns)
            {
                
                if (col.ColumnEditName != null)
                {
                    
                   RepositoryItemMemoEdit  edit = new  RepositoryItemMemoEdit();
                   edit.AutoHeight = true;
                   edit.ScrollBars = ScrollBars.Vertical;
                   col.ColumnEdit = edit;
                }
            }
        }

        public GridControl GridControl {
            get { return this.gridControl; }
        }

        public LayoutView LayoutView {
            get { return this.layoutView; }
        }

        private LayoutViewCard hoverCard;

        private LayoutViewCard HoverCard {
            get { return hoverCard; }
            set {
                if (hoverCard != value) {
                    int prevHoverRow = hoverCard == null ? GridControl.InvalidRowHandle : hoverCard.RowHandle;

                    hoverCard = value;

                    // undo the previous hover 
                    layoutView.RefreshRow(prevHoverRow);

                    // set the new hover
                    if (hoverCard != null)
                        layoutView.RefreshRow(hoverCard.RowHandle);
                }
            }
        }

        private void layoutView_MouseMove(object sender, MouseEventArgs e) {
            LayoutView view = sender as LayoutView;

            LayoutViewHitInfo info = view.CalcHitInfo(new Point(e.X, e.Y));

            HoverCard = info.HitCard;
        }

        private void layoutView_CustomDrawCardFieldValue(object sender, RowCellCustomDrawEventArgs e) {
            bool hovering = HoverCard != null && e.RowHandle == HoverCard.RowHandle;
            bool isSideBand = e.Column == colLayoutSpacer;

            if (isSideBand) {
                e.Appearance.BackColor = hovering ? Color.FromArgb(140, 176, 89) : Color.FromArgb(146, 180, 93);
            } else {
                Color generalColor = Color.FromArgb(231, 231, 231);
                LayoutView cardView = sender as LayoutView;
                if (cardView != null)
                {
                    object rowData = cardView.GetRow(e.RowHandle);
                    PropertyInfo proInfo = rowData.GetType().GetProperty("BgColor");
                    if (proInfo != null)
                    {
                        object colorValue = proInfo.GetValue(rowData, null);
                        if (colorValue is Color)
                        {
                            generalColor = (Color)colorValue;
                        }
                    }
                }
                e.Appearance.BackColor = hovering ? Color.FromArgb(236, 234, 235) : generalColor;// Color.FromArgb(231, 231, 231);
            }
        }

        private void layoutView_MouseLeave(object sender, EventArgs e) {
            HoverCard = null;
        }
    }

    public enum States
    {
        None,
        StartPage,
        Dashboard,
        OppDetail,
        ReportViewer,
        Scheduler,
        UnderConstruction
    }

    public delegate void NavRequestEventHandler(object sender, NavRequestEventArgs e);

    public class NavRequestEventArgs : EventArgs
    {
        public NavRequestEventArgs(States targetState)
        {
            this.TargetState = targetState;
        }

        public NavRequestEventArgs(States targetState, int opportunityId)
        {
            this.TargetState = targetState;
            this.OpportunityId = opportunityId;
        }

        public States TargetState { get; set; }
        public int OpportunityId { get; set; }
    }
}
