using System;
namespace Katrin.Win.ProjectReportModule.Report
{
    partial class ProjectReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectReport));
            this.ProductData = new DevExpress.XtraReports.UI.XRControlStyle();
            this.OddStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.GroupHeader = new DevExpress.XtraReports.UI.XRControlStyle();
            this.ProductHeader = new DevExpress.XtraReports.UI.XRControlStyle();
            this.SupplierTitle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.EvenStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.SupplierInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ProjectSummaryInfoCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.projectStatusCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.projectNameCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.customerNameCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.latestFeadbackCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.estimatedEndDateCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.actualStartDateCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.totalQuoteWorkHoursCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.totalActualWorkHoursCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.TotalActualInputCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.TotalEffortCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.totalRemainderTimeCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.TotalEvaluateExactlyRateCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.TotalInputEffortRateCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.WeekQuoteWorkHoursCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.WeekActualWorkHoursCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.weekActualInputCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.weekEffortCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.WeekRemainderTimeCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.EvaluateExactlyRateCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.InputEffortRateCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.qualityCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.objectiveCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.lbTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.headerTable = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow17 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell59 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell63 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell64 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell68 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell70 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerTable)).BeginInit();
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
            this.xrTable5,
            this.xrTable4,
            this.xrTable1,
            this.xrTable2,
            this.xrTable3});
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // xrTable5
            // 
            resources.ApplyResources(this.xrTable5, "xrTable5");
            this.xrTable5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable5.Name = "xrTable5";
            this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            // 
            // xrTableRow2
            // 
            resources.ApplyResources(this.xrTableRow2, "xrTableRow2");
            this.xrTableRow2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell4,
            this.ProjectSummaryInfoCell});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.StylePriority.UseBorders = false;
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell1
            // 
            resources.ApplyResources(this.xrTableCell1, "xrTableCell1");
            this.xrTableCell1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell1.BorderWidth = 0;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseBackColor = false;
            this.xrTableCell1.StylePriority.UseForeColor = false;
            this.xrTableCell1.Weight = 1.7208329051301632D;
            // 
            // xrTableCell4
            // 
            resources.ApplyResources(this.xrTableCell4, "xrTableCell4");
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell4.StylePriority.UseBorderColor = false;
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UseForeColor = false;
            this.xrTableCell4.Weight = 0.90000068203918449D;
            // 
            // ProjectSummaryInfoCell
            // 
            resources.ApplyResources(this.ProjectSummaryInfoCell, "ProjectSummaryInfoCell");
            this.ProjectSummaryInfoCell.Name = "ProjectSummaryInfoCell";
            this.ProjectSummaryInfoCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.ProjectSummaryInfoCell.StylePriority.UseBorderColor = false;
            this.ProjectSummaryInfoCell.StylePriority.UseForeColor = false;
            this.ProjectSummaryInfoCell.Weight = 8.9691605552824214D;
            // 
            // xrTable4
            // 
            resources.ApplyResources(this.xrTable4, "xrTable4");
            this.xrTable4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrTableCell9,
            this.projectStatusCell});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.StylePriority.UseBorders = false;
            this.xrTableRow5.Weight = 1D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell7.BorderWidth = 0;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Weight = 1.7208329051301632D;
            // 
            // xrTableCell9
            // 
            resources.ApplyResources(this.xrTableCell9, "xrTableCell9");
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell9.StylePriority.UseBorderColor = false;
            this.xrTableCell9.StylePriority.UseFont = false;
            this.xrTableCell9.Weight = 0.90000068203918426D;
            // 
            // projectStatusCell
            // 
            resources.ApplyResources(this.projectStatusCell, "projectStatusCell");
            this.projectStatusCell.Name = "projectStatusCell";
            this.projectStatusCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.projectStatusCell.StylePriority.UseBorderColor = false;
            this.projectStatusCell.Weight = 8.96916300199988D;
            // 
            // xrTable1
            // 
            resources.ApplyResources(this.xrTable1, "xrTable1");
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.StylePriority.UseBackColor = false;
            this.xrTable1.StylePriority.UsePadding = false;
            // 
            // xrTableRow1
            // 
            resources.ApplyResources(this.xrTableRow1, "xrTableRow1");
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.projectNameCell,
            this.customerNameCell,
            this.latestFeadbackCell,
            this.estimatedEndDateCell,
            this.actualStartDateCell,
            this.totalQuoteWorkHoursCell,
            this.totalActualWorkHoursCell,
            this.TotalActualInputCell,
            this.TotalEffortCell,
            this.totalRemainderTimeCell,
            this.TotalEvaluateExactlyRateCell,
            this.TotalInputEffortRateCell,
            this.WeekQuoteWorkHoursCell,
            this.WeekActualWorkHoursCell,
            this.weekActualInputCell,
            this.weekEffortCell,
            this.WeekRemainderTimeCell,
            this.EvaluateExactlyRateCell,
            this.InputEffortRateCell});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrTableRow1.Weight = 1D;
            // 
            // projectNameCell
            // 
            this.projectNameCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.projectNameCell.Name = "projectNameCell";
            this.projectNameCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.projectNameCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.projectNameCell, "projectNameCell");
            this.projectNameCell.Weight = 0.26474349639125722D;
            // 
            // customerNameCell
            // 
            this.customerNameCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.customerNameCell.Name = "customerNameCell";
            this.customerNameCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.customerNameCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.customerNameCell, "customerNameCell");
            this.customerNameCell.Weight = 0.13846162773770068D;
            // 
            // latestFeadbackCell
            // 
            this.latestFeadbackCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.latestFeadbackCell.Name = "latestFeadbackCell";
            this.latestFeadbackCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
            this.latestFeadbackCell.StylePriority.UseBorders = false;
            this.latestFeadbackCell.StylePriority.UsePadding = false;
            this.latestFeadbackCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.latestFeadbackCell, "latestFeadbackCell");
            this.latestFeadbackCell.Weight = 0.1278845652242411D;
            // 
            // estimatedEndDateCell
            // 
            this.estimatedEndDateCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.estimatedEndDateCell.Name = "estimatedEndDateCell";
            this.estimatedEndDateCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
            this.estimatedEndDateCell.StylePriority.UseBorders = false;
            this.estimatedEndDateCell.StylePriority.UsePadding = false;
            this.estimatedEndDateCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.estimatedEndDateCell, "estimatedEndDateCell");
            this.estimatedEndDateCell.Weight = 0.12435875481957985D;
            // 
            // actualStartDateCell
            // 
            this.actualStartDateCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.actualStartDateCell.Name = "actualStartDateCell";
            this.actualStartDateCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
            this.actualStartDateCell.StylePriority.UseBorders = false;
            this.actualStartDateCell.StylePriority.UsePadding = false;
            this.actualStartDateCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.actualStartDateCell, "actualStartDateCell");
            this.actualStartDateCell.Weight = 0.13750028803278325D;
            // 
            // totalQuoteWorkHoursCell
            // 
            this.totalQuoteWorkHoursCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.totalQuoteWorkHoursCell.Name = "totalQuoteWorkHoursCell";
            this.totalQuoteWorkHoursCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
            this.totalQuoteWorkHoursCell.StylePriority.UseBorders = false;
            this.totalQuoteWorkHoursCell.StylePriority.UsePadding = false;
            this.totalQuoteWorkHoursCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.totalQuoteWorkHoursCell, "totalQuoteWorkHoursCell");
            this.totalQuoteWorkHoursCell.Weight = 0.071153723321653123D;
            // 
            // totalActualWorkHoursCell
            // 
            this.totalActualWorkHoursCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.totalActualWorkHoursCell.Name = "totalActualWorkHoursCell";
            this.totalActualWorkHoursCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
            this.totalActualWorkHoursCell.StylePriority.UseBorders = false;
            this.totalActualWorkHoursCell.StylePriority.UsePadding = false;
            this.totalActualWorkHoursCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.totalActualWorkHoursCell, "totalActualWorkHoursCell");
            this.totalActualWorkHoursCell.Weight = 0.0682691100474965D;
            // 
            // TotalActualInputCell
            // 
            this.TotalActualInputCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.TotalActualInputCell.Name = "TotalActualInputCell";
            this.TotalActualInputCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
            this.TotalActualInputCell.StylePriority.UseBorders = false;
            this.TotalActualInputCell.StylePriority.UsePadding = false;
            this.TotalActualInputCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.TotalActualInputCell, "TotalActualInputCell");
            this.TotalActualInputCell.Weight = 0.0881408353190597D;
            // 
            // TotalEffortCell
            // 
            this.TotalEffortCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.TotalEffortCell.Name = "TotalEffortCell";
            this.TotalEffortCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
            this.TotalEffortCell.StylePriority.UseBorders = false;
            this.TotalEffortCell.StylePriority.UsePadding = false;
            this.TotalEffortCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.TotalEffortCell, "TotalEffortCell");
            this.TotalEffortCell.Weight = 0.061698725675675553D;
            // 
            // totalRemainderTimeCell
            // 
            this.totalRemainderTimeCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.totalRemainderTimeCell.Name = "totalRemainderTimeCell";
            this.totalRemainderTimeCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
            this.totalRemainderTimeCell.StylePriority.UseBorders = false;
            this.totalRemainderTimeCell.StylePriority.UsePadding = false;
            this.totalRemainderTimeCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.totalRemainderTimeCell, "totalRemainderTimeCell");
            this.totalRemainderTimeCell.Weight = 0.06570502505898769D;
            // 
            // TotalEvaluateExactlyRateCell
            // 
            this.TotalEvaluateExactlyRateCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.TotalEvaluateExactlyRateCell.Name = "TotalEvaluateExactlyRateCell";
            this.TotalEvaluateExactlyRateCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
            this.TotalEvaluateExactlyRateCell.StylePriority.UseBorders = false;
            this.TotalEvaluateExactlyRateCell.StylePriority.UsePadding = false;
            this.TotalEvaluateExactlyRateCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.TotalEvaluateExactlyRateCell, "TotalEvaluateExactlyRateCell");
            this.TotalEvaluateExactlyRateCell.Weight = 0.07411857734980401D;
            // 
            // TotalInputEffortRateCell
            // 
            this.TotalInputEffortRateCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.TotalInputEffortRateCell.Name = "TotalInputEffortRateCell";
            this.TotalInputEffortRateCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
            this.TotalInputEffortRateCell.StylePriority.UseBorders = false;
            this.TotalInputEffortRateCell.StylePriority.UsePadding = false;
            this.TotalInputEffortRateCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.TotalInputEffortRateCell, "TotalInputEffortRateCell");
            this.TotalInputEffortRateCell.Weight = 0.082131410484341222D;
            // 
            // WeekQuoteWorkHoursCell
            // 
            this.WeekQuoteWorkHoursCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.WeekQuoteWorkHoursCell.Name = "WeekQuoteWorkHoursCell";
            this.WeekQuoteWorkHoursCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
            this.WeekQuoteWorkHoursCell.StylePriority.UseBorders = false;
            this.WeekQuoteWorkHoursCell.StylePriority.UsePadding = false;
            this.WeekQuoteWorkHoursCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.WeekQuoteWorkHoursCell, "WeekQuoteWorkHoursCell");
            this.WeekQuoteWorkHoursCell.Weight = 0.074519202542111668D;
            // 
            // WeekActualWorkHoursCell
            // 
            this.WeekActualWorkHoursCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.WeekActualWorkHoursCell.Name = "WeekActualWorkHoursCell";
            this.WeekActualWorkHoursCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
            this.WeekActualWorkHoursCell.StylePriority.UseBorders = false;
            this.WeekActualWorkHoursCell.StylePriority.UsePadding = false;
            this.WeekActualWorkHoursCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.WeekActualWorkHoursCell, "WeekActualWorkHoursCell");
            this.WeekActualWorkHoursCell.Weight = 0.079326904770339185D;
            // 
            // weekActualInputCell
            // 
            this.weekActualInputCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.weekActualInputCell.Name = "weekActualInputCell";
            this.weekActualInputCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
            this.weekActualInputCell.StylePriority.UseBorders = false;
            this.weekActualInputCell.StylePriority.UsePadding = false;
            this.weekActualInputCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.weekActualInputCell, "weekActualInputCell");
            this.weekActualInputCell.Weight = 0.073718236548699384D;
            // 
            // weekEffortCell
            // 
            this.weekEffortCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.weekEffortCell.Name = "weekEffortCell";
            this.weekEffortCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
            this.weekEffortCell.StylePriority.UseBorders = false;
            this.weekEffortCell.StylePriority.UsePadding = false;
            this.weekEffortCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.weekEffortCell, "weekEffortCell");
            this.weekEffortCell.Weight = 0.060432573419185572D;
            // 
            // WeekRemainderTimeCell
            // 
            this.WeekRemainderTimeCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.WeekRemainderTimeCell.Name = "WeekRemainderTimeCell";
            this.WeekRemainderTimeCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
            this.WeekRemainderTimeCell.StylePriority.UseBorders = false;
            this.WeekRemainderTimeCell.StylePriority.UsePadding = false;
            this.WeekRemainderTimeCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.WeekRemainderTimeCell, "WeekRemainderTimeCell");
            this.WeekRemainderTimeCell.Weight = 0.0684453596036203D;
            // 
            // EvaluateExactlyRateCell
            // 
            this.EvaluateExactlyRateCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.EvaluateExactlyRateCell.Name = "EvaluateExactlyRateCell";
            this.EvaluateExactlyRateCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
            this.EvaluateExactlyRateCell.StylePriority.UseBorders = false;
            this.EvaluateExactlyRateCell.StylePriority.UsePadding = false;
            this.EvaluateExactlyRateCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.EvaluateExactlyRateCell, "EvaluateExactlyRateCell");
            this.EvaluateExactlyRateCell.Weight = 0.062035172739622932D;
            // 
            // InputEffortRateCell
            // 
            this.InputEffortRateCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.InputEffortRateCell.Name = "InputEffortRateCell";
            this.InputEffortRateCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
            this.InputEffortRateCell.StylePriority.UseBorders = false;
            this.InputEffortRateCell.StylePriority.UsePadding = false;
            this.InputEffortRateCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.InputEffortRateCell, "InputEffortRateCell");
            this.InputEffortRateCell.Weight = 0.060432660105333422D;
            // 
            // xrTable2
            // 
            resources.ApplyResources(this.xrTable2, "xrTable2");
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            // 
            // xrTableRow3
            // 
            resources.ApplyResources(this.xrTableRow3, "xrTableRow3");
            this.xrTableRow3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell2,
            this.xrTableCell5,
            this.qualityCell});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.StylePriority.UseBorders = false;
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell2.BorderWidth = 0;
            resources.ApplyResources(this.xrTableCell2, "xrTableCell2");
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Weight = 1.7208312266638601D;
            // 
            // xrTableCell5
            // 
            resources.ApplyResources(this.xrTableCell5, "xrTableCell5");
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell5.StylePriority.UseBorderColor = false;
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.Weight = 0.9000006816858841D;
            // 
            // qualityCell
            // 
            resources.ApplyResources(this.qualityCell, "qualityCell");
            this.qualityCell.Name = "qualityCell";
            this.qualityCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.qualityCell.StylePriority.UseBorderColor = false;
            this.qualityCell.Weight = 8.96911098053278D;
            // 
            // xrTable3
            // 
            resources.ApplyResources(this.xrTable3, "xrTable3");
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell6,
            this.xrTableCell11,
            this.objectiveCell});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.StylePriority.UseBorders = false;
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell6.BorderWidth = 0;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Weight = 1.720830311136786D;
            // 
            // xrTableCell11
            // 
            resources.ApplyResources(this.xrTableCell11, "xrTableCell11");
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell11.StylePriority.UseBorderColor = false;
            this.xrTableCell11.StylePriority.UseFont = false;
            this.xrTableCell11.Weight = 0.90000037686349321D;
            // 
            // objectiveCell
            // 
            resources.ApplyResources(this.objectiveCell, "objectiveCell");
            this.objectiveCell.Name = "objectiveCell";
            this.objectiveCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.objectiveCell.StylePriority.UseBorderColor = false;
            this.objectiveCell.Weight = 8.969161023670388D;
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
            this.xrTable6,
            this.headerTable});
            resources.ApplyResources(this.PageHeader, "PageHeader");
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable6
            // 
            resources.ApplyResources(this.xrTable6, "xrTable6");
            this.xrTable6.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable6.KeepTogether = true;
            this.xrTable6.Name = "xrTable6";
            this.xrTable6.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
            // 
            // xrTableRow6
            // 
            resources.ApplyResources(this.xrTableRow6, "xrTableRow6");
            this.xrTableRow6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrTableCell12,
            this.xrTableCell28,
            this.xrTableCell13,
            this.xrTableCell18});
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrTableRow6.StylePriority.UseBorders = false;
            this.xrTableRow6.Weight = 0.33391304347826084D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            resources.ApplyResources(this.xrTableCell10, "xrTableCell10");
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell10.StyleName = "ProductHeader";
            this.xrTableCell10.StylePriority.UseBorders = false;
            this.xrTableCell10.Weight = 0.79173070784005262D;
            // 
            // xrTableCell12
            // 
            resources.ApplyResources(this.xrTableCell12, "xrTableCell12");
            this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell12.StyleName = "ProductHeader";
            this.xrTableCell12.StylePriority.UseBorders = false;
            this.xrTableCell12.StylePriority.UseTextAlignment = false;
            this.xrTableCell12.Weight = 0.35442214660853294D;
            // 
            // xrTableCell28
            // 
            resources.ApplyResources(this.xrTableCell28, "xrTableCell28");
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.StylePriority.UseBackColor = false;
            this.xrTableCell28.StylePriority.UseBorderColor = false;
            this.xrTableCell28.StylePriority.UseFont = false;
            this.xrTableCell28.StylePriority.UseForeColor = false;
            this.xrTableCell28.StylePriority.UseTextAlignment = false;
            this.xrTableCell28.Weight = 0.15601022064848502D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            resources.ApplyResources(this.xrTableCell13, "xrTableCell13");
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell13.StyleName = "ProductHeader";
            this.xrTableCell13.StylePriority.UseBorders = false;
            this.xrTableCell13.Weight = 0.3558944803669547D;
            // 
            // xrTableCell18
            // 
            resources.ApplyResources(this.xrTableCell18, "xrTableCell18");
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.StylePriority.UseBackColor = false;
            this.xrTableCell18.StylePriority.UseBorderColor = false;
            this.xrTableCell18.StylePriority.UseFont = false;
            this.xrTableCell18.StylePriority.UseForeColor = false;
            this.xrTableCell18.StylePriority.UseTextAlignment = false;
            this.xrTableCell18.Weight = 0.12227990470658885D;
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
            this.xrTableRow17});
            // 
            // xrTableRow17
            // 
            this.xrTableRow17.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableRow17.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell59,
            this.xrTableCell8,
            this.xrTableCell63,
            this.xrTableCell64,
            this.xrTableCell19,
            this.xrTableCell66,
            this.xrTableCell3,
            this.xrTableCell15,
            this.xrTableCell17,
            this.xrTableCell20,
            this.xrTableCell22,
            this.xrTableCell24,
            this.xrTableCell21,
            this.xrTableCell23,
            this.xrTableCell68,
            this.xrTableCell70,
            this.xrTableCell25,
            this.xrTableCell14,
            this.xrTableCell16});
            this.xrTableRow17.Name = "xrTableRow17";
            this.xrTableRow17.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrTableRow17.StyleName = "ProductData";
            this.xrTableRow17.StylePriority.UseBorders = false;
            resources.ApplyResources(this.xrTableRow17, "xrTableRow17");
            this.xrTableRow17.Weight = 0.55652173913043479D;
            // 
            // xrTableCell59
            // 
            this.xrTableCell59.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            resources.ApplyResources(this.xrTableCell59, "xrTableCell59");
            this.xrTableCell59.Name = "xrTableCell59";
            this.xrTableCell59.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell59.StylePriority.UseBorders = false;
            this.xrTableCell59.Weight = 0.2643368728332206D;
            // 
            // xrTableCell8
            // 
            resources.ApplyResources(this.xrTableCell8, "xrTableCell8");
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseFont = false;
            this.xrTableCell8.Weight = 0.13824898028884863D;
            // 
            // xrTableCell63
            // 
            resources.ApplyResources(this.xrTableCell63, "xrTableCell63");
            this.xrTableCell63.Name = "xrTableCell63";
            this.xrTableCell63.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell63.StylePriority.UseFont = false;
            this.xrTableCell63.Weight = 0.12768813286379382D;
            // 
            // xrTableCell64
            // 
            resources.ApplyResources(this.xrTableCell64, "xrTableCell64");
            this.xrTableCell64.Name = "xrTableCell64";
            this.xrTableCell64.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell64.StylePriority.UseFont = false;
            this.xrTableCell64.Weight = 0.12416773676654785D;
            // 
            // xrTableCell19
            // 
            resources.ApplyResources(this.xrTableCell19, "xrTableCell19");
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.StylePriority.UseFont = false;
            this.xrTableCell19.StylePriority.UseTextAlignment = false;
            this.xrTableCell19.Weight = 0.13728906712413422D;
            // 
            // xrTableCell66
            // 
            resources.ApplyResources(this.xrTableCell66, "xrTableCell66");
            this.xrTableCell66.Name = "xrTableCell66";
            this.xrTableCell66.StylePriority.UseFont = false;
            this.xrTableCell66.Weight = 0.071044340912462312D;
            // 
            // xrTableCell3
            // 
            resources.ApplyResources(this.xrTableCell3, "xrTableCell3");
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Weight = 0.06816434447849222D;
            // 
            // xrTableCell15
            // 
            resources.ApplyResources(this.xrTableCell15, "xrTableCell15");
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.StylePriority.UseFont = false;
            this.xrTableCell15.StylePriority.UseTextAlignment = false;
            this.xrTableCell15.Weight = 0.088005546253588265D;
            // 
            // xrTableCell17
            // 
            resources.ApplyResources(this.xrTableCell17, "xrTableCell17");
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.StylePriority.UseFont = false;
            this.xrTableCell17.StylePriority.UseTextAlignment = false;
            this.xrTableCell17.Weight = 0.061603816709028009D;
            // 
            // xrTableCell20
            // 
            resources.ApplyResources(this.xrTableCell20, "xrTableCell20");
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.StylePriority.UseFont = false;
            this.xrTableCell20.StylePriority.UseTextAlignment = false;
            this.xrTableCell20.Weight = 0.065604102821923735D;
            // 
            // xrTableCell22
            // 
            resources.ApplyResources(this.xrTableCell22, "xrTableCell22");
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.StylePriority.UseFont = false;
            this.xrTableCell22.StylePriority.UseTextAlignment = false;
            this.xrTableCell22.Weight = 0.07400459129430173D;
            // 
            // xrTableCell24
            // 
            resources.ApplyResources(this.xrTableCell24, "xrTableCell24");
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.StylePriority.UseFont = false;
            this.xrTableCell24.StylePriority.UseTextAlignment = false;
            this.xrTableCell24.Weight = 0.08200535117942287D;
            // 
            // xrTableCell21
            // 
            resources.ApplyResources(this.xrTableCell21, "xrTableCell21");
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.StylePriority.UseFont = false;
            this.xrTableCell21.StylePriority.UseTextAlignment = false;
            this.xrTableCell21.Weight = 0.074404835563984487D;
            // 
            // xrTableCell23
            // 
            resources.ApplyResources(this.xrTableCell23, "xrTableCell23");
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StylePriority.UseFont = false;
            this.xrTableCell23.StylePriority.UseTextAlignment = false;
            this.xrTableCell23.Weight = 0.079204860217572018D;
            // 
            // xrTableCell68
            // 
            resources.ApplyResources(this.xrTableCell68, "xrTableCell68");
            this.xrTableCell68.Name = "xrTableCell68";
            this.xrTableCell68.StylePriority.UseFont = false;
            this.xrTableCell68.StylePriority.UseTextAlignment = false;
            this.xrTableCell68.Weight = 0.073604910112975264D;
            // 
            // xrTableCell70
            // 
            resources.ApplyResources(this.xrTableCell70, "xrTableCell70");
            this.xrTableCell70.Name = "xrTableCell70";
            this.xrTableCell70.StylePriority.UseFont = false;
            this.xrTableCell70.StylePriority.UseTextAlignment = false;
            this.xrTableCell70.Weight = 0.060339751968723078D;
            // 
            // xrTableCell25
            // 
            resources.ApplyResources(this.xrTableCell25, "xrTableCell25");
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.StylePriority.UseFont = false;
            this.xrTableCell25.StylePriority.UseTextAlignment = false;
            this.xrTableCell25.Weight = 0.068340418097869227D;
            // 
            // xrTableCell14
            // 
            resources.ApplyResources(this.xrTableCell14, "xrTableCell14");
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.StylePriority.UseFont = false;
            this.xrTableCell14.StylePriority.UseTextAlignment = false;
            this.xrTableCell14.Weight = 0.061939884918299215D;
            // 
            // xrTableCell16
            // 
            resources.ApplyResources(this.xrTableCell16, "xrTableCell16");
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.StylePriority.UseFont = false;
            this.xrTableCell16.StylePriority.UseTextAlignment = false;
            this.xrTableCell16.Weight = 0.060339915765426293D;
            // 
            // ProjectReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.BottomMargin,
            this.ReportHeader1,
            this.topMarginBand1,
            this.PageHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(5, 5, 0, 25);
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
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRTable headerTable;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow17;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell63;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell64;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell66;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell68;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell70;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell customerNameCell;
        private DevExpress.XtraReports.UI.XRTableCell latestFeadbackCell;
        private DevExpress.XtraReports.UI.XRTableCell estimatedEndDateCell;
        private DevExpress.XtraReports.UI.XRTableCell totalQuoteWorkHoursCell;
        private DevExpress.XtraReports.UI.XRTableCell weekActualInputCell;
        private DevExpress.XtraReports.UI.XRTableCell weekEffortCell;
        private DevExpress.XtraReports.UI.XRTableCell projectNameCell;
        private DevExpress.XtraReports.UI.XRTable xrTable4;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableCell projectStatusCell;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell qualityCell;
        private DevExpress.XtraReports.UI.XRTable xrTable3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell11;
        private DevExpress.XtraReports.UI.XRTableCell objectiveCell;
        private DevExpress.XtraReports.UI.XRTable xrTable5;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell ProjectSummaryInfoCell;
        private DevExpress.XtraReports.UI.XRTableCell actualStartDateCell;
        private DevExpress.XtraReports.UI.XRTableCell totalActualWorkHoursCell;
        private DevExpress.XtraReports.UI.XRTableCell TotalActualInputCell;
        private DevExpress.XtraReports.UI.XRTableCell TotalEffortCell;
        private DevExpress.XtraReports.UI.XRTableCell totalRemainderTimeCell;
        private DevExpress.XtraReports.UI.XRTable xrTable6;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell13;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell19;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell17;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell20;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell18;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell16;
        private DevExpress.XtraReports.UI.XRTableCell EvaluateExactlyRateCell;
        private DevExpress.XtraReports.UI.XRTableCell InputEffortRateCell;
        private DevExpress.XtraReports.UI.XRTableCell WeekActualWorkHoursCell;
        private DevExpress.XtraReports.UI.XRTableCell WeekRemainderTimeCell;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell59;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell23;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell25;
        private DevExpress.XtraReports.UI.XRTableCell WeekQuoteWorkHoursCell;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell21;
        private DevExpress.XtraReports.UI.XRTableCell TotalEvaluateExactlyRateCell;
        private DevExpress.XtraReports.UI.XRTableCell TotalInputEffortRateCell;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell28;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell22;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell24;
    }
}
