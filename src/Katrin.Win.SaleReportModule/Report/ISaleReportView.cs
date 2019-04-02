using System;
using System.Collections.Generic;
using System.Collections;
using DevExpress.XtraPrinting.Control;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.WinForms.MVC;

namespace Katrin.Win.SaleReportModule.Report
{
    public interface ISaleReportView : IView
    {
        event EventHandler SearchReport;
        event EventHandler<EventArgs<SaleOverview>> NameCellClicked;
        void Bind(IEnumerable list);
        bool ValidateData();
        PrintControl ReportPrintControl { get; }
        event EventHandler OnViewReady;
        void DimensionItemChange(ArrayList dimensions);
        void ChangeChart(string stargetName, int dimsionIndex,int chartType);
        void SelectChart(int selectValue);
    }
}
