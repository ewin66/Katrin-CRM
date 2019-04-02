using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Katrin.Win.ProjectReportModule.Report
{
    public enum ProjectDateRange
    {
        ThisWeek,
        LastWeek,
        ThisMonth,
        LastMonth,
        ThisQuarter,
        LastQuarter,
        ThisYear,
        LastYear,
        Custom
    }

    public enum ProjectStatus
    {
        NotStarted = 1,
        InProgress = 2,
        Completed =3
    }

    public class ProjectOverviewCollection : ArrayList, ITypedList
    {
        PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            if (listAccessors != null && listAccessors.Length > 0)
            {
                PropertyDescriptor listAccessor = listAccessors[listAccessors.Length - 1];
                if (listAccessor.PropertyType == typeof(ProjectOverview))
                    return TypeDescriptor.GetProperties(typeof(ProjectOverview));
            }
            return TypeDescriptor.GetProperties(typeof(ProjectOverview));
        }

        string ITypedList.GetListName(PropertyDescriptor[] listAccessors)
        {
            return "Projects";
        }
    }

    public class ProjectOverview
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string Type { get; set; }
        public string Technology { get; set; }
        public string ProjectSummaryInfo { get; set; }
        public string Probability { get; set; }
        public string ResponsibilityPerson { get; set; }
        public DateTime? LatestFeadbackOn { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public double? TotalQuoteWorkHours { get; set; }
        public double? TotalActualWorkHours { get; set; }
        public double? TotalActualInput { get; set; }
        public double? TotalEffort { get; set; }
        public double? TotalRemainderTime { get; set; }
        public double? TotalEvaluateExactlyRate { get; set; }
        public double? TotalInputEffortRate { get; set; }
        public double? WeekQuoteWorkHours { get; set; }
        public double? WeekActualWorkHours { get; set; }
        public double? WeekActualInput { get; set; }
        public double? WeekEffort { get; set; }
        public double? WeekRemainderTime { get; set; }
        public double? InputEffortRate { get; set; }
        public double? EvaluateExactlyRate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public string ProjectStatus { get; set; }
        public string Quality { get; set; }
        public string Objective { get; set; }
        //readonly NoteCollection _notes = new NoteCollection();

        //public NoteCollection Notes { get { return _notes; } }

        //public void Add(Note note)
        //{
        //    _notes.Add(note);
        //}
    }

    //public class NoteCollection : ArrayList, ITypedList
    //{

    //    PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
    //    {
    //        return TypeDescriptor.GetProperties(typeof(Note));
    //    }

    //    string ITypedList.GetListName(PropertyDescriptor[] listAccessors)
    //    {
    //        return "Notes";
    //    }
    //}

    //public class Note
    //{
    //    //public string Subject { get; set; }
    //    public string NoteText { get; set; }
    //    public string CreatedBy { get; set; }
    //    public DateTime? CreatedOn { get; set; }
    //}
}
