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
using Microsoft.Practices.CompositeUI.SmartParts;
using DevExpress.Data.Filtering;

namespace Katrin.Win.MainModule.Views.ProjectWeekReport
{
    [SmartPart]
    public partial class ProjectWeekReportDetailView : AbstractDetailView, IProjectWeekReportDetailView
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
            string defaultLayoutPath = "Katrin.Win.MainModule.DefaultLayout";
            CurrentProgressCodeLookUpEdit.BindPickList(entity);
            OutlookProgressCodeLookUpEdit.BindPickList(entity);
            CurrentQualityCodeLookUpEdit.BindPickList(entity);
            OutlookQualityCodeLookUpEdit.BindPickList(entity);
            ProjectSearchLookUpEdit.Bind(entity);
            ProjectIterationSearchLookUpEdit.Bind(entity);
        }

        private void ProjectSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (ProjectSearchLookUpEdit.EditValue != null)
            {
                Guid projectId = (Guid)ProjectSearchLookUpEdit.EditValue;
                if (projectId != Guid.Empty)
                {
                    ProjectIterationSearchLookUpEdit.ReloadData(new BinaryOperator("ProjectId",projectId));
                    EntityBindingSource.Current.AsDyanmic().ProjectId = projectId;
                    if(sender.AsDyanmic().Tag != null)
                    EntityBindingSource.Current.AsDyanmic().ProjectIterationId = Guid.Empty;
                    sender.AsDyanmic().Tag = e;
                }
            }
        }
    }
}
