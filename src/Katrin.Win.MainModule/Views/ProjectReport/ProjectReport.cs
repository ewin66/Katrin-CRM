using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Microsoft.Practices.CompositeUI.Utility;

namespace Katrin.Win.MainModule.Views.ProjectReport
{
    public partial class ProjectReport : DevExpress.XtraReports.UI.XtraReport
    {
        private string progressDescriptionCaption = string.Empty;
        public event EventHandler<DataEventArgs<ProjectOverview>> NameCellClicked;

        public void OnNameCellClicked(DataEventArgs<ProjectOverview> e)
        {
            EventHandler<DataEventArgs<ProjectOverview>> handler = NameCellClicked;
            if (handler != null) handler(this, e);
        }

        public ProjectReport()
        {
            InitializeComponent();
            projectNameCell.DataBindings.Add(new XRBinding("Text", null, "Name"));
            customerNameCell.DataBindings.Add(new XRBinding("Text", null, "CustomerName"));
            //projectTypeCell.DataBindings.Add(new XRBinding("Text", null, "Type"));
            //projectTechnologyCell.DataBindings.Add(new XRBinding("Text", null, "Technology"));
            //probabilityCell.DataBindings.Add(new XRBinding("Text", null, "Probability"));
            //responsibilityPersonCell.DataBindings.Add(new XRBinding("Text", null, "ResponsibilityPerson"));
            latestFeadbackCell.DataBindings.Add(new XRBinding("Text", null, "LatestFeadbackOn", "{0:d}"));
            estimatedEndDateCell.DataBindings.Add(new XRBinding("Text", null, "EstimatedEndDate", "{0:d}"));
            totalQuoteWorkHoursCell.DataBindings.Add(new XRBinding("Text", null, "TotalQuoteWorkHours"));
            totalActualWorkHoursCell.DataBindings.Add(new XRBinding("Text", null, "TotalActualWorkHours"));
            TotalEffortCell.DataBindings.Add(new XRBinding("Text", null, "TotalEffort"));
            TotalActualInputCell.DataBindings.Add(new XRBinding("Text", null, "TotalActualInput"));
            TotalInputEffortRateCell.DataBindings.Add(new XRBinding("Text", null, "TotalInputEffortRate", "{0:0%}"));
            TotalEvaluateExactlyRateCell.DataBindings.Add(new XRBinding("Text", null, "TotalEvaluateExactlyRate", "{0:0%}"));
            weekActualInputCell.DataBindings.Add(new XRBinding("Text", null, "WeekActualInput"));
            weekEffortCell.DataBindings.Add(new XRBinding("Text", null, "WeekEffort"));
            totalRemainderTimeCell.DataBindings.Add(new XRBinding("Text", null, "TotalRemainderTime"));
            actualStartDateCell.DataBindings.Add(new XRBinding("Text", null, "ActualStartDate", "{0:d}"));
            projectStatusCell.DataBindings.Add(new XRBinding("Text", null, "ProjectStatus"));
            qualityCell.DataBindings.Add(new XRBinding("Text", null, "Quality"));
            objectiveCell.DataBindings.Add(new XRBinding("Text", null, "Objective"));
            ProjectSummaryInfoCell.DataBindings.Add(new XRBinding("Text", null, "ProjectSummaryInfo"));
            WeekQuoteWorkHoursCell.DataBindings.Add(new XRBinding("Text", null, "WeekQuoteWorkHours"));
            WeekActualWorkHoursCell.DataBindings.Add(new XRBinding("Text", null, "WeekActualWorkHours"));
            WeekRemainderTimeCell.DataBindings.Add(new XRBinding("Text", null, "WeekRemainderTime"));
            InputEffortRateCell.DataBindings.Add(new XRBinding("Text", null, "InputEffortRate", "{0:0%}"));
            EvaluateExactlyRateCell.DataBindings.Add(new XRBinding("Text", null, "EvaluateExactlyRate", "{0:0%}"));
            //progressDescriptionHeaderCell.BeforePrint += progressDescriptionHeaderCell_BeforePrint;
            //progressDescriptionCaption = progressDescriptionHeaderCell.Text;

            projectNameCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(projectNameCell_BeforePrint);
            projectNameCell.PreviewClick += new PreviewMouseEventHandler(projectNameCell_PreviewClick);
            
        }

        void projectNameCell_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRTableCell) sender).Tag = GetCurrentRow();
        }

        void projectNameCell_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            //var overviewItem = (ProjectOverview)e.Brick.Value;
            //OnNameCellClicked(new DataEventArgs<ProjectOverview>(overviewItem));
        }

        void progressDescriptionHeaderCell_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //var cell = ((XRTableCell) sender);
            //cell.Text = DetailReportBand.CurrentRowIndex == 0 ? progressDescriptionCaption : string.Empty;
        }
    }
}
