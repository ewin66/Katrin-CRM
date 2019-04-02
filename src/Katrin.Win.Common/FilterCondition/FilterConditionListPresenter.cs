using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Runtime.Serialization.Formatters.Binary;
using DevExpress.XtraGrid;
using System.Drawing;
using DevExpress.XtraEditors;

using Katrin.Win.Infrastructure;

namespace Katrin.Win.Common.FilterCondition
{
    public class FilterConditionListPresenter : Presenter<IFilterConditionView>
    {
        private string _entityTypeName;

        protected override void OnViewSet()
        {
            View.Apply += ViewApply;
            View.OK += ViewOK;
            _entityTypeName = View.EntityTypeName;
        }
     
        private void ApplyConditions(IEnumerable<FilterCondition> activeConditons)
        {
            View.ClearConditions();
            foreach (var conditionSetting in activeConditons)
            {
                var condition = CreateStyleFormatCondition(conditionSetting);
                View.AddCondition(condition);
            }
        }

        private static StyleFormatCondition CreateStyleFormatCondition(FilterCondition conditionSetting)
        {
            StyleFormatCondition condition = new StyleFormatCondition();
            condition.Condition = FormatConditionEnum.Expression;
            condition.Expression = conditionSetting.Conditions;
            condition.Appearance.Options.UseFont = true;
            condition.Appearance.Options.UseForeColor = true;
            condition.Appearance.Options.UseBackColor = true;
            return condition;
        }

        void ViewApply(object sender, EventArgs e)
        {
            var activeConditons = View.Conditions.Where(c => c.Active);
            ApplyConditions(activeConditons);
        }

        void ViewOK(object sender, EventArgs e)
        {
            var activeConditons = View.Conditions.Where(c => c.Active);
            ApplyConditions(activeConditons);
        }

       
    }
}
