using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.Services
{
    public interface INavigationService
    {
        void Navigate(string path, string workspace);
    }
}
