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
using Katrin.AppFramework.WinForms.Context;
namespace Katrin.Win.ProjectTaskModule.Detail
{
    public partial class ProjectTaskDetailView : DetailView, IProjectTaskDetailView
    {
        public event EventHandler<EventArgs<Guid>> OnProjectChange;
        private ActionContext _context;
        public ActionContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new ActionContext();
                }
                return _context;
            }
        }

        public ProjectTaskDetailView()
        {
            InitializeComponent();
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
            ProjectSearchLookUpEdit.Bind(entity);
            ProjectIterationSearchLookUpEdit.Bind(entity, new BinaryOperator("StatusCode", 2, BinaryOperatorType.NotEqual));
            ProjectModuleSearchLookUpEdit.Bind(entity);
            ProjectIterationSearchLookUpEdit.Properties.ReadOnly = true;
            ProjectModuleSearchLookUpEdit.Properties.ReadOnly = true;
            OwnerIdLookUpEdit.Bind(entity);
            StatusCodeLookUpEdit.BindPickList(entity);
            priorityLookUpEdit.BindPickList(entity);
            taskCategoryCodeLookUpEdit.BindPickList(entity);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public override void InitValidation()
        {

            SetValidationRule(NameTextEdit, ValidationRules.IsNotBlankRule(ItemForName.Text));
            SetValidationRule(ProjectSearchLookUpEdit, ValidationRules.IsNotBlankRule(itemforproject.Text));
            SetValidationRule(ProjectSearchLookUpEdit, ValidationRules.IsGuidNotBlankRule(itemforproject.Text));
            SetValidationRule(StatusCodeLookUpEdit, ValidationRules.IsNotZeroRule(itemforstatus.Text));
        }

        private void ActualWorkHoursTextEdit_EditValueChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(ActualWorkHoursTextEdit.Text))
            {
                var projectTask = (Katrin.Domain.Impl.ProjectTask)EntityBindingSource.Current;
                string actualWorkHours = ActualWorkHoursTextEdit.Text;
                if (actualWorkHours.Contains('_'))
                {
                    actualWorkHours = actualWorkHours.Substring(0, actualWorkHours.Length - 1);
                }
                if (projectTask != null)
                    projectTask.ActualWorkHours = Convert.ToDouble(actualWorkHours);
                if (string.IsNullOrEmpty(EffortTextEdit.Text))
                    projectTask.Effort = 0d;
                if (projectTask != null)
                    projectTask.RemainderTime = Convert.ToDouble(projectTask.ActualWorkHours) - Convert.ToDouble(projectTask.Effort);

            }
        }

        public void SetProjectEable(bool enable)
        {
            ProjectSearchLookUpEdit.Enabled = enable;
        }

        private void ProjectSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            ProjectIterationSearchLookUpEdit.Properties.ReadOnly = true;
            ProjectModuleSearchLookUpEdit.Properties.ReadOnly = true;

            if (ProjectSearchLookUpEdit.EditValue == null)
            {
                ProjectSearchLookUpEdit.EditValue = Guid.Empty;
            }
            if (string.IsNullOrEmpty(ProjectSearchLookUpEdit.EditValue.ToString())) return;
            Guid projectId = projectId = (Guid)ProjectSearchLookUpEdit.EditValue;
            if (projectId == Guid.Empty) return;




            ProjectIterationSearchLookUpEdit.Properties.ReadOnly = false;
            ProjectModuleSearchLookUpEdit.Properties.ReadOnly = false;

            // owner reload data
            EventHandler<EventArgs<Guid>> handler = OnProjectChange;
            if (handler != null) handler(OwnerIdLookUpEdit, new EventArgs<Guid>(projectId));

            var taskEntity = (Katrin.Domain.Impl.ProjectTask)EntityBindingSource.Current;
            taskEntity.ProjectId = projectId;

            // iteration reload data
            CriteriaOperator filter = (new BinaryOperator("ProjectId", projectId));
            filter &= new BinaryOperator("StatusCode", 2, BinaryOperatorType.NotEqual);
            if (taskEntity.ProjectIterationId != null && taskEntity.ProjectIterationId != Guid.Empty)
                filter |= new BinaryOperator("ProjectIterationId", taskEntity.ProjectIterationId ?? Guid.Empty, BinaryOperatorType.Equal);
            ProjectIterationSearchLookUpEdit.ReLoadData(filter, "ProjectIteration");

            // iteration reload data
            ProjectModuleSearchLookUpEdit.ReLoadData(new BinaryOperator("ProjectId", projectId), "ProjectModule");

            CriteriaOperator theOperator = Context.GetFilter("ProjectIterationId");
            if (theOperator == null) return;
            if (!(theOperator is BinaryOperator)) return;
            OperandValue operandValue = ((BinaryOperator)theOperator).RightOperand as OperandValue;
            if (operandValue.Value is Guid)
            {
                ((Katrin.Domain.Impl.ProjectTask)EntityBindingSource.Current).ProjectIterationId = (Guid)operandValue.Value;
            }
        }

        private void QuoteWorkHoursTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            var projectTask = (Katrin.Domain.Impl.ProjectTask)EntityBindingSource.Current;
            bool actualNull = true;
            if (QuoteWorkHoursTextEdit.EditValue == null) return;
            actualNull = ActualWorkHoursTextEdit.EditValue == null;
            actualNull = !actualNull ? projectTask.ActualWorkHours <= 0 : actualNull;
            actualNull = !actualNull && QuoteWorkHoursTextEdit.OldEditValue != null ?
                double.Parse(ActualWorkHoursTextEdit.EditValue.ToString())
                == double.Parse(QuoteWorkHoursTextEdit.OldEditValue.ToString()) : actualNull;
            projectTask.QuoteWorkHours = double.Parse(QuoteWorkHoursTextEdit.EditValue.ToString());
            if (actualNull)
            {
                ActualWorkHoursTextEdit.EditValue = QuoteWorkHoursTextEdit.EditValue;
            }
        }

        public override void Bind(object entity)
        {
            base.Bind(entity);
            this.DescriptionRichEdit.DataBindings.Clear();
            this.DescriptionRichEdit.DataBindings.Add(new System.Windows.Forms.Binding("HtmlText", this.EntityBindingSource, "Description", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            SetContextProject();
        }

        private void SetContextProject()
        {

            if (EntityBindingSource.Current == null) return;
            CriteriaOperator theOperator = Context.GetFilter("ProjectId");
            if (theOperator == null) return;
            if (!(theOperator is BinaryOperator)) return;
            OperandValue operandValue = ((BinaryOperator)theOperator).RightOperand as OperandValue;
            if (operandValue.Value is Guid)
            {
                ((Katrin.Domain.Impl.ProjectTask)EntityBindingSource.Current).ProjectId = (Guid)operandValue.Value;
            }

        }

        private void QuoteWorkHoursTextEdit_Click(object sender, EventArgs e)
        {
            if (QuoteWorkHoursTextEdit.Value <= 0)
                QuoteWorkHoursTextEdit.SelectAll();
        }

        private void ActualWorkHoursTextEdit_Click(object sender, EventArgs e)
        {
            if (ActualWorkHoursTextEdit.Value <= 0)
                ActualWorkHoursTextEdit.SelectAll();
        }
    }
}
