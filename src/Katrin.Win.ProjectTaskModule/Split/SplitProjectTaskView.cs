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
using Katrin.AppFramework.Extensions;
using ICSharpCode.Core;
using DevExpress.XtraEditors.Controls;
namespace Katrin.Win.ProjectTaskModule.Split
{
    public partial class SplitProjectTaskView : DetailView, ISplitProjectTaskView
    {
        private int _minValue = 0;
        public event EventHandler<EventArgs<int,int>> OnValueChanged;
        public SplitProjectTaskView()
        {
            InitializeComponent();
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
           
            ProjectIterationSearchLookUpEdit.Bind(entity);
            NewProjectIterationSearchLookUpEdit.Bind(entity);
            TNewProjectIterationSearchLookUpEdit.Bind(entity);

            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public override void InitValidation()
        {
            SetValidationRule(NameTextEdit, ValidationRules.IsNotBlankRule(ItemForName.Text));
            SetValidationRule(NewNameTextEdit, ValidationRules.IsNotBlankRule(ItemForNewName.Text));
            SetValidationRule(TNewNameTextEdit, ValidationRules.IsNotBlankRule(TItemForNewName.Text));
        }

        private void ActualWorkHoursTextEdit_EditValueChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(ActualWorkHoursTextEdit.Text))
            {
                var projectTask = (Katrin.Domain.Impl.ProjectTask)EntityBindingSource.Current;
                if (projectTask == null) return;
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

        public void BindNewTask(int minValue,int defaultValue,Guid projectId, object newTaskOne, object newTaskTwo)
        {
            _minValue = minValue;
            NewTaskOneBindingSource.DataSource = newTaskOne;
            NewTaskTwoBindingSource.DataSource = newTaskTwo;
            hourTrackBarControl.Value = defaultValue;
            ProjectIterationSearchLookUpEdit.ReLoadData(new BinaryOperator("ProjectId", projectId), "ProjectIteration");
            NewProjectIterationSearchLookUpEdit.ReLoadData(new BinaryOperator("ProjectId", projectId), "ProjectIteration");
            TNewProjectIterationSearchLookUpEdit.ReLoadData(new BinaryOperator("ProjectId", projectId), "ProjectIteration");
            string[] splitTypes = { "RemainderTime", "Rate", "Manual" };
            splitTypeRadio.Properties.Items.Clear();
            for (int i = 0; i < splitTypes.Count(); i++)
            {
                RadioGroupItem item = new RadioGroupItem(i, ResourceService.GetString(splitTypes[i]));
                splitTypeRadio.Properties.Items.Add(item);
            }
            splitTypeRadio.EditValue = 0;
            if (OnValueChanged != null)
                OnValueChanged(null, new EventArgs<int, int>(hourTrackBarControl.Value, 0));
        }

        private void hourTrackBarControl_ValueChanged(object sender, EventArgs e)
        {
            if (hourTrackBarControl.Value < _minValue)
            {
                hourTrackBarControl.Value = _minValue;
                return;
            }
            if (OnValueChanged != null)
                OnValueChanged(null,new EventArgs<int,int>(hourTrackBarControl.Value,1));

        }

        private void splitTypeRadio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (splitTypeRadio.EditValue == null) return;
            if (string.IsNullOrEmpty(splitTypeRadio.EditValue.ToString())) return;
            int editValue = int.Parse(splitTypeRadio.EditValue.ToString());
            if (editValue == 1)
                hourTrackBarControl.Enabled = true;
            else
                hourTrackBarControl.Enabled = false;
            if (editValue == 2)
            {
                NewActualWorkHoursTextEdit.Enabled = true;
                TNewActualWorkHoursTextEdit.Enabled = true;
                NewQuoteWorkHoursTextEdit.Enabled = true;
                TNewQuoteWorkHoursTextEdit.Enabled = true;
            }
            else
            {
                NewActualWorkHoursTextEdit.Enabled = false;
                TNewActualWorkHoursTextEdit.Enabled = false;
                NewQuoteWorkHoursTextEdit.Enabled = false;
                TNewQuoteWorkHoursTextEdit.Enabled = false;
            }
            if (OnValueChanged != null)
                OnValueChanged(null, new EventArgs<int, int>(hourTrackBarControl.Value, editValue));
        }
    }
}
