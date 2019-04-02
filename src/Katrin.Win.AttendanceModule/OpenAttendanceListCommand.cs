using Katrin.AppFramework;
using Katrin.AppFramework.Messages;
using ICSharpCode.Core;

namespace Katrin.Win.AttendanceModule
{
    public class OpenAttendanceListCommand : AbstractCommand
    {
        public override void Run()
        {
            var message = new ShowScreenMessage("/Attendance/List", "Attendance");
            EventAggregationManager.SendMessage(message);
        }
    }
}
