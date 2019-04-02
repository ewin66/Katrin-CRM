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
namespace Katrin.Win.MainModule.Views.ProjectTask
{
    [SmartPart]
    public partial class ProjectTaskDetailView : AbstractDetailView, IProjectTaskDetailView
    {
        private ProjectTaskDetailPresenter _presenter;
        public event EventHandler<EventArgs<Guid>> OnProjectChange;
        [CreateNew]
        public ProjectTaskDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        public ProjectTaskDetailView()
        {
            InitializeComponent();
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
            string layoutResourceNamespace = "Katrin.Win.MainModule.DefaultLayout";
            ProjectSearchLookUpEdit.Bind(entity);
            ProjectIterationSearchLookUpEdit.Bind(entity);
            ProjectModuleSearchLookUpEdit.Bind(entity);
            OwnerIdLookUpEdit.Bind(entity);
            StatusCodeLookUpEdit.BindPickList(entity);
            priorityLookUpEdit.BindPickList(entity);
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
                var dyanmic = EntityBindingSource.Current.AsDyanmic();
                dyanmic.ActualWorkHours = Convert.ToDouble(ActualWorkHoursTextEdit.Text);
                if (string.IsNullOrEmpty(EffortTextEdit.Text))
                    dyanmic.Effort = 0d;
                dyanmic.RemainderTime = Convert.ToDouble(dyanmic.ActualWorkHours) - Convert.ToDouble(dyanmic.Effort);
                
            }
        }

        public void SetProjectEable(bool enable)
        {
            ProjectSearchLookUpEdit.Enabled = enable;
        }

        private void ProjectSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (ProjectSearchLookUpEdit.EditValue == null) return;

            Guid projectId = projectId = (Guid)ProjectSearchLookUpEdit.EditValue;;
            if (projectId == Guid.Empty) return;


            // iteration reload data
            ProjectIterationSearchLookUpEdit.ReloadData(new BinaryOperator("ProjectId",projectId));

            // iteration reload data
            ProjectModuleSearchLookUpEdit.ReloadData(new BinaryOperator("ProjectId", projectId));
            // owner reload data
            EventHandler<EventArgs < Guid >> handler = OnProjectChange;
            if (handler != null) handler(OwnerIdLookUpEdit, new EventArgs<Guid>(projectId));

            EntityBindingSource.Current.AsDyanmic().ProjectId = projectId;
           
            CriteriaOperator theOperator = Context.GetFilter("ProjectIterationId");
            if (theOperator == null) return;
            if (!(theOperator is BinaryOperator)) return;
            OperandValue operandValue = ((BinaryOperator)theOperator).RightOperand as OperandValue;
            if (operandValue.Value is Guid)
            {
                EntityBindingSource.Current.AsDyanmic().ProjectIterationId = operandValue.Value;
            }
        }

        private void QuoteWorkHoursTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            var dyanmic = EntityBindingSource.Current.AsDyanmic();
            bool actualNull = true;
            if(QuoteWorkHoursTextEdit.EditValue == null) return;
            actualNull = ActualWorkHoursTextEdit.EditValue == null;
            actualNull = !actualNull ? dyanmic.ActualWorkHours <= 0 : actualNull;
            actualNull = !actualNull && QuoteWorkHoursTextEdit.OldEditValue != null ?
                double.Parse(ActualWorkHoursTextEdit.EditValue.ToString())
                == double.Parse(QuoteWorkHoursTextEdit.OldEditValue.ToString()) : actualNull;
            dyanmic.QuoteWorkHours = double.Parse(QuoteWorkHoursTextEdit.EditValue.ToString());
            if (actualNull)
            {
                ActualWorkHoursTextEdit.EditValue = QuoteWorkHoursTextEdit.EditValue;
            }
        }

        protected override void OnContextChanged(EventArgs e)
        {
            base.OnContextChanged(e);
            SetContextProject();

        }

        public override void Bind(object entity)
        {
            base.Bind(entity);
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
                EntityBindingSource.Current.AsDyanmic().ProjectId = operandValue.Value;
            }

        }
    }
}
