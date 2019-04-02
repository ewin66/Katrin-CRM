using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Views
{
    public interface IObjectConvert
    {
        void ConvertObject(object sourceObject, object targetObject);
    }
}
