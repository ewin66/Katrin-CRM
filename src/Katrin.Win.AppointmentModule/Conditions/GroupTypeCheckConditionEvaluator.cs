using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Workspaces;
using DevExpress.XtraScheduler;
using ICSharpCode.Core;

namespace Katrin.Win.AppointmentModule.Conditions
{
    public class GroupTypeCheckConditionEvaluator : IConditionEvaluator
    {
        public bool IsValid(object owner, Condition condition)
        {
            if (!(owner is IWorkspace1)) return false;
            IWorkspace1 workspace = (IWorkspace1)owner;
            AppointmentController controller = workspace.FindController<AppointmentController>("");
            if (controller != null)
            {
                SchedulerGroupType groupType;
                bool parseSuccess = SchedulerGroupType.TryParse(condition.Name, true, out groupType);
                if (parseSuccess)
                {
                    return controller.IsTheSameGroupType(groupType);
                }
            }
            return false;
        }
    }
}
