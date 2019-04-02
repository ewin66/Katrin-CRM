
using System;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.Win.ListViewModule.ListViews;
using ICSharpCode.Core;

namespace Katrin.Win.ProjectTaskModule.ConditionEvaluators
{
	public class EnabledConditionEvaluator : IConditionEvaluator
	{
		public bool IsValid(object caller, Condition condition)
		{
            if (caller is ProjectTaskController)
            {
                ProjectTaskController controllder = caller as ProjectTaskController;
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
