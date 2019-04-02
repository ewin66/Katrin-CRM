using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Ribbon;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.MVC;
using System.Collections.ObjectModel;
using Katrin.AppFramework.WinForms.Doozers;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.ConfigService;
using Katrin.AppFramework.WinForms.ContextMenu;
using Katrin.AppFramework.WinForms.CommandManage;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.Context;

namespace Katrin.AppFramework.WinForms.Workspaces
{
    public partial class RibbonFormWorkspace : DevExpress.XtraBars.Ribbon.RibbonForm, IWorkspace1, IListener<ToggleVisibilityMessage>, IListener<ActivateViewMessage>, ILayoutRemember, IListener<UpdateRibbonItemMessage>, IControllerFinder,  IProcessInfo
    {
        private IConfigService _config;
        private CommandManager _commandManager;
        private Guid _wokspaceID;
        private Dictionary<string, IController> _controllers = new Dictionary<string, IController>();
        private IController _mainController;
        private IWorkSpaceContext _workspaceContext;

        public RibbonFormWorkspace(ActionParameters parameters)
        {
            InitializeComponent();
            EventAggregationManager.AddListener(this);
            _wokspaceID = Guid.NewGuid();

            _config = new ConfigService.ConfigService();
            _workspaceContext = new WorkSpaceContext(this, this, this,parameters,this);
           
        }

        public string BasePath { get; set; }
        public string ObjectName { get; set; }
        public string ControllerId { get; set; }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int LockWindowUpdate(IntPtr hWnd);

        public void LockWindow()
        {
            LockWindowUpdate(this.Handle);
        }

        public void UnLockWindow()
        {
            LockWindowUpdate((IntPtr)0);
        }

        void IListener<ToggleVisibilityMessage>.Handle(ToggleVisibilityMessage message)
        {
            if (ObjectName != message.ObjectName) return;
            if (this._wokspaceID != message.WorkSpaceID) return;

            var panel = dockManager1.Panels[message.ViewName];
            if (panel != null)
            {
                LockWindow();
                ToggleViewVisibility(panel);
                UnLockWindow();
            }
        }

        private void ToggleViewVisibility(DockPanel panel)
        {
            if (panel.Visibility == DockVisibility.Hidden)
                panel.Show();
            else
                panel.Hide();
        }
        public IActionResult ActionResult
        {
            get;
            private set;
        }
        public IView ActiveView
        {
            get;
            private set;
        }

        private Dictionary<string, IView> _views = new Dictionary<string, IView>();

        public void AddView(IView view)
        {
            Guard.ObjectIsInstanceOfType(view, typeof(Control), "view");
            _views.Add(view.ViewName, view);
            view.WorkSpaceID = this._wokspaceID;
            view.Context = this._workspaceContext;
            MenuCreater creater = new MenuCreater();
            PopupMenu menu = creater.CreateMenu(this.ObjectName,
                   view.ViewName,
                   this.ribbon,
                   this._commandManager);
            if (menu != null)
            {
                //this.ribbon.SetPopupContextMenu(view as Control, menu);
                if (view is IObjectListView)
                {
                    ((IObjectListView)view).PopupMenu = menu;
                }
            }
        }

        public void RemoveView(IView view)
        {
            _views.Remove(view.ViewName);
        }

        public ReadOnlyCollection<IView> Views
        {
            get { return _views.Values.ToList().AsReadOnly(); }
        }

        public string Title
        {
            get
            {
                return this.Text;
            }
            set
            {
                Text = value;
            }
        }
        public Guid ID
        {
            get { return _wokspaceID; }
        }
        public bool IsViewShowing(string viewId)
        {
            string[] paths = BasePath.Split('/');
            if (paths.Length > 0)
            {
                if (paths[paths.Length - 1] == "Detail")
                {
                    if (ActiveView != null && ActiveView.ViewName == viewId)
                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }
                }
                else if (paths[paths.Length - 1] == "List")
                {
                    return this.IsDockViewShowing(viewId);
                }
                else
                {
                    throw new Exception("Error basePath :" + BasePath);
                }
            }
            else
            {
                throw (new Exception("Error basePath :" + BasePath));
            }
          
        }

