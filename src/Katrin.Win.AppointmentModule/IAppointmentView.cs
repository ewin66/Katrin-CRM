using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.MVC;

namespace Katrin.Win.AppointmentModule
{
    public interface IAppointmentView : IView
    {
        event EventHandler StateChanged;
        event EventHandler<DevExpress.XtraScheduler.PersistentObjectsEventArgs> AppointmentsInserted;
        event EventHandler<DevExpress.XtraScheduler.PersistentObjectsEventArgs> AppointmentsChanged;
        event EventHandler<DevExpress.XtraScheduler.PersistentObjectsEventArgs> AppointmentsDeleted;
        event EventHandler<DevExpress.XtraScheduler.PersistentObjectCancelEventArgs> AppointmentInserting;
        event EventHandler<DevExpress.XtraScheduler.PersistentObjectCancelEventArgs> AppointmentChanging;
        event EventHandler<DevExpress.XtraScheduler.PersistentObjectCancelEventArgs> AppointmentDeleting;
        DevExpress.XtraScheduler.SchedulerViewType ActiveViewType { get; set; }
        DevExpress.XtraScheduler.SchedulerGroupType GroupType { get; set; }
        bool IsSelectedAppointment { get; }
        void BindAppointments(object dataSource);
        void BindResources(object dataSource);
        void GotoToday();
        void AddNewAppointment();
        void DeleteSelectedAppointment();
        void EditSelectedAppointment();
        void SetAppointmentId(DevExpress.XtraScheduler.Appointment appointment, object id);
        void DataBeginUpdate();
        void DataEndUpdate();
        void SetResourcesFilter(string filterString);
    }
}
