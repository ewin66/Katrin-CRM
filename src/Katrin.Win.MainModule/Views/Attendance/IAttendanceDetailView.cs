using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.MetadataServiceReference;

namespace Katrin.Win.MainModule.Views.Attendance
{
    public  interface IAttendanceDetailView: IEntityDetailView
    {
        EntityDetailWorkingMode WorkMode { get;set;}
        List<Guid> GetRecordPersonList();
    }
}
