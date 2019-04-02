using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.MetadataServiceReference;

namespace Katrin.Win.MainModule.Views.TimeTracking
{
    public interface ITimeTrackingDetail : IEntityDetailView
    {
        event EventHandler Saved;
        void Close(DialogResult result);
    }
}
