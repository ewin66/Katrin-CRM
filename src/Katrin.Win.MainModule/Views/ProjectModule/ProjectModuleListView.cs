using Katrin.Win.Common.Core;
using Katrin.Win.Infrastructure;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Practices.CompositeUI.EventBroker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Katrin.Win.MainModule.Views.ProjectModule
{
    public class ProjectModuleListView : RecordListView
    {
        [EventPublication("EditProjectModule", PublicationScope.WorkItem)]
        public event EventHandler<EventArgs<Guid>> EditProjectModule;

        public void OnEditProjectModule(EventArgs<Guid> e)
        {
            EventHandler<EventArgs<Guid>> handler = EditProjectModule;
            if (handler != null) handler(this, e);
        }

        [EventPublication("DeleteProjectModule", PublicationScope.WorkItem)]
        public event EventHandler<EventArgs<Guid>> DeleteProjectModule;

        public void OnDeleteProjectModule(EventArgs<Guid> e)
        {
            DialogResult dialogResult = XtraMessageBox.Show(this, Properties.Resources.DeleteProjectModuleTip,
                  Properties.Resources.Katrin,
                   MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Question,
                   MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.OK)
            {
                EventHandler<EventArgs<Guid>> handler = DeleteProjectModule;
                if (handler != null) handler(this, e);
            }
        }

        public ProjectModuleListView()
        {
            RegisterPoupMenuItem("Edit", "Edit", ProjectModule =>
            {
                Guid id = ProjectModule.AsDyanmic().ProjectModuleId;
                OnEditProjectModule(new EventArgs<Guid>(id));
            });
            RegisterPoupMenuItem("Delete", "Delete", ProjectModule =>
            {
                Guid id = ProjectModule.AsDyanmic().ProjectModuleId;
                OnDeleteProjectModule(new EventArgs<Guid>(id));
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
                    object projectModule = view.GetRow(e.RowHandle);
                    if (projectModule == null) return;
                    Brush interestBrush = new SolidBrush(Color.FromArgb(235, 236, 240));
                    Rectangle r = e.Bounds;
                    Rectangle ri = new Rectangle(r.X, r.Y, r.Width + 5, r.Height);
                    e.Graphics.FillRectangle(interestBrush, ri);
                };
            }
        }
    }
}
