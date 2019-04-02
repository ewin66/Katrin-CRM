using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.WinForms.ViewInterface;

namespace Katrin.Win.NoteModule.Note
{

    public partial class NoteDetailForm : XtraForm, INoteDetailForm, IView
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
            this.Close();
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

        public void SetEditorStatus(bool isReadOnly)
        {
        }

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

        public event EventHandler ObjectChanged;

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

        public void ShowView()
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


        public Guid WorkSpaceID
        {
            get;
            set;
        }

        private void NoteDetailForm_Load(object sender, EventArgs e)
        {

        }


        public AppFramework.WinForms.Context.IWorkSpaceContext Context
        {
            get;
            set;
        }

        private void NoteDetailForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
