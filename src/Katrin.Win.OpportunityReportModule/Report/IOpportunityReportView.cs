using System;
using System.Collections.Generic;
using System.Collections;
using DevExpress.XtraPrinting.Control;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.WinForms.MVC;

namespace Katrin.Win.OpportunityReportModule.Report
{
    public interface IOpportunityReportView : IView
    {
        event EventHandler SearchReport;
        event EventHandler<EventArgs<OpportunityOverview>> NameCellClicked;
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
        event EventHandler OnViewReady;
    }
}
