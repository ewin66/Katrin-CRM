using Katrin.AppFramework.WinForms.Context;
using Katrin.AppFramework.WinForms.MVC.Data;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// Base Controller Implementation
    /// </summary>
    public abstract class ControllerBase : IController
    {
        #region Fields

        /// <summary>
        /// Stores Session datas
        /// </summary>
        Session _session;

        /// <summary>
        ///<see cref="IActionResult" />
        /// </summary>
        private IActionResult _actionResult;

        /// <summary>
        /// Asynchronous methods
        /// </summary>
        private List<String> _asynchMethods;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructeur de l'implmentation de base des actions
        /// </summary>
        public ControllerBase()
        {

        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// <see cref="asynchMethods"/>
        /// </summary>
        public List<String> AsynchMethods
        {
            set
            {
                if (_asynchMethods != null)
                {
                    var InitializedSessionException = "The session is already initialized";
                    LoggingService.Error(InitializedSessionException);
                    throw new Exception(InitializedSessionException);
                }
                _asynchMethods = value;
            }
        }

        /// <summary>
        /// <see cref="_session"/>
        /// </summary>
        public Session Session
        {
            set
            {
                if (_session != null)
                {
                    var InitializedSessionException = "The session is already initialized";
                    LoggingService.Error(InitializedSessionException);
                    throw new Exception(InitializedSessionException);
                }
                _session = value;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Stores message to the session message data
        /// </summary>
        /// <param name="message">The message to store</param>
        /// <param name="messageType">The type of the message</param>
        public void AddMessage(string message, MessageType messageType)
        {
            this._session.AddMessage(message, messageType);
        }

        /// <summary>
        /// Clear all messages
        /// </summary>
        public void ClearErrorsAndMessage()
        {
            this._session.ClearErrorsAndMessage();
        }

        /// <summary>
        /// Default action for all controllers
        /// </summary>
        /// <returns>The action execution result</returns>
        public virtual IActionResult Execute(ActionParameters parameters)
        {
            var NotImplementedMethodException = "The method should be implemented";
            LoggingService.Error(NotImplementedMethodException);
            throw new NotImplementedException(NotImplementedMethodException);
        }

        /// <summary>
        /// Get the session data from the key name
        /// </summary>
        /// <param name="cle">The session data key</param>
        /// <returns>The session data</returns>
        public AbstractBaseData GetSessionData(string key)
        {
            return _session[key];
        }

        /// <summary>
        /// Check if the action should be executed in an asynchronous way
        /// </summary>
        /// <param name="actionName">The action name</param>
        /// <returns>true if it's an asychronous action, false otherwiser</returns>
        public bool IsAnAsynchronousAction(string actionName)
        {
            //File configuration
            if (this._asynchMethods != null && this._asynchMethods.Contains(actionName)) return true;

            //Attribute configuration
            object[] asynchronousAttributes = this.GetType().GetMethod(actionName).GetCustomAttributes(typeof(AsynchronousAttribute), false);

            if (asynchronousAttributes != null && asynchronousAttributes.Length != 0) return true;

            //Not an asynchronous action
            return false;
        }

        /// <summary>
        /// Intialize the action result to Execute another action
        /// </summary>
        /// <param name="controllerName">The controller name</param>
        /// <param name="methodName">The action to execute</param>		
        /// <returns>The configured redirect action result</returns>
        public IActionResult RedirectToAction(string controllerName, string actionName, ActionParameters parameters)
        {
            return new RedirectToActionResult(controllerName, actionName, parameters);
        }

        /// <summary>
        /// Intialize the action result to show a view
        /// </summary>        /// 
        /// <param name="viewName">The view to show</param>		
        /// <returns>The configured show view action result</returns>
        public IActionResult View(string viewName, object viewModel)
        {
            return new ViewResult(viewName, viewModel);
        }

        #endregion Public Methods


        public Guid WorkSpaceID
        {
            get;
            set;
        }

        public IWorkSpaceContext Context
        {
            get;
            set;
        }

        public virtual void Dispose()
        {
            
        }
    }
}
