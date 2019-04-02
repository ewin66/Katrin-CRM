using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Katrin.AppFramework.WinForms.ViewInterface;
using Katrin.AppFramework.Utils;

namespace Katrin.Win.ProjectModule.Detail
{
    public interface IProjectDetailView : IObjectDetailView
    {
        void BindStatisticNumber(List<ProjectSummary> statisticNumberList);
        event EventHandler<EventArgs<Guid>> ContractEditValueChanged;
        void BindProjectMember(List<Guid> selectedProjectMember);
        ArrayList SelectedProjectMember { get; }
       
    }
}
