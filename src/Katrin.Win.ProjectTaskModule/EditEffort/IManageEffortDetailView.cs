using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.ViewInterface;
using Katrin.AppFramework.WinForms.Views;

namespace Katrin.Win.ProjectTaskModule.EditEffort
{
    public interface IManageEffortDetailView : IObjectDetailView
    {
        bool ValidateResult { get; set; } 
        event EventHandler OnCreateData;
        event EventHandler<EventArgs<int>> OnDeleteData;
        void Bind(object entity);
    }
}
