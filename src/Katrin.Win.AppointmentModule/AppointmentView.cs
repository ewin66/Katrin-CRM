using System;
using Katrin.AppFramework.WinForms.Views;
using Katrin.Win.AppointmentModule.Detail;
using DevExpress.XtraScheduler;

namespace Katrin.Win.AppointmentModule
{
    public partial class AppointmentView : BaseView, IAppointmentView
    {
        public AppointmentView()
        {
            InitializeComponent();
            InitScheduler();
        }

        #region IAppointmentView Members

        public event EventHandler StateChanged;
        public event EventHandler<PersistentObjectsEventArgs> AppointmentsInserted;
        public event EventHandler<PersistentObjectsEventArgs> AppointmentsChanged;
        public event EventHandler<PersistentObjectsEventArgs> AppointmentsDeleted;
        public event EventHandler<PersistentObjectCancelEventArgs> AppointmentInserting;
        public event EventHandler<PersistentObjectCancelEventArgs> AppointmentChanging;
        public event EventHandler<PersistentObjectCancelEventArgs> AppointmentDeleting;

        public SchedulerViewType ActiveViewType
        {
            get { return schedulerControl.ActiveViewType; }
            set { schedulerControl.ActiveViewType = value; }
        }

        public SchedulerGroupType GroupType
        {
            get { return schedulerControl.GroupType; }
            set { schedulerControl.GroupType = value; }
        }

        public bool IsSelectedAppointment
        {
            get { return schedulerControl.SelectedAppointments.Count > 0; }
        }

        public void BindAppointments(object dataSource)
        {
            schedulerStorage.Appointments.DataSource = null;
            schedulerStorage.Appointments.DataSource = dataSource;
        }

        public void BindResources(object dataSource)
        {
            schedulerStorage.Resources.DataSource = null;
            schedulerStorage.Resources.DataSource = dataSource;
        }

        public void GotoToday()
        {
            schedulerControl.Services.DateTimeNavigation.GoToToday();
        }

        public void AddNewAppointment()
        {
            schedulerControl.CreateNewAppointment();
        }

        public void DeleteSelectedAppointment()
        {
            schedulerControl.DeleteSelectedAppointments();
        }

        public void EditSelectedAppointment()
        {
            if (schedulerControl.SelectedAppointments.Count > 0)
            {
                schedulerControl.ShowEditAppointmentForm(schedulerControl.SelectedAppointments[0]);
            }
        }

        public void SetAppointmentId(Appointment appointment, object id)
        {
            schedulerStorage.SetAppointmentId(appointment, id);
        }

        public void DataBeginUpdate()
        {
            schedulerStorage.BeginUpdate();
        }

        public void DataEndUpdate()
        {
            schedulerStorage.EndUpdate();
        }

        public void SetResourcesFilter(string filterString)
        {
            schedulerStorage.Resources.Filter = filterString;
        }

        #endregion

        private void InitScheduler()
        {
            schedulerStorage.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("CreatedOn", "CreatedOn"));
            schedulerStorage.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("CreatedBy", "CreatedBy"));
            schedulerStorage.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("ModifiedOn", "ModifiedOn"));
            schedulerStorage.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("ModifiedBy", "ModifiedBy"));
            schedulerStorage.Appointments.AutoReload = false;
            schedulerControl.GroupType = SchedulerGroupType.Date;
            schedulerControl.GoToToday();
            schedulerControl.DayView.TopRowTime = schedulerControl.DayView.WorkTime.Start;
            schedulerControl.DayView.ShowAllDayArea = false;
            schedulerControl.DayView.AppointmentDisplayOptions.StartTimeVisibility = AppointmentTimeVisibility.Always;
            schedulerControl.DayView.AppointmentDisplayOptions.EndTimeVisibility = AppointmentTimeVisibility.Always;
            schedulerControl.WorkWeekView.TopRowTime = schedulerControl.WorkWeekView.WorkTime.Start;
            schedulerControl.WorkWeekView.ShowAllDayArea = false;
            schedulerControl.WorkWeekView.AppointmentDisplayOptions.StartTimeVisibility = AppointmentTimeVisibility.Always;
            schedulerControl.WorkWeekView.AppointmentDisplayOptions.EndTimeVisibility = AppointmentTimeVisibility.Always;
            schedulerControl.MonthView.AppointmentDisplayOptions.StartTimeVisibility = AppointmentTimeVisibility.Always;
            schedulerControl.MonthView.AppointmentDisplayOptions.EndTimeVisibility = AppointmentTimeVisibility.Always;
        }

        private void schedulerControl_ActiveViewChanged(object sender, EventArgs e)
        {
            if (StateChanged != null)
            {
                StateChanged(sender, e);
            }
        }

        private void schedulerControl_SelectionChanged(object sender, EventArgs e)
        {
            if (StateChanged != null)
            {
                StateChanged(sender, e);
            }
        }

        private void schedulerControl_InitAppointmentDisplayText(object sender, AppointmentDisplayTextEventArgs e)
        {
            Resource resource = schedulerStorage.Resources.GetResourceById(e.Appointment.ResourceId);
            e.Text += " " + resource.Caption;
        }

        private void schedulerStorage_AppointmentInserting(object sender, PersistentObjectCancelEventArgs e)
        {
            if (AppointmentInserting != null)
            {
                AppointmentInserting(sender, e);
            }
        }

        private void schedulerStorage_AppointmentsInserted(object sender, PersistentObjectsEventArgs e)
        {
            if (AppointmentsInserted != null)
            {
                AppointmentsInserted(sender, e);
            }
        }

        private void schedulerStorage_AppointmentChanging(object sender, PersistentObjectCancelEventArgs e)
        {
            if (AppointmentChanging != null)
            {
                AppointmentChanging(sender, e);
            }
        }

        private void schedulerStorage_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            if (AppointmentsChanged != null)
            {
                AppointmentsChanged(sender, e);
            }
        }

        private void schedulerStorage_AppointmentDeleting(object sender, PersistentObjectCancelEventArgs e)
        {
            if (AppointmentDeleting != null)
            {
                AppointmentDeleting(sender, e);
            }
        }

        private void schedulerStorage_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {
            if (AppointmentsDeleted != null)
            {
                AppointmentsDeleted(sender, e);
            }
        }

        private void schedulerControl_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            Appointment appointment = e.Appointment;
            bool openRecurrenceForm = appointment.IsRecurring &&
                                      schedulerStorage.Appointments.IsNewAppointment(appointment);

            var form = new AppointmentDetailView((SchedulerControl)sender, appointment, openRecurrenceForm);
            form.LookAndFeel.ParentLookAndFeel = LookAndFeel.ParentLookAndFeel;
            e.DialogResult = form.ShowDialog();
            e.Handled = true;

            if (appointment.Type == AppointmentType.Pattern &&
                schedulerControl.SelectedAppointments.Contains(appointment))
            {
                schedulerControl.SelectedAppointments.Remove(appointment);
            }

            schedulerControl.Refresh();
        }
    }
}
