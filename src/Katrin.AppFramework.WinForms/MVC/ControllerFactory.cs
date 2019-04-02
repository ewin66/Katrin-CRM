using Katrin.AppFramework.WinForms.Doozers;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC
{
    public class ControllerFactory
    {
        /// <summary>
        /// Set of application's controllers
        /// </summary>
        private static IDictionary<string, IController> _controllers;

        private static IDictionary<string, ControllerDescriptor> _controllerDescriptors;

        static void EnsureIntialize()
        {
            if (_controllerDescriptors == null)
            {
                _controllerDescriptors = AddInTree.BuildDictionaryItems<ControllerDescriptor>("/Controllers", null, false);
            }
        }

        public static IController CreateController(string controllerName)
        {
            EnsureIntialize();
            //The controller doesn't exist
            if (!_controllerDescriptors.ContainsKey(controllerName))
            {
                var ViewMissingException = "The controller [{0}] is not configured. Check the controller configurations.";
                LoggingService.ErrorFormatted(ViewMissingException, controllerName);

                //The view is missing
                throw new Exception(string.Format(ViewMissingException, controllerName));
            }
            var descriptor = _controllerDescriptors[controllerName];
            return descriptor.CreateController();
        }
    }
}
