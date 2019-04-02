using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.MVC.Data;
using DevExpress.XtraEditors;
using Katrin.AppFramework.WinForms.Workspaces;

namespace Katrin.AppFramework.WinForms.Views
{
    public partial class BaseView : XtraUserControl,IView
    {

        public event EventHandler Closed;

        #region Fields

        /// <summary>
        /// An instance of the controllerManger is passed to the view; is injected by
        /// an IoC framework (unity, spring, pico, etc.)
        /// </summary>
        private IControllerManager _controllerManager;

        /// <summary>
        /// Indicates that the view is a child view
        /// </summary>
        private bool _isChildForm = true;

        /// <summary>
        ///<see cref="Session" />
        /// </summary>
        private Session _session;

        /// <summary>
        /// Current view's name
        /// </summary>
        private string _viewName;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructeur de la Vue
        /// </summary>
        public BaseView()
        {
            InitializeComponent();
           
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// <see cref="Controller"/>
        /// </summary>
        public IControllerManager ControllerManager
        {
            get
            {
                return this._controllerManager;
            }
            set
            {
                if (this._controllerManager == null)
                    this._controllerManager = value;
            }
        }

        /// <summary>
        /// <see cref="_isChildForm"/>
        /// </summary>
        public bool IsChildForm
        {
            get
            {
                return _isChildForm;
            }
            set
            {
                _isChildForm = value;
            }
        }

        public object Model
        {
            get;
            set;
        }

        /// <summary>
        /// <see cref="Session"/>
        /// </summary>
        public Session Session
        {
            set
            {
                if (_session != null)
                {
                    var InitializedSessionException = "The session is already initialized";
                    throw new Exception(InitializedSessionException);
                }
                _session = value;
            }
        }

        /// <summary>
        /// Current view's name
        /// </summary>
        public string ViewName
        {
            get
            {
                return this._viewName;
            }
            set
            {
                this._viewName = value;
                this.Text = this._viewName;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Initialize DataSources
        /// </summary>
        public virtual void BindDataToView()
        {
            //Retrieving the manager
            ControllerManager manager = this.ControllerManager as ControllerManager;

            //Subscribing to events
            manager.BgAsyncMethods.ProgressChanged += new ProgressChangedEventHandler(BgAsyncMethods_ProgressChanged);
            manager.BgAsyncMethods.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BgAsyncMethods_RunWorkerCompleted);
        }

        protected virtual void BgAsyncMethods_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Hiding the progress bar panel
            //this.plProcess.Visible = false;
        }

        protected virtual void BgAsyncMethods_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Showing the progress bar
            //if (!plProcess.Visible) plProcess.Visible = true;
            //plProcess.Refresh();
        }

        /// <summary>
        /// Gets the bool which indicates wheter the error message is displayed or not
        /// </summary>
        /// <returns>La valeur boolenne reprsentant la visibilit</returns>
        public bool GetContextVisibility()
        {
            return this._session.MessageData.LblContextMessageVisibility;
        }

        /// <summary>
        /// <see cref="Session"/>
        /// </summary>
        /// <param name="messageType"></param>
        /// <returns></returns>
        public string GetMessage(MessageType messageType)
        {
            return this._session.GetMessage(messageType);
        }

        /// <summary>
        /// Get the session data from the key name
        /// </summary>
        /// <param name="key">The session data key</param>
        /// <returns>The session data</returns>
        public AbstractBaseData GetSessionData(string key)
        {
            return this._session[key];
        }

        /// <summary>
        /// Get the session data from the key name
        /// </summary>
        /// <param name="key">The session data key</param>
        /// <returns>The session data</returns>
        public T GetSessionData<T>(string key) where T: AbstractBaseData
        {
            return this._session[key] as T;
        }

        /// <summary>
        /// Invoke an action of the controller
        /// </summary>
        /// <param name="controllerName">The controller name</param>
        public void InvokeController(string controllerName)
        {
            this.ControllerManager.Invoke(controllerName);
        }

        /// <summary>
        /// Invoke an action of the controller
        /// </summary>
        /// <param name="controllerName">The controller name</param>
        /// <param name="actionName">The action name</param>
        public void InvokeController(string controllerName, string actionName)
        {
            var parameters = new ActionParameters(controllerName, Guid.Empty, ViewShowType.Show);
            this.ControllerManager.Invoke(controllerName, actionName, parameters);
        }

        #endregion Public Methods


        public virtual void ShowView()
        {
            BindDataToView();
            if (this.Visible == true) return;
            this.Show();
        }

        public virtual void OnDeactivated()
        {

        }

        public virtual void OnActivated()
        {

        }

        public void ActiveView()
        {
            //this.Activate();
        }

        public void CloseView()
        {
            //Retrieving the manager
            ControllerManager manager = this.ControllerManager as ControllerManager;

            //Removing events
            manager.BgAsyncMethods.ProgressChanged -= BgAsyncMethods_ProgressChanged;
            manager.BgAsyncMethods.RunWorkerCompleted -= BgAsyncMethods_RunWorkerCompleted;
        }

        //public string RibbonPath
        //{
        //    get;
        //    set;
        //}


        public Guid WorkSpaceID
        {
            get;
            set;
        }


        public Context.IWorkSpaceContext Context
        {
            get;
            set;
        }
    }
}
