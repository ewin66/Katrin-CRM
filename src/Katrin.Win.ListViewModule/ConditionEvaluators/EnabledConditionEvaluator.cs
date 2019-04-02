
using System;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.Win.ListViewModule.ListViews;
using ICSharpCode.Core;

namespace Katrin.Win.ListViewModule.ConditionEvaluators
{
	public class EnabledConditionEvaluator : IConditionEvaluator
	{
		public bool IsValid(object caller, Condition condition)
		{
            if (caller is ListController)
            {
                ListController listControl = (ListController)caller;
                return listControl.RibbonEnabledValid();
            }
			return true;

		}
	}
}
