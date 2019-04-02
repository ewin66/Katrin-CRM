using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Katrin.AppFramework.Utils;

namespace Katrin.Win.OpportunityReportModule.Report
{
    public partial class OpportunityReport : DevExpress.XtraReports.UI.XtraReport
    {
        private string progressDescriptionCaption = string.Empty;
        public event EventHandler<EventArgs<OpportunityOverview>> NameCellClicked;

        public void OnNameCellClicked(EventArgs<OpportunityOverview> e)
        {
            EventHandler<EventArgs<OpportunityOverview>> handler = NameCellClicked;
            if (handler != null) handler(this, e);
        }

        public OpportunityReport()
        {
            InitializeComponent();
            DetailReportBand.DataMember = "Notes";
            projectNameCell.DataBindings.Add(new XRBinding("Text", null, "Name"));
            customerNameCell.DataBindings.Add(new XRBinding("Text", null, "CustomerName"));
            projectTypeCell.DataBindings.Add(new XRBinding("Text", null, "Type"));
            projectTechnologyCell.DataBindings.Add(new XRBinding("Text", null, "Technology"));
            probabilityCell.DataBindings.Add(new XRBinding("Text", null, "Probability", "{0}%"));
            latestFeadbackCell.DataBindings.Add(new XRBinding("Text", null, "LatestFeadbackOn", "{0:d}"));
            expectedStartDateCell.DataBindings.Add(new XRBinding("Text", null, "ExpectedStartDate", "{0:d}"));
            workAmountCell.DataBindings.Add(new XRBinding("Text", null, "EstimatedWorkAmount", "{0:#}"));
            closedDateCell.DataBindings.Add(new XRBinding("Text", null, "ClosedDate","{0:d}"));
            statusCell.DataBindings.Add(new XRBinding("Text", null, "Status"));
            contractTotalCell.DataBindings.Add(new XRBinding("Text", null, "ContractTotal", "{0:#}"));
            salesNameCell.DataBindings.Add(new XRBinding("Text", null, "SaleName"));
            salesTotalEffortsCell.DataBindings.Add(new XRBinding("Text", null, "SaleTotalEfforts"));
            salesCurrentEffortCell.DataBindings.Add(new XRBinding("Text", null, "SaleCurrentEfforts"));
            technicianNameCell.DataBindings.Add(new XRBinding("Text", null, "TechnicianName"));
            technicianTotalEffortsCell.DataBindings.Add(new XRBinding("Text", null, "TechnicianTotalEfforts"));
            technicianCurrentEffortsCell.DataBindings.Add(new XRBinding("Text", null, "TechnicianCurrentEfforts"));
            costRatioCell.DataBindings.Add(new XRBinding("Text", null, "CostRatio", "{0:0%}"));

            progressDescriptionCell.DataBindings.Add(new XRBinding("Text", null, "Notes.NoteText"));
            noteCreatedOnCell.DataBindings.Add(new XRBinding("Text", null, "Notes.CreatedOn", "{0:d}"));
            noteCreatedByCell.DataBindings.Add(new XRBinding("Text", null, "Notes.CreatedBy"));
            summaryDescriptionCell.DataBindings.Add(new XRBinding("Text", null, "Description"));
            progressDescriptionHeaderCell.BeforePrint += progressDescriptionHeaderCell_BeforePrint;
            projectNameCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(projectNameCell_BeforePrint);
            projectNameCell.PreviewClick += new PreviewMouseEventHandler(projectNameCell_PreviewClick);
            progressDescriptionCaption = progressDescriptionHeaderCell.Text;
        }

        void projectNameCell_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRTableCell) sender).Tag = GetCurrentRow();
        }

        void projectNameCell_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            var overviewItem = (OpportunityOverview)e.Brick.Value;
            OnNameCellClicked(new EventArgs<OpportunityOverview>(overviewItem));
        }

        void progressDescriptionHeaderCell_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var cell = ((XRTableCell) sender);
            cell.Text = DetailReportBand.CurrentRowIndex == 0 ? progressDescriptionCaption : string.Empty;
        }
    }
}
