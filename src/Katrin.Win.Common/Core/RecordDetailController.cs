using System;
using System.Collections.Generic;
using System.Linq;
using CABDevExpress.SmartPartInfos;
using Katrin.Win.Common.MetadataServiceReference;
using Katrin.Win.Common.Security;
using Katrin.Win.Infrastructure.Services;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using DevExpress.XtraBars.Ribbon;
using System.Linq.Expressions;
using Microsoft.Practices.CompositeUI.Collections;
using System.Reflection;
using Katrin.Win.Common.Constants;
using Katrin.Win.Common.Controls;
using Microsoft.Practices.CompositeUI.EventBroker;
using DevExpress.XtraBars;
using Katrin.Win.Infrastructure;

namespace Katrin.Win.Common.Core
{
    public class RecordDetailController<TView> : WorkItem where TView : AbstractDetailView
    {
        private DetailLayoutView _detailLayoutView;
        private bool _isLoad = false;
        private UserDataPersistenceService _userDataPersistenceService;
        private TView _view;

        [EventPublication(EventTopicNames.RefreshCommandStatus, PublicationScope.WorkItem)]
        public event EventHandler RefreshCommandStatus;

        public void OnRefreshCommandStatus(EventArgs e)
        {
            EventHandler handler = RefreshCommandStatus;
            if (handler != null) handler(this, e);
        }

        public string EntityName
        {
            get { return (string) State["EntityName"]; }
            set { State["EntityName"] = value; }
        }

        public EntityDetailWorkingMode WorkingMode
        {
            get { return (EntityDetailWorkingMode) State["WorkingMode"]; }
            set
            {
                State["WorkingMode"] = value;
                _view.SetEditorStatus(WorkingMode == EntityDetailWorkingMode.View);
            }
        }

        public bool HasChanges
        {
            get { return (bool) State["HasChanges"]; }
            private set { State["HasChanges"] = value; }
        }

        public virtual void Initialize()
        {
            _userDataPersistenceService = new UserDataPersistenceService(EntityName + "Detail");
            Services.Add(_userDataPersistenceService);
            _detailLayoutView = Items.AddNew<DetailLayoutView>();
            _detailLayoutView.EntityName = EntityName;

            var homePage =
                UIExtensionSites[ExtensionSiteNames.DetailRibbon].Add(new RibbonPage(GetLocalizedCaption("Home")));
            UIExtensionSites.RegisterSite("DetailHomePage", homePage);
            var generalGroup =
                UIExtensionSites["DetailHomePage"].Add(new RibbonPageGroup(GetLocalizedCaption("General")));

            UIExtensionSites.RegisterSite("DetailGeneralPageGroup", generalGroup);
            RegisterGenearlCommand("SaveAndClose", "Save", "Exit");
            RegisterGenearlCommand("Save", "Save", null);
            RegisterGenearlCommand("DetailGeneralPageGroup", "EditMode", "Edit", null, "Edit");
        }


        protected virtual void UpdateCommandStatus()
        {
            Commands["EditMode"].Status = WorkingMode == EntityDetailWorkingMode.View &&
                                          AuthorizationManager.CheckAccess(EntityName, "Write")
                                              ? CommandStatus.Enabled
                                              : CommandStatus.Unavailable;
            if (WorkingMode == EntityDetailWorkingMode.View)
            {
                Commands["SaveAndClose"].Status = CommandStatus.Unavailable;
                Commands["Save"].Status = CommandStatus.Unavailable;
            }
            else
            {
                Commands["SaveAndClose"].Status = HasChanges ? CommandStatus.Enabled : CommandStatus.Disabled;
                Commands["Save"].Status = HasChanges ? CommandStatus.Enabled : CommandStatus.Disabled;
            }
            OnRefreshCommandStatus(EventArgs.Empty);
        }


        protected override void OnRunStarted()
        {
            ShowDetailView();

            Workspaces[WorkspaceNames.RibbonWindows].Show(_detailLayoutView);
            HasChanges = false;
            UpdateCommandStatus();
            base.OnRunStarted();
            _isLoad = true;
        }


        #region RegisterCommand
        protected void RegisterGenearlCommand(string commandName, string imageName, string overlay)
        {
            RegisterGenearlCommand("DetailGeneralPageGroup", commandName, imageName, overlay, commandName);
        }

        protected void RegisterShowCommand(string commandName, string imageName, string overlay, string caption)
        {
            RegisterGenearlCommand(ExtensionSiteNames.DetailShowRibbonPageGroup, commandName, imageName, overlay,
                                    caption);
        }

        public void RegisterGenearlCommand(string groupName, string commandName, string imageName, string overlay,
                                            string caption)
        {
            var localizedCaption = GetLocalizedCaption(caption);
            var buttonItem = new BarButtonItemEx(imageName, overlay) {Caption = localizedCaption};
            if (imageName != "Save")
            {
                buttonItem.ButtonStyle = BarButtonStyle.Check;
            }
            if (Commands[commandName] != null)
            {
                Commands[commandName].AddInvoker(buttonItem, "ItemClick");
            }
            buttonItem.Name = commandName;
            UIExtensionSites[groupName].Add(buttonItem);
        }

        #endregion


        protected string GetLocalizedCaption(string name)
        {
            return Properties.Resources.ResourceManager.GetString(name);
        }


        protected static Type FindLoadedType(string typeName)
        {
            return
                (from assem in AppDomain.CurrentDomain.GetAssemblies().Where(asm => asm.FullName.StartsWith("Katrin"))
                 select assem.GetTypes().Where(t => t.Name == typeName)
                 into query where query.Any() select query.Single()).FirstOrDefault();
        }

        private LambdaExpression CreateLambda(Type type)
        {
            var pa = Expression.Constant(this);
            var items = Expression.Property(pa, "Items");

            var source = Expression.Parameter(
                typeof (ManagedObjectCollection<>).MakeGenericType(type), "source");

            var call = Expression.Call(
                typeof (ManagedObjectCollection<>), "AddNew", new Type[] {type}, source);

            return Expression.Lambda(call, source);
        }

        [CommandHandler("EditMode")]
        public void OnEditMode(object sender, EventArgs e)
        {
            WorkingMode = EntityDetailWorkingMode.Edit;
            UpdateCommandStatus();
        }

        [CommandHandler("ShowGeneral")]
        public void OnView(object sender, EventArgs e)
        {
            ShowDetailView();
        }

        private void ShowDetailView()
        {
            const string key = "Details";
            _view = Items.Get<TView>(key);
            if (_view == null)
            {
                _view = Items.AddNew<TView>(key);
                _view.TurnOnChangeTracker();
            }
            var info = new XtraTabSmartPartInfo {Title = EntityName};

            Workspaces[WorkspaceNames.DetailContentWorkspace].Show(_view, info);
        }

        public TView View
        {
            get { return _view; }
        }

        [EventSubscription(EventTopicNames.ObjectChanged, Thread = ThreadOption.UserInterface)]
        public void OnObjectChanged(object sender, EventArgs e)
        {
            if (!_isLoad) return;
            HasChanges = true;
            UpdateCommandStatus();
        }

        [EventSubscription(EventTopicNames.EntitySaved, Thread = ThreadOption.UserInterface)]
        public void OnEntitySaved(object sender, EventArgs<bool> e)
        {
            HasChanges = e.Data;
            UpdateCommandStatus();
        }

        protected override void OnTerminated()
        {
            _userDataPersistenceService.SaveUserData(_view);
            _userDataPersistenceService.SaveUserData(_detailLayoutView);
            base.OnTerminated();
        }

        
    }
}
