using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.ViewInterface;

namespace Katrin.Win.ProjectTaskModule.BatchEffort
{
    public interface INewTaskEffortDetailView : IObjectDetailView
    {
        bool ValidateResult { get; set; } 
    }
}
