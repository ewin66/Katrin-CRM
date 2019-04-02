using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.ProjectTaskModule.Common
{
    public class TaskTimeHistoryComparer : IEqualityComparer<TaskTimeHistory>
    {
        public bool Equals(TaskTimeHistory x, TaskTimeHistory y)
        {
            return x.TaskTimeHistoryId == y.TaskTimeHistoryId;
        }

        public int GetHashCode(TaskTimeHistory obj)
        {
            if (Object.ReferenceEquals(obj, null))
                return 0;
            return obj.TaskTimeHistoryId.GetHashCode();
        }
    }
}
