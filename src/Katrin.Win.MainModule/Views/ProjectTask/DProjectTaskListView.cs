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

namespace Katrin.Win.MainModule.Views.ProjectTask
{
    public partial class DProjectTaskListView : RecordListView
    {
        [EventPublication("EditProjectTask", PublicationScope.WorkItem)]
        public event EventHandler<EventArgs<Guid>> EditProjectTask;

        public void OnEditProjectTask(EventArgs<Guid> e)
        {
            EventHandler<EventArgs<Guid>> handler = EditProjectTask;
            if (handler != null) handler(this, e);
        }

        [EventPublication("DeleteProjectTask", PublicationScope.WorkItem)]
        public event EventHandler<EventArgs<Guid>> DeleteProjectTask;

        public void OnDeleteProjectTask(EventArgs<Guid> e)
        {
            DialogResult dialogResult = XtraMessageBox.Show(this, Properties.Resources.DeleteProjectTaskTip,
                  Properties.Resources.Katrin,
                   MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Question,
                   MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.OK)
            {
                EventHandler<EventArgs<Guid>> handler = DeleteProjectTask;
                if (handler != null) handler(this, e);
            }
        }

        public DProjectTaskListView()
        {
            RegisterPoupMenuItem("Edit", "Edit", ProjectTask =>
                                                     {
                                                         Guid id = ProjectTask.AsDyanmic().TaskId;
                                                         OnEditProjectTask(new EventArgs<Guid>(id));
                                                     });
            RegisterPoupMenuItem("Delete", "Delete", ProjectTask =>
                                                         {
                                                             Guid id = ProjectTask.AsDyanmic().TaskId;
                                                             OnDeleteProjectTask(new EventArgs<Guid>(id));
                                                         });
        }
    }
}
