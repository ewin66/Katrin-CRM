using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars.Ribbon;

namespace Katrin.AppFramework.WinForms.Views
{
    public interface IReceiveNotification
    {
        void StartReceiveNotification(RibbonForm ribbonForm);
    }
}
