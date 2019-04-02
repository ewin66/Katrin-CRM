using System.Collections;
using System.ComponentModel;
using System.Threading;
using Katrin.AppFramework;
using Katrin.AppFramework.Security;
using Katrin.AppFramework.WinForms.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Messages;
using ICSharpCode.Core;
using Katrin.Domain.Impl;

namespace Katrin.Win.AppointmentModule
{
    public class AppointmentController : ObjectController, IListener<FilterChangedMessage>
    {
        private Appointment _deletedAppointment;
        private IList<Appointment> _deletedAppointments = new List<Appointment>();
        private IAppointmentView _appointmentView;
        private IList _resources;
        private IList<Appointment> _appointments;
        private IList<Appointment> _newAppointments;
        private bool _isDeletingPattern = false;
        private bool _isCancelInserted = false;
        private DevExpress.XtraScheduler.SchedulerStorage _schedulerStorage;
        private DevExpress.XtraScheduler.SchedulerControl _schedulerControl;

        public override string ObjectName
        {
            get
            {
                return "Appointment";
            }
        }

        public override object SelectedObject
        {
            get { return null; }
        }

        public bool IsSelected
        {
            get { return _appointmentView.IsSelectedAppointment; }
        }

        public AppointmentController()
        {
            EventAggregationManager.AddListener(this);
            InitScheduler();
        }

        private void InitScheduler()
        {
            _schedulerStorage = new DevExpress.XtraScheduler.SchedulerStorage();
            _schedulerStorage.Resources.Mappings.Caption = "Name";
            _schedulerStorage.Resources.Mappings.Color = "LabelColor";
            _schedulerStorage.Resources.Mappings.Id = "ResourceId";
            _schedulerStorage.Appointments.Mappings.AppointmentId = "AppointmentId";
            _schedulerStorage.Appointments.Mappings.Description = "Description";
            _schedulerStorage.Appointments.Mappings.End = "EndTime";
            _schedulerStorage.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
            _schedulerStorage.Appointments.Mappings.ResourceId = "ResourceId";
            _schedulerStorage.Appointments.Mappings.Start = "StartTime";
            _schedulerStorage.Appointments.Mappings.Subject = "Subject";
            _schedulerStorage.Appointments.Mappings.Type = "AppointmentType";
            _schedulerControl = new DevExpress.XtraScheduler.SchedulerControl(_schedulerStorage);
            _schedulerControl.OptionsCustomization.AllowAppointmentConflicts =
                DevExpress.XtraScheduler.AppointmentConflictsMode.Forbidden;
        }

        public override IActionResult Execute(ActionParameters parameters)
        {
            _appointmentView = ViewFactory.CreateView("DefaultAppointmentView") as IAppointmentView;
            BindNewData();
            _appointmentView.StateChanged += AppointmentViewStateChanged;
            _appointmentView.AppointmentsInserted += AppointmentViewAppointmentsInserted;
            _appointmentView.AppointmentsChanged += AppointmentViewAppointmentsChanged;
            _appointmentView.AppointmentsDeleted += AppointmentViewAppointmentsDeleted;
            _appointmentView.AppointmentInserting += AppointmentViewAppointmentInserting;
            _appointmentView.AppointmentChanging += AppointmentViewAppointmentChanging;
            _appointmentView.AppointmentDeleting += AppointmentViewAppointmentDeleting;
            var result = new PartialViewResult();
            result.View = _appointmentView;
            return result;
        }

        private void AppointmentViewAppointmentInserting(object sender, DevExpress.XtraScheduler.PersistentObjectCancelEventArgs e)
        {
            UpdateSchedulerStorage();
            var insertingAppointment = (DevExpress.XtraScheduler.Appointment)e.Object;
            var isResolved = IsConflictResolved(insertingAppointment);
            if (!isResolved)
            {
                e.Cancel = true;
                string message = ResourceService.GetString("AppointmentConflict");
                MessageService.ShowWarning(message);
                AutoRefresh();
                return;
            }
            _isCancelInserted = false;
        }

        private void UpdateSchedulerStorage()
        {
            _schedulerStorage.BeginUpdate();
            _schedulerStorage.Resources.DataSource = null;
            _schedulerStorage.Resources.DataSource = _objectSpace.GetObjects("Resource");
            _schedulerStorage.Appointments.DataSource = null;
            _newAppointments = (IList<Appointment>)_objectSpace.GetObjects("Appointment");
            _schedulerStorage.Appointments.DataSource = _newAppointments;
            _schedulerStorage.EndUpdate();
        }

        private bool IsConflictResolved(DevExpress.XtraScheduler.Appointment appointment)
        {
            var controller = new DevExpress.XtraScheduler.UI.AppointmentFormController(_schedulerControl, appointment);
            return controller.IsConflictResolved();
        }

