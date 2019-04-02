using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Windows.Forms;

namespace Katrin.Win.Common.FilterCondition
{
    public interface IFilterConditionView 
    {
      void Close();
      IEnumerable<FilterCondition> Conditions { get; }
      void AddCondition(StyleFormatCondition condition);
      void ClearConditions();
      event EventHandler Apply;
      event EventHandler OK;
      DialogResult ShowDialog();
      void ShowMessage(string message);
      string EntityTypeName { get; set; }
      //void RestoreLayout(string _formatConditionFileName);
    }
}
