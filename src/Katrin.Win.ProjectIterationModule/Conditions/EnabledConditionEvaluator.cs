
using System;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.Win.ListViewModule.ListViews;
using ICSharpCode.Core;

namespace Katrin.Win.ProjectIterationModule.ConditionEvaluators
{
	public class EnabledConditionEvaluator : IConditionEvaluator
	{
		public bool IsValid(object caller, Condition condition)
		{
            if (caller is ListController)
            {
                ListController controllder = caller as ListController;
                if (controllder.SelectedObject != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;

		}
	}
}
