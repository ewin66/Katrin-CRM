using Katrin.AppFramework.WinForms.Workspaces;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.DetailViewModule.ConditionEvaluators
{
    public class CheckConditionEvaluator : IConditionEvaluator
    {
        public bool IsValid(object caller, Condition condition)
        {
            if (!(caller is IWorkspace1)) return false;
            IWorkspace1 workspace = (IWorkspace1)caller;
            string viewName = condition.Properties["viewName"];        
            return workspace.IsViewShowing(viewName);       
        }
    }
}
