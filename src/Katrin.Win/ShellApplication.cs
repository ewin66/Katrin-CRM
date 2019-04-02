using System;
using System.Configuration;
using System.Security.Authentication;
using Katrin.Win.Common;
using Katrin.Win.Common.CustomerFunctions;
using DevExpress.Data.Filtering;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraSplashScreen;
using Microsoft.Practices.CompositeUI;
using Katrin.Win.Common.Constants;
using System.Windows.Forms;
using Katrin.Win.Infrastructure;
using Katrin.Win.Infrastructure.Services;
using Microsoft.Practices.CompositeUI.Services;
using CABDevExpress.Workspaces;
using System.Threading;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using Katrin.Win.Common.CustomerFunctions.Katrin.Win.Common.CustomerFunctions;

namespace Katrin.Win
{
    public class ShellApplication : SmartClientApplication<WorkItem, ShellForm>
    {
        /// <summary>
        /// Application entry point.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SkinManager.EnableFormSkins();
            BonusSkins.Register();
            DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font("????", 8.5f);

            Thread.CurrentThread.CurrentCulture = CultureManager.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = CultureManager.CurrentCulture;

            CriteriaOperator.RegisterCustomFunction(new IsEarlierNextWeekFunction());
            CriteriaOperator.RegisterCustomFunction(new IsPriorDaysFunction());
            CriteriaOperator.RegisterCustomFunction(new IsDuringDaysFunction());
            CriteriaOperator.RegisterCustomFunction(new IsLastMonthFunction());
#if (DEBUG)
            RunInDebugMode();
#else
			RunInReleaseMode();
#endif
        }

        private static void RunInDebugMode()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(AppDomainUnhandledException);
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                new ShellApplication().Run();
            }
            catch (AuthenticationException ex)
            {
                Application.ExitThread();
                Application.Exit();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        protected override void AddServices()
        {
            base.AddServices();
            RootWorkItem.Services.Remove<IUserSelectorService>();
            RootWorkItem.Services.Remove<IAuthenticationService>();
            RootWorkItem.Services.Remove<IRoleService>();
            RootWorkItem.Services.AddNew<LoginForm, IAuthenticationService>();
            RootWorkItem.Services.AddNew<SimpleRoleService, IRoleService>();
        }

        protected override void AfterShellCreated()
        {
            base.AfterShellCreated();

            RootWorkItem.Items.Add(Shell.ContentWorkspace, WorkspaceNames.ShellContentWorkspace);
            RootWorkItem.Items.Add(Shell.NavBarWorkspace, WorkspaceNames.ShellNavBarWorkspace);
            var modalWorkSpace = new XtraWindowWorkspace(Shell);
            RootWorkItem.Items.Add(new XtraWindowWorkspace(Shell), WorkspaceNames.ModalWindows);
            RootWorkItem.Items.Add(new RibbonWindowWorkspace(Shell), WorkspaceNames.RibbonWindows);

            RootWorkItem.UIExtensionSites.RegisterSite(ExtensionSiteNames.ShellNavBar, Shell.NavBarWorkspace);
            RootWorkItem.UIExtensionSites.RegisterSite(ExtensionSiteNames.Ribbon, Shell.Ribbon);
            RootWorkItem.UIExtensionSites.RegisterSite(ExtensionSiteNames.RibbonStatusBar, Shell.StatusBar);
            InitRibbonGroup();
        }

        protected void InitRibbonGroup()
        {
            var homePage = RootWorkItem.UIExtensionSites[ExtensionSiteNames.Ribbon].Add(new RibbonPage(GetLocalizedCaption("Home")));
            RootWorkItem.UIExtensionSites.RegisterSite("HomePage", homePage);


            var generalGroup = RootWorkItem.UIExtensionSites["HomePage"].Add(new RibbonPageGroup(GetLocalizedCaption("General")));
            string generalPageGroup = "GeneralPageGroup";
            RootWorkItem.UIExtensionSites.RegisterSite(generalPageGroup, generalGroup);

            AddRibbonViewPage();
        }

        protected void AddRibbonViewPage()
        {
            var skinPage = RootWorkItem.UIExtensionSites[ExtensionSiteNames.Ribbon].Add(new RibbonPage(GetLocalizedCaption("ViewPageCaption")));
            RootWorkItem.UIExtensionSites.RegisterSite("SkinPage", skinPage);

            RibbonPageGroup skinsPageGroup = RootWorkItem.UIExtensionSites["SkinPage"].Add(new RibbonPageGroup(GetLocalizedCaption("Skins")));
            string skinPageGroup = "SkinPageGroup";
            RootWorkItem.UIExtensionSites.RegisterSite(skinPageGroup, skinsPageGroup);

            RibbonGalleryBarItem skinGalleryBarItem = new RibbonGalleryBarItem();
            skinGalleryBarItem.Gallery.AllowHoverImages = true;
            skinGalleryBarItem.Gallery.FixedHoverImageSize = false;
            skinGalleryBarItem.Gallery.ItemCheckMode = DevExpress.XtraBars.Ribbon.Gallery.ItemCheckMode.SingleRadio;
            skinGalleryBarItem.Id = 1;
            skinGalleryBarItem.Name = "skinGalleryBarItem";
            RootWorkItem.UIExtensionSites[skinPageGroup].Add(skinGalleryBarItem);
            skinPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            skinsPageGroup});

            SkinHelper.InitSkinGallery(skinGalleryBarItem, true);
        }

        protected string GetLocalizedCaption(string name)
        {
            return Properties.Resources.ResourceManager.GetString(name);
        }

        private static void RunInReleaseMode()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(AppDomainUnhandledException);
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                new ShellApplication().Run();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private static void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

        private static void HandleException(Exception ex)
        {
            if (ex == null)
                return;

            ShellNotificationService notifications = new ShellNotificationService();

            notifications.Show(BuildExceptionString(ex), "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);


            Environment.Exit(0);
        }

        protected override void Start()
        {
            base.Start();
            var loginForm = RootWorkItem.Services.Get<IAuthenticationService>() as LoginForm;
            if (loginForm != null) loginForm.Close();
        }

        private static string BuildExceptionString(Exception exception)
        {
            string errMessage = string.Empty;

            errMessage += exception.Message + Environment.NewLine + exception.StackTrace;

            while (exception.InnerException != null)
            {
                errMessage += BuildInnerExceptionString(exception.InnerException);
                exception = exception.InnerException;
            }

            return errMessage;
        }

        private static string BuildInnerExceptionString(Exception innerException)
        {
            string errMessage = string.Empty;

            errMessage += Environment.NewLine + " InnerException ";
            errMessage += Environment.NewLine + innerException.Message + Environment.NewLine + innerException.StackTrace;

            return errMessage;
        }
    }
}
