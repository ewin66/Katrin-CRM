using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.ContractModule.Detail;
using Katrin.Win.AccountModule.Detail;
using DevExpress.Data.Filtering;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.WinForms.Extensions;

namespace Katrin.Win.ProjectWeekReportModule.Detail
{
    public partial class ProjectWeekReportDetailView : DetailView, IProjectWeekReportDetailView
    {
      
        public event EventHandler<EventArgs<Guid>> ContractEditValueChanged;
      
        public ProjectWeekReportDetailView()
        {
            InitializeComponent();
        }

        public override void InitValidation()
        {
            SetValidationRule(NameTextEdit, ValidationRules.IsNotBlankRule(ItemForName.Text));
            SetValidationRule(ProjectSearchLookUpEdit, ValidationRules.IsNotBlankRule(itemforproectId.Text));
            SetValidationRule(ProjectSearchLookUpEdit, ValidationRules.IsGuidNotBlankRule(itemforproectId.Text));
            SetValidationRule(ProjectIterationSearchLookUpEdit, ValidationRules.IsNotBlankRule(itemforprojectiterationId.Text));
            SetValidationRule(ProjectIterationSearchLookUpEdit, ValidationRules.IsGuidNotBlankRule(itemforprojectiterationId.Text));
        }

        public void SetRichEdit()
        {
            CriteriaProgressRichEditControl.Views.SimpleView.Padding = new Padding(1);
            CriteriaQualityRichEditControl.Views.SimpleView.Padding = new Padding(1);
            SuggestionsRichEditControl.Views.SimpleView.Padding = new Padding(1);
            ReviewsRichEditControl.Views.SimpleView.Padding = new Padding(1);
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
            CurrentProgressCodeLookUpEdit.BindPickList(entity);
            CurrentProgressCodeLookUpEdit.BindPickList(entity);
            OutlookProgressCodeLookUpEdit.BindPickList(entity);
            CurrentQualityCodeLookUpEdit.BindPickList(entity);
            OutlookQualityCodeLookUpEdit.BindPickList(entity);
            ProjectSearchLookUpEdit.Bind(entity);
            ProjectIterationSearchLookUpEdit.Bind(entity);
        }

        private void ProjectSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (ProjectSearchLookUpEdit.EditValue == null) return;
            if(string.IsNullOrEmpty(ProjectSearchLookUpEdit.EditValue.ToString())) return;
            
            Guid projectId = (Guid)ProjectSearchLookUpEdit.EditValue;
            if (projectId != Guid.Empty)
            {
                ProjectIterationSearchLookUpEdit.ReLoadData(new BinaryOperator("ProjectId", projectId), "ProjectIteration");

                ((Katrin.Domain.Impl.ProjectWeekReport)EntityBindingSource.Current).ProjectId = projectId;

                if (ProjectSearchLookUpEdit.Tag != null)
                    ((Katrin.Domain.Impl.ProjectWeekReport)EntityBindingSource.Current).ProjectIterationId = Guid.Empty;
                ProjectSearchLookUpEdit.Tag = e;
            }
            
        }
    }
}
