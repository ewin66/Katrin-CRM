using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Katrin.Win.Common.MetadataServiceReference;
using DevExpress.XtraEditors;
using Microsoft.Practices.ObjectBuilder;

namespace Katrin.Win.MainModule.Views.Note
{

    public partial class NoteDetailForm : XtraForm,INoteDetailForm
    {
        private NoteDetailPresenter _presenter;

        public event EventHandler Saved;

        public NoteDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
            get { return _presenter; }
        }

        public void OnSaved(EventArgs e)
        {
            EventHandler handler = Saved;
            if (handler != null) handler(this, e);
        }

        public NoteDetailForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            OnSaved(e);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public void ShowView()
        {
            ShowDialog();
        }

        public bool ValidateData()
        {
            var result = dxValidationProvider.Validate();
            var firstInvalideControl = dxValidationProvider.GetInvalidControls().FirstOrDefault();
            if (firstInvalideControl != null)
            {
                firstInvalideControl.Focus();
            }
            return result;
        }

        public void InitEditors(Entity entity)
        {
        }

        public void Bind(object entity)
        {
            noteBindingSource.DataSource = entity;
        }

        public void PostEditors()
        {
        }

        public bool ShowCheckOptions
        {
            set
            {
                PutNoteChEdit.Visible = value;
                PutNoteDateToModifyEdit.Visible = value;
            }
        }

        public bool UpdateLatestFeadback
        {
            get { return PutNoteDateToModifyEdit.Checked; }
        }

        public bool AppandDescription
        {
            get { return PutNoteChEdit.Checked; }
        }


        public void Close(DialogResult result)
        {
            DialogResult = result;
            Close();
        }

        public void SetEditorStatus(bool isReadOnly)
        {
        }

        public Infrastructure.Services.UserDataPersistenceService UserDataPersistenceService { get; set; }


        public void BeginInit()
        {
        }

        public void EndInit()
        {
        }

        public void SetDescriptionVisible(bool isVisible)
        {
            PutNoteChEdit.Visible = isVisible;
        }

        public void SetModifyEditVisible(bool isVisible)
        {
            PutNoteDateToModifyEdit.Visible = isVisible;
        }

        public string EntityName
        {
            get;
            set;
        }
    }
}
