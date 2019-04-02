using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI;
using ICSharpCode.Core;

namespace Katrin.Win.AppointmentModule.Detail
{
    public partial class AppointmentDetailView : DevExpress.XtraEditors.XtraForm
    {
        private SchedulerControl _control;
        private Appointment _appointmentapt;
        private bool _openRecurrenceForm = false;
        private bool _isAutoOpenRecurrenceForm = true;
        private int _suspendUpdateCount;
        private AppointmentDetailController _controller;
        private IList<Resource> _meetingRooms;

        protected AppointmentStorage Appointments { get { return _control.Storage.Appointments; } }
        protected internal bool IsNewAppointment { get { return _controller != null ? _controller.IsNewAppointment : true; } }
        protected bool IsUpdateSuspended { get { return _suspendUpdateCount > 0; } }

        public AppointmentDetailView(SchedulerControl control, Appointment apt, bool openRecurrenceForm)
        {
            _openRecurrenceForm = openRecurrenceForm;
            _isAutoOpenRecurrenceForm = openRecurrenceForm;
            _controller = new AppointmentDetailController(control, apt);
            _appointmentapt = apt;
            _control = control;

            SuspendUpdate();
            InitializeComponent();
            InitInformation();
            ResumeUpdate();

            UpdateForm();
        }

        private void InitInformation()
        {
            _meetingRooms = new List<Resource>(_control.Storage.Resources.Items);
            foreach (var meetingRoom in _meetingRooms)
            {
                cmbMeetingRoom.Properties.Items.Add(meetingRoom.Caption);
            }
            if (_controller.CreatedBy != null)
            {
                txtCreatedBy.Text = _controller.CreatedBy.FullName;
            }
            if (_controller.CreatedOn != null)
            {
                txtCreatedOn.Text = _controller.CreatedOn.Value.ToShortDateString();
            }
            if (_controller.ModifiedBy != null)
            {
                txtModifiedBy.Text = _controller.ModifiedBy.FullName;
            }
            if (_controller.ModifiedOn != null)
            {
                txtModifiedOn.Text = _controller.ModifiedOn.Value.ToShortDateString();
            }
        }

        protected void SuspendUpdate()
        {
            _suspendUpdateCount++;
        }

        protected void ResumeUpdate()
        {
            if (_suspendUpdateCount > 0)
                _suspendUpdateCount--;
        }

        private void btnRecurrence_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnRecurrenceButton();
        }

        private void OnRecurrenceButton()
        {
            ShowRecurrenceForm();
        }

        private void ShowRecurrenceForm()
        {
            if (!_control.SupportsRecurrence)
                return;

            // Prepare to edit appointment's recurrence.
            Appointment editedAptCopy = _controller.EditedAppointmentCopy;
            Appointment editedPattern = _controller.EditedPattern;
            Appointment patternCopy = _controller.PrepareToRecurrenceEdit();

            AppointmentRecurrenceForm dlg = new AppointmentRecurrenceForm(patternCopy, _control.OptionsView.FirstDayOfWeek, _controller);

            // Required for skins support.
            dlg.LookAndFeel.ParentLookAndFeel = this.LookAndFeel.ParentLookAndFeel;
            dlg.ShowExceptionsRemoveMsgBox = _controller.AreExceptionsPresent();

            DialogResult result = dlg.ShowDialog(this);
            dlg.Dispose();

            if (result == DialogResult.Abort)
            {
                _controller.RemoveRecurrence();
            }
            else if (result == DialogResult.OK)
            {
                _controller.ApplyRecurrence(patternCopy);
                if (_controller.EditedAppointmentCopy != editedAptCopy)
                {
                    UpdateForm();
                }
            }
            else if (_isAutoOpenRecurrenceForm && result == DialogResult.Cancel)
            {
                _controller.RemoveRecurrence();
                _isAutoOpenRecurrenceForm = false;
            }
            UpdateIntervalControls();
        }

