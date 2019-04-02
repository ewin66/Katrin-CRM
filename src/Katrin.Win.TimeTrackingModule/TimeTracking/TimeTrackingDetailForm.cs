using System;
using System.Linq;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.WinForms.MVC;
using System.Windows.Forms;


namespace Katrin.Win.TimeTrackingModule.TimeTracking
{

    public partial class TimeTrackingDetailForm : XtraForm, ITimeTrackingDetail
    {

        public event EventHandler Saved;

        public void OnSaved(EventArgs e)
        {
            EventHandler handler = Saved;
            if (handler != null) handler(this, e);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.Dispose();
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

        //public Infrastructure.Services.UserDataPersistenceService UserDataPersistenceService { get; set; }


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

        #region no user
        public DevExpress.XtraBars.Ribbon.RibbonControl GetRibbon()
        {
            return null;
        }

        public IControllerManager ControllerManager
        {
            get;
            set;
        }

        public bool IsChildForm
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        public object Model
        {
            get;
            set;
        }

        public string ViewName
        {
            get;
            set;
        }

        public void BindDataToView()
        {

        }


        public void HideView()
        {

        }


        public void ActiveView()
        {

        }

        public void CloseView()
        {
            Close();
        }

        public string ViewType
        {
            get;
            set;
        }
        public event EventHandler ObjectChanged;
        #endregion




        public Guid WorkSpaceID
        {
            get;
            set;
        }


        public AppFramework.WinForms.Context.IWorkSpaceContext Context
        {
            get;
            set;
        }

        private void TimeTrackingDetailForm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }

    public class DropDownDateEdit : DateEdit
    {
        bool _isPopupOpen;
        public DropDownDateEdit()
        {
            this.MouseUp += (sender, e) =>
            {
                if (_isPopupOpen && !this.IsPopupOpen)
                {
                    _isPopupOpen = false;
                    this.ClosePopup();
                }
                else
                {
                    _isPopupOpen = true;
                    this.ShowPopup();
                }
            };
            this.Closed += (sender, e) =>
            {
                _isPopupOpen = false;
            };
            this.Popup += (sender, e) =>
            {
                _isPopupOpen = true;
            };
        }
    }
}
