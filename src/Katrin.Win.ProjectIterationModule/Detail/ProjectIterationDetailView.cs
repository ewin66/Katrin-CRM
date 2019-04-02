using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Data.Filtering;
using Katrin.AppFramework.Utils;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.Extensions;
namespace Katrin.Win.ProjectIterationModule.ProjectIteration
{
    public partial class ProjectIterationDetailView : DetailView, IProjectIterationDetailView
    {
        public event EventHandler<EventArgs<Guid>> OnProjectChange;
        public event EventHandler<EventArgs<Guid>> OnVersionChange;


        public ProjectIterationDetailView()
        {
            InitializeComponent();
        }

        public void SetProjectEable(bool enable)
        {
            ProjectSearchLookUpEdit.Enabled = enable;
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
            ProjectSearchLookUpEdit.Bind(entity);
            VersionNumberSearchLookUpEdit.Bind(entity);
            statusLookUpEdit.BindPickList(entity);
        }

        public override void InitValidation()
        {

            SetValidationRule(NameTextEdit, ValidationRules.IsNotBlankRule(ItemForName.Text));
            SetValidationRule(ProjectSearchLookUpEdit, ValidationRules.IsNotBlankRule(itemforproject.Text));
            SetValidationRule(ProjectSearchLookUpEdit, ValidationRules.IsGuidNotBlankRule(itemforproject.Text));
            SetValidationRule(StartDateEdit, ValidationRules.IsNotBlankRule(itemForStartDate.Text));
            SetValidationRule(EndDateEdit, ValidationRules.IsNotBlankRule(itemForEndTime.Text));
        }

        public bool ValidateResult { get; set; }
        public override bool ValidateData()
        {
            bool result = base.ValidateData();
            return result && ValidateResult;
        }

        private void ProjectSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (ProjectSearchLookUpEdit.EditValue == null) return;
            Guid projectId = Guid.Empty;
            if (ProjectSearchLookUpEdit.EditValue != System.DBNull.Value)
                projectId = (Guid)ProjectSearchLookUpEdit.EditValue;
            if (projectId != Guid.Empty)
            {
                CriteriaOperator filter = new BinaryOperator("ProjectId", projectId);
                VersionNumberSearchLookUpEdit.ReLoadData(filter, "ProjectVersion");
            }
            var projectIteration = (Katrin.Domain.Impl.ProjectIteration)EntityBindingSource.Current;
            if (projectIteration == null) return;
            projectIteration.ProjectId = projectId;
            if (string.IsNullOrEmpty(ProjectSearchLookUpEdit.EditValue.ToString())) return;
            EventHandler<EventArgs<Guid>> handler = OnProjectChange;
            if (handler == null) return;
            
            handler(sender, new EventArgs<Guid>(projectId));

        }
        private void VersionNameSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (VersionNumberSearchLookUpEdit.EditValue == null) return;
            if (string.IsNullOrEmpty(VersionNumberSearchLookUpEdit.EditValue.ToString())) return;
            EventHandler<EventArgs<Guid>> handler = OnVersionChange;
            if (handler == null) return;
            Guid projectId = (Guid)VersionNumberSearchLookUpEdit.EditValue;
            handler(sender, new EventArgs<Guid>(projectId));
        }
    }
}
