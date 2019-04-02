using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Workspaces;
using DevExpress.XtraScheduler;
using ICSharpCode.Core;

namespace Katrin.Win.AppointmentModule.Conditions
{
    public class ActiveViewCheckConditionEvaluator : IConditionEvaluator
    {
        public bool IsValid(object owner, Condition condition)
        {
            if (!(owner is IWorkspace1)) return false;
            IWorkspace1 workspace = (IWorkspace1)owner;
            AppointmentController controller = workspace.FindController<AppointmentController>("");
            if (controller != null)
            {
                SchedulerViewType viewType;
                bool parseSuccess = SchedulerViewType.TryParse(condition.Name, true, out viewType);
                if (parseSuccess)
                {
                    return controller.IsTheSameActiveViewType(viewType);
                }
            }
            return false;
        }
    }
}
