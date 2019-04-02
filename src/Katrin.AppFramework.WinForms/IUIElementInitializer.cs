using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms
{
    public interface IUIElementInitializer
    {
        void Initialize(object element);
    }
}