        private void AppointmentViewAppointmentChanging(object sender, DevExpress.XtraScheduler.PersistentObjectCancelEventArgs e)
        {
            var changingAppointment = (DevExpress.XtraScheduler.Appointment)e.Object;
            if (changingAppointment.Type == DevExpress.XtraScheduler.AppointmentType.Occurrence)
            {
                return;
            }
            UpdateSchedulerStorage();
            if (changingAppointment.Id != null)
            {
                Guid changingAppointmentId = (Guid)changingAppointment.Id;

                var oldAppointment =
                    _newAppointments.FirstOrDefault(
                        appointment => appointment.AppointmentId == changingAppointmentId);
                _newAppointments.Remove(oldAppointment);
                _schedulerStorage.RefreshData();
            }

            bool isResolved = true;
            if (changingAppointment.Type == DevExpress.XtraScheduler.AppointmentType.ChangedOccurrence)
            {
                Guid patternId = (Guid)changingAppointment.RecurrencePattern.Id;
                var pattern =
                    _schedulerStorage.Appointments.Items.FirstOrDefault(
                        appointment => (Guid)appointment.Id == patternId);

                var copyAppointment = pattern.CreateException(
                    DevExpress.XtraScheduler.AppointmentType.ChangedOccurrence,
                    changingAppointment.RecurrenceIndex);
                copyAppointment.Start = changingAppointment.Start;
                copyAppointment.End = changingAppointment.End;
                isResolved = IsConflictResolved(copyAppointment);
            }
            else if (changingAppointment.Type == DevExpress.XtraScheduler.AppointmentType.Normal ||
                     changingAppointment.Type == DevExpress.XtraScheduler.AppointmentType.Pattern)
            {
                var copyAppointment = changingAppointment.Copy();
                isResolved = IsConflictResolved(copyAppointment);
            }

            if (!isResolved)
            {
                _isCancelInserted = true;
                e.Cancel = true;
                string message = ResourceService.GetString("AppointmentConflict");
                MessageService.ShowWarning(message);
                AutoRefresh();
                return;
            }
            _isCancelInserted = false;
        }

        private void AppointmentViewAppointmentDeleting(object sender, DevExpress.XtraScheduler.PersistentObjectCancelEventArgs e)
        {
            var deletingAppointment = (DevExpress.XtraScheduler.Appointment)e.Object;
            if (deletingAppointment.Id == null)
            {
                return;
            }
            if (deletingAppointment.Type == DevExpress.XtraScheduler.AppointmentType.Pattern)
            {
                _isDeletingPattern = true;
            }
            Guid id = (Guid)deletingAppointment.Id;
            foreach (var appointment in _appointments)
            {
                if (appointment.AppointmentId == id)
                {
                    if (_isDeletingPattern)
                    {
                        _deletedAppointments.Add(appointment);
                    }
                    else
                    {
                        _deletedAppointment = appointment;
                    }
                    break;
                }
            }
            _isCancelInserted = false;
        }

        private bool CheckAppointmentCanDelete(Guid id)
        {
            bool isDeleted = true;
            foreach (var appointment in _schedulerStorage.Appointments.Items)
            {
                if ((Guid)appointment.Id == id)
                {
                    isDeleted = false;
                    break;
                }
                if (appointment.HasExceptions)
                {
                    isDeleted =
                        appointment.GetExceptions().All(
                            exceptionAppointment => (Guid)exceptionAppointment.Id != id);
                }
                if (!isDeleted)
                {
                    break;
                }
            }
            return !isDeleted;
        }

