using System;
using System.Collections.Generic;
using System.Linq;
using Katrin.Win.Infrastructure;
using Microsoft.Practices.CompositeUI;
using CABDevExpress.SmartPartInfos;
using Katrin.Win.MainModule.Constants;
using Microsoft.Practices.CompositeUI.Commands;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.Controls;
using System.Windows.Forms;
using Katrin.Win.Common;
using DevExpress.XtraEditors;
using Microsoft.Practices.CompositeUI.EventBroker;
using DevExpress.Data.Filtering;

namespace Katrin.Win.MainModule.Views.Note
{
    [WorkItemExtension(typeof(EnityDetailController<>), "EntityDetailNoteExtension")]
    public class EntityDetailNoteExtension : WorkItemExtension
    {

        [EventPublication("ReloadNote", PublicationScope.Global)]
        public event EventHandler OnReloadNote;

        private IDynamicDataServiceContext _dynamicDataServiceContext;

        protected IDynamicDataServiceContext DynamicDataServiceContext
        {
            get { return _dynamicDataServiceContext ?? (_dynamicDataServiceContext = new DynamicDataServiceContext()); }
        }

        public string EntityName
        {
            get { return (string)WorkItem.State["EntityName"]; }
        }

        public EntityDetailWorkingMode WorkingMode
        {
            get { return (EntityDetailWorkingMode)WorkItem.State["WorkingMode"]; }
        }

        public Guid EntityId
        {
            get { return (Guid)WorkItem.State["EntityId"]; }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void OnRunStarted()
        {
            base.OnRunStarted();
            RegisterCommand(ExtensionSiteNames.DetailShowRibbonPageGroup, "ShowNoteInDetail", "Note", null, "Notes");
            RegisterCommand(ExtensionSiteNames.DetailAddGroup, "AddDetailNote", "Note", "add", "AddNote");
            UpdateCommandStatus();
        }

        [EventSubscription(EventTopicNames.RefreshCommandStatus, Thread = ThreadOption.UserInterface)]
        public void OnRefreshCommandStatus(object sender, EventArgs e)
        {
            UpdateCommandStatus();
        }

        private void UpdateCommandStatus()
        {
            var status = WorkingMode != EntityDetailWorkingMode.Add ? CommandStatus.Enabled : CommandStatus.Disabled;
            WorkItem.Commands["ShowNoteInDetail"].Status = status;
            WorkItem.Commands["AddDetailNote"].Status = status;
        }

        private void RegisterCommand(string groupName, string commandName, string imageName, string overlay, string caption)
        {
            var localizedCaption = Properties.Resources.ResourceManager.GetString(caption);
            var buttonItem = new BarButtonItemEx(imageName, overlay) { Caption = localizedCaption };
            if (WorkItem.Commands[commandName] != null)
            {
                WorkItem.Commands[commandName].AddInvoker(buttonItem, "ItemClick");
            }
            if (commandName == "ShowNoteInDetail")
            {
                buttonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            }
            buttonItem.Name = commandName;
            WorkItem.UIExtensionSites[groupName].Add(buttonItem);
        }

        [EventSubscription("EditNote", ThreadOption.UserInterface)]
        public void OnEditNote(object sender, EventArgs<Guid> e)
        {
            ShowNoteDetailView(e.Data);
        }

        [EventSubscription("DeleteNote", ThreadOption.UserInterface)]
        public void DeleteNote(object sender, EventArgs<Guid> e)
        {
            var noteEntity = DynamicDataServiceContext.GetOrNew("Note", e.Data);
            DynamicDataServiceContext.DeleteObject("Note", noteEntity);
            DynamicDataServiceContext.SaveChanges();

            string key = "NoteDetailListView";
            var noteListView = WorkItem.Items.Get<NoteListView>(key);
            noteListView.DeleteFocusedRow();
            if (OnReloadNote != null)
                OnReloadNote(this, new EventArgs());
        }

        [CommandHandler("ShowNoteInDetail")]
        public void ShowNoteInDetail(object sender, EventArgs e)
        {
            ShowNoteListView();
        }

        [CommandHandler("AddDetailNote")]
        public void AddDetailNote(object sender, EventArgs e)
        {
            ShowNoteDetailView(Guid.Empty);
        }

        private void ShowNoteDetailView(Guid noteId)
        {
            var presenter = WorkItem.Items.AddNew<NoteDetailPresenter>();
            var addNoteView = WorkItem.Items.AddNew<NoteDetailForm>();
            presenter.WorkingMode = noteId == Guid.Empty
                                                    ? EntityDetailWorkingMode.Add
                                                    : EntityDetailWorkingMode.Edit;
            presenter.NoteId = noteId;
            presenter.ObjectType = EntityName;
            addNoteView.Presenter = presenter;
            if (addNoteView.ShowDialog() == DialogResult.OK)
            {
                ShowNoteListView();
                if (OnReloadNote != null)
                    OnReloadNote(this, new EventArgs());
            }
            WorkItem.Items.Remove(presenter);
            WorkItem.Items.Remove(addNoteView);
        }

       

        private void ShowNoteListView()
        {
            string key = "NoteDetailListView";
            var noteListView = WorkItem.Items.Get<NoteListView>(key);
            if (noteListView == null)
            {
                noteListView = WorkItem.Items.AddNew<NoteListView>(key);
                var info = new XtraTabSmartPartInfo { Title = "Notes" };
                WorkItem.RegisterSmartPartInfo(noteListView, info);
                noteListView.InitEntityView("Note");
            }
            noteListView.FixedPredicate = new BinaryOperator("ObjectId", EntityId);
            noteListView.Bind("Note");
            WorkItem.Workspaces[WorkspaceNames.DetailContentWorkspace].Show(noteListView);
            
        }
    }
}
