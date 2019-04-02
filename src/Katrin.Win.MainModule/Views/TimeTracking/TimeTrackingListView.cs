using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.Infrastructure;
using DevExpress.XtraEditors;
using Katrin.Win.Common.Core;
using Katrin.Win.Common;
using CABDevExpress.SmartPartInfos;
using Katrin.Win.Common.Constants;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Practices.CompositeUI.EventBroker;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;

namespace Katrin.Win.MainModule.Views.TimeTracking
{
    public partial class TimeTrackingListView : RecordListView
    {
        public override void Bind(string entityName)
        {
            base.Bind(entityName);
            var gridView = EntityGridView as GridView;
            if (gridView != null && gridView.GroupSummary.Count > 1)
            {
                gridView.GroupSummary[1].DisplayFormat = GetLocalizedCaption("Effort") + ":(Sum={0:#.##})";
            }
        }

        [EventPublication("EditTimeTracking", PublicationScope.WorkItem)]
        public event EventHandler<EventArgs<Guid>> EditTimeTracking;

        public void OnEditTimeTracking(EventArgs<Guid> e)
        {
            EventHandler<EventArgs<Guid>> handler = EditTimeTracking;
            if (handler != null) handler(this, e);
        }

        [EventPublication("DeleteTimeTracking", PublicationScope.WorkItem)]
        public event EventHandler<EventArgs<Guid>> DeleteTimeTracking;

        public void OnDeleteTimeTracking(EventArgs<Guid> e)
        {
            DialogResult dialogResult = XtraMessageBox.Show(this, Properties.Resources.DeleteTimingTip,
                  Properties.Resources.Katrin,
                   MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Question,
                   MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.OK)
            {
                EventHandler<EventArgs<Guid>> handler = DeleteTimeTracking;
                if (handler != null) handler(this, e);
            }
        }

        public TimeTrackingListView()
        {
            RegisterPoupMenuItem("Edit", "Edit", time =>
                                                     {
                                                         Guid id = time.AsDyanmic().TimeTrackingId;
                                                         OnEditTimeTracking(new EventArgs<Guid>(id));
                                                     });
            RegisterPoupMenuItem("Delete", "Delete", time =>
                                                         {
                                                             Guid id = time.AsDyanmic().TimeTrackingId;
                                                             OnDeleteTimeTracking(new EventArgs<Guid>(id));
                                                         });
        }
    }
}
