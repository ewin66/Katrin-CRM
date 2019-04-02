using System;
using System.Collections.Generic;
using Katrin.Win.Common.Core;
using System.Windows.Forms;
using Katrin.Win.Infrastructure;
using DevExpress.XtraEditors;
using Microsoft.Practices.CompositeUI.EventBroker;

namespace Katrin.Win.MainModule.Views.Note
{
    public class NoteListView : RecordListView
    {
        [EventPublication("EditNote",PublicationScope.WorkItem)]
        public event EventHandler<EventArgs<Guid>> EditNote;

        [EventPublication("DeleteNote", PublicationScope.WorkItem)]
        public event EventHandler<EventArgs<Guid>> DeleteNote;


        public NoteListView()
        {
            RegisterPoupMenuItem("Edit", "Edit", note =>
                                                     {
                                                         Guid noteId = note.AsDyanmic().NoteId;
                                                         OnEditNote(new EventArgs<Guid>(noteId));
                                                     });
            RegisterPoupMenuItem("Delete", "Delete", note =>
                                                         {
                                                             Guid noteId = note.AsDyanmic().NoteId;
                                                             OnDeleteNote(new EventArgs<Guid>(noteId));
                                                         });
        }

        public void OnEditNote(EventArgs<Guid> e)
        {
            EventHandler<EventArgs<Guid>> handler = EditNote;
            if (handler != null) handler(this, e);
        }

        public void OnDeleteNote(EventArgs<Guid> e)
        {
            DialogResult dialogResult = XtraMessageBox.Show(this, Properties.Resources.DeleteNoteTip,
                    Properties.Resources.Katrin,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.OK)
            {
                EventHandler<EventArgs<Guid>> handler = DeleteNote;
                if (handler != null) handler(this, e);
            }
        }

        protected override DevExpress.XtraGrid.Views.Base.ColumnView CreateDataView()
        {
            var layoutView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            return layoutView;
        }

        
    }
}
