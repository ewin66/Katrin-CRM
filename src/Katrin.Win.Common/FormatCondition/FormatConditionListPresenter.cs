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

namespace Katrin.Win.Common.FormatCondition
{
    public class FormatConditionListPresenter : Presenter<IFormatConditionView>
    {
        public  string _formatConditionFileName = "FormatConditions.xml";

        protected override void OnViewSet()
        {

        }
     
        private void ApplyConditions(IEnumerable<FormatCondition> activeConditons)
        {
            View.PostEdit();
            View.ClearConditions();
            foreach (var conditionSetting in activeConditons)
            {
                var condition = CreateStyleFormatCondition(conditionSetting);
                View.AddCondition(condition);
            }
        }

        public static StyleFormatCondition CreateStyleFormatCondition(FormatCondition conditionSetting)
        {
            StyleFormatCondition condition = new StyleFormatCondition();
            var fontStyle = FontStyle.Regular;
            if (conditionSetting.Underline)
            {
                fontStyle |= FontStyle.Underline;
            }
            if (conditionSetting.Italic)
            {
                fontStyle |= FontStyle.Italic;
            }
            if (conditionSetting.Bold)
            {
                fontStyle |= FontStyle.Bold;
            }
            FontFamily fontFamily = new FontFamily(conditionSetting.FontName);
            System.Drawing.Font font = new Font(fontFamily, float.Parse(conditionSetting.Size), fontStyle);
            condition.Appearance.Font = font;
            condition.Condition = FormatConditionEnum.Expression;
            condition.Expression = conditionSetting.Conditions;
            condition.Appearance.BackColor = conditionSetting.Backcolor;
            condition.Appearance.ForeColor = conditionSetting.Forecolor;
            condition.Appearance.Options.UseFont = true;
            condition.Appearance.Options.UseForeColor = true;
            condition.Appearance.Options.UseBackColor = true;
            return condition;
        }

        public void ViewApply(object sender, EventArgs e)
        {
            var activeConditons = View.Conditions.Where(c => c.Active);
            ApplyConditions(activeConditons);
        }

        public void ViewOK(object sender, EventArgs e)
        {
            View.SaveLayout(_formatConditionFileName);
            var activeConditons = View.Conditions.Where(c => c.Active);
            ApplyConditions(activeConditons);
            
        }

       
    }
}
