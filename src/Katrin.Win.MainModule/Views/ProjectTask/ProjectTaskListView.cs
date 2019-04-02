using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Katrin.Win.Common.Core;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using Katrin.Win.Infrastructure;
using DevExpress.XtraGrid.Views.Base;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;
using Katrin.Win.MainModule.Properties;

namespace Katrin.Win.MainModule.Views.ProjectTask
{

    public partial class ProjectTaskListView : EntityListView, IProejctTaskFilter
    {
        private ProjectTaskListPresenter _presenter;

        [CreateNew]
        public ProjectTaskListPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        public ProjectTaskListView()
        {
            InitializeComponent();
            this.TopPanel.Visible = true;
            this.TopPanel.Controls.Add(this.layountContrl);
        }

        protected override void BindData()
        {
            _presenter.UpdateContextFilters();
            EntityName = "ProjectTask";
            base.BindData();
        }

        void IProejctTaskFilter.BindData()
        {
            BindData();
        }

        private void BindLookUp(LookUpEdit lookUp, List<LookupListItem<Guid?>> dataSource)
        {
            lookUp.Properties.InitializeLookUpEdit(dataSource);
            lookUp.Properties.AllowNullInput = DefaultBoolean.True;
            lookUp.Properties.NullText = Resources.All;
        }

        public void BindProjectLookUp(List<LookupListItem<Guid?>> projectDataSource)
        {
            BindLookUp(ProjectSearchLookUpEdit, projectDataSource);
        }

        public void BindIterationLookUp(List<LookupListItem<Guid?>> iterationDataSource)
        {
            BindLookUp(ProjectIterationSearchLookUpEdit, iterationDataSource);
        }

        public void BindMemberLookUp(List<LookupListItem<Guid?>> memberDataSource)
        {
            BindLookUp(memberLookUp, memberDataSource);
        }

        private void ProjectSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            BeginUpdate();
            _presenter.OnProjectChanged(ProjectId);
            EndUpdate();
            BindData();
        }

        private void ProjectIterationSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void memberLookUp_EditValueChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private Guid? GetValue(object value)
        {
            if (Convert.IsDBNull(value)) return null;
            return (Guid?)value;
        }

        public Guid? ProjectId
        {
            get
            {
                return GetValue(ProjectSearchLookUpEdit.EditValue);
            }
            set
            {
                ProjectSearchLookUpEdit.EditValue = value;
            }
        }

        public Guid? ProjectIterationId
        {
            get
            {
                return GetValue(ProjectIterationSearchLookUpEdit.EditValue);
            }
            set
            {
                ProjectIterationSearchLookUpEdit.EditValue = value;
            }
        }

        public Guid? MemberId
        {
            get
            {
                return GetValue(memberLookUp.EditValue);
            }
            set
            {
                memberLookUp.EditValue = value;
            }
        }


        public void InitFilters()
        {
            _presenter.InitFilters();
        }


        public void BeginUpdate()
        {
            this.ProjectSearchLookUpEdit.EditValueChanged -= new System.EventHandler(this.ProjectSearchLookUpEdit_EditValueChanged);
            this.ProjectIterationSearchLookUpEdit.EditValueChanged -= new System.EventHandler(this.ProjectIterationSearchLookUpEdit_EditValueChanged);
            this.memberLookUp.EditValueChanged -= new System.EventHandler(this.memberLookUp_EditValueChanged);
        }

        public void EndUpdate()
        {
            this.ProjectSearchLookUpEdit.EditValueChanged += new System.EventHandler(this.ProjectSearchLookUpEdit_EditValueChanged);
            this.ProjectIterationSearchLookUpEdit.EditValueChanged += new System.EventHandler(this.ProjectIterationSearchLookUpEdit_EditValueChanged);
            this.memberLookUp.EditValueChanged += new System.EventHandler(this.memberLookUp_EditValueChanged);
        }
    }

    public class ProjectTaskListPresenter : ProjectTaskFilterPresenter<IProejctTaskFilter>
    {
    }
}
