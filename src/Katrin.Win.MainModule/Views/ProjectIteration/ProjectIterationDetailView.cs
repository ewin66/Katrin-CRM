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
using DevExpress.Data.Filtering;
namespace Katrin.Win.MainModule.Views.ProjectIteration
{
    [SmartPart]
    public partial class ProjectIterationDetailView : AbstractDetailView, IProjectIterationDetailView
    {
        public event EventHandler<EventArgs<Guid>> OnProjectChange;
        public event EventHandler<EventArgs<Guid>> OnVersionChange;
        private ProjectIterationDetailPresenter _presenter;

        [CreateNew]
        public ProjectIterationDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

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
            string layoutResourceNamespace = "Katrin.Win.MainModule.DefaultLayout";
            ProjectSearchLookUpEdit.Bind(entity);
            VersionNumberSearchLookUpEdit.Bind(entity);
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
                VersionNumberSearchLookUpEdit.ReloadData(filter);
            }

            if (string.IsNullOrEmpty(ProjectSearchLookUpEdit.EditValue.ToString())) return;
            EventHandler<EventArgs<Guid>> handler = OnProjectChange;
            if (handler == null) return;
            //Guid projectId = (Guid)ProjectSearchLookUpEdit.EditValue;
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
