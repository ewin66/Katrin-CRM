using System;
using System.Collections.Generic;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.ViewInterface;

namespace Katrin.Win.AttendanceModule.Detail
{
    public interface IAttendanceDetailView : IObjectDetailView
    {
        EntityDetailWorkingMode WorkMode { get;set;}
        List<Guid> GetRecordPersonList();
    }
}
