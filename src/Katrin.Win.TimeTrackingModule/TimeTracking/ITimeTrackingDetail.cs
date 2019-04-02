using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Katrin.AppFramework.WinForms.ViewInterface;


namespace Katrin.Win.TimeTrackingModule.TimeTracking
{
    public interface ITimeTrackingDetail : IObjectDetailView
    {
        event EventHandler Saved;
        void Close(DialogResult result);
    }
}
