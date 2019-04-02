using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.ViewInterface;

namespace Katrin.Win.ProjectTaskModule.Detail
{
    public interface IProjectTaskDetailView : IObjectDetailView
    {
        void SetProjectEable(bool enable);
        event EventHandler<EventArgs<Guid>> OnProjectChange;
    }
}
