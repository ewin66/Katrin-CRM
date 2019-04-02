using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win.ProjectTaskModule.Common
{
    public class TaskTimeHistory
    {
        public Guid TaskTimeHistoryId { get; set; }
        public Guid TaskId { get; set; }
        public string RecordPerson { get; set; }
        public string IterationName { get; set; }
        public string Name { get; set; }
        public string ProjectName { get; set; }
        public DateTime RecordOn { get; set; }
        public double ActualWorkHours { get; set; }
        public double ActualInput { get; set; }
        public double Effort { get; set; }
        public double SourceEffort { get; set; }
        public double Overtime { get; set; }
        public double RemainderTime { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
