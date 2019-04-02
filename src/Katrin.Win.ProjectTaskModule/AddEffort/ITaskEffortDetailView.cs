using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.ViewInterface;
namespace Katrin.Win.ProjectTaskModule.AddEffort
{
    public interface ITaskEffortDetailView : IObjectDetailView
    {
        bool ValidateResult { get; set; } 
        event EventHandler OnCreateData;
        event EventHandler<EventArgs<int>> OnDeleteData;
        void BindGrid(object listDataSource);
    }
}
