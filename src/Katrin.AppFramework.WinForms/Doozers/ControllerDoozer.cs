using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;
using ICSharpCode.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Doozers
{
    public class ControllerDescriptor
    {
        private Codon _codon;

        public string Id
        {
            get
            {
                return _codon.Id;
            }
        }

        public ControllerDescriptor(Codon codon)
        {
            _codon = codon;
        }

        public IController CreateController()
        {
            var controllerClassName = _codon.Properties["class"];
            var controllerType = _codon.AddIn.FindType(controllerClassName);
            if (!typeof(IController).IsAssignableFrom(controllerType))
            {
                var message = "The class {0} doesn't implement the interface:{1}, please check class property of Controller({Id:2}) in your addin config file";
                throw new Exception(string.Format(message, controllerType.FullName, typeof(IController).FullName, _codon.Id));
            }
            var controller = (IController)Activator.CreateInstance(controllerType);
            IObjectAware objectAware = controller as IObjectAware;
            if (objectAware != null && _codon.Properties.Contains("objectName"))
            {
                objectAware.ObjectName = _codon.Properties["objectName"];
            }
            return controller;
        }
    }

    public class ControllerDoozer : IDoozer
    {
        public bool HandleConditions
        {
            get { return false; }
        }

        public object BuildItem(BuildItemArgs args)
        {
            return new ControllerDescriptor(args.Codon);
        }
    }
}
