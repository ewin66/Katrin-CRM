using Katrin.AppFramework;
using Katrin.AppFramework.Parts;
using Katrin.AppFramework.Messages;
using Katrin.AppFramework.UIElements;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Ribbon;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Katrin.AppFramework.WinForms.Workspaces;
using Katrin.AppFramework.WinForms.MVC;
using DevExpress.Data.Filtering;
using Katrin.AppFramework.ConfigService;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.NavBarBuilder;
using Katrin.AppFramework.Security;
using System.IO;
using Katrin.AppFramework.WinForms.Views;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Katrin.AppFramework.WinForms.Context;

namespace Katrin.Shell
{
    public partial class MainForm : RibbonForm, IListener<ShowScreenMessage>, IListener<SelectedWorkSpaceChanged>, IListener<WorkSpaceClosed>
    {
        private App _application = App.Instance;
        private IConfigService _Config = new ConfigService();
        public MainForm()
        {
            InitializeComponent();
            ribbonControl1.MdiMergeStyle = RibbonMdiMergeStyle.Always;
            this.Bounds = Screen.PrimaryScreen.WorkingArea;
            EventAggregationManager.AddListener(this);
           
        }

        

        private void MainForm_Load(object sender, EventArgs e)
        {
            ribbonControl1.Pages.Clear();
            navBarControl1.Groups.Clear();

            _application.MainWorkspace = new MdiWorkspace(tabbedView1, this);

            RibbonManager.AddItemsToMenu(ribbonControl1, _application, "/Workbench/MainMenu",null);
            NavItemManager.AddItemsToNavigation(navBarControl1, _application, "/Workbench/Navigation");

            var startCommands = AddInTree.BuildItems<ICommand>("/Workbench/StartCommands", null);
            startCommands.ForEach(command => command.Run());

            LoadingFormManager.EndLoading();
            WindowState = FormWindowState.Maximized;
            Activate();
            //restore layout
            this._Config.RestoreFormLayout(ConfigKey.Main_Form_Layout, this);
            this._Config.RestoreRibbonLayOut(this.ribbonControl1, ConfigKey.Main_Form_Ribbon);
            this._Config.RestoreNavBarLayout(this.navBarControl1, ConfigKey.Main_Form_Navbar);

            InitLoginUser();
            InitApplicationButton();
        }

