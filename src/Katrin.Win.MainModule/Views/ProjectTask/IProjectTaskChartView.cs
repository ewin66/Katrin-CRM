using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.MetadataServiceReference;
using Katrin.Win.Infrastructure;

namespace Katrin.Win.MainModule.Views.ProjectTask
{
    public interface IProjectTaskChartView :IProejctTaskFilter
    {
        void InitEditors();
        void BindTaskData(BindingList<object> taskList);
        event EventHandler<EventArgs<object,int,int>> OnStatusCodeChange;
        event EventHandler<EventArgs<object>> OnEditItem;
    }
}
