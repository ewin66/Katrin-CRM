using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Workspaces;
using ICSharpCode.Core;

namespace Katrin.Win.AppointmentModule.Conditions
{
    public class AppointmentEnabledConditionEvaluator : IConditionEvaluator
    {
        public bool IsValid(object owner, Condition condition)
        {
            if (!(owner is AppointmentController)) return false;
            AppointmentController controller = (AppointmentController)owner;
            return controller.IsSelected;
        }
    }
}
