using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Katrin.Win.Common.Core;
using Microsoft.Practices.CompositeUI.EventBroker;
using Katrin.Win.Infrastructure;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Katrin.Win.MainModule.Views.ProjectIteration
{
    public partial class ProjectIterationListView : RecordListView
    {

        [EventPublication("EditProjectIteration", PublicationScope.WorkItem)]
        public event EventHandler<EventArgs<Guid>> EditProjectIteration;

        public void OnEditProjectIteration(EventArgs<Guid> e)
        {
            EventHandler<EventArgs<Guid>> handler = EditProjectIteration;
            if (handler != null) handler(this, e);
        }

        [EventPublication("DeleteProjectIteration", PublicationScope.WorkItem)]
        public event EventHandler<EventArgs<Guid>> DeleteProjectIteration;

        public void OnDeleteProjectIteration(EventArgs<Guid> e)
        {
            DialogResult dialogResult = XtraMessageBox.Show(this, Properties.Resources.DeleteProjectIterationTip,
                  Properties.Resources.Katrin,
                   MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Question,
                   MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.OK)
            {
                EventHandler<EventArgs<Guid>> handler = DeleteProjectIteration;
                if (handler != null) handler(this, e);
            }
        }

        public ProjectIterationListView()
        {
            RegisterPoupMenuItem("Edit", "Edit", ProjectIteration =>
                                                     {
                                                         Guid id = ProjectIteration.AsDyanmic().ProjectIterationId;
                                                         OnEditProjectIteration(new EventArgs<Guid>(id));
                                                     });
            RegisterPoupMenuItem("Delete", "Delete", ProjectIteration =>
                                                         {
                                                             Guid id = ProjectIteration.AsDyanmic().ProjectIterationId;
                                                             OnDeleteProjectIteration(new EventArgs<Guid>(id));
                                                         });

           
            SetRowHighlight();

        }

        private void SetRowHighlight()
        {
            GridView gridView = EntityGridView as GridView;
            if (gridView != null)
            {
                gridView.CustomDrawCell += (s, e) =>
                    {
                        GridView view = s as GridView;
                        object projectiteration = view.GetRow(e.RowHandle);
                        if (projectiteration == null) return;
                        var dyanmic = projectiteration.AsDyanmic();
                        DateTime? startDate = dyanmic.StartDate;
                        DateTime? endDate = dyanmic.Deadline;
                        Brush interestBrush = new SolidBrush(Color.FromArgb(235, 236, 240));
                        if (startDate <= DateTime.Today && endDate >= DateTime.Today)
                        {
                            interestBrush = new SolidBrush(Color.FromArgb(240,226,181));
                        }
                        Rectangle r = e.Bounds;
                        Rectangle ri = new Rectangle(r.X, r.Y, r.Width+5, r.Height);
                        e.Graphics.FillRectangle(interestBrush, ri);
                    };
            }
        }

        protected override void EntityGridViewDoubleClick(object sender, EventArgs e)
        {
            base.EntityGridViewDoubleClick(sender, e);
            var view = (ColumnView)sender;
            var pt = view.GridControl.PointToClient(MousePosition);

            var gridView = view as GridView;
            if (gridView == null) return;
            
            GridHitInfo info = gridView.CalcHitInfo(pt);
            if (!info.InRow && !info.InRowCell)
                return;
            Guid id = SelectedEntity.AsDyanmic().ProjectIterationId;
            OnEditProjectIteration(new EventArgs<Guid>(id));
        }
    }
}
