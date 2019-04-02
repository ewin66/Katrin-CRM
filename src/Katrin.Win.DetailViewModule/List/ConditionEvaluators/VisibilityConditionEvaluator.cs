
using System;
using Katrin.AppFramework.Security;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.Win.ListViewModule.ListViews;
using ICSharpCode.Core;

namespace Katrin.Win.ListViewModule.ConditionEvaluators
{

    public class VisibilityConditionEvaluator : IConditionEvaluator
	{
		public bool IsValid(object caller, Condition condition)
		{
            if (string.IsNullOrEmpty(condition.Properties["priviledge"])) return true;
            if (!(caller is ListController)) return true;
            ListController listController = (ListController)caller;
            return AuthorizationManager.CheckAccess(listController.ObjectName, condition.Properties["priviledge"]);
		}
	}
}
