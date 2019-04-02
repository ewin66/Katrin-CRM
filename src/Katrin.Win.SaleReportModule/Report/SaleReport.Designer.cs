using System;
using DevExpress.XtraReports.UI;
using System.Collections;
namespace Katrin.Win.SaleReportModule.Report
{
    partial class SaleReport
    {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader1;
        private DevExpress.XtraReports.UI.XRLabel lbTitle;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRControlStyle ProductData;
        private DevExpress.XtraReports.UI.XRControlStyle OddStyle;
        private DevExpress.XtraReports.UI.XRControlStyle GroupHeader;
        private DevExpress.XtraReports.UI.XRControlStyle ProductHeader;
        private DevExpress.XtraReports.UI.XRControlStyle SupplierTitle;
        private DevExpress.XtraReports.UI.XRControlStyle EvenStyle;
        private DevExpress.XtraReports.UI.XRControlStyle SupplierInfo;
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (this.DataSource != null)
            {
                IList data = this.DataSource as IList;
                if (data != null) data.Clear();              
                this.DataSource = null;

            }
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
            GC.Collect();
            GC.SuppressFinalize(this);
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleReport));
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel1 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel2 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView2 = new DevExpress.XtraCharts.PieSeriesView();
            this.ProductData = new DevExpress.XtraReports.UI.XRControlStyle();
            this.OddStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.GroupHeader = new DevExpress.XtraReports.UI.XRControlStyle();
            this.ProductHeader = new DevExpress.XtraReports.UI.XRControlStyle();
            this.SupplierTitle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.EvenStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.SupplierInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.tableDetail = new DevExpress.XtraReports.UI.XRTable();
            this.dimensionCellRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.UnitNameCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.LeadNumberCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.FirstEmailCountCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.ResponseRateCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.NumberIntoOpportunityCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.RateIntoOpportunityCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.NumberOfTheDeadCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.ClosureRateCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.OpportunityNumberCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.NumberIntoContractCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.QuoteSuccessRateCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.ContractAmountCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.ContractNumberCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.RateOfOldCustomerCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.lbTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.headerTable = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.DimensionCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.dimensionRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell61 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell63 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell67 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell69 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell68 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell70 = new DevExpress.XtraReports.UI.XRTableCell();
            this.technicianTotalEffortsHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell73 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell74 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell72 = new DevExpress.XtraReports.UI.XRTableCell();
            this.RootLayoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.xrChart1 = new DevExpress.XtraReports.UI.XRChart();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.tableDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // ProductData
            // 
            this.ProductData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.ProductData.BorderColor = System.Drawing.Color.White;
            this.ProductData.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.ProductData.BorderWidth = 1;
            this.ProductData.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ProductData.ForeColor = System.Drawing.Color.Black;
            this.ProductData.Name = "ProductData";
            // 
            // OddStyle
            // 
            this.OddStyle.BackColor = System.Drawing.Color.Transparent;
            this.OddStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(205)))), ((int)(((byte)(162)))));
            this.OddStyle.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.OddStyle.BorderWidth = 1;
            this.OddStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.OddStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OddStyle.Name = "OddStyle";
            // 
            // GroupHeader
            // 
            this.GroupHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.GroupHeader.BorderColor = System.Drawing.Color.White;
            this.GroupHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.GroupHeader.BorderWidth = 1;
            this.GroupHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GroupHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.GroupHeader.Name = "GroupHeader";
            // 
            // ProductHeader
            // 
            this.ProductHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(132)))), ((int)(((byte)(213)))));
            this.ProductHeader.BorderColor = System.Drawing.Color.White;
            this.ProductHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.ProductHeader.BorderWidth = 1;
            this.ProductHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ProductHeader.ForeColor = System.Drawing.Color.White;
            this.ProductHeader.Name = "ProductHeader";
            // 
            // SupplierTitle
            // 
            this.SupplierTitle.BackColor = System.Drawing.Color.Transparent;
            this.SupplierTitle.BorderColor = System.Drawing.Color.Empty;
            this.SupplierTitle.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.SupplierTitle.BorderWidth = 1;
            this.SupplierTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.SupplierTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.SupplierTitle.Name = "SupplierTitle";
            // 
            // EvenStyle
            // 
            this.EvenStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(196)))));
            this.EvenStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(205)))), ((int)(((byte)(162)))));
            this.EvenStyle.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.EvenStyle.BorderWidth = 1;
            this.EvenStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.EvenStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EvenStyle.Name = "EvenStyle";
            // 
            // SupplierInfo
            // 
            this.SupplierInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(132)))), ((int)(((byte)(213)))));
            this.SupplierInfo.BorderColor = System.Drawing.Color.White;
            this.SupplierInfo.BorderWidth = 1;
            this.SupplierInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.SupplierInfo.ForeColor = System.Drawing.Color.White;
            this.SupplierInfo.Name = "SupplierInfo";
            this.SupplierInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(7, 0, 0, 0, 100F);
            // 
            // Detail
            // 
            resources.ApplyResources(this.Detail, "Detail");
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tableDetail});
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // tableDetail
            // 
            resources.ApplyResources(this.tableDetail, "tableDetail");
            this.tableDetail.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableDetail.Name = "tableDetail";
            this.tableDetail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.tableDetail.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.dimensionCellRow});
            this.tableDetail.StylePriority.UseBackColor = false;
            this.tableDetail.StylePriority.UsePadding = false;
            // 
            // dimensionCellRow
            // 
            resources.ApplyResources(this.dimensionCellRow, "dimensionCellRow");
            this.dimensionCellRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.UnitNameCell,
            this.LeadNumberCell,
            this.FirstEmailCountCell,
            this.ResponseRateCell,
            this.NumberIntoOpportunityCell,
            this.RateIntoOpportunityCell,
            this.NumberOfTheDeadCell,
            this.ClosureRateCell,
            this.OpportunityNumberCell,
            this.NumberIntoContractCell,
            this.QuoteSuccessRateCell,
            this.ContractAmountCell,
            this.ContractNumberCell,
            this.RateOfOldCustomerCell});
            this.dimensionCellRow.Name = "dimensionCellRow";
            this.dimensionCellRow.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.dimensionCellRow.Weight = 1D;
            // 
            // UnitNameCell
            // 
            resources.ApplyResources(this.UnitNameCell, "UnitNameCell");
            this.UnitNameCell.Name = "UnitNameCell";
            this.UnitNameCell.Weight = 0.36288850690201224D;
            // 
            // LeadNumberCell
            // 
            this.LeadNumberCell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            resources.ApplyResources(this.LeadNumberCell, "LeadNumberCell");
            this.LeadNumberCell.Name = "LeadNumberCell";
            this.LeadNumberCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.LeadNumberCell.StylePriority.UseBorders = false;
            this.LeadNumberCell.Weight = 0.14146295582557106D;
            // 
            // FirstEmailCountCell
            // 
            this.FirstEmailCountCell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            resources.ApplyResources(this.FirstEmailCountCell, "FirstEmailCountCell");
            this.FirstEmailCountCell.Name = "FirstEmailCountCell";
            this.FirstEmailCountCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.FirstEmailCountCell.StylePriority.UseBorders = false;
            this.FirstEmailCountCell.Weight = 0.073533032620059D;
            // 
            // ResponseRateCell
            // 
            this.ResponseRateCell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            resources.ApplyResources(this.ResponseRateCell, "ResponseRateCell");
            this.ResponseRateCell.Name = "ResponseRateCell";
            this.ResponseRateCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.ResponseRateCell.StylePriority.UseBorders = false;
            this.ResponseRateCell.Weight = 0.095192176281529178D;
            // 
            // NumberIntoOpportunityCell
            // 
            this.NumberIntoOpportunityCell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            resources.ApplyResources(this.NumberIntoOpportunityCell, "NumberIntoOpportunityCell");
            this.NumberIntoOpportunityCell.Name = "NumberIntoOpportunityCell";
            this.NumberIntoOpportunityCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100F);
            this.NumberIntoOpportunityCell.StylePriority.UseBorders = false;
            this.NumberIntoOpportunityCell.Weight = 0.12916676503643715D;
            // 
            // RateIntoOpportunityCell
            // 
            this.RateIntoOpportunityCell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            resources.ApplyResources(this.RateIntoOpportunityCell, "RateIntoOpportunityCell");
            this.RateIntoOpportunityCell.Name = "RateIntoOpportunityCell";
            this.RateIntoOpportunityCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.RateIntoOpportunityCell.StylePriority.UseBorders = false;
            this.RateIntoOpportunityCell.StylePriority.UseTextAlignment = false;
            this.RateIntoOpportunityCell.Weight = 0.1134616914816714D;
            // 
            // NumberOfTheDeadCell
            // 
            this.NumberOfTheDeadCell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            resources.ApplyResources(this.NumberOfTheDeadCell, "NumberOfTheDeadCell");
            this.NumberOfTheDeadCell.Name = "NumberOfTheDeadCell";
            this.NumberOfTheDeadCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100F);
            this.NumberOfTheDeadCell.StylePriority.UseBorders = false;
            this.NumberOfTheDeadCell.Weight = 0.12019217345704021D;
            // 
            // ClosureRateCell
            // 
            this.ClosureRateCell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            resources.ApplyResources(this.ClosureRateCell, "ClosureRateCell");
            this.ClosureRateCell.Name = "ClosureRateCell";
            this.ClosureRateCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.ClosureRateCell.StylePriority.UseBorders = false;
            this.ClosureRateCell.Weight = 0.089743338470040818D;
            // 
            // OpportunityNumberCell
            // 
            this.OpportunityNumberCell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            resources.ApplyResources(this.OpportunityNumberCell, "OpportunityNumberCell");
            this.OpportunityNumberCell.Name = "OpportunityNumberCell";
            this.OpportunityNumberCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100F);
            this.OpportunityNumberCell.StylePriority.UseBorders = false;
            this.OpportunityNumberCell.Weight = 0.11923091201343503D;
            // 
            // NumberIntoContractCell
            // 
            this.NumberIntoContractCell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            resources.ApplyResources(this.NumberIntoContractCell, "NumberIntoContractCell");
            this.NumberIntoContractCell.Name = "NumberIntoContractCell";
            this.NumberIntoContractCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100F);
            this.NumberIntoContractCell.StylePriority.UseBorders = false;
            this.NumberIntoContractCell.Weight = 0.13128197238160738D;
            // 
            // QuoteSuccessRateCell
            // 
            this.QuoteSuccessRateCell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            resources.ApplyResources(this.QuoteSuccessRateCell, "QuoteSuccessRateCell");
            this.QuoteSuccessRateCell.Name = "QuoteSuccessRateCell";
            this.QuoteSuccessRateCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.QuoteSuccessRateCell.StylePriority.UseBorders = false;
            this.QuoteSuccessRateCell.Weight = 0.11794880193775684D;
            // 
            // ContractAmountCell
            // 
            this.ContractAmountCell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            resources.ApplyResources(this.ContractAmountCell, "ContractAmountCell");
            this.ContractAmountCell.Name = "ContractAmountCell";
            this.ContractAmountCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100F);
            this.ContractAmountCell.StylePriority.UseBorders = false;
            this.ContractAmountCell.Weight = 0.1030126550227433D;
            // 
            // ContractNumberCell
            // 
            this.ContractNumberCell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            resources.ApplyResources(this.ContractNumberCell, "ContractNumberCell");
            this.ContractNumberCell.Name = "ContractNumberCell";
            this.ContractNumberCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100F);
            this.ContractNumberCell.StylePriority.UseBorders = false;
            this.ContractNumberCell.Weight = 0.11004446310558497D;
            // 
            // RateOfOldCustomerCell
            // 
            this.RateOfOldCustomerCell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            resources.ApplyResources(this.RateOfOldCustomerCell, "RateOfOldCustomerCell");
            this.RateOfOldCustomerCell.Name = "RateOfOldCustomerCell";
            this.RateOfOldCustomerCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100F);
            this.RateOfOldCustomerCell.StylePriority.UseBorders = false;
            this.RateOfOldCustomerCell.Weight = 0.075916804656003478D;
            // 
            // BottomMargin
            // 
            resources.ApplyResources(this.BottomMargin, "BottomMargin");
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // ReportHeader1
            // 
            this.ReportHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1,
            this.lbTitle,
            this.xrPageInfo2});
            resources.ApplyResources(this.ReportHeader1, "ReportHeader1");
            this.ReportHeader1.Name = "ReportHeader1";
            this.ReportHeader1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // xrLine1
            // 
            resources.ApplyResources(this.xrLine1, "xrLine1");
            this.xrLine1.LineWidth = 2;
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // lbTitle
            // 
            this.lbTitle.Borders = DevExpress.XtraPrinting.BorderSide.None;
            resources.ApplyResources(this.lbTitle, "lbTitle");
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTitle.StylePriority.UseTextAlignment = false;
            // 
            // xrPageInfo2
            // 
            resources.ApplyResources(this.xrPageInfo2, "xrPageInfo2");
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            // 
            // topMarginBand1
            // 
            resources.ApplyResources(this.topMarginBand1, "topMarginBand1");
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.headerTable});
            resources.ApplyResources(this.PageHeader, "PageHeader");
            this.PageHeader.Name = "PageHeader";
            // 
            // headerTable
            // 
            resources.ApplyResources(this.headerTable, "headerTable");
            this.headerTable.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.headerTable.KeepTogether = true;
            this.headerTable.Name = "headerTable";
            this.headerTable.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.headerTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2,
            this.dimensionRow});
            this.headerTable.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.headerTable_BeforePrint);
            // 
            // xrTableRow2
            // 
            resources.ApplyResources(this.xrTableRow2, "xrTableRow2");
            this.xrTableRow2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.DimensionCell,
            this.xrTableCell6,
            this.xrTableCell4,
            this.xrTableCell10});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrTableRow2.StylePriority.UseBorders = false;
            this.xrTableRow2.Weight = 0.33391304347826084D;
            // 
            // DimensionCell
            // 
            resources.ApplyResources(this.DimensionCell, "DimensionCell");
            this.DimensionCell.Name = "DimensionCell";
            this.DimensionCell.StylePriority.UseBackColor = false;
            this.DimensionCell.StylePriority.UseBorderColor = false;
            this.DimensionCell.StylePriority.UseFont = false;
            this.DimensionCell.StylePriority.UseForeColor = false;
            this.DimensionCell.StylePriority.UseTextAlignment = false;
            this.DimensionCell.Weight = 0.50205242872868028D;
            // 
            // xrTableCell6
            // 
            resources.ApplyResources(this.xrTableCell6, "xrTableCell6");
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseBackColor = false;
            this.xrTableCell6.StylePriority.UseBorderColor = false;
            this.xrTableCell6.StylePriority.UseFont = false;
            this.xrTableCell6.StylePriority.UseForeColor = false;
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.Weight = 1.0552594007027496D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            resources.ApplyResources(this.xrTableCell4, "xrTableCell4");
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell4.StyleName = "ProductHeader";
            this.xrTableCell4.StylePriority.UseBorders = false;
            this.xrTableCell4.Weight = 0.50976304887926438D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            resources.ApplyResources(this.xrTableCell10, "xrTableCell10");
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell10.StyleName = "ProductHeader";
            this.xrTableCell10.StylePriority.UseBorders = false;
            this.xrTableCell10.Weight = 0.39979246457082585D;
            // 
            // dimensionRow
            // 
            this.dimensionRow.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.dimensionRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell12,
            this.xrTableCell61,
            this.xrTableCell63,
            this.xrTableCell2,
            this.xrTableCell66,
            this.xrTableCell67,
            this.xrTableCell69,
            this.xrTableCell68,
            this.xrTableCell70,
            this.technicianTotalEffortsHeaderCell,
            this.xrTableCell71,
            this.xrTableCell73,
            this.xrTableCell74,
            this.xrTableCell72});
            resources.ApplyResources(this.dimensionRow, "dimensionRow");
            this.dimensionRow.Name = "dimensionRow";
            this.dimensionRow.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.dimensionRow.StyleName = "ProductData";
            this.dimensionRow.StylePriority.UseBorders = false;
            this.dimensionRow.Weight = 0.55652173913043479D;
            // 
            // xrTableCell12
            // 
            resources.ApplyResources(this.xrTableCell12, "xrTableCell12");
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Weight = 0.50205244651089687D;
            // 
            // xrTableCell61
            // 
            resources.ApplyResources(this.xrTableCell61, "xrTableCell61");
            this.xrTableCell61.Name = "xrTableCell61";
            this.xrTableCell61.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell61.StylePriority.UseFont = false;
            this.xrTableCell61.Weight = 0.19571251707747889D;
            // 
            // xrTableCell63
            // 
            resources.ApplyResources(this.xrTableCell63, "xrTableCell63");
            this.xrTableCell63.Name = "xrTableCell63";
            this.xrTableCell63.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell63.StylePriority.UseFont = false;
            this.xrTableCell63.Weight = 0.10173209501697306D;
            // 
            // xrTableCell2
            // 
            resources.ApplyResources(this.xrTableCell2, "xrTableCell2");
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.Weight = 0.13169749628994815D;
            // 
            // xrTableCell66
            // 
            resources.ApplyResources(this.xrTableCell66, "xrTableCell66");
            this.xrTableCell66.Name = "xrTableCell66";
            this.xrTableCell66.StylePriority.UseFont = false;
            this.xrTableCell66.Weight = 0.17870070142134309D;
            // 
            // xrTableCell67
            // 
            resources.ApplyResources(this.xrTableCell67, "xrTableCell67");
            this.xrTableCell67.Name = "xrTableCell67";
            this.xrTableCell67.StylePriority.UseFont = false;
            this.xrTableCell67.Weight = 0.15697313093066811D;
            // 
            // xrTableCell69
            // 
            resources.ApplyResources(this.xrTableCell69, "xrTableCell69");
            this.xrTableCell69.Name = "xrTableCell69";
            this.xrTableCell69.StylePriority.UseFont = false;
            this.xrTableCell69.StylePriority.UseTextAlignment = false;
            this.xrTableCell69.Weight = 0.16628446195049018D;
            // 
            // xrTableCell68
            // 
            resources.ApplyResources(this.xrTableCell68, "xrTableCell68");
            this.xrTableCell68.Name = "xrTableCell68";
            this.xrTableCell68.StylePriority.UseFont = false;
            this.xrTableCell68.StylePriority.UseTextAlignment = false;
            this.xrTableCell68.Weight = 0.12415912327244744D;
            // 
            // xrTableCell70
            // 
            resources.ApplyResources(this.xrTableCell70, "xrTableCell70");
            this.xrTableCell70.Name = "xrTableCell70";
            this.xrTableCell70.StylePriority.UseFont = false;
            this.xrTableCell70.StylePriority.UseTextAlignment = false;
            this.xrTableCell70.Weight = 0.16495480735195939D;
            // 
            // technicianTotalEffortsHeaderCell
            // 
            resources.ApplyResources(this.technicianTotalEffortsHeaderCell, "technicianTotalEffortsHeaderCell");
            this.technicianTotalEffortsHeaderCell.Name = "technicianTotalEffortsHeaderCell";
            this.technicianTotalEffortsHeaderCell.StylePriority.UseFont = false;
            this.technicianTotalEffortsHeaderCell.StylePriority.UseTextAlignment = false;
            this.technicianTotalEffortsHeaderCell.Weight = 0.1816270903270843D;
            // 
            // xrTableCell71
            // 
            resources.ApplyResources(this.xrTableCell71, "xrTableCell71");
            this.xrTableCell71.Name = "xrTableCell71";
            this.xrTableCell71.StylePriority.UseFont = false;
            this.xrTableCell71.StylePriority.UseTextAlignment = false;
            this.xrTableCell71.Weight = 0.16318091256828765D;
            // 
            // xrTableCell73
            // 
            resources.ApplyResources(this.xrTableCell73, "xrTableCell73");
            this.xrTableCell73.Name = "xrTableCell73";
            this.xrTableCell73.StylePriority.UseFont = false;
            this.xrTableCell73.StylePriority.UseTextAlignment = false;
            this.xrTableCell73.Weight = 0.14251685734875338D;
            // 
            // xrTableCell74
            // 
            resources.ApplyResources(this.xrTableCell74, "xrTableCell74");
            this.xrTableCell74.Name = "xrTableCell74";
            this.xrTableCell74.StylePriority.UseFont = false;
            this.xrTableCell74.StylePriority.UseTextAlignment = false;
            this.xrTableCell74.Weight = 0.15224534607953705D;
            // 
            // xrTableCell72
            // 
            resources.ApplyResources(this.xrTableCell72, "xrTableCell72");
            this.xrTableCell72.Name = "xrTableCell72";
            this.xrTableCell72.StylePriority.UseFont = false;
            this.xrTableCell72.StylePriority.UseTextAlignment = false;
            this.xrTableCell72.Weight = 0.10503035673565253D;
            // 
            // RootLayoutControlGroup
            // 
            resources.ApplyResources(this.RootLayoutControlGroup, "RootLayoutControlGroup");
            this.RootLayoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.RootLayoutControlGroup.GroupBordersVisible = false;
            this.RootLayoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.RootLayoutControlGroup.Name = "RootLayoutControlGroup";
            this.RootLayoutControlGroup.Size = new System.Drawing.Size(906, 667);
            this.RootLayoutControlGroup.TextVisible = false;
            // 
            // xrChart1
            // 
            resources.ApplyResources(this.xrChart1, "xrChart1");
            this.xrChart1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrChart1.Name = "xrChart1";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
            pieSeriesLabel1.LineVisible = true;
            series1.Label = pieSeriesLabel1;
            resources.ApplyResources(series1, "series1");
            pieSeriesView1.RuntimeExploding = false;
            series1.View = pieSeriesView1;
            this.xrChart1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            pieSeriesLabel2.LineVisible = true;
            this.xrChart1.SeriesTemplate.Label = pieSeriesLabel2;
            pieSeriesView2.RuntimeExploding = false;
            this.xrChart1.SeriesTemplate.View = pieSeriesView2;
            this.xrChart1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrChart1_BeforePrint);
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrChart1});
            resources.ApplyResources(this.ReportFooter, "ReportFooter");
            this.ReportFooter.Name = "ReportFooter";
            // 
            // SaleReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.BottomMargin,
            this.ReportHeader1,
            this.topMarginBand1,
            this.PageHeader,
            this.ReportFooter});
            resources.ApplyResources(this, "$this");
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(5, 5, 0, 56);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportPrintOptions.DetailCountAtDesignTime = 1;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.ProductData,
            this.OddStyle,
            this.GroupHeader,
            this.ProductHeader,
            this.SupplierTitle,
            this.EvenStyle,
            this.SupplierInfo});
            this.Version = "12.1";
            ((System.ComponentModel.ISupportInitialize)(this.tableDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        protected DevExpress.XtraLayout.LayoutControlGroup RootLayoutControlGroup;
        private XRChart xrChart1;
        private ReportFooterBand ReportFooter;
        private XRTable tableDetail;
        private XRTableRow dimensionCellRow;
        private XRTableCell UnitNameCell;
        private XRTableCell LeadNumberCell;
        private XRTableCell FirstEmailCountCell;
        private XRTableCell ResponseRateCell;
        private XRTableCell NumberIntoOpportunityCell;
        private XRTableCell RateIntoOpportunityCell;
        private XRTableCell NumberOfTheDeadCell;
        private XRTableCell ClosureRateCell;
        private XRTableCell OpportunityNumberCell;
        private XRTableCell NumberIntoContractCell;
        private XRTableCell QuoteSuccessRateCell;
        private XRTableCell ContractAmountCell;
        private XRTableCell ContractNumberCell;
        private XRTableCell RateOfOldCustomerCell;
        private XRTable headerTable;
        private XRTableRow xrTableRow2;
        private XRTableCell DimensionCell;
        private XRTableCell xrTableCell6;
        private XRTableCell xrTableCell4;
        private XRTableCell xrTableCell10;
        private XRTableRow dimensionRow;
        private XRTableCell xrTableCell12;
        private XRTableCell xrTableCell61;
        private XRTableCell xrTableCell63;
        private XRTableCell xrTableCell2;
        private XRTableCell xrTableCell66;
        private XRTableCell xrTableCell67;
        private XRTableCell xrTableCell69;
        private XRTableCell xrTableCell68;
        private XRTableCell xrTableCell70;
        private XRTableCell technicianTotalEffortsHeaderCell;
        private XRTableCell xrTableCell71;
        private XRTableCell xrTableCell73;
        private XRTableCell xrTableCell74;
        private XRTableCell xrTableCell72;
    }
}
