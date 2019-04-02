using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.MVC;

namespace Katrin.Win.ProjectTaskModule.Chart
{
    public interface IProjectTaskChartView : IView
    {
        void InitEditors();
        void BindTaskData(BindingList<object> taskList);
        event EventHandler<EventArgs<object,int,int>> OnStatusCodeChange;
        event EventHandler<EventArgs<object>> OnEditItem;
        //event EventHandler BindProjectTaskData;
        IProejctTaskFilter TaskFilter { get; }
    }
}