        private void InitApplicationButton()
        {
            
            string notificationPath = "/Notification/StartNotification";
            if (AddInTree.ExistsTreeNode(notificationPath))
            {
                var descriptor = AddInTree.BuildItems<IReceiveNotification>(notificationPath, null);
                if (descriptor != null && descriptor.Count() > 0) 
                    descriptor.First().StartReceiveNotification(this);
            }

            //send sys msg
            var sysMsgItem = new BarButtonItem();
            sysMsgItem.Caption = StringParser.Parse("SendSysMessage");
            sysMsgItem.Glyph = (Bitmap)WinFormsResourceService.GetIcon("notification1").ToBitmap();
            Ribbon.Items.Add(sysMsgItem);
            sysMsgItem.ItemClick += (s, e) =>
            {
                var parameters = new ActionParameters(string.Empty, Guid.Empty, ViewShowType.Show);
                _application.Invoke("NotificationDetail", "NotificationAction", parameters);
            };
            
            //??CLEAR SET
            var clearSettingButton = new BarButtonItem();
            clearSettingButton.Caption = StringParser.Parse("ClearSetting");
            clearSettingButton.Glyph = (Bitmap)WinFormsResourceService.GetBitmap("clear");
            
            Ribbon.Items.Add(clearSettingButton);
            clearSettingButton.ItemClick += delegate
            {
                string message = StringParser.Parse("ClearSettingConfirm");
                var result = XtraMessageBox.Show(message, StringParser.Parse("Katrin"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {
                    //restore default layout.
                    var oldParameter = PropertyService.Get<UserLoginParameter>("Document.ParameterSettingName", null);
                    this._application.ViewManager.RestoreAllViewDefaultLayout();
                    PropertyService.Clean();
                    PropertyService.Set<UserLoginParameter>("Document.ParameterSettingName", oldParameter);
                    PropertyService.Save();

                    
                }
            };

            //set language
            BarSubItem languageSettingButton = new BarSubItem();
            languageSettingButton.Caption = StringParser.Parse("languageSetting");
            languageSettingButton.Glyph = WinFormsResourceService.GetIcon("edit").ToBitmap();
            Ribbon.Items.Add(languageSettingButton);

            //CMP Lista de Lenguajes Hardcodeado
            List<string> languages = new List<string>();
            languages.Add("zh-CN");
            languages.Add("en-US");
            languages.Add("es-ES");

            foreach (string language in languages)
            {
                BarButtonItem itemLanguage = new BarButtonItem();
                itemLanguage.Caption = StringParser.Parse(language);
                itemLanguage.ItemClick += itemZh_ItemClick;
                languageSettingButton.ItemLinks.Add(itemLanguage);
                itemLanguage.Tag = language;
                Ribbon.Items.Add(itemLanguage);
            }            
           pmAppMain.ItemLinks.AddRange(new BarItem[] { sysMsgItem, clearSettingButton, languageSettingButton });         
        }

        void itemZh_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarItem item = e.Item;
            string language = item.Tag.ToString();
            CultureManager.SetLaguage(language);
            string message = StringParser.Parse("DoLanguageSetting");
            var result = XtraMessageBox.Show(message, StringParser.Parse("Katrin"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            
        }

        private void InitLoginUser()
        {
            //set logined user full name
            var _fullNameItem = new BarStaticItem();
            _fullNameItem.Caption = AuthorizationManager.FullName;
            _fullNameItem.Glyph = (Bitmap)WinFormsResourceService.GetBitmap("pnguserinfo");
            Ribbon.Items.Add(_fullNameItem);
            _fullNameItem.ItemClick += (s, e) => 
                {
                    ActionParameters parameters = new ActionParameters("User",AuthorizationManager.CurrentUserId,ViewShowType.Show)
                    {
                        {"WorkingMode", EntityDetailWorkingMode.Edit}
                    };
                    _application.Invoke("User","Detail",parameters);
                };
 

            // Notification
            var notificationItem = new BarStaticItem();
            string notifcationName = ResourceService.GetString("Notification");
            notificationItem.Caption = notifcationName;
            AuthorizationManager.NotificationList.DataSourceChanged += (s, e) =>
                {
                    notificationItem.Caption = notifcationName + "(" +
                        ((List<NotificationDTO>)AuthorizationManager.NotificationList.List).Where(c => c.NotificationStatusName != "Readed").Count() + ")  ";
                };
            Ribbon.Items.Add(notificationItem);
            notificationItem.Glyph = (Bitmap)WinFormsResourceService.GetBitmap("notification");
            notificationItem.ItemClick += (s, e) =>
            {
                ActionParameters parameters = new ActionParameters("Notification", Guid.Empty, ViewShowType.Show);
                _application.Invoke("Notification", "List", parameters);
            };
            
            Ribbon.PageHeaderItemLinks.AddRange(new BarItem[] {_fullNameItem, notificationItem });

        }

     
        private void FocusModule(string moduleName)
        {
            foreach (var item in this.navBarControl1.Items)
            {
                if (item is ModuleNavBarItem)
                {
                    ModuleNavBarItem moduleItem = item as ModuleNavBarItem;
                    if (moduleItem.ModuleName == moduleName)
                    {
                   
                            if (moduleItem.Links.Count > 0)
                                this.navBarControl1.SelectedLink = moduleItem.Links[0];
                   
                    }
                }
            }
        }

        private void UnFocusModule(string moduleName)
        {
            if (this.navBarControl1.SelectedLink == null)
            {
                return;
            }

            if (this.navBarControl1.SelectedLink.Item is ModuleNavBarItem)
            {
                ModuleNavBarItem focusModule = this.navBarControl1.SelectedLink.Item as ModuleNavBarItem;
                if (focusModule.ModuleName == moduleName)
                {
                    this.navBarControl1.SelectedLink = null;
                }
            }
        }
        
        #region Message
        void IListener<ShowScreenMessage>.Handle(ShowScreenMessage message)
        {
            var segments = message.Path.Split('/');
            var controllerName = segments[1];
            var actionName = segments[2];
            _application.Invoke(controllerName, actionName, new ActionParameters(controllerName, Guid.Empty, ViewShowType.Mdi));
            //_mdiWorkspace.Show(message.Path);
        }

        public new void Handle(SelectedWorkSpaceChanged message)
        {
            this.FocusModule(message.ModuleName);
        }

        public new void Handle(WorkSpaceClosed message)
        {
            this.UnFocusModule(message.ModuleName);
        }
        #endregion

        private void ribbonControl1_ShowCustomizationMenu(object sender, RibbonCustomizationMenuEventArgs e)
        {
            e.ShowCustomizationMenu = false;
        }
        
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //save layout
            this._Config.SaveFormLayOut(this, ConfigKey.Main_Form_Layout);
            this._Config.SaveRibbonLayOut(this.ribbonControl1,ConfigKey.Main_Form_Ribbon);
            this._Config.SaveNavBarLayout(this.navBarControl1, ConfigKey.Main_Form_Navbar);
           
        }


    }
}
