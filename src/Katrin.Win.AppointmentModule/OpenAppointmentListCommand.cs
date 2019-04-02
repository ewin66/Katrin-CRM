using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;

namespace Katrin.Win.AppointmentModule
{
    public class OpenAppointmentListCommand : AbstractCommand
    {
        public override void Run()
        {
            var message = new ShowScreenMessage("/Appointment/List", "Appointment");
            EventAggregationManager.SendMessage(message);
        }
    }
}
