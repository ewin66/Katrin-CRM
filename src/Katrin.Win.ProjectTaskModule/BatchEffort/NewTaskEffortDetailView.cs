using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.MetadataServiceReference;
namespace Katrin.Win.ProjectTaskModule.BatchEffort
{
    public partial class NewTaskEffortDetailView : DetailView, INewTaskEffortDetailView
    {
        public event EventHandler OnCreateData;
        public event EventHandler<EventArgs<int>> OnDeleteData;


        public NewTaskEffortDetailView()
        {
            InitializeComponent();
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
        }
   
        public override void InitValidation()
        {
            
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
    }
}
