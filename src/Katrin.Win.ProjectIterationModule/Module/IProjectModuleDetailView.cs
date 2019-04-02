using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.ViewInterface;

namespace Katrin.Win.ProjectIterationModule.Module
{
    public interface IProjectModuleDetailView : IObjectDetailView
    {
        void SetProjectEable(bool enable);
        bool ValidateResult { get; set; }
        event EventHandler<EventArgs<Guid>> OnProjectChange;
    }
}
