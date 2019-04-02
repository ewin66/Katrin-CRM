
using System;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.ViewInterface;
using Katrin.AppFramework.WinForms.Views;
using ICSharpCode.Core;

namespace Katrin.Win.DetailViewModule.ConditionEvaluators
{

	public class EnabledConditionEvaluator : IConditionEvaluator
	{
		public bool IsValid(object caller, Condition condition)
		{
            if (!(caller is IObjectDetailController)) return true;
            IObjectDetailController detailpresenter = (IObjectDetailController)caller;
            string itemType = condition.Properties["type"];
            bool status = detailpresenter.HasChanges;
            if (itemType == "copyandnew") status = !status && detailpresenter.WorkingMode != EntityDetailWorkingMode.Add;
            else if (itemType != "save") status = detailpresenter.WorkingMode != EntityDetailWorkingMode.Add;
            return status;
		}
	}
}
