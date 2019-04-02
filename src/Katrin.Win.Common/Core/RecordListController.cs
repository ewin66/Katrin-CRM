using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.CompositeUI;
using Katrin.Win.Common.Controls;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.Commands;
using DevExpress.XtraEditors;
using Katrin.Win.Common.Constants;
using Microsoft.Practices.CompositeUI.EventBroker;
using Katrin.Win.Infrastructure;

namespace Katrin.Win.Common.Core
{
    public abstract class RecordListController<TListView, TDetailView> : WorkItem
        where TListView : EntityListView
        where TDetailView : AbstractDetailView
    {
        protected TListView _entityListView;

        protected abstract string EntityName { get; }

        private IDynamicDataServiceContext _dynamicDataServiceContext;

        protected IDynamicDataServiceContext DynamicDataServiceContext
        {
            get { return _dynamicDataServiceContext ?? (_dynamicDataServiceContext = new DynamicDataServiceContext()); }
        }


        #region Init
        protected override void OnRunStarted()
        {
            InitController();
            BindListData();
            base.OnRunStarted();
        }

        protected virtual void InitController()
        {
            string generalPageGroup = "GeneralPageGroup";
            RegisterCommandInvoker("Add", EntityName, "Add", generalPageGroup, false, 65);
            RegisterCommandInvoker("Edit", EntityName, "Edit", generalPageGroup, false, 69);
            RegisterCommandInvoker("View", EntityName, "View", generalPageGroup, true, 86);
            RegisterCommandInvoker("Delete", EntityName, "Delete", generalPageGroup, true, 68);
            RegisterCommandInvoker("Refresh", "Refresh", null, generalPageGroup, true, 82);
            InitViewList();
        }

        protected virtual void InitViewList()
        {
            if (_entityListView == null)
            {
                _entityListView = Items.AddNew<TListView>();
                _entityListView.InitEntityView(EntityName);
            }

            object startView = GetStartView();
            Workspaces[WorkspaceNames.ShellContentWorkspace].Show(startView);
        }

        protected virtual object GetStartView()
        {
            return _entityListView;
        }

        protected virtual void BindListData()
        {
            if (_entityListView != null)
            {
                _entityListView.Bind(EntityName);
            }
        }
        #endregion


        #region command
        protected void RegisterCommandInvoker(string commandName, string imageName, string overlay, string pageGroup, bool isSmall, int shortCut)
        {
            var localizedCaption = GetLocalizedCaption(commandName);
            var buttonItem = new BarButtonItemEx(imageName, overlay) { Caption = localizedCaption };
            if (shortCut != 0)
                buttonItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((
                    Keys.Alt |
                    (Keys)shortCut));
            if (isSmall)
                buttonItem.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText |
                    DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            buttonItem.Name = commandName;
            Commands[commandName].AddInvoker(buttonItem, "ItemClick");

            UIExtensionSites[pageGroup].Add(buttonItem);
        }

        [CommandHandler("View")]
        public virtual void OnView(object sender, EventArgs e)
        {
            Guid id = GetId(_entityListView.SelectedEntity);
            ShowEntityDetails<TDetailView>(EntityDetailWorkingMode.View, EntityName, id);

        }

        [CommandHandler("Add")]
        public void OnAdd(object sender, EventArgs e)
        {
            ShowEntityDetails<TDetailView>(EntityDetailWorkingMode.Add, EntityName, Guid.Empty);
        }

        [CommandHandler("Edit")]
        public virtual void OnEdit(object sender, EventArgs e)
        {
            Guid id = GetId(_entityListView.SelectedEntity);
            ShowEntityDetails<TDetailView>(EntityDetailWorkingMode.Edit, EntityName, id);
        }

        [CommandHandler("Delete")]
        public void OnDelete(object sender, EventArgs e)
        {
            var deleteObject = _entityListView.SelectedEntity;
            if (deleteObject != null)
            {
                DialogResult dialogResult = XtraMessageBox.Show(_entityListView,
                    Properties.Resources.DeleteListItemWarning,
                    Properties.Resources.Katrin,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (dialogResult == DialogResult.OK)
                {
                    DynamicDataServiceContext.DeleteObject(EntityName, deleteObject);
                    DynamicDataServiceContext.SaveChanges();
                    OnRefresh(null, null);
                }
            }
        }

        [CommandHandler("Refresh")]
        public void OnRefresh(object sender, EventArgs e)
        {
            _entityListView.RefreshList(EntityName);
        }

        public void ShowEntityDetails<T>(EntityDetailWorkingMode workingMode, string entityName, Guid id) where T : AbstractDetailView
        {
            string key = id + entityName + ":DetailWorkItem";

            var detailWorkItem = Items.Get<EnityDetailController<T>>(key);

            if (detailWorkItem == null)
            {
                detailWorkItem = Items.AddNew<EnityDetailController<T>>(key);
                detailWorkItem.EntityName = entityName;
                detailWorkItem.Initialize();
            }
            if (workingMode == EntityDetailWorkingMode.Convert)
            {
                detailWorkItem.State["ConvertEntiy"] = _entityListView.SelectedEntity;
                detailWorkItem.State["ConvertName"] = EntityName;
            }
            detailWorkItem.State["EntityId"] = id;
            detailWorkItem.State["WorkingMode"] = workingMode;
            detailWorkItem.Run();
            if (detailWorkItem.View == null) return;
            detailWorkItem.View.Context = _entityListView.Context;
        }
        #endregion

        [EventSubscription(EventTopicNames.RowDoubleClick, Thread = ThreadOption.UserInterface)]
        public void OnRowDoubleClick(object sender, EventArgs<object> e)
        {
            OnView(sender, e);
        }

        protected abstract Guid GetId(object entity);

        protected string GetLocalizedCaption(string name)
        {
            return Properties.Resources.ResourceManager.GetString(name);
        }
    }
}
