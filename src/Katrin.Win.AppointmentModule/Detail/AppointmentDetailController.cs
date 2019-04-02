using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI;

namespace Katrin.Win.AppointmentModule.Detail
{
    public class AppointmentDetailController : AppointmentFormController
    {
        public DateTime? CreatedOn
        {
            get { return (DateTime?)EditedAppointmentCopy.CustomFields["CreatedOn"]; }
            set { EditedAppointmentCopy.CustomFields["CreatedOn"] = value; }
        }
        public Katrin.Domain.Impl.User CreatedBy
        {
            get { return (Katrin.Domain.Impl.User)EditedAppointmentCopy.CustomFields["CreatedBy"]; }
            set { EditedAppointmentCopy.CustomFields["CreatedBy"] = value; }
        }
        public DateTime? ModifiedOn
        {
            get { return (DateTime?)EditedAppointmentCopy.CustomFields["ModifiedOn"]; }
            set { EditedAppointmentCopy.CustomFields["ModifiedOn"] = value; }
        }
        public Katrin.Domain.Impl.User ModifiedBy
        {
            get { return (Katrin.Domain.Impl.User)EditedAppointmentCopy.CustomFields["ModifiedBy"]; }
            set { EditedAppointmentCopy.CustomFields["ModifiedBy"] = value; }
        }

        //DateTime? SourceCreatedOn
        //{
        //    get { return (DateTime?)SourceAppointment.CustomFields["CreatedOn"]; }
        //    set { SourceAppointment.CustomFields["CreatedOn"] = value; }
        //}
        //Katrin.Domain.Impl.User SourceCreatedBy
        //{
        //    get { return (Katrin.Domain.Impl.User)SourceAppointment.CustomFields["CreatedBy"]; }
        //    set { SourceAppointment.CustomFields["CreatedBy"] = value; }
        //}
        //DateTime? SourceModifiedOn
        //{
        //    get { return (DateTime?)SourceAppointment.CustomFields["ModifiedOn"]; }
        //    set { SourceAppointment.CustomFields["ModifiedOn"] = value; }
        //}
        //Katrin.Domain.Impl.User SourceModifiedBy
        //{
        //    get { return (Katrin.Domain.Impl.User)SourceAppointment.CustomFields["ModifiedBy"]; }
        //    set { SourceAppointment.CustomFields["ModifiedBy"] = value; }
        //}

        public AppointmentDetailController(SchedulerControl control, Appointment apt)
            : base(control, apt)
        {
        }

        //public override bool IsAppointmentChanged()
        //{
        //    if (base.IsAppointmentChanged())
        //        return true;
        //    return SourceCreatedOn != CreatedOn ||
        //        SourceCreatedBy != CreatedBy ||
        //        SourceModifiedOn != ModifiedOn ||
        //        SourceModifiedBy != ModifiedBy;
        //}

        //protected override void ApplyCustomFieldsValues()
        //{
        //    SourceCreatedOn = CreatedOn;
        //    SourceCreatedBy = CreatedBy;
        //    SourceModifiedOn = ModifiedOn;
        //    SourceModifiedBy = ModifiedBy;
        //}
    }
}
