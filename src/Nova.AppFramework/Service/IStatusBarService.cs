using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.Service
{
    public interface IStatusBarService
    {
        void ShowMessage(string message);
        void ShowProgress(double currentValue, double allValue);
    }
}
