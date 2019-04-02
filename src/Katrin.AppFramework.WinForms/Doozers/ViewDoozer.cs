using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Views;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Doozers
{
    public class ViewDescriptor
    {
        private Codon _codon;

        public string Id
        {
            get
            {
                return _codon.Id;
            }
        }

        public Codon Codon { get { return _codon; } }

        public ViewDescriptor(Codon codon)
        {
            _codon = codon;
        }

        public IView CreateView()
        {
            var viewClassName = _codon.Properties["class"];
            var viewType = _codon.AddIn.FindType(viewClassName);
            if (!typeof(IView).IsAssignableFrom(viewType))
            {
                var message = "The class {0} doesn't implement the interface:{1}, please check the class property in your addin config file";
                throw new Exception(string.Format(message,viewType.FullName,typeof(IView).FullName));
            }
            var view = (IView)Activator.CreateInstance(viewType);
            var listView = view as IObjectListView;
            if (listView != null)
            {
                var listViewType = _codon.Properties.Get("viewType", ListViewType.GridView);
                listView.ViewType = listViewType;
            }
            return view;
        }
    }

    public class ViewDoozer : IDoozer
    {
        public bool HandleConditions
        {
            get { return false; }
        }

        public object BuildItem(BuildItemArgs args)
        {
            return new ViewDescriptor(args.Codon);
        }
    }
}
