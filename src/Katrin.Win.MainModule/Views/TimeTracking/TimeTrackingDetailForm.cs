using System;
using System.Linq;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using Katrin.Win.Common.MetadataServiceReference;
using Microsoft.Practices.ObjectBuilder;


namespace Katrin.Win.MainModule.Views.TimeTracking
{

    public partial class TimeTrackingDetailForm : XtraForm, ITimeTrackingDetail
    {
        private TimeTrackingDetailPresenter _presenter;

        public TimeTrackingDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
            get { return _presenter; }
        }

        public event EventHandler Saved;

        public void OnSaved(EventArgs e)
        {
            EventHandler handler = Saved;
            if (handler != null) handler(this, e);
        }

        public TimeTrackingDetailForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            OnSaved(e);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void SetViewDialogResult()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
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
            TypeCodeLookUpEdit.BindPickList(entity);
        }

        public void Bind(object entity)
        {
            timeTrackingBindingSource.DataSource = entity;
        }

        public void PostEditors()
        {
        }


        public void Close(System.Windows.Forms.DialogResult result)
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


        public string EntityName
        {
            get;
            set;
        }
    }
}
