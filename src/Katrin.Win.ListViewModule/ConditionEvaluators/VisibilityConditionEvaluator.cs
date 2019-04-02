
using System;
using Katrin.Win.ListViewModule.ListViews;
using ICSharpCode.Core;

namespace Katrin.Win.ListViewModule.ConditionEvaluators
{

    public class VisibilityConditionEvaluator : IConditionEvaluator
	{
		public bool IsValid(object caller, Condition condition)
		{
			return true;
		}
	}
}
