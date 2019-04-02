using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.MetadataServiceReference;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Katrin.Win.Infrastructure;
namespace Katrin.Win.MainModule.Views.ProjectTask
{
    [SmartPart]
    public partial class NewTaskEffortDetailView : AbstractDetailView, INewTaskEffortDetailView
    {
        private NewTaskEffortDetailPresenter _presenter;
        public event EventHandler OnCreateData;
        public event EventHandler<EventArgs<int>> OnDeleteData;

        [CreateNew]
        public NewTaskEffortDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

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
