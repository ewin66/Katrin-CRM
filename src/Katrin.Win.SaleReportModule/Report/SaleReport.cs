using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Katrin.AppFramework.Utils;
using DevExpress.XtraCharts;
using System.Collections.Generic;
using System.Linq;
using Katrin.AppFramework.Extensions;
using ICSharpCode.Core;
using DevExpress.XtraPrinting;
using DevExpress.Utils;
using System.Linq.Dynamic;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.Parameters;

namespace Katrin.Win.SaleReportModule.Report
{
    public partial class SaleReport : DevExpress.XtraReports.UI.XtraReport
    {
        public event EventHandler<EventArgs<SaleOverview>> NameCellClicked;
        List<string> cellControl = new List<string>() { "DepartMentName", "SalesName", "TechnologyName", "TechnologyPerson"};
        string[] arrColums = { "LeadNumber", "FirstEmailCount", "ResponseRate", "NumberIntoOpportunity", "RateIntoOpportunity",
                                     "NumberOfTheDead", "ClosureRate","OpportunityNumber","NumberIntoContract","QuoteSuccessRate",
                                 "ContractAmount","ContractNumber","RateOfOldCustomer"};
        bool[] isRate = { false, false, true, false, true, false, true, false, false, true, false, false, true };
        List<float> widths = new List<float>();
        List<double> weights = new List<double>();
        private string targetName = "LeadNumber";
        private int dimsionValue = 0;
        private int chartType = 0;
        private int chartSelectValue = 0;
        double firstWeight = 0;
        private int dimensionCount = 0;
        public SaleReport()
        {
            InitializeComponent();
           
        }


        protected string GetLocalizedCaption(string name)
        {
            return ResourceService.GetString(name);
        }

        public void DimensionItemChange(ArrayList dimensions)
        {
            if (dimensions == null) return;
            if (widths.Count <= 0)
            {
                for (int p = 0; p < arrColums.Count(); p++)
                {
                    widths.Add(this.FindControl(arrColums[p] + "Cell", false).WidthF);
                    weights.Add(((XRTableCell)this.FindControl(arrColums[p] + "Cell", false)).Weight);
                }
            }
            float width = DimensionCell.WidthF;
            if (firstWeight == 0) firstWeight = UnitNameCell.Weight;
            double weight = firstWeight;
            float avgWidth = width / (dimensions.Count + 1);
            double avgWeight = weight / (dimensions.Count + 1);
            dimensionRow.Cells.Clear();
            dimensionCellRow.Cells.Clear();
            XRTableCell headerCell = new XRTableCell();
            headerCell.Text = GetLocalizedCaption("UnitType");
            headerCell.WidthF = avgWidth;
            headerCell.BackColor = Color.FromArgb(196, 220, 255);
            headerCell.TextAlignment = TextAlignment.MiddleCenter;
            headerCell.Borders = BorderSide.Left | BorderSide.Top;
            headerCell.Weight = avgWeight;
            headerCell.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Bold);
            headerCell.ForeColor = Color.Black;
            headerCell.BorderColor = Color.White;

            
            XRTableCell detailCell = new XRTableCell();
            detailCell.BackColor = Color.FromArgb(255, 237, 196);
            detailCell.BorderColor = Color.FromArgb(232, 205, 162);
            detailCell.Borders = BorderSide.Left | BorderSide.Top;
            detailCell.TextAlignment = TextAlignment.MiddleCenter;
            detailCell.WidthF = avgWidth;
            detailCell.Weight = avgWeight;
            detailCell.DataBindings.Add("Text", null, "UnitName");
            

           
            dimensionRow.Cells.Add(headerCell);
            dimensionCellRow.Cells.Add(detailCell);

            bool resetDemenIndex = true;
            dimensionCount = dimensions.Count;
            if (dimensions.Count > 1)
            {
                PageHeader.Visible = true;
                Detail.Visible = true;
                ReportFooter.Visible = false;
            }
            else
                SelectChart(chartSelectValue);

