using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.ViewInterface;

namespace Katrin.Win.ProjectTaskModule.Split
{
    public interface ISplitProjectTaskView : IObjectDetailView
    {
        void BindNewTask(int minValue,int defaultValue,Guid projectId, object newTaskOne, object newTaskTwo);
        event EventHandler<EventArgs<int,int>> OnValueChanged;
    }
}
