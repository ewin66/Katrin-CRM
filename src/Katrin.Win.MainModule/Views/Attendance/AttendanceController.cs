using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;

namespace Katrin.Win.MainModule.Views.Attendance
{
    public  class AttendanceController:EntityListController<AttendanceListView,AttendanceDetailView>
    {
        protected override string EntityName
        {
            get { return "Attendance"; }
        }
    }
}