            foreach (var item in dimensions)
            {
                LookupListItem<int?> lookup = (LookupListItem<int?>)item;
                headerCell = new XRTableCell();
                headerCell.Text = lookup.DisplayName;
                headerCell.WidthF = avgWidth;
                detailCell = new XRTableCell();
                detailCell.DataBindings.Add("Text", null, ((Dimension)lookup.Value).ToString());
                detailCell.WidthF = avgWidth;
                if (lookup.Value == dimsionValue) resetDemenIndex = false;

                headerCell.Borders = BorderSide.Left | BorderSide.Top;
                headerCell.BackColor = Color.FromArgb(196, 220, 255);
                headerCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                headerCell.Weight = avgWeight;
                headerCell.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Bold);
                headerCell.ForeColor = Color.Black;
                headerCell.BorderColor = Color.White;

                detailCell.BackColor = Color.FromArgb(255, 237, 196);
                detailCell.BorderColor = Color.FromArgb(232, 205, 162);
                detailCell.Borders = BorderSide.Left | BorderSide.Top;
                detailCell.TextAlignment = TextAlignment.MiddleCenter;
                detailCell.Weight = avgWeight;

                dimensionRow.Cells.Add(headerCell);
                dimensionCellRow.Cells.Add(detailCell);
            }

            if (resetDemenIndex)
                dimsionValue = 0;

            for (int i = 0; i < arrColums.Count(); i++)
            {
                headerCell = new XRTableCell();
                headerCell.Text = GetLocalizedCaption(arrColums[i]);
                headerCell.WidthF = widths[i];
                headerCell.Weight = weights[i];
                detailCell = new XRTableCell();
                if (isRate[i])
                {
                    detailCell.DataBindings.Add("Text", null, arrColums[i], "{0:0.00%}");
                }
                else
                {
                    detailCell.DataBindings.Add("Text", null, arrColums[i]);
                }
                detailCell.Name = arrColums[i] + "Cell";
                detailCell.WidthF = widths[i];
                detailCell.Weight = weights[i];
                
                headerCell.Borders = BorderSide.Left | BorderSide.Top;
                headerCell.BackColor = Color.FromArgb(196, 220, 255);
                headerCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                headerCell.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Bold);
                headerCell.ForeColor = Color.Black;
                headerCell.BorderColor = Color.White;

                detailCell.BackColor = Color.FromArgb(255, 237, 196);
                detailCell.BorderColor = Color.FromArgb(232, 205, 162);
                detailCell.Borders = BorderSide.Left | BorderSide.Top;
                detailCell.TextAlignment = TextAlignment.MiddleCenter;

