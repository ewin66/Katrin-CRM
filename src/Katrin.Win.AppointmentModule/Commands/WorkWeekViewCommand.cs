using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.Utils;
using ICSharpCode.Core;

namespace Katrin.Win.AppointmentModule.Commands
{
    public class WorkWeekViewCommand : AbstractCommand
    {
        public override void Run()
        {
            Guard.ObjectIsInstanceOfType(Owner, typeof(AppointmentController), "Owner");
            var controller = (AppointmentController)Owner;
            controller.SwitchActiveView(DevExpress.XtraScheduler.SchedulerViewType.WorkWeek);
        }
    }
}
