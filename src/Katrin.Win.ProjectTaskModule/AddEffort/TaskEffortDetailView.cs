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
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.MetadataServiceReference;
namespace Katrin.Win.ProjectTaskModule.AddEffort
{
    public partial class TaskEffortDetailView : DetailView, ITaskEffortDetailView
    {
        public event EventHandler OnCreateData;
        public event EventHandler<EventArgs<int>> OnDeleteData;

        //public TaskEffortDetailPresenter Presenter
        //{
        //    set
        //    {
        //        _presenter = value;
        //        _presenter.View = this;
        //    }
        //}

        public TaskEffortDetailView()
        {
            InitializeComponent();
            RecordOnDateEdit.DateTimeChanged += RecordOnDateEdit_DateTimeChanged;
        }

        void RecordOnDateEdit_DateTimeChanged(object sender, EventArgs e)
        {

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
        }

        public void BindGrid(object listDataSource)
        {
            ListBindSource.DataSource = listDataSource;
            gridView1.RefreshData();
        }


        private void RepositoryItem_EditValueChanged(object sender, EventArgs e)
        {
            OnObjectChanged(e);
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
                handler(sender, new EventArgs<int>(rowIndex));

        }

        private void ActualInputTextEdit_Click(object sender, EventArgs e)
        {
            if (ActualInputTextEdit.Value <= 0)
                ActualInputTextEdit.SelectAll();
        }

        private void EffortTextEdit_Click(object sender, EventArgs e)
        {
            if (EffortTextEdit.Value <= 0)
                EffortTextEdit.SelectAll();
        }

        private void OverTimeTextEdit_Click(object sender, EventArgs e)
        {
            if (OverTimeTextEdit.Value <= 0)
                OverTimeTextEdit.SelectAll();
        }
    }
}