                dimensionRow.Cells.Add(headerCell);
                dimensionCellRow.Cells.Add(detailCell);
            }
        }

        private void BindChart()
        {
            string dimensionName = string.Empty;
            if(dimsionValue > 0)
                dimensionName = ((Dimension)dimsionValue).ToString();
            xrChart1.Series.Clear();
            if (dimsionValue <= 0 && chartType == 0)
            {
                Series pieSeries = new Series();
                pieSeries.ValueScaleType = ScaleType.Numerical;
                pieSeries.LegendPointOptions.PointView = PointView.Argument;
                pieSeries.LegendPointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                PieSeriesView pieView = new PieSeriesView();
                pieView.ExplodedDistancePercentage = 10;
                SeriesTitle title = new SeriesTitle();
                title.Text = GetLocalizedCaption(targetName) +"-" +GetLocalizedCaption("Rate");
                pieView.Titles.Add(title);
                pieView.RuntimeExploding = true;
                pieSeries.View = pieView;

                List<SaleOverview> dataList = (List<SaleOverview>)this.DataSource;
                var resultData = dataList.AsQueryable().GroupBy("UnitName", "it")
                    .Select("new (Key as UnitName,Sum(" + targetName + ") as " + targetName + ")", null);

                foreach (var item in resultData)
                {
                    Type itemType = item.GetType();
                    SeriesPoint seriesPoint = new SeriesPoint(itemType.GetProperty("UnitName").GetValue(item, null)
                        , new object[] { ((object)itemType.GetProperty(targetName).GetValue(item, null)) });
                    pieSeries.Points.Add(seriesPoint);
                }
                xrChart1.Series.Add(pieSeries);

                PieSeriesLabel pieSerieslable = pieSeries.Label as PieSeriesLabel;
                if (pieSerieslable != null)
                {
                    pieSerieslable.PointOptions.PointView = PointView.ArgumentAndValues;
                    pieSerieslable.Position = PieSeriesLabelPosition.TwoColumns;
                    pieSerieslable.TextAlignment = StringAlignment.Center;
                }
                PiePointOptions options = pieSeries.Label.PointOptions as PiePointOptions;
                if (options != null)
                {
                    options.PercentOptions.PercentageAccuracy = 2;
                    options.PercentOptions.ValueAsPercent = true;
                    options.ValueNumericOptions.Format = NumericFormat.Percent;
                }
            }
            else
            {
                
                List<SaleOverview> dataList = (List<SaleOverview>)this.DataSource;
                List<string> demisionList = new List<string>();

                if (!string.IsNullOrEmpty(dimensionName))
                {
                    foreach (var item in dataList)
                    {
                        Type itemType = item.GetType();
                        string demisionName = itemType.GetProperty(dimensionName).GetValue(item, null).ToString();
                        if (!demisionList.Contains(demisionName))
                            demisionList.Add(demisionName);
                    }
                }
                else
                {
                    demisionList.Add(string.Empty);
                }

                for (int d = 0; d < demisionList.Count; d++)
                {
                    IQueryable resultData = null;
                    if (!string.IsNullOrEmpty(dimensionName))
                    {
                        resultData = dataList.AsQueryable().Where(dimensionName + "=@0", demisionList[d]).GroupBy("UnitName", "it")
                       .Select("new (Key as UnitName,Sum(" + targetName + ") as " + targetName + ")", null);
                    }
                    else
                    {
                        resultData = dataList.AsQueryable().GroupBy("UnitName", "it")
                            .Select("new (Key as UnitName,Sum(" + targetName + ") as " + targetName + ")", null);
                    }
                    
                    Series lineSeries = new Series();
                    lineSeries.Name = demisionList[d];
                    lineSeries.ShowInLegend = true;
                    if (chartType == 1)
                    {
                        LineSeriesView lineView = new LineSeriesView();
                        lineSeries.View = lineView;
                    }
                    else if(chartType == 2)
                    {
                        BarSeriesView barView = new SideBySideBarSeriesView();
                        lineSeries.View = barView;
                    }

                    foreach (var item in resultData)
                    {
                        Type itemType = item.GetType();

                        SeriesPoint effortSeriesPoint = new SeriesPoint(itemType.GetProperty("UnitName").GetValue(item, null)
                            , new object[] { ((object)(itemType.GetProperty(targetName).GetValue(item, null))) });
                        lineSeries.Points.Add(effortSeriesPoint);
                    }
                    xrChart1.Series.Add(lineSeries);
                }
                XYDiagram diagram = xrChart1.Diagram as XYDiagram;
                if (diagram == null) return;
                diagram.AxisY.Title.Visible = true;
                if (!string.IsNullOrEmpty(dimensionName))
                {
                    diagram.AxisY.Title.Text = GetLocalizedCaption(dimensionName) + "-" + GetLocalizedCaption(targetName);
                }
                else
                {
                    diagram.AxisY.Title.Text = string.Empty;
                }
            }
        }

        public void SelectChart(int selectValue)
        {
            chartSelectValue = selectValue;
            if (selectValue == 0)
            {
                PageHeader.Visible = true;
                Detail.Visible = true;
                if(dimensionCount <= 1)
                    ReportFooter.Visible = true;
            }
            else if (selectValue == 1)
            {
                PageHeader.Visible = true;
                Detail.Visible = true;
                ReportFooter.Visible = false;
            }
            else if(dimensionCount <= 1)
            {
                PageHeader.Visible = false;
                Detail.Visible = false;
                ReportFooter.Visible = true;
            }
            this.CreateDocument(true);
        }

        public void ChangeChart(string stargetName,int dimsionIndex,int chartType)
        {
            targetName = stargetName;
            dimsionValue = dimsionIndex;
            this.chartType = chartType;
            this.CreateDocument(true);
        }

        private void xrChart1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            BindChart();
        }

        private void headerTable_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }
    }
}
