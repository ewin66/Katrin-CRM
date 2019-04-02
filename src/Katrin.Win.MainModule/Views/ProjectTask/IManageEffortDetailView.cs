using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;
using Katrin.Win.Infrastructure;

namespace Katrin.Win.MainModule.Views.ProjectTask
{
    public interface IManageEffortDetailView : IEntityDetailView
    {
        bool ValidateResult { get; set; } 
        event EventHandler OnCreateData;
        event EventHandler<EventArgs<int>> OnDeleteData;
    }
}
