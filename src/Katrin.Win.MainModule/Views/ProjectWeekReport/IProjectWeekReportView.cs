using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;

namespace Katrin.Win.MainModule.Views.ProjectWeekReport
{
    public interface IProjectWeekReportDetailView : IEntityDetailView
    {
        void SetRichEdit();
    }
}