        private void btnSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Required to check appointment's conflicts.
            if (!_controller.IsConflictResolved())
            {
                string message = ResourceService.GetString("AppointmentConflict");
                MessageService.ShowWarning(message);
                return;
            }
            _controller.Description = txtDescription.Text;
            _controller.Subject = txtSubject.Text;
            _controller.DisplayStart = this.dtStart.DateTime.Date + this.timeStart.Time.TimeOfDay;
            _controller.DisplayEnd = this.dtEnd.DateTime.Date + this.timeEnd.Time.TimeOfDay;
            _controller.ResourceId = _meetingRooms[cmbMeetingRoom.SelectedIndex].Id;
       
            _controller.ApplyChanges();
            DialogResult = DialogResult.OK;
        }

        private void UpdateForm()
        {
            SuspendUpdate();
            try
            {
                txtSubject.Text = _controller.Subject;

                dtStart.DateTime = _controller.DisplayStart.Date;
                dtEnd.DateTime = _controller.DisplayEnd.Date;

                timeStart.Time = DateTime.MinValue.AddTicks(_controller.Start.TimeOfDay.Ticks);
                timeEnd.Time = DateTime.MinValue.AddTicks(_controller.End.TimeOfDay.Ticks);

                txtDescription.Text = _controller.Description;
                if (_controller.ResourceId == DevExpress.XtraScheduler.Native.EmptyResource.Empty)
                {
                    cmbMeetingRoom.EditValue = _meetingRooms[0].Caption;
                }
                else
                {
                    cmbMeetingRoom.EditValue = _control.Storage.Resources.GetResourceById(_controller.ResourceId).Caption;
                }
            }
            finally
            {
                ResumeUpdate();
            }
            UpdateIntervalControls();
        }

        private void AppointmentDetailView_Activated(object sender, EventArgs e)
        {
            if (_openRecurrenceForm)
            {
                _openRecurrenceForm = false;
                OnRecurrenceButton();
            }
        }

        private void dtStart_EditValueChanged(object sender, EventArgs e)
        {
            if (!IsUpdateSuspended)
                _controller.DisplayStart = dtStart.DateTime.Date + timeStart.Time.TimeOfDay;
            UpdateIntervalControls();
        }

        private void dtEnd_EditValueChanged(object sender, EventArgs e)
        {
            if (IsUpdateSuspended) return;
            if (IsIntervalValid())
                _controller.DisplayEnd = dtEnd.DateTime + timeEnd.Time.TimeOfDay;
            else
                dtEnd.EditValue = _controller.DisplayEnd.Date;
        }

        private void timeEnd_EditValueChanged(object sender, EventArgs e)
        {
            if (IsUpdateSuspended) return;
            if (IsIntervalValid())
                _controller.DisplayEnd = dtEnd.DateTime + timeEnd.Time.TimeOfDay;
            else
                timeEnd.EditValue = _controller.End.TimeOfDay;
        }

        bool IsIntervalValid()
        {
            DateTime start = dtStart.DateTime + timeStart.Time.TimeOfDay;
            DateTime end = dtEnd.DateTime + timeEnd.Time.TimeOfDay;
            return end >= start;
        }

        protected virtual void UpdateIntervalControls()
        {
            if (IsUpdateSuspended)
                return;

            SuspendUpdate();
            try
            {
                dtStart.EditValue = _controller.DisplayStart.Date;
                dtEnd.EditValue = _controller.DisplayEnd.Date;
                timeStart.EditValue = _controller.DisplayStart.TimeOfDay;
                timeEnd.EditValue = _controller.DisplayEnd.TimeOfDay;

                Appointment editedAptCopy = _controller.EditedAppointmentCopy;
                bool showControls = editedAptCopy.Type != AppointmentType.Pattern;
                dtStart.Enabled = showControls;
                dtEnd.Enabled = showControls;
                timeStart.Enabled = showControls;
                timeEnd.Enabled = showControls;

                btnRecurrence.Down = !showControls;
            }
            finally
            {
                ResumeUpdate();
            }
        }
    }
}
