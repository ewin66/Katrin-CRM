using System;
using System.Collections.Generic;
using System.Collections;
using Microsoft.Practices.CompositeUI.Utility;
using DevExpress.XtraPrinting.Control;

namespace Katrin.Win.MainModule.Views.Reports
{
    public interface IOpportunityReportView
    {
        event EventHandler SearchReport;
        event EventHandler<DataEventArgs<OpportunityOverview>> NameCellClicked;
        //void Init();
        void Bind(IEnumerable list);
        //int? DataRangeValue { get; }
        //DateTime StartDate { get; }
        //DateTime EndDate { get; }

        //List<Guid> TechnicianIds { get; }
        //List<Guid> OwnerIds { get; }
        //int? StatusValue { get; }
        bool ValidateData();
        PrintControl ReportPrintControl { get; }
    }
}
