using Katrin.AppFramework.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Katrin.AppFramework
{
    public class WinApplication : IDisposable
    {
        private const string Confirmations = "Confirmations";
        private static MessageDialog messaging = new MessageDialog(null);
        protected bool isLoggedOn = false;
        private bool isLoggedOff = false;
        private bool exiting;
        private ISplash splash = new SplashScreen();
        private CompositionContainer container;

        public bool IsLoggedOn
        {
            get { return isLoggedOn; }
        }

        public string Title { get; set; }
        public static MessageDialog MessageDialog
        {
            get { return messaging; }
            set { messaging = value; }
        }

        public WinApplication()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
        }

        private void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        public void Start()
        {
            try
            {
                Tick.In("WinApplication.Start()");
                DoLogon();
                if (IsLoggedOn)
                {
                    try
                    {
                        ProcessStartupActions();
                        if (!exiting)
                        {
                            UpdateStatus();
                            ShowStartupWindow();
                        }
                        else
                        {
                            return;
                        }
                    }
                    finally
                    {
                        SplashStop();
                    }
                    Tracing.Tracer.LogSeparator("Application startup done");
                    Tracing.Tracer.LogSeparator("Application running");
                    Tick.Out("WinApplication.Start()");
                    DoApplicationRun();
                    SaveUserPreferenceChanges();
                }
            }
            catch (Exception e)
            {
                HandleException(e);
            }
            finally
            {
                LogOffCore(false);
            }
            Tracing.Tracer.LogSeparator("Application stopping");
        }

        private void LogOffCore(bool p)
        {
        }

        private void HandleException(Exception e)
        {
            messaging.Show(Title, e);
        }

        private void SplashStop()
        {
            splash.Stop();
        }

        protected virtual void DoLogon()
        {
        }

        private void SplashStart()
        {
            splash.Start();
        }

        private void ProcessStartupActions()
        {
        }

        private void ShowStartupWindow()
        {
        }

        private void UpdateStatus()
        {
            Application.DoEvents();
        }

        private void DoApplicationRun()
        {
            Application.Run();
        }

        private void SaveUserPreferenceChanges()
        {
        }

        public ConfirmationResult AskConfirmation(ConfirmationType confirmationType)
        {
            ConfirmationResult result = ConfirmationResult.Cancel;
            DialogResult userChoice = DialogResult.None;
            switch (confirmationType)
            {
                case ConfirmationType.NeedSaveChanges:
                    {
                        userChoice = GetUserChoice(CaptionHelper.GetLocalizedText(Confirmations, "Save"),
                            MessageBoxButtons.YesNoCancel);
                        break;
                    }
                case ConfirmationType.CancelChanges:
                    {
                        userChoice = GetUserChoice(CaptionHelper.GetLocalizedText(Confirmations, "Cancel"),
                            MessageBoxButtons.YesNo);
                        break;
                    }
            }
            if (userChoice == DialogResult.Yes)
            {
                result = ConfirmationResult.Yes;
            }
            if (userChoice == DialogResult.No)
            {
                result = ConfirmationResult.No;
            }
            if (userChoice == DialogResult.Cancel)
            {
                result = ConfirmationResult.Cancel;
            }
            Tracing.Tracer.LogValue("UserConfirmationResult", result);
            return result;
        }

        public DialogResult GetUserChoice(string message, MessageBoxButtons buttons)
        {
            return MessageDialog.GetUserChoice(message, Title, buttons);
        }

        public void Dispose()
        {
            Application.ThreadException -= Application_ThreadException;
        }

        protected void Configure()
        {
            var catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new DirectoryCatalog(Environment.CurrentDirectory + "/AddIns"));

            container = new CompositionContainer(catalog);

            var batch = new CompositionBatch();

            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue<IResourceService>(new ResourceService());
            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue(container);
            batch.AddExportedValue(catalog);

            container.Compose(batch);

            container.ComposeParts(container.GetExportedValue<IResourceService>());
        }
    }
}
