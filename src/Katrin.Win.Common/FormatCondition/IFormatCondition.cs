using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Windows.Forms;

namespace Katrin.Win.Common.FormatCondition
{
   public interface IFormatConditionView 
    {
      void Close();
      IEnumerable<FormatCondition> Conditions { get; }
      void AddCondition(StyleFormatCondition condition);
      void ClearConditions();
      DialogResult ShowDialog();
      void ShowMessage(string message);
      string EntityTypeName { get; set; }
      void SaveLayout(string _formatConditionFileName);
      void RestoreLayout(string _formatConditionFileName);
      void PostEdit();
    }
}
