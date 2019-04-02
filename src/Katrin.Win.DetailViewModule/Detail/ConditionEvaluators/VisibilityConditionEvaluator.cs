
using System;
using Katrin.AppFramework.Security;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.ViewInterface;
using Katrin.AppFramework.WinForms.Views;
using ICSharpCode.Core;

namespace Katrin.Win.DetailViewModule.ConditionEvaluators
{

    public class VisibilityConditionEvaluator : IConditionEvaluator
	{
		public bool IsValid(object caller, Condition condition)
		{
            if (!(caller is IObjectDetailController)) return true;
            IObjectDetailController detailController = (IObjectDetailController)caller;
            if (!string.IsNullOrEmpty(condition.Properties["priviledge"]))
            {
                bool result  = AuthorizationManager.CheckAccess(detailController.ObjectName, condition.Properties["priviledge"]);
                if (!result) return result;
            }
            string itemType = condition.Properties["type"];
            bool status = detailController.WorkingMode == EntityDetailWorkingMode.View;
            if (itemType == "edit") return status;
            else return !status;
		}
	}
}
