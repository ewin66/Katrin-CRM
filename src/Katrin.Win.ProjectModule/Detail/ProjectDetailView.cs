using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.Utils;
namespace Katrin.Win.ProjectModule.Detail
{
    public partial class ProjectDetailView : DetailView, IProjectDetailView
    {
        public event EventHandler<EventArgs<Guid>> ContractEditValueChanged;

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
            ManagerSearchLookUpEdit.InitEdit("User", "Department", false);
            ContractIdSearchLookUpEdit.Bind(entity);
            ContractIdSearchLookUpEdit.AddDetailButton("Contract");
            CustomerIdSearchLookUpEdit.Bind(entity);
            CustomerIdSearchLookUpEdit.AddDetailButton("Account");
            projectTypeCodeLookUpEdit.BindPickList(entity);
            technologyCodeLookUpEdit.BindComboBoxList(entity, "TechnologyCode");
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
            ProjectMemberGridLookUpEdit.Properties.BindDataAsync("User", "UserId", selectedProjectMember);
            ProjectMemberGridLookUpEdit.Properties.View.OptionsSelection.MultiSelect = true;
        }

        private void ContractIdSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (ContractIdSearchLookUpEdit.EditValue == null) return;
            if (string.IsNullOrEmpty(ContractIdSearchLookUpEdit.EditValue.ToString())) return;
            if (ContractEditValueChanged == null) return;
            var contractId = (Guid)ContractIdSearchLookUpEdit.EditValue;
            ContractEditValueChanged(sender, new EventArgs<Guid>(contractId));
        }
    }
}