        private bool IsDockViewShowing(string viewId)
        {
            foreach (DockPanel panel in this.dockManager1.Panels)
            {
                if (panel.Visibility != DockVisibility.Hidden && panel.Name == viewId)
                {
                    return true;
                }
            }
            return false;
        }
        public void LoadViews(ActionParameters parameters)
        {
            var dockPath = BasePath + "/DockPanels";

            if (AddInTree.ExistsTreeNode(dockPath))
            {
                LoadMainView(dockPath, parameters);

                var descriptors = AddInTree.BuildItems<object>(dockPath, this, false).OfType<DockPanelDescriptor>().ToList();

                foreach (var descriptor in descriptors)
                {
                    bool isLazy = false;
                    bool.TryParse(descriptor.Codon.Properties["lazy"], out isLazy);
                    if (isLazy) continue;
                    var controller = ControllerFactory.CreateController(descriptor.ControllerId);
                    controller.WorkSpaceID = this.ID;
                    controller.Context = this._workspaceContext;
                    _controllers[descriptor.ControllerId] = controller;
                    InitObjectWidget(controller);
                    var result = new ActionInvoker().Invoke(controller, null, parameters) as IPartialViewResult;
                    if (result != null)
                    {
                        result.View.ViewName = descriptor.Codon.Id;
                        AddView(result.View);
                        CreateDockPanel(descriptor, result.View);
                    }
                }
            }
            else
            {
                throw new Exception("Config path not found:" + dockPath);
            }

            WorkSpaceTextLoader txtLoader = new WorkSpaceTextLoader();
            string mainText = string.Empty;
            Title = txtLoader.GetListWorkSpaceTitle(ObjectName, out mainText);
            this.UpdateRibbonItems();
        }
        private void LoadCommands()
        {
            _commandManager = new CommandManager(this._workspaceContext, this.ribbon.Manager);
            string commandPath = BasePath + "/Commands";
            string commandOverridePath = BasePath + "/CommandOverrides";
            this._commandManager.LoadCommands(commandPath);
            this._commandManager.OverrideCommands(commandOverridePath);
        }
        private void LoadMainView(string dockPath, ActionParameters parameters)
        {
            var viewDescriptors = AddInTree.BuildItems<object>(dockPath, this, false).OfType<ViewDescriptor>().ToList();

            if (!viewDescriptors.Any())
                throw new Exception(string.Format("{0} doesn't contains any view, please check it", dockPath));
            if (viewDescriptors.Count > 1 && !viewDescriptors.Any(c => c.Codon.Properties.Contains("MainView")))
                throw new Exception(string.Format("One screen only supprt one view, {0} contains more then one view, please check it", dockPath));
            var mainViewDescriptor = viewDescriptors[0];
            if (viewDescriptors.Any(c => c.Codon.Properties.Contains("MainView")))
                mainViewDescriptor = viewDescriptors.Where(c => c.Codon.Properties.Contains("MainView")).First();
            if (!mainViewDescriptor.Codon.Properties.Contains("controller"))
                throw new Exception(string.Format("{0}/{1} doesn't contains controller property, please check it", dockPath, mainViewDescriptor.Id));
            _mainController = ControllerFactory.CreateController(mainViewDescriptor.Codon.Properties["controller"]);
            _mainController.WorkSpaceID = this.ID;
            _mainController.Context = this._workspaceContext;
            this.LoadCommands();

            var ribbonPath = BasePath + "/Ribbon";
            if (AddInTree.ExistsTreeNode(ribbonPath))
            {
                RibbonManager.AddItemsToMenu(ribbon, _mainController, ribbonPath, this._commandManager);
            }
            parameters.Add("ribbonControl", this.ribbon);
            ActionResult = new ActionInvoker().Invoke(_mainController, null, parameters) as IActionResult;
            var result = ActionResult as IPartialViewResult;
            if (result == null) return;
            result.View.ViewName = mainViewDescriptor.Codon.Id;
            var mainControl = (Control)result.View;
            if (viewDescriptors.Count > 1)
                LoadSubViews(viewDescriptors.Where(c => !c.Codon.Properties.Contains("MainView")).ToList(), dockPath, parameters, mainControl);
            mainControl.Dock = DockStyle.Fill;
            AddView(result.View);
            this.Controls.Add(mainControl);
            ActiveView = result.View;
        }

