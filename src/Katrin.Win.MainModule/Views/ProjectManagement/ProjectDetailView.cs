using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.Common.Core;
using Microsoft.Practices.ObjectBuilder;
using Katrin.Win.Common.MetadataServiceReference;
using Katrin.Win.MainModule.Views.Opportunity;
using Katrin.Win.MainModule.Views.Contract;
using Katrin.Win.MainModule.Views.Account;
using System.Collections;
using Katrin.Win.Common.Controls;
using DevExpress.XtraCharts;

namespace Katrin.Win.MainModule.Views.ProjectManagement
{
    public partial class ProjectDetailView : AbstractDetailView, IProjectDetailView
    {
        private ProjectDetailPresenter _presenter;
        public event EventHandler<Katrin.Win.Infrastructure.EventArgs<Guid>> ContractEditValueChanged;

        [CreateNew]
        public ProjectDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        public ProjectDetailView()
        {
            InitializeComponent();
        }



        public override void InitValidation()
        {
            SetValidationRule(NameTextEdit, ValidationRules.IsNotBlankRule(ItemForName.Text));
            SetValidationRule(StatusCodeLookUpEdit, ValidationRules.IsNotZeroRule(ItemForStatus.Text));
        }

        public void BindStatisticNumber(List<ProjectSummary> statisticNumberList)
        {
            StatisticNumberBindingSource.DataSource = statisticNumberList;
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
            StatusCodeLookUpEdit.BindPickList(entity);
            string defaultLayoutPath = "Katrin.Win.MainModule.DefaultLayout";
            ManagerSearchLookUpEdit.InitEdit("User", "Department", false);
            ContractIdSearchLookUpEdit.Bind(entity);
            ContractIdSearchLookUpEdit.AddDetailButton<ContractDetailView>(OpenDetail, "Contract");
            CustomerIdSearchLookUpEdit.Bind(entity);
            CustomerIdSearchLookUpEdit.AddDetailButton<AccountDetailView>(OpenDetail, "Account");
            projectTypeCodeLookUpEdit.BindPickList(entity);
            technologyCodeLookUpEdit.BindPickList(entity);
            probabilityLookUpEdit.BindPickList(entity);
            OwnerIdSearchLookUpEdit.InitEdit("User", "Department", false);
        }


        public ArrayList SelectedProjectMember
        {
            get { return ProjectMemberGridLookUpEdit.Properties.GridSelection.Selection; }
        }

        public void BindProjectMember(List<Guid> selectedProjectMember)
        {
            ProjectMemberGridLookUpEdit.Properties.DisplayMember = "FullName";
            ProjectMemberGridLookUpEdit.Properties.View.OptionsSelection.MultiSelect = true;
            ProjectMemberGridLookUpEdit.Properties.BindDataAsync("User", "UserId", selectedProjectMember);
        }

        private void ContractIdSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (ContractIdSearchLookUpEdit.EditValue == null) return;
            if (string.IsNullOrEmpty(ContractIdSearchLookUpEdit.EditValue.ToString())) return;
            if (ContractEditValueChanged == null) return;
            var contractId = (Guid) ContractIdSearchLookUpEdit.EditValue;
            ContractEditValueChanged(sender, new Infrastructure.EventArgs<Guid>(contractId));
        }
    }
}
