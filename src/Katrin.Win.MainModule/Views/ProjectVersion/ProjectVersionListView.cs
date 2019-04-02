using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.Common.Core;
using Katrin.Win.Infrastructure;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Practices.CompositeUI.EventBroker;

namespace Katrin.Win.MainModule.Views.ProjectVersion
{

    public partial class ProjectVersionListView : RecordListView
    {

        [EventPublication("EditProjectVersion", PublicationScope.WorkItem)]
        public event EventHandler<EventArgs<Guid>> EditProjectVersion;

        public void OnEditProjectVersion(EventArgs<Guid> e)
        {
            EventHandler<EventArgs<Guid>> handler = EditProjectVersion;
            if (handler != null) handler(this, e);
        }

        [EventPublication("DeleteProjectVersion", PublicationScope.WorkItem)]
        public event EventHandler<EventArgs<Guid>> DeleteProjectVersion;

        public void OnDeleteProjectVersion(EventArgs<Guid> e)
        {
            DialogResult dialogResult = XtraMessageBox.Show(this, Properties.Resources.DeleteProjectVersionTip,
                  Properties.Resources.Katrin,
                   MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Question,
                   MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.OK)
            {
                EventHandler<EventArgs<Guid>> handler = DeleteProjectVersion;
                if (handler != null) handler(this, e);
            }
        }

        public ProjectVersionListView()
        {
            RegisterPoupMenuItem("Edit", "Edit", ProjectVersion =>
            {
                Guid id = ProjectVersion.AsDyanmic().ProjectVersionId;
                OnEditProjectVersion(new EventArgs<Guid>(id));
            });
            RegisterPoupMenuItem("Delete", "Delete", ProjectVersion =>
            {
                Guid id = ProjectVersion.AsDyanmic().ProjectVersionId;
                OnDeleteProjectVersion(new EventArgs<Guid>(id));
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
                    object projectVersion = view.GetRow(e.RowHandle);
                    if (projectVersion == null) return;
                    Brush interestBrush = new SolidBrush(Color.FromArgb(235, 236, 240));
                    Rectangle r = e.Bounds;
                    Rectangle ri = new Rectangle(r.X, r.Y, r.Width + 5, r.Height);
                    e.Graphics.FillRectangle(interestBrush, ri);
                };
            }
        }
    }
}
