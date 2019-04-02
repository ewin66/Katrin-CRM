using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.Utils;
using ICSharpCode.Core;

namespace Katrin.Win.AppointmentModule.Commands
{
    public class EditAppointmentCommand : AbstractCommand
    {
        public override void Run()
        {
            Guard.ObjectIsInstanceOfType(Owner, typeof(AppointmentController), "Owner");
            var controller = (AppointmentController)Owner;
            controller.EditAppointment();
        }
    }
}
