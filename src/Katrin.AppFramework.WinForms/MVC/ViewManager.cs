using Katrin.AppFramework.WinForms.Doozers;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC
{
    public class ViewFactory
    {
        /// <summary>
        /// Set of application's views
        /// </summary>        
        private static IDictionary<string, ViewDescriptor> _viewDescriptors;

        static void Initialize()
        {
            _viewDescriptors = AddInTree.BuildDictionaryItems<ViewDescriptor>("/Views", null, false);
        }

        static void EnsureInitialize()
        {
            if (_viewDescriptors == null)
            {
                Initialize();
            }
        }

        public static IView GetView(string viewName)
        {
            return null;
        }

        public static IView CreateView(string viewName)
        {
            var descriptor = GetDescriptor(viewName);
            var view = descriptor.CreateView();
            view.ViewName = viewName;
            view.Closed += view_Closed;
            return view;
        }

        public static ViewDescriptor GetDescriptor(string viewName)
        {
            EnsureInitialize();

            //The view doesn't exist
            if (!_viewDescriptors.ContainsKey(viewName))
            {
                var ViewMissingException = "The view [{0}] is not configured. Check the controller manager configurations.";
                LoggingService.ErrorFormatted(ViewMissingException, viewName);

                //The view is missing
                throw new Exception(string.Format(ViewMissingException, viewName));
            }
            return  _viewDescriptors[viewName];
        }

        static void view_Closed(object sender, EventArgs e)
        {
            IView view = sender as IView;
            if (view != null)
            {
                view.Closed -= view_Closed;
            }
        }
    }
}
