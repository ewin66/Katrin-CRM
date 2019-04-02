using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;
using System.Collections;

namespace Katrin.Win.MainModule.Views.ProjectManagement
{
    public interface IProjectDetailView : IEntityDetailView
    {
        void BindStatisticNumber(List<ProjectSummary> statisticNumberList);
        event EventHandler<Katrin.Win.Infrastructure.EventArgs<Guid>> ContractEditValueChanged;
        void BindProjectMember(List<Guid> selectedProjectMember);
        ArrayList SelectedProjectMember { get; }
       
    }
}