        private void LoadSubViews(List<ViewDescriptor> subViews, string dockPath, ActionParameters parameters, Control mainControl)
        {
            foreach (var subView in subViews)
            {
                if (!subView.Codon.Properties.Contains("controller"))
                    throw new Exception(string.Format("{0}/{1} doesn't contains controller property, please check it", dockPath, subView.Id));
                var subController = ControllerFactory.CreateController(subView.Codon.Properties["controller"]);
                _controllers[subView.Codon.Properties["controller"]] = subController;
                subController.WorkSpaceID = this.ID;
                subController.Context = this._workspaceContext;
                var subActionResult = new ActionInvoker().Invoke(subController, null, parameters) as IActionResult;
                var result = subActionResult as IPartialViewResult;
                if (result == null) continue;
                result.View.ViewName = subView.Codon.Id;
                var subControl = (Control)result.View;
                subControl.Dock = DockStyle.Top;
                mainControl.Controls.Add(subControl);
            }
        }

        private void InitObjectWidget(object obj)
        {
            var objectWidget = obj as IObjectWidget;
            if (objectWidget == null) return;
            objectWidget.ParentObjectName = ObjectName;
        }

        private void CreateDockPanel(DockPanelDescriptor descriptor, IView view)
        {
            var dockPanel = dockManager1.AddPanel(DockingStyle.Right);

            dockPanel.Name = descriptor.Codon.Id;

            dockPanel.Text = StringParser.Parse(descriptor.Codon.Properties["label"]);
            string strGuid = descriptor.Codon.Properties["guid"];
            dockPanel.ID = new Guid(strGuid);

            SetPanelWidth(descriptor.Codon, dockPanel);
            var control = (Control)view;
            control.Dock = DockStyle.Fill;
            dockPanel.Controls.Add(control);
            dockPanel.Name = view.ViewName;
            dockPanel.VisibilityChanged += dockPanel_VisibilityChanged;

            if (dockManager1.Panels.Count <= 1) return;
            string dockType = descriptor.Codon.Properties["DockType"];
            if (string.IsNullOrEmpty(dockType)) return;
            string dockTo = descriptor.Codon.Properties["DockTo"];
            if (string.IsNullOrEmpty(dockTo)) return;
            DockPanel dockToPanel = dockManager1.Panels[dockTo];
            if (dockToPanel == null) return;
            if (dockType == "Tab") dockPanel.DockAsTab(dockToPanel);
            else if (dockType == "Bottom") dockPanel.DockTo(dockToPanel);
            else if (dockType == "Top") dockToPanel.DockTo(dockPanel);
        }

