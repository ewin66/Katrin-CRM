using ICSharpCode.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.Services
{
    public static class NavigationService
    {
        public static void Navigate(string path, string workspace)
        {
            var navigationService = ServiceManager.Instance.GetService<INavigationService>();
            navigationService.Navigate(path, workspace);
        }
    }
}
