using System;
using System.Linq;
using Katrin.Win.Infrastructure;
using Microsoft.Practices.CompositeUI;
using Katrin.Win.Common.Core;
using Microsoft.Practices.CompositeUI.Commands;
using Katrin.Win.Common;
using System.Collections.Generic;
using System.Collections;
using Katrin.Win.Common.MetadataServiceReference;

namespace Katrin.Win.MainModule.Views.Attendance
{
    public class AttendanceDetailPresenter : EntityDetailPresenter<IAttendanceDetailView>
    {
        public AttendanceDetailPresenter()
        {
            EntityName = "Attendance";
        }

        protected override void OnSaving()
        {
            if (WorkingMode == EntityDetailWorkingMode.Add)
            {
                int itemCount = 0;
                foreach (Guid recordPersonId in View.GetRecordPersonList())
                {
                    if (DynamicEntity.RecordOn == null)
                    {
                        DynamicEntity.RecordOn = DateTime.Today;
                    }
                    if (itemCount == 0)
                        DynamicEntity.RecordPersonId = recordPersonId;
                    else
                    {
                        var recordPersonEntity = DynamicDataServiceContext.GetOrNew("Attendance", Guid.Empty);
                        recordPersonEntity.AsDyanmic().RecordOn = DynamicEntity.RecordOn;
                        recordPersonEntity.AsDyanmic().AttendanceTypeCode = DynamicEntity.AttendanceTypeCode;
                        recordPersonEntity.AsDyanmic().AttendanceLength = DynamicEntity.AttendanceLength;
                        recordPersonEntity.AsDyanmic().AttendanceUnitCode = DynamicEntity.AttendanceUnitCode;
                        recordPersonEntity.AsDyanmic().CreatedOn = DynamicEntity.CreatedOn;
                        recordPersonEntity.AsDyanmic().Description = DynamicEntity.Description;
                        recordPersonEntity.AsDyanmic().CreatedById = DynamicEntity.CreatedById;
                        recordPersonEntity.AsDyanmic().ModifiedOn = DynamicEntity.ModifiedOn;
                        recordPersonEntity.AsDyanmic().ModifiedById = DynamicEntity.ModifiedById;
                        recordPersonEntity.AsDyanmic().RecordPersonId = recordPersonId;

                    }
                    itemCount++;
                }
            }
            base.OnSaving();
        }
        protected override void OnViewSet()
        {
            View.WorkMode = WorkingMode;
            base.OnViewSet();
        }
    }
}
