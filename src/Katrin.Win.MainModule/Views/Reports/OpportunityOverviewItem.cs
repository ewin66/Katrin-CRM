using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Katrin.Win.MainModule.Views.Reports
{
    public class OpportunityOverviewCollection : ArrayList, ITypedList
    {
        PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            if (listAccessors != null && listAccessors.Length > 0)
            {
                PropertyDescriptor listAccessor = listAccessors[listAccessors.Length - 1];
                if (listAccessor.PropertyType == typeof(NoteCollection))
                    return TypeDescriptor.GetProperties(typeof(Note));
            }
            return TypeDescriptor.GetProperties(typeof (OpportunityOverview));
        }

        string ITypedList.GetListName(PropertyDescriptor[] listAccessors)
        {
            return "Opportunities";
        }
    }

    public class OpportunityOverview
    {
        public Guid OpportunityId { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string Type { get; set; }
        public string Technology { get; set; }
        public int? Probability { get; set; }
        public DateTime? LatestFeadbackOn { get; set; }
        public DateTime? ExpectedStartDate { get; set; }
        public double? EstimatedWorkAmount { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string Status { get; set; }
        public decimal? ContractTotal { get; set; }
        public string SaleName { get; set; }
        public double? SaleTotalEfforts { get; set; }
        public double? SaleCurrentEfforts { get; set; }
        public string TechnicianName { get; set; }
        public double? TechnicianTotalEfforts { get; set; }
        public double? TechnicianCurrentEfforts { get; set; }
        public double? CostRatio { get; set; }
        public string Description { get; set; }

        readonly NoteCollection _notes = new NoteCollection();

        public NoteCollection Notes { get { return _notes; } }

        public void Add(Note note)
        {
            _notes.Add(note);
        }
    }

    public class NoteCollection : ArrayList, ITypedList
    {
        PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            return TypeDescriptor.GetProperties(typeof(Note));
        }

        string ITypedList.GetListName(PropertyDescriptor[] listAccessors)
        {
            return "Notes";
        }
    }

    public class Note
    {
        //public string Subject { get; set; }
        public string NoteText { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
