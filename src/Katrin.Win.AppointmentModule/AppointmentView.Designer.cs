namespace Katrin.Win.AppointmentModule
{
    partial class AppointmentView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            StateChanged = null;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            this.schedulerControl = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStorage = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.dateNavigator = new DevExpress.XtraScheduler.DateNavigator();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // schedulerControl
            // 
            this.schedulerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl.Location = new System.Drawing.Point(0, 0);
            this.schedulerControl.Name = "schedulerControl";
            this.schedulerControl.OptionsCustomization.AllowAppointmentConflicts = DevExpress.XtraScheduler.AppointmentConflictsMode.Forbidden;
            this.schedulerControl.OptionsCustomization.AllowAppointmentMultiSelect = false;
            this.schedulerControl.OptionsCustomization.AllowInplaceEditor = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl.Size = new System.Drawing.Size(522, 509);
            this.schedulerControl.Start = new System.DateTime(2012, 12, 6, 0, 0, 0, 0);
            this.schedulerControl.Storage = this.schedulerStorage;
            this.schedulerControl.TabIndex = 0;
            this.schedulerControl.Text = "schedulerControl1";
            timeRuler1.TimeZone.Id = DevExpress.XtraScheduler.TimeZoneId.China;
            timeRuler1.UseClientTimeZone = false;
            this.schedulerControl.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl.Views.GanttView.Enabled = false;
            this.schedulerControl.Views.TimelineView.Enabled = false;
            this.schedulerControl.Views.WeekView.Enabled = false;
            timeRuler2.TimeZone.Id = DevExpress.XtraScheduler.TimeZoneId.China;
            timeRuler2.UseClientTimeZone = false;
            this.schedulerControl.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl.SelectionChanged += new System.EventHandler(this.schedulerControl_SelectionChanged);
            this.schedulerControl.ActiveViewChanged += new System.EventHandler(this.schedulerControl_ActiveViewChanged);
            this.schedulerControl.InitAppointmentDisplayText += new DevExpress.XtraScheduler.AppointmentDisplayTextEventHandler(this.schedulerControl_InitAppointmentDisplayText);
            this.schedulerControl.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.schedulerControl_EditAppointmentFormShowing);
            // 
            // schedulerStorage
            // 
            this.schedulerStorage.Appointments.Mappings.AppointmentId = "AppointmentId";
            this.schedulerStorage.Appointments.Mappings.Description = "Description";
            this.schedulerStorage.Appointments.Mappings.End = "EndTime";
            this.schedulerStorage.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
            this.schedulerStorage.Appointments.Mappings.ResourceId = "ResourceId";
            this.schedulerStorage.Appointments.Mappings.Start = "StartTime";
            this.schedulerStorage.Appointments.Mappings.Subject = "Subject";
            this.schedulerStorage.Appointments.Mappings.Type = "AppointmentType";
            this.schedulerStorage.EnableReminders = false;
            this.schedulerStorage.Resources.Mappings.Caption = "Name";
            this.schedulerStorage.Resources.Mappings.Color = "LabelColor";
            this.schedulerStorage.Resources.Mappings.Id = "ResourceId";
            this.schedulerStorage.AppointmentInserting += new DevExpress.XtraScheduler.PersistentObjectCancelEventHandler(this.schedulerStorage_AppointmentInserting);
            this.schedulerStorage.AppointmentsInserted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage_AppointmentsInserted);
            this.schedulerStorage.AppointmentChanging += new DevExpress.XtraScheduler.PersistentObjectCancelEventHandler(this.schedulerStorage_AppointmentChanging);
            this.schedulerStorage.AppointmentsChanged += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage_AppointmentsChanged);
            this.schedulerStorage.AppointmentDeleting += new DevExpress.XtraScheduler.PersistentObjectCancelEventHandler(this.schedulerStorage_AppointmentDeleting);
            this.schedulerStorage.AppointmentsDeleted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage_AppointmentsDeleted);
            // 
            // dateNavigator
            // 
            this.dateNavigator.AppearanceCalendar.Font = new System.Drawing.Font("Microsoft YaHei", 10F);
            this.dateNavigator.AppearanceCalendar.Options.UseFont = true;
            this.dateNavigator.AppearanceHeader.Font = new System.Drawing.Font("Microsoft YaHei", 10F);
            this.dateNavigator.AppearanceHeader.Options.UseFont = true;
            this.dateNavigator.AppearanceWeekNumber.Font = new System.Drawing.Font("Microsoft YaHei", 8F);
            this.dateNavigator.AppearanceWeekNumber.Options.UseFont = true;
            this.dateNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateNavigator.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dateNavigator.HotDate = null;
            this.dateNavigator.Location = new System.Drawing.Point(0, 0);
            this.dateNavigator.Name = "dateNavigator";
            this.dateNavigator.SchedulerControl = this.schedulerControl;
            this.dateNavigator.ShowTodayButton = false;
            this.dateNavigator.Size = new System.Drawing.Size(230, 509);
            this.dateNavigator.TabIndex = 1;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.schedulerControl);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.dateNavigator);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(757, 509);
            this.splitContainerControl1.SplitterPosition = 230;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // AppointmentView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "AppointmentView";
            this.Size = new System.Drawing.Size(757, 509);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerControl schedulerControl;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    }
}
