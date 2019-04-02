using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework;
using Katrin.AppFramework.WinForms.Messages;
namespace Katrin.Win.ProjectTaskModule.EditEffort
{
    public partial class ManageEffortDetailView : DetailView, IManageEffortDetailView
    {

        public event EventHandler OnCreateData;
        public event EventHandler<EventArgs<int>> OnDeleteData;

        public ManageEffortDetailView()
        {
            InitializeComponent();
            EventAggregationManager.AddListener(this);
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
        }

        public override void InitValidation()
        {

        }

        public bool ValidateResult { get; set; }
        public override bool ValidateData()
        {
            return ValidateResult;
        }

        public override void PostEditors()
        {
            gridView1.PostEditor();
            base.PostEditors();
        }


        public override void Bind(object entity)
        {
            EntityBindingSource.DataSource = entity;
            gridView1.RefreshData();
        }


        private void RepositoryItem_EditValueChanged(object sender, EventArgs e)
        {
            OnObjectChanged(e);
        }

        private void RepositoryItem_Click(object sender, EventArgs e)
        {
            if (sender is SpinEdit)
            {
                var spinEdit = (SpinEdit)sender;
                if (spinEdit.Value <= 0)
                    spinEdit.SelectAll();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            EventHandler handler = OnCreateData;
            if (handler != null)
                handler(sender, e);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (gridView1.GetSelectedRows().Count() <= 0) return;
            int rowIndex = gridView1.GetSelectedRows()[0];
            EventHandler<EventArgs<int>> handler = OnDeleteData;
            if (handler != null)
            {
                handler(sender, new EventArgs<int>(rowIndex));
                OnObjectChanged(e);
            }

        }

        #region IView
        public AppFramework.WinForms.MVC.IControllerManager ControllerManager
        {
            get;
            set;
        }

        public bool IsChildForm
        {
            get;
            set;
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

        public void ActiveView()
        {

        }

        public void CloseView()
        {

        }
        #endregion


    }
}
