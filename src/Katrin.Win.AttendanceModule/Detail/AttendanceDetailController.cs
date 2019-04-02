using System;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.Win.DetailViewModule;

namespace Katrin.Win.AttendanceModule.Detail
{
    public class AttendanceDetailController : ObjectDetailController
    {
        public override string ObjectName
        {
            get
            {
                return "Attendance";
            }
        }

        protected override bool OnSaving()
        {
            if (WorkingMode == EntityDetailWorkingMode.Add)
            {
                var view = (IAttendanceDetailView)_detailView;
                var attendance = (Katrin.Domain.Impl.Attendance)ObjectEntity;
                int itemCount = 0;
                foreach (Guid recordPersonId in view.GetRecordPersonList())
                {
                    if (attendance.RecordOn == null)
                    {
                        attendance.RecordOn = DateTime.Today;
                    }
                    if (itemCount == 0)
                    {
                        attendance.RecordPersonId = recordPersonId;
                    }
                    else
                    {
                        var recordPersonEntity = (Katrin.Domain.Impl.Attendance)_objectSpace.GetOrNew("Attendance", Guid.Empty, null);
                        recordPersonEntity.RecordOn = attendance.RecordOn;
                        recordPersonEntity.AttendanceTypeCode = attendance.AttendanceTypeCode;
                        recordPersonEntity.AttendanceLength = attendance.AttendanceLength;
                        recordPersonEntity.AttendanceUnitCode = attendance.AttendanceUnitCode;
                        recordPersonEntity.CreatedOn = attendance.CreatedOn;
                        recordPersonEntity.Description = attendance.Description;
                        recordPersonEntity.CreatedById = attendance.CreatedById;
                        recordPersonEntity.ModifiedOn = attendance.ModifiedOn;
                        recordPersonEntity.ModifiedById = attendance.ModifiedById;
                        recordPersonEntity.RecordPersonId = recordPersonId;
                    }
                    itemCount++;
                }
            }
            return base.OnSaving(); 
        }

        protected override void OnViewSet()
        {
            var view = (IAttendanceDetailView)_detailView;
            view.WorkMode = WorkingMode;
            base.OnViewSet();
        }
    }
}
