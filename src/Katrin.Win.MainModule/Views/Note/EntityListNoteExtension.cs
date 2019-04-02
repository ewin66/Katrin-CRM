using System;
using Katrin.Win.Common;
using Katrin.Win.Infrastructure;
using Microsoft.Practices.CompositeUI;
using CABDevExpress.SmartPartInfos;
using Katrin.Win.MainModule.Constants;
using Microsoft.Practices.CompositeUI.Commands;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.Controls;
using Microsoft.Practices.CompositeUI.EventBroker;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking;
using System.Reflection;
using DevExpress.Data.Filtering;

namespace Katrin.Win.MainModule.Views.Note
{
    [WorkItemExtension(typeof(EntityListController<,>), "EntityListNoteExtension")]
    public class EntityListNoteExtension : WorkItemExtension
    {
        private IDynamicDataServiceContext _dynamicDataServiceContext;

        protected IDynamicDataServiceContext DynamicDataServiceContext
        {
            get { return _dynamicDataServiceContext ?? (_dynamicDataServiceContext = new DynamicDataServiceContext()); }
        }

        protected override void OnRunStarted()
        {
            base.OnRunStarted();
            RegisterCommand("ShowPageGroup", "ShowNoteInList", "Note", null, "Notes");
            RegisterCommand("AddPageGroup", "AddNote", "Note", "add", "AddNote");
            ShowNoteListView();
            UpdateCommandStatus();
        }

        private void UpdateCommandStatus()
        {
            var status = SelectEntityId != Guid.Empty ? CommandStatus.Enabled : CommandStatus.Disabled;
            WorkItem.Commands["ShowNoteInList"].Status = status;
            WorkItem.Commands["AddNote"].Status = status;
        }

        private void RegisterCommand(string groupName, string commandName, string imageName, string overlay, string caption)
        {
            var localizedCaption = Properties.Resources.ResourceManager.GetString(caption);
            var buttonItem = new BarButtonItemEx(imageName, overlay) { Caption = localizedCaption };
            buttonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            if (WorkItem.Commands[commandName] != null)
            {
                WorkItem.Commands[commandName].AddInvoker(buttonItem, "ItemClick");
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

            NoteListView.DeleteFocusedRow();
        }

        [EventSubscription("ReloadNote", ThreadOption.Publisher)]
        public void OnReloadNote(object sender, EventArgs e)
        {
            var noteListView = NoteListView;
            if (noteListView != null)
            {
                BindNotes(noteListView);
            }
        }


        private void ShowNoteDetailView(Guid noteId)
        {
            var presenter = WorkItem.Items.AddNew<NoteDetailPresenter>();
            var addNoteView = WorkItem.Items.AddNew<NoteDetailForm>();
            presenter.WorkingMode = noteId == Guid.Empty
                                                    ? EntityDetailWorkingMode.Add
                                                    : EntityDetailWorkingMode.Edit;
            presenter.NoteId = noteId;
            presenter.ObjectType = GetEntityName();

            WorkItem.State["EntityId"] = SelectEntityId;
            addNoteView.Presenter = presenter;
            if (addNoteView.ShowDialog() == DialogResult.OK)
            {
                var noteListView = NoteListView;
                if (noteListView != null)
                {
                    BindNotes(noteListView);
                }
            }
            WorkItem.Items.Remove(presenter);
            WorkItem.Items.Remove(addNoteView);
        }

        private string GetEntityName()
        {
            var entityNamePropertyInfo = WorkItem.GetType().GetProperty("EntityName",
                                                                        BindingFlags.Instance | BindingFlags.NonPublic);
            if (entityNamePropertyInfo == null)
                throw new Exception("This extension have to work with a workitem that have Entity Name property");
            return (string) entityNamePropertyInfo.GetValue(WorkItem, null);
        }

        [CommandHandler("ShowNoteInList")]
        public void ShowNoteInList(object sender, EventArgs e)
        {
            var noteListView = NoteListView;
            if (noteListView != null)
            {
                if (noteListView.Visible)
                    WorkItem.Workspaces[WorkspaceNames.DockManagerWorkspace].Hide(noteListView);
                else
                    WorkItem.Workspaces[WorkspaceNames.DockManagerWorkspace].Show(noteListView);
            }
        }

        [CommandHandler("AddNote")]
        public void AddNote(object sender, EventArgs e)
        {
            ShowNoteDetailView(Guid.Empty);
        }

        [EventSubscription(EventTopicNames.FocusedRowChanged, Thread = ThreadOption.UserInterface)]
        public void OnFocusedRowChanged(object sender, EventArgs<object> e)
        {
            UpdateCommandStatus();
            var noteListView = NoteListView;
            if (noteListView != null)
            {
                BindNotes(noteListView);
            }
        }

        private void BindNotes(NoteListView noteListView)
        {
            noteListView.FixedPredicate = new BinaryOperator("ObjectId", SelectEntityId);
            noteListView.Bind("Note");
        }

        private Guid SelectEntityId
        {
            get
            {
                MethodInfo methodInfo = WorkItem.GetType().GetMethod("GetSelectEntityId");
                return (Guid)methodInfo.Invoke(WorkItem, null);
            }
        }

        private NoteListView NoteListView
        {
            get
            {
                string key = "NoteListView";
                var noteListView = WorkItem.Items.Get<NoteListView>(key);
                return noteListView;
            }
        }

        private void ShowNoteListView()
        {
            string key = "NoteListView";
            var noteListView = WorkItem.Items.Get<NoteListView>(key);
            if (noteListView == null)
            {
                noteListView = WorkItem.Items.AddNew<NoteListView>(key);
                WorkItem.EventTopics[EventTopicNames.FocusedRowChanged]
                    .RemovePublication(noteListView, EventTopicNames.FocusedRowChanged);
                var localizedCaption = Properties.Resources.ResourceManager.GetString("Notes");
                var info = new DockManagerSmartPartInfo
                               {
                                   ID = new Guid("E4A671F2-C37B-4C40-B3B3-53C6724586A7"),
                                   Title = localizedCaption,
                                   Name = "Note",
                                   Dock = DockingStyle.Right,
                                   XtraBounds = new System.Drawing.Rectangle(0, 0, 448, 0),
                                   Index = 0
                               };
                WorkItem.RegisterSmartPartInfo(noteListView, info);
                noteListView.InitEntityView("Note");
            }
            noteListView.Dock = DockStyle.Fill;
            BindNotes(noteListView);
            WorkItem.Workspaces[WorkspaceNames.DockManagerWorkspace].Show(noteListView);
        }
    }
}