        private void AppointmentViewAppointmentsDeleted(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {
            if (_isDeletingPattern)
            {
                UpdateSchedulerStorage();
                foreach (var appointment in _deletedAppointments)
                {
                    bool canDelete = CheckAppointmentCanDelete(appointment.AppointmentId);
                    if (canDelete)
                    {
                        _objectSpace.DeleteObject("Appointment", appointment);
                    }
                }
                _objectSpace.SaveChanges();
                Context.UpdateCommandState();
                _isDeletingPattern = false;
                _deletedAppointments.Clear();
                _deletedAppointment = null;
            }
            else if (_deletedAppointment != null)
            {
                UpdateSchedulerStorage();
                bool canDelete = CheckAppointmentCanDelete(_deletedAppointment.AppointmentId);
                if (canDelete)
                {
                    _objectSpace.DeleteObject("Appointment", _deletedAppointment);
                    _objectSpace.SaveChanges();
                    Context.UpdateCommandState();
                    _deletedAppointment = null;
                }
            }
        }

        private void AppointmentViewAppointmentsChanged(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {
            var changedAppointments = (DevExpress.XtraScheduler.AppointmentBaseCollection)e.Objects;
            if (changedAppointments.Count == 0)
            {
                return;
            }
            var changedAppointment = changedAppointments[0];
            Guid id = (Guid)changedAppointment.Id;
            foreach (Appointment appointment in _appointments)
            {
                if (appointment.AppointmentId == id)
                {
                    SetModifiedInformation(appointment);
                    _objectSpace.UpdateObject(appointment);
                    break;
                }
            }
            _objectSpace.SaveChanges();
        }

        private void AppointmentViewAppointmentsInserted(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {
            if (_isCancelInserted)
            {
                _isCancelInserted = false;
                return;
            }
            var insertedAppointments = (DevExpress.XtraScheduler.AppointmentBaseCollection)e.Objects;
            if (insertedAppointments.Count == 0)
            {
                return;
            }
            var newAppointment = insertedAppointments[0];
            foreach (var appointment in _appointments)
            {
                if (appointment.AppointmentId == Guid.Empty)
                {
                    Guid id = Guid.NewGuid();
                    _appointmentView.SetAppointmentId(newAppointment, id);
                    appointment.AppointmentId = id;
                    if (newAppointment.Type == DevExpress.XtraScheduler.AppointmentType.Pattern)
                    {
                        appointment.RecurrenceEndTime = newAppointment.RecurrenceInfo.Range ==
                                                        DevExpress.XtraScheduler.RecurrenceRange.NoEndDate
                                                            ? DateTime.MaxValue
                                                            : newAppointment.RecurrenceInfo.End;
                    }
                    SetCreatedInformation(appointment);
                    _objectSpace.AddObject("Appointment", appointment);
                    break;
                }
            }
            _objectSpace.SaveChanges();
        }

        private void AppointmentViewStateChanged(object sender, EventArgs e)
        {
            Context.UpdateCommandState();
        }

        private void SetCreatedInformation(Appointment appointment)
        {
            appointment.CreatedById = AuthorizationManager.CurrentUserId;
            appointment.CreatedOn = DateTime.Now;
        }

        private void SetModifiedInformation(Appointment appointment)
        {
            appointment.ModifiedById = AuthorizationManager.CurrentUserId;
            appointment.ModifiedOn = DateTime.Now;
        }

        private void BindNewData()
        {
            _appointmentView.DataBeginUpdate();
            _resources = _objectSpace.GetObjects("Resource");
            var query = _objectSpace.GetObjectQuery("Appointment");
            var appointments = (IList<Appointment>)query.Expand("CreatedBy").Expand("ModifiedBy").ToList();
            _appointments = new System.ComponentModel.BindingList<Appointment>(appointments);
            _appointmentView.BindAppointments(_appointments);
            _appointmentView.BindResources(_resources);
            _appointmentView.DataEndUpdate();
        }

        public bool IsTheSameActiveViewType(DevExpress.XtraScheduler.SchedulerViewType viewType)
        {
            return _appointmentView.ActiveViewType == viewType;
        }

        public bool IsTheSameGroupType(DevExpress.XtraScheduler.SchedulerGroupType groupType)
        {
            return _appointmentView.GroupType == groupType;
        }

        public void GotoToday()
        {
            _appointmentView.GotoToday();
        }

        public void SwitchActiveView(DevExpress.XtraScheduler.SchedulerViewType viewType)
        {
            _appointmentView.ActiveViewType = viewType;
            Context.UpdateCommandState();
        }

        public void SwitchGroupType(DevExpress.XtraScheduler.SchedulerGroupType groupType)
        {
            _appointmentView.GroupType = groupType;
            Context.UpdateCommandState();
        }

        public void AddNewAppointment()
        {
            _appointmentView.AddNewAppointment();
        }

        public void DeleteAppointment()
        {
            _appointmentView.DeleteSelectedAppointment();
        }

        public void EditAppointment()
        {
            _appointmentView.EditSelectedAppointment();
        }

        public void Refresh()
        {
            BindNewData();
        }

        private void AutoRefresh()
        {
            Action action = () =>
            {
                Thread.Sleep(500);
                Refresh();
            };
            action.BeginInvoke(null, null);
        }

        void IListener<FilterChangedMessage>.Handle(FilterChangedMessage message)
        {
            if (message.ObjectName != ObjectName) return;
            string filterString;
            if (message.Filter != null)
            {
                string legacyString = message.Filter.LegacyToString();
                int index = legacyString.IndexOf('=');
                if (index < 0)
                {
                    return;
                }
                filterString = "[Caption] " + legacyString.Substring(index);
            }
            else
            {
                filterString = string.Empty;
            }
            _appointmentView.SetResourcesFilter(filterString);
        }
    }
}