        void dockPanel_VisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (e.Panel.Controls.Count == 1)
            {              
                if (e.Visibility == DockVisibility.Hidden)
                {
                    this._commandManager.UpdateViewCheckCommandState(e.Panel.Name, false);
                }
                else
                {
                    this._commandManager.UpdateViewCheckCommandState(e.Panel.Name, true);
                }

            }
        }


        private static void SetPanelWidth(Codon codon, DockPanel panel)
        {
            string panelWidth = codon.Properties["width"];
            if (string.IsNullOrEmpty(panelWidth)) return;
            panel.Width = int.Parse(panelWidth);
        }

        protected override void OnLoad(EventArgs e)
        {
            var message = new ViewManageMessage
            {
                ViewName = this.Name,
                ViewAction = ViewAction.Add,
                RelationObject = this
            };
            EventAggregationManager.SendMessage(message);
            this.SaveDefaultLayout();
            if (this._mainController is ListController)
            {                      
               this.RestoreLayout();
            }
            base.OnLoad(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.SaveLayout();
            var message = new ViewManageMessage
            {
                ViewName = this.Name,
                ViewAction = ViewAction.Remove
            };
            EventAggregationManager.SendMessage(message);
            base.OnClosing(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                EventAggregationManager.RemoveListener(this);
                if (_mainController != null)
                {
                    _mainController.Dispose();
                    _mainController = null;
                }
                ActionResult = null;
                ActiveView = null;
                if (_controllers != null)
                {
                    _controllers.Clear();
                    _controllers = null;
                }
                if (_views != null)
                {
                    _views.Clear();
                    _views = null;
                }

                if (components != null)
                {
                    components.Dispose();
                }
                BindingContext = null;
                if (this._commandManager != null)
                {
                    this._commandManager.Dispose();
                    this._commandManager = null;
                }
                if (this._workspaceContext != null)
                {
                    this._workspaceContext.Dispose();
                    this._workspaceContext = null;
                }
               
            }
            base.Dispose(disposing);
            LoggingService.InfoFormatted(" Start SuppressFinalize WorkSpace {0}:{1}", this.ObjectName, DateTime.Now.ToString("HH:mm:ss fff"));
            GC.Collect();
            GC.SuppressFinalize(this);
            LoggingService.InfoFormatted(" End SuppressFinalize WorkSpace {0}:{1}", this.ObjectName, DateTime.Now.ToString("HH:mm:ss fff"));
        }

        void IListener<ActivateViewMessage>.Handle(ActivateViewMessage message)
        {
            if (this.ID == message.WorkSpaceID)
            {
                ActivateView(message);
            }
        }

        private void ActivateView(ActivateViewMessage message)
        {
            var viewName = message.ViewName;
            if (_views.ContainsKey(viewName))
            {
                var view = (Control)_views[viewName];
                if (Controls.Contains(view))
                {
                    view.BringToFront();
                    ActiveView = _views[viewName];
                    UpdateRibbonItems();
                }
            }
            else
            {
                var viewPath = BasePath + "/DockPanels/" + viewName;
                if (!AddInTree.ExistsTreeNode(viewPath)) return;
                var viewDescriptor = (DockPanelDescriptor)AddInTree.BuildItem(viewPath, null);
                if (viewDescriptor == null) throw new Exception(string.Format("{0} doesn't exist in addin file, please check it.", viewPath));
                var controller = ControllerFactory.CreateController(viewDescriptor.ControllerId);
                this._controllers[viewDescriptor.ControllerId] = controller;
                var result = new ActionInvoker().Invoke(controller, null, message.Parameters) as IPartialViewResult;
                if (result != null)
                {
                    result.View.ViewName = viewDescriptor.Codon.Id;
                    AddView(result.View);
                    var view = (Control)result.View;
                    view.Dock = DockStyle.Fill;
                    this.Controls.Add(view);
                    view.BringToFront();
                    ActiveView = result.View;
                    InitObjectWidget(controller);
                    UpdateRibbonItems();
                }
            }
        
        }

        void IListener<UpdateRibbonItemMessage>.Handle(UpdateRibbonItemMessage message)
        {
            if (message.WorkSpaceID != this._wokspaceID)
            {
                return;
            }           
            this.UpdateRibbonItems();
        }

        private void UpdateRibbonItems()
        {
            if (this._commandManager == null)
            {
                throw new Exception("CommandManager not initialization");
            }
            this._commandManager.UpdateCommandState(this);
        }
        #region ContextMenu & CommandManage
        private void SetContextMenu()
        {

            MenuCreater creater = new MenuCreater();
            foreach (KeyValuePair<string, IView> viewKey in this._views)
            {
                PopupMenu menu = creater.CreateMenu(this.ObjectName,
                    viewKey.Value.ViewName,
                    this.ribbon,
                    this._commandManager);
                if (menu != null)
                {
                    this.ribbon.SetPopupContextMenu(viewKey.Value as Control, menu);
                }
            }
        }


        #endregion

        #region ILayoutRemember
        private string GetBasePath()
        {
            return this.BasePath.Replace("/", ".");
        }

        private IFilter GetFilter()
        {
            foreach (var item in this.ribbon.Items)
            {
                if (item is IFilter)
                {
                    return item as IFilter;
                }
            }
            return null;
        }
        public void SaveLayout()
        {
            this._config.SaveDockManagerLayout(this.dockManager1, "DOCKMANAGER_" + this.GetBasePath() + this.ObjectName);
            foreach (KeyValuePair<string, IView> viewKey in this._views)
            {
                if (viewKey.Value is ILayoutRemember)
                {
                    ILayoutRemember ilayout = viewKey.Value as ILayoutRemember;
                    ilayout.SaveLayout();
                }

            }
            //WorkspceForm
            this._config.SaveFormLayOut(this, "WORKSPACE_" + this.GetBasePath() + this.ObjectName);
            //Filter
            IFilter filter = this.GetFilter();
            if (filter != null)
            {
                string filterName = filter.GetSelectedFilterName();
                this._config.SaveMainFilter(filterName, "FILTER_" + this.GetBasePath() + this.ObjectName);
            }
        }

        public void RestoreLayout()
        {
            //save default
            this._config.SaveDockManagerLayout(this.dockManager1, "DEFAULT_DOCKMANAGER_" + this.GetBasePath() + this.ObjectName);
            //restore
            this._config.RestoreDockManagerLayout(this.dockManager1, "DOCKMANAGER_" + this.GetBasePath() + this.ObjectName);
            foreach (KeyValuePair<string, IView> viewKey in this._views)
            {
                if (viewKey.Value is ILayoutRemember)
                {
                    ILayoutRemember ilayout = viewKey.Value as ILayoutRemember;
                    ilayout.RestoreLayout();
                }
            }
            this._config.RestoreFormLayout("WORKSPACE_" + this.GetBasePath() + this.ObjectName, this);

            //Filter
            IFilter filter = this.GetFilter();
            if (filter != null)
            {
                string defaultFilter = filter.GetSelectedFilterName();
                string filterName = this._config.GetMainFilter("FILTER_" + this.GetBasePath() + this.ObjectName, defaultFilter);
                filter.SetItemChecked(filterName);
            }

        }    
        public void RestoreDefaultLayout()
        {
            //restore default
            this._config.RestoreDockManagerLayout(this.dockManager1, "DEFAULT_DOCKMANAGER_" + this.GetBasePath() + this.ObjectName);
            foreach (KeyValuePair<string, IView> viewKey in this._views)
            {
                if (viewKey.Value is ILayoutRemember)
                {
                    ILayoutRemember ilayout = viewKey.Value as ILayoutRemember;
                    ilayout.RestoreDefaultLayout();
                }
            }
        }

        public void SaveDefaultLayout()
        {
            //save default
            this._config.SaveDockManagerLayout(this.dockManager1, "DEFAULT_DOCKMANAGER_" + this.GetBasePath() + this.ObjectName);
            foreach (KeyValuePair<string, IView> viewKey in this._views)
            {
                if (viewKey.Value is ILayoutRemember)
                {
                    ILayoutRemember ilayout = viewKey.Value as ILayoutRemember;
                    ilayout.SaveDefaultLayout();
                }
            }
        }
        #endregion
        #region IControllerFinder
        public IController FindController(string controllerId)
        {
            if (controllerId == string.Empty)
            {              
                return this._mainController;
            }
            else
            {
                if (this._controllers.ContainsKey(controllerId))
                {
                    return this._controllers[controllerId];
                }
                else
                {
                    //throw new Exception("ControllerId not exist:" + controllerId + " in " + this.BasePath);
                    return null;
                }
            }
        }
        public T FindController<T>(string controllerId)
        {
            if (this._mainController is T)
            {
                return (T)this._mainController;
            }
            IController controller = this.FindController(controllerId);
            return (T)controller;
        }
        #endregion 
       

        private void RibbonFormWorkspace_FormClosing(object sender, FormClosingEventArgs e)
        {
            //IObjectDetailController detailController = _mainController as IObjectDetailController;
            //if (detailController != null && detailController.HasChanges)
            //{
            //    string question = ResourceService.GetString("AlertSave");
            //    string caption = ResourceService.GetString("Katrin");
            //    DialogResult needSave = MessageService.AskQuestionYesNoCancel(question, caption);
            //    if (needSave == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        detailController.SaveAndClose();
            //    }
            //    else if (needSave == System.Windows.Forms.DialogResult.Cancel)
            //    {
            //        e.Cancel = true;
            //    }
            //}
           
        }

        private void RibbonFormWorkspace_FormClosed(object sender, FormClosedEventArgs e)
        {
            EventAggregationManager.RemoveListener(this);

            EventAggregationManager.RemoveListener(this._mainController);
            
            foreach (var controller in this._controllers)
            {
                EventAggregationManager.RemoveListener(controller.Value);
                controller.Value.Dispose();
            }
        }

        public void UpdateCommandState()
        {
            this.UpdateRibbonItems();
        }


        public void ActiveWorkSpaceWindow()
        {
            this.BringToFront();
            this.Activate();
        }

        public void Deactivated()
        {
            if (!(ActiveView is BaseView)) return;
            var baseView = ActiveView as BaseView;
            baseView.OnDeactivated();
        }

        public void Activated()
        {
            if (!(ActiveView is BaseView)) return;
            var baseView = ActiveView as BaseView;
            baseView.OnActivated();
        }



        #region IProcessInfo
        public void BeginProcess()
        {
            this.itemProgress.Visibility = BarItemVisibility.Always;
        }

        public void ShowProcessInfo(string processInfo)
        {
            throw new NotImplementedException();
        }

        public void EndProcess()
        {
            this.itemProgress.Visibility = BarItemVisibility.Never;
        }
        #endregion

        private void RibbonFormWorkspace_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }   

      
    }
}
