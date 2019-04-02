using Katrin.AppFramework;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using Katrin.Shell.UIElements;
using Katrin.AppFramework.Metadata;
using System.Reflection;
using ICSharpCode.Core;
using System.IO;
using System.Resources;
using Katrin.AppFramework.UIElements;
using Autofac;
using DevExpress.Data.Filtering;
using Katrin.AppFramework.CustomFunction;

namespace Katrin.Shell
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UIElementAdapterFactoryCatalog>().As<IUIElementAdapterFactoryCatalog>().SingleInstance();
            var container = builder.Build();
            IoC.GetInstance = (t, p) => container.Resolve(t);

            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            SkinManager.EnableFormSkins();
            BonusSkins.Register();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CriteriaOperator.RegisterCustomFunction(new IsDuringDaysFunction());
            CriteriaOperator.RegisterCustomFunction(new IsEarlierNextWeekFunction());
            CriteriaOperator.RegisterCustomFunction(new IsLastMonthFunction());
            CriteriaOperator.RegisterCustomFunction(new IsPriorDaysFunction());
            
            DevExpress.Utils.AppearanceObject.DefaultFont = System.Drawing.SystemFonts.DefaultFont;

            // The LoggingService is a small wrapper around log4net.
            // Our application contains a .config file telling log4net to write
            // to System.Diagnostics.Trace.
            ICSharpCode.Core.Services.ServiceManager.Instance = new Katrin.AppFramework.WinForms.Services.ServiceManager();
            LoggingService.Info("Application start");

            // Get a reference to the entry assembly (Startup.exe)
            Assembly exe = typeof(Program).Assembly;

            // Set the root path of our application. ICSharpCode.Core looks for some other
            // paths relative to the application root:
            // "data/resources" for language resources, "data/options" for default options
            FileUtility.ApplicationRootPath = Path.GetDirectoryName(exe.Location);

            LoggingService.Info("Starting core services...");

            // CoreStartup is a helper class making starting the Core easier.
            // The parameter is used as the application name, e.g. for the default title of
            // MessageService.ShowMessage() calls.
            CoreStartup coreStartup = new CoreStartup("Katrin");
            // It is also used as default storage location for the application settings:
            // "%Application Data%\%Application Name%", but you can override that by setting c.ConfigDirectory

            // Specify the name of the application settings file (.xml is automatically appended)
            coreStartup.PropertiesName = "AppProperties";

            // Initializes the Core services (ResourceService, PropertyService, etc.)
            coreStartup.StartCoreServices();

            // Registeres the default (English) strings and images. They are compiled as
            // "EmbeddedResource" into Startup.exe.
            // Localized strings are automatically picked up when they are put into the
            // "data/resources" directory.
            ResourceService.RegisterNeutralStrings(new ResourceManager("Katrin.Shell.Resources.StringResources", exe));
            ResourceService.RegisterNeutralImages(new ResourceManager("Katrin.Shell.Resources.ImageResources", exe));

            System.Threading.Thread.CurrentThread.CurrentCulture = CultureManager.CurrentCulture;
            ResourceService.Language = CultureManager.CurrentCulture.Name;

            LoggingService.Info("Looking for AddIns...");
            // Searches for ".addin" files in the application directory.
            coreStartup.AddAddInsFromDirectory(Path.Combine(FileUtility.ApplicationRootPath, "AddIns"));

            // Searches for a "AddIns.xml" in the user profile that specifies the names of the
            // add-ins that were deactivated by the user, and adds "external" AddIns.
            coreStartup.ConfigureExternalAddIns(Path.Combine(PropertyService.ConfigDirectory, "AddIns.xml"));

            // Searches for add-ins installed by the user into his profile directory. This also
            // performs the job of installing, uninstalling or upgrading add-ins if the user
            // requested it the last time this application was running.
            coreStartup.ConfigureUserAddIns(Path.Combine(PropertyService.ConfigDirectory, "AddInInstallTemp"),
                                            Path.Combine(PropertyService.ConfigDirectory, "AddIns"));

            LoggingService.Info("Loading AddInTree...");
            // Now finally initialize the application. This parses the ".addin" files and
            // creates the AddIn tree. It also automatically runs the commands in
            // "/Workspace/Autostart"
            coreStartup.RunInitialization();

            LoggingService.Info("Initializing Workbench...");
            // Workbench is our class from the base project, this method creates an instance
            // of the main form.
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();

            try
            {
                LoggingService.Info("Running application...");
                // Workbench.Instance is the instance of the main form, run the message loop.
                if (SecurityContext.IsLogon)
                {
                    var catalog = IoC.Get<IUIElementAdapterFactoryCatalog>();
                    catalog.RegisterFactory(new XtraNavBarUIAdapterFactory());
                    catalog.RegisterFactory(new XtraBarUIAdapterFactory());
                    catalog.RegisterFactory(new RibbonUIAdapterFactory());
                    catalog.RegisterFactory(new NavigatorCustomButtonUIAdapterFactory());
                    catalog.RegisterFactory(new EditorButtonCollectionUIAdapterFactory());

                    ODataObjectSpace.Initialize();
                    MetadataRepository.Initialize();

                    MainForm mainForm = new MainForm();
                    mainForm.FormClosed += mainForm_FormClosed;
                    mainForm.Show();

                    Application.Run();
                }
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex, ex.Message);
            }
            finally
            {
                LoadingFormManager.EndLoading();
                try
                {
                    // Save changed properties
                    PropertyService.Save();
                }
                catch (Exception ex)
                {
                    MessageService.ShowException(ex, ex.Message);
                }
            }

            LoggingService.Info("Application shutdown");
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            MessageService.ShowException(ex,ex.Message);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
           MessageService.ShowException(e.Exception, e.Exception.Message);
        }

        static void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
