using Katrin.AppFramework.WinForms.MVC.Context;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// An implementation of controller manager, it manages applications controllers
    /// </summary>
    public class ControllerManager : IControllerManager
    {
        #region Fields

        /// <summary>
        /// BackgroundWorker for asynchronous actions execution
        /// </summary>
        private BackgroundWorker _bgAsyncMethods;

        /// <summary>
        /// The default controller
        /// </summary>
        private string _defaultController;

        /// <summary>
        /// List of filter of a specific action
        /// </summary>
        private FilterInfo actionFilterInfo = null;

        /// <summary>
        /// The list of all executed before attribute
        /// </summary>
        private IList<IActionFilter> listOfExecutedActionFilters = null;

        private App _application;

        #endregion Fields

        #region Constructors

        public ControllerManager(App application)
        {
            _application = application;
            //BackgroundWorker intialization
            _bgAsyncMethods = new BackgroundWorker();

            //BackgroundWorker configuration
            BgAsyncMethods.WorkerReportsProgress = true;
            BgAsyncMethods.WorkerSupportsCancellation = true;

            //Souscription to the backgroundWorker's event
            BgAsyncMethods.DoWork += new DoWorkEventHandler(BgAsyncMethods_DoWork);
            BgAsyncMethods.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BgAsyncMethods_RunWorkerCompleted);
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// <see cref="_bgAsyncMethods"/>
        /// </summary>
        public BackgroundWorker BgAsyncMethods
        {
            get { return _bgAsyncMethods; }
        }

        /// <summary>
        /// <see cref="_defaultController"/>
        /// </summary>
        public string DefaultController
        {
            set
            {
                if (_defaultController != null)
                {
                    var InitializedSessionException = "The session is already initialized";
                    LoggingService.Error(InitializedSessionException);
                    throw new Exception(InitializedSessionException);
                }
                _defaultController = value;
            }
        }


        #endregion Public Properties

        #region Private Methods

        /// <summary>
        /// Execute asynchronous actions. It's executed in a different thread
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event's arguments</param>
        void BgAsyncMethods_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] parameters = null;
            IController controller = null;
            string actionName = null;
            object[] results = null;
            IActionResult actionResult = null;
            Exception exception = null;

            try
            {
                BgAsyncMethods.ReportProgress(1);

                //Getting arguments
                parameters = e.Argument as object[];
                //Retrieving controller and action to invoke
                controller = parameters[0] as IController;
                actionName = parameters[1] as string;

                //Building de result object
                results = new object[] { actionResult, controller, exception /*exception*/ };

                //Executing action
                actionResult = (IActionResult)controller.GetType().GetMethod(actionName).Invoke(controller, null);

                //Storing the result object for the next step
                results[0] = actionResult;
                e.Result = results;
            }
            catch (Exception ex)
            {
                //Init the result object
                results[2] = ex.InnerException; /* The innerException is used because the Invoke method of a MethodInfo throws a System.TargetInvocationException*/
                e.Result = results;
            }
        }

        /// <summary>
        /// Executed when the background process has ended. 
        /// This method is executed by the principal thread
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event's Arguments</param>
        void BgAsyncMethods_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //error occurs or background process is cancelled
            if (e.Cancelled) return;

            //Background process execution has ended successfully.
            //Executing the next command
            object[] results = e.Result as object[];
            IActionResult actionResult = results[0] as IActionResult;
            IController controller = results[1] as IController;

            //Retrieve the exception
            Exception exception = results[2] as Exception;

            try
            {
                //If error occurs
                if (exception != null)
                {
                    //Executing the post action execution filter of all pre executed filter
                    if (listOfExecutedActionFilters != null)
                    {
                        //Creating the context. The exception is passed so that the after attribute can use it
                        ActionExecutedContext postContext = new ActionExecutedContext(controller, false /*cancelled*/, exception /*exception*/);
                        postContext = InvokeExecutedFilters(listOfExecutedActionFilters, postContext);
                        if (!postContext.ExceptionHandled)
                        {
                            throw exception;
                        }
                    }
                    else throw exception;
                }

                //if no errors
                if (listOfExecutedActionFilters != null) /*Executing OnActionExecuted*/
                {
                    ActionExecutedContext postContext = new ActionExecutedContext(controller, false, null) { Result = actionResult };
                    postContext = InvokeExecutedFilters(listOfExecutedActionFilters, postContext);

                    //Initializing the actionResult
                    actionResult = postContext.Result;
                }

                //Executing the actionResultFilter
                ResultExecutedContext postResultContext = InvokeActionResultWithFilters(controller, actionFilterInfo.ResultFilters, actionResult);

                // Executing the result
                if (postResultContext != null) postResultContext.Result.ExecuteResult(this);
            }
            catch (Exception ex)
            {
                //The exception is not handled. the exception filter is called to manage the exception
                ExceptionContext exceptionContext = InvokeExceptionFilters(controller, actionFilterInfo.ExceptionFilters, ex);
                if (!exceptionContext.ExceptionHandled)
                {
                    var ActionExecutionException = "An error occured while executing the action [{0}], check the underlying implementation : TECHNICAL_DETAIL [{1}] .";

                    throw new Exception(string.Format(ActionExecutionException, "actionName", ex.Message));
                }
                InvokeActionResult(exceptionContext.Result);
            }
        }

        /// <summary>
        /// Invoke an action of a specific controller
        /// </summary>
        /// <param name="controller">The controller</param>
        /// <param name="actionName">The name of the action to execute</param>
        /// <param name="asyncMode">Indicates wheter the action should be executed in a asynchronous mode or not</param>
        /// <returns>The result of the action. Null is returned for asynchronous actions</returns>
        private IActionResult InvokeActionMethod(IController controller, string actionName, bool asyncMode, ActionParameters parameters)
        {
            //If the action should be executed asynchronously
            if (asyncMode && !this.BgAsyncMethods.IsBusy)
            {
                //building parameter
                parameters.Add("controller", controller);
                parameters.Add("actionName", actionName);
                BgAsyncMethods.RunWorkerAsync(parameters);
                return null;
            }

            return new ActionInvoker().Invoke(controller, actionName, parameters);
        }

        /// <summary>
        /// Execute the pre filter, the action and the post filter attribute
        /// </summary>
        /// <param name="filter">The action filter attribute</param>
        /// <param name="preContext">The builded executing context</param>
        /// <param name="continuation">Lambda expression that create the actionExecutedContext </param>
        /// <returns></returns>
        private ActionExecutedContext InvokeActionMethodFilter(IActionFilter filter, ActionExecutingContext preContext, Func<ActionExecutedContext> continuation)
        {
            //Execute the filter
            filter.OnActionExecuting(preContext);

            //Store the executed filter
            listOfExecutedActionFilters.Add(filter);

            //if the execution process is cancelled by the pre filter
            if (preContext.Result != null)
            {
                return new ActionExecutedContext(preContext.Controller, true /*cancelled*/, null/*exception*/)
                {
                    Result = preContext.Result
                };
            }

            bool wasError = false;
            ActionExecutedContext postContext = null;
            try
            {
                //Executing the action and initializing the postContext
                postContext = continuation();
            }
            catch (Exception ex)
            {
                //An exception is caught
                wasError = true;
                postContext = new ActionExecutedContext(preContext.Controller, false /*cancelled*/, ex /*exception*/);
                filter.OnActionExecuted(postContext);

                //If the error is not handled by the filter the exception is thrown
                if (!postContext.ExceptionHandled)
                {
                    throw;
                }
            }

            //Everything is well done
            if (!wasError && postContext.Result != null)
            {
                filter.OnActionExecuted(postContext);
            }
            return postContext;
        }

        /// <summary>
        /// Execute the actionResult passed as parameter
        /// </summary>
        /// <param name="actionResult">The result to execute</param>
        private void InvokeActionResult(IActionResult actionResult)
        {
            actionResult.ExecuteResult(this);
        }

        /// <summary>
        /// Execute the prefilter result, the actionResult and the postfilter result
        /// </summary>
        /// <param name="filter">The result filter</param>
        /// <param name="preContext">The builded preContext</param>
        /// <param name="continuation">The lambda expression wich execute the actionResult and the post filter result attribute</param>
        /// <returns>The result of the execution of the post filter result attribute</returns>
        private ResultExecutedContext InvokeActionResultFilter(IResultFilter filter, ResultExecutingContext preContext, Func<ResultExecutedContext> continuation)
        {
            //Executing the filter
            filter.OnResultExecuting(preContext);

            //If the execution is cancelled
            if (preContext.Cancel)
            {
                return new ResultExecutedContext(preContext.Controller, preContext.Result, true /* canceled */, null /* exception */);
            }

            bool wasError = false;
            ResultExecutedContext postContext = null;
            try
            {
                //Creating the ResultExecutedContext by executing the actionResult
                postContext = continuation();
            }
            catch (Exception ex)
            {
                wasError = true;
                //Creating the context
                postContext = new ResultExecutedContext(preContext.Controller, preContext.Result, false /* canceled */, ex);

                filter.OnResultExecuted(postContext);

                //If the exception is !handled we throw it
                if (!postContext.ExceptionHandled)
                {
                    throw;
                }
            }

            //Everything is executed well
            if (!wasError)
            {
                filter.OnResultExecuted(postContext);
            }
            return postContext;
        }

        /// <summary>
        /// Invoke the list of all authorizationFilters
        /// </summary>
        /// <param name="controller">The controller</param>
        /// <param name="iList">The list of Authorization filters</param>
        /// <returns>The resulted authorizationContext</returns>
        private AuthorizationContext InvokeAuthorizationFilters(IController controller, IList<IAuthorizationFilter> iList)
        {
            //If the list is empty or null then nothing is executed
            if (iList == null || iList.Count == 0) return null;

            //Building the context
            AuthorizationContext context = new AuthorizationContext(controller);

            //Executing filters
            foreach (IAuthorizationFilter filter in iList)
            {
                filter.OnAuthorization(context);

                //Something is wrong
                if (context.Result != null) break;
            }
            return context;
        }

        /// <summary>
        /// Invoke the list of all excpetion filters
        /// </summary>
        /// <param name="controller">The controller</param>
        /// <param name="filters">The list of all filters</param>
        /// <param name="exception">The exception wich is caught</param>
        /// <returns>The resulted ExceptionContext</returns>
        private ExceptionContext InvokeExceptionFilters(IController controller, IList<IExceptionFilter> filters, Exception exception)
        {
            //Building the context
            ExceptionContext context = new ExceptionContext(controller, exception);

            if (filters == null) return context;
            //Executing the exception filters
            foreach (IExceptionFilter filter in filters)
            {
                filter.OnException(context);
            }
            return context;
        }

        /// <summary>
        /// Executes the list of actionfilter that have their OnActionExecuting executed
        /// </summary>
        /// <param name="listOfExecutedActionFilters">The list of executed action filters</param>
        /// <param name="postContext">The context of the execution</param>
        /// <returns></returns>
        private ActionExecutedContext InvokeExecutedFilters(IList<IActionFilter> listOfExecutedActionFilters, ActionExecutedContext postContext)
        {
            //Executing the list of all Executed action filters
            foreach (IActionFilter filter in listOfExecutedActionFilters)
            {
                filter.OnActionExecuted(postContext);
            }
            return postContext;
        }

        #endregion Private Methods

        #region Protected Methods

        /// <summary>
        /// Launch the execution of filters and action method
        /// </summary>
        /// <param name="controller">The controller</param>
        /// <param name="filters">The list of action filters</param>
        /// <param name="action">The action to executed</param>
        /// <param name="asyncMode">The mode of the execution of the action</param>
        /// <returns>The actionExecutedContext build by the execution</returns>
        protected virtual ActionExecutedContext InvokeActionMethodWithFilters(IController controller, IList<IActionFilter> filters, MethodInfo action, bool asyncMode, ActionParameters parameters)
        {
            ActionExecutingContext preContext = new ActionExecutingContext(controller);

            //If there is no ActionFilter, the action is simple executed
            if (filters == null)
            {
                ActionExecutedContext postContext = new ActionExecutedContext(controller, false, null);
                postContext.Result = InvokeActionMethod(controller, action.Name, asyncMode, parameters);
                return postContext;
            }

            //Now we know that there is, at least one actionFilter
            if (listOfExecutedActionFilters == null) listOfExecutedActionFilters = new List<IActionFilter>();
            else listOfExecutedActionFilters.Clear();

            //Passing the list throught the lambda expression
            Func<ActionExecutedContext> continuation = () =>
                new ActionExecutedContext(controller, false, null)
                {
                    Result = InvokeActionMethod(controller, action.Name, asyncMode, parameters)
                };

            // need to reverse the filter list because the continuations are built up backward
            Func<ActionExecutedContext> reverseFiltersList = filters.Reverse().Aggregate(continuation,
                (next, filter) => () => InvokeActionMethodFilter(filter, preContext, next));
            return reverseFiltersList();
        }

        /// <summary>
        /// Execute filters and result
        /// </summary>
        /// <param name="controller">The controller</param>
        /// <param name="filters">The list of filters</param>
        /// <param name="actionResult">The result to executed</param>
        /// <returns>The resultExecutedContext</returns>
        protected virtual ResultExecutedContext InvokeActionResultWithFilters(IController controller, IList<IResultFilter> filters, IActionResult actionResult)
        {
            ResultExecutingContext preContext = new ResultExecutingContext(controller, actionResult);

            //if there is no available result filter the actionResult is simply saved
            if (filters == null)
            {
                InvokeActionResult(actionResult);
                return null;
            }

            Func<ResultExecutedContext> continuation = () =>
            {
                InvokeActionResult(actionResult);
                return new ResultExecutedContext(controller, actionResult, false /* canceled */, null /* exception */);
            };

            // need to reverse the filter list because the continuations are built up backward
            Func<ResultExecutedContext> reverseResultFilterList = filters.Reverse().Aggregate(continuation,
                (next, filter) => () => InvokeActionResultFilter(filter, preContext, next));
            return reverseResultFilterList();
        }

        #endregion Protected Methods

        #region Public Methods

        /// <summary>
        /// Invoke the Execute action of the controller
        /// </summary>
        /// <param name="controllerName">The controller's name</param>
        public void Invoke(string controllerName)
        {
            Invoke(controllerName, null,null);
        }

        /// <summary>
        /// Invoke an action
        /// </summary>
        /// <param name="controllerName">The controller's name</param>
        /// <param name="actionName">The action's name</param>
        public void Invoke(string controllerName, string actionName, ActionParameters parameters)
        {
            IController controller = null;
            IActionResult actionResult = null;

            if (controllerName == null)
            {
                //Default controller is invoked when null is passed as an argument
                controllerName = _defaultController;
            }

            //Getting the controller to invoke
            controller = ControllerFactory.CreateController(controllerName);
            try
            {
                //if null is passed as an argument then the default Execute action is executed
                if (string.IsNullOrEmpty(actionName)) actionName = "Execute";

                //Getting the action mode
                bool asynchMode = controller.IsAnAsynchronousAction(actionName);

                //Retrieving the MethodInfo
                MethodInfo actionMethod = controller.GetType().GetMethod(actionName);

                //Retrieving filterInfo by applying the GetFilters extended method located in Extensions/CustomExtension
                actionFilterInfo = actionMethod.GetFilters();

                //Invoking Autorization filters
                AuthorizationContext authContext = InvokeAuthorizationFilters(controller, actionFilterInfo.AuthorizationFilters);
                if (authContext != null)
                {
                    if (authContext.Result != null)
                    {
                        InvokeActionResult(authContext.Result);
                        return;
                    }
                }

                //Executing the action
                ActionExecutedContext postActionContext = InvokeActionMethodWithFilters(controller, actionFilterInfo.ActionFilters, actionMethod, asynchMode, parameters);// (controllerContext, filterInfo.ActionFilters, actionDescriptor, parameters);

                if (postActionContext.Result == null) return;
                //Executing the actionResultFilter
                ResultExecutedContext postResultContext = InvokeActionResultWithFilters(controller, actionFilterInfo.ResultFilters, postActionContext.Result);

            }
            catch (Exception ex)
            {
                LoggingService.Error(ex);

                //Executing the exception filter
                //ExceptionContext exceptionContext = InvokeExceptionFilters(controller, actionFilterInfo.ExceptionFilters, ex.InnerException);
                //if (!exceptionContext.ExceptionHandled)
                //{
                    var ActionExecutionException = "An error occured while executing the action [{0}], check the underlying implementation : TECHNICAL_DETAIL [{1}] .";

                    //throw new Exception(string.Format(ActionExecutionException, actionName, ex.Message));
                    throw ex;
               // }
               // InvokeActionResult(exceptionContext.Result);
            }
        }

        public void RenderView(string viewName, object viewModel)
        {
            IView view = ViewFactory.GetView(viewName);
            if (view == null)
            {
                view = ViewFactory.CreateView(viewName);
                view.ControllerManager = this;
                view.Model = viewModel;
                view.ShowView();
            }
            else
            {
                view.ActiveView();
            }
        }

        #endregion Public Methods

        public App App
        {
            get { return _application; }
        }
    }
}
