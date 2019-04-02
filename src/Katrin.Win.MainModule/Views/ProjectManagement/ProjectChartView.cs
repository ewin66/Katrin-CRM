using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.Common.Core;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using System.Collections;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using Microsoft.Practices.ObjectBuilder;
using DevExpress.XtraCharts;
using Katrin.Win.Common.Controls;
using DevExpress.XtraGauges.Core.Model;
using DevExpress.XtraGauges.Core.Base;
using DevExpress.XtraEditors.Controls;
using Katrin.Win.Infrastructure;
using DevExpress.XtraEditors;

namespace Katrin.Win.MainModule.Views.ProjectManagement
{
    public partial class ProjectChartView : Katrin.Win.Common.Core.View, IProjectChartView
    {
        private ProjectChartPresenter _presenter;
        public event EventHandler<EventArgs<Guid>> OnIterationChange;

        public ProjectChartView()
        {
            InitializeComponent();
        }

        [CreateNew]
        public ProjectChartPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        protected override void OnContextChanged(EventArgs e)
        {
            base.OnContextChanged(e);
            BindProjects();
        }

        private void InitLookUpControl(string displayName, string valueName, object dataSource, LookUpEdit lookUpControl)
        {
            lookUpControl.Properties.DisplayMember = displayName;
            lookUpControl.Properties.ValueMember = valueName;
            lookUpControl.Properties.DataSource = dataSource;
            lookUpControl.Properties.NullText = string.Empty;
            lookUpControl.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            lookUpControl.Properties.ShowFooter = false;
            lookUpControl.Properties.AllowNullInput = DefaultBoolean.True;
            lookUpControl.Properties.Columns.Clear();
            lookUpControl.Properties.Columns.Add(new LookUpColumnInfo(lookUpControl.Properties.DisplayMember));
            lookUpControl.Properties.ShowHeader = false;
        }

        private void BindProjects()
        {
            InitLookUpControl("Name", "ProjectId", Context.BindingSource, projectNameLookUp);
        }

        protected override void BindData()
        {
            base.BindData();
        }

        #region summary data
        public void BindSummaryData(object dataSource, List<ProjectSummary> statisticNumberList)
        {
            EntityBindingSource.DataSource = dataSource;
            StatisticNumberBindingSource.DataSource = statisticNumberList;
            if (saleServiceName.DataBindings.Count <= 0)
                saleServiceName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "SaleService.FullName", true));
            if (ManagerName.DataBindings.Count <= 0)
                ManagerName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Manager.FullName", true));
            if (EntityBindingSource.Current == null) return;
            var project = EntityBindingSource.Current.AsDyanmic();
            DateTime beginDate = project.ActualStartDate == null ? DateTime.Today : project.ActualStartDate;
            DateTime endDate = project.PlannedEndDate == null ? DateTime.Today : project.PlannedEndDate;
            DateTime actualEndDate = project.ActualEndDate == null ? DateTime.Today : project.ActualEndDate;
            DateTime currentDate = DateTime.Today;
            TimeSpan span = endDate - beginDate;
            if (actualEndDate > endDate)
                span = actualEndDate - beginDate;
            TimeSpan currentSpan = currentDate - beginDate;

            DateLinearScale.MaxValue = span.Days;
            DateLinearScale.Value = currentSpan.Days;
            DateGauge.Labels[0].Text = "S:" + beginDate.ToShortDateString();//Properties.Resources.BeginDate
            DateGauge.Labels[1].Text = "E:" + endDate.ToShortDateString(); //Properties.Resources.EndDate
            DateGauge.Labels[3].Text = "A:" + actualEndDate.ToShortDateString();
            if (currentSpan.Days <= span.Days)
                DateGauge.Labels[2].Text = "C:" + currentDate.ToShortDateString();//Properties.Resources.CurrentDate
            else
                DateGauge.Labels[2].Text = string.Empty;
            float positionX = 250;
            if (DateLinearScale.MaxValue > 0)
            {
                float cX = (positionX - DateGauge.Labels[0].Position.X) * (currentSpan.Days / DateLinearScale.MaxValue);
                float eX = (positionX - DateGauge.Labels[0].Position.X) * ((endDate - beginDate).Days / DateLinearScale.MaxValue);
                float aX = (positionX - DateGauge.Labels[0].Position.X) * ((actualEndDate - beginDate).Days / DateLinearScale.MaxValue);
                DateGauge.Labels[1].Position = new PointF2D(eX, DateGauge.Labels[0].Position.Y);
                DateGauge.Labels[2].Position = new PointF2D(cX, DateGauge.Labels[2].Position.Y);
                DateGauge.Labels[3].Position = new PointF2D(aX, DateGauge.Labels[0].Position.Y);
                if (DateGauge.Labels[1].Position.X - DateGauge.Labels[0].Position.X < 40)
                {
                    DateGauge.Labels[1].Position = new PointF2D(eX, DateGauge.Labels[0].Position.Y - 10);
                }
                if (DateGauge.Labels[3].Position.X - DateGauge.Labels[0].Position.X < 40)
                {
                    DateGauge.Labels[3].Position = new PointF2D(aX, DateGauge.Labels[0].Position.Y - 10);
                }
                if (DateGauge.Labels[3].Position.X - DateGauge.Labels[1].Position.X < 40)
                {
                    DateGauge.Labels[3].Position = new PointF2D(aX, DateGauge.Labels[1].Position.Y - 10);
                }
            }

            DateLinearScale.Ranges.Clear();
            string[] rangeColor = { "Green", "Red" };//"GreenYellow", "Yellow",
            for (int rangeIndex = 0; rangeIndex < rangeColor.Length; rangeIndex++)
            {
                LinearScaleRange range = new LinearScaleRange();
                range.ShapeOffset = -5;
                if (actualEndDate > endDate)
                {
                    range.EndValue = rangeIndex == 0 ? (endDate - beginDate).Days : (actualEndDate - beginDate).Days;
                    range.StartValue = rangeIndex == 0 ? 0 : (endDate - beginDate).Days;
                }
                else
                {
                    range.EndValue = rangeIndex == 0 ? (actualEndDate - beginDate).Days : (endDate - beginDate).Days;
                    range.StartValue = rangeIndex == 0 ? 0 : (actualEndDate - beginDate).Days;
                }
                range.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:" + rangeColor[rangeIndex]);
                DateLinearScale.Ranges.Add(range);
            }

            // 
            if (statisticNumberList.Count <= 0) return;
            float evaluateExactlyRate = (float)statisticNumberList[0].SumEvaluateExactlyRate * 100;
            arcEvaluateExactlyRate.Ranges[3].EndValue = 100;
            arcEvaluateExactlyRate.Ranges[4].StartValue = 0;
            arcEvaluateExactlyRate.Ranges[4].EndValue = 0;
            arcEvaluateExactlyRate.Ranges[5].StartValue = 0;
            arcEvaluateExactlyRate.Ranges[5].EndValue = 0;
            if (evaluateExactlyRate > 100)
            {
                circularGaugeEvaluateExactlyRate.Scales[0].MaxValue = evaluateExactlyRate > 150 ? 150 : evaluateExactlyRate;
                if (evaluateExactlyRate <= 110)
                    arcEvaluateExactlyRate.Ranges[3].EndValue = evaluateExactlyRate;
                else
                {
                    arcEvaluateExactlyRate.Ranges[3].EndValue = 110;
                    arcEvaluateExactlyRate.Ranges[4].StartValue = 110;
                    if (evaluateExactlyRate > 110 && evaluateExactlyRate <= 130)
                        arcEvaluateExactlyRate.Ranges[4].EndValue = evaluateExactlyRate;
                    else
                    {
                        arcEvaluateExactlyRate.Ranges[4].EndValue = 130;
                        arcEvaluateExactlyRate.Ranges[5].StartValue = 130;
                    }
                    if (evaluateExactlyRate > 130 && evaluateExactlyRate <= 150)
                        arcEvaluateExactlyRate.Ranges[5].EndValue = evaluateExactlyRate;
                }
            }
            else
                circularGaugeEvaluateExactlyRate.Scales[0].MaxValue = 100;

            circularGaugeEvaluateExactlyRate.Scales[0].Value = evaluateExactlyRate;
            circularGaugeEvaluateExactlyRate.Scales[1].MaxValue = (float)statisticNumberList[0].SumActualWorkHours;

            float inputEffortRate = (float)statisticNumberList[0].SumInputEffortRate * 100;
            arcInputEffortRate.Ranges[3].EndValue = 100;
            arcInputEffortRate.Ranges[4].StartValue = 0;
            arcInputEffortRate.Ranges[4].EndValue = 0;
            arcInputEffortRate.Ranges[5].StartValue = 0;
            arcInputEffortRate.Ranges[5].EndValue = 0;
            if (inputEffortRate > 100)
            {
                circularGaugeInputEffortRate.Scales[0].MaxValue = inputEffortRate > 150 ? 150 : inputEffortRate;
                if (inputEffortRate <= 110)
                    arcInputEffortRate.Ranges[3].EndValue = inputEffortRate;
                else
                {
                    arcInputEffortRate.Ranges[3].EndValue = 110;
                    arcInputEffortRate.Ranges[4].StartValue = 110;
                    if (inputEffortRate > 110 && inputEffortRate <= 130)
                        arcInputEffortRate.Ranges[4].EndValue = inputEffortRate;
                    else
                    {
                        arcInputEffortRate.Ranges[4].EndValue = 130;
                        arcInputEffortRate.Ranges[5].StartValue = 130;
                    }
                    if (inputEffortRate > 130 && inputEffortRate <= 150)
                        arcInputEffortRate.Ranges[5].EndValue = inputEffortRate;
                }
            }
            else
                circularGaugeInputEffortRate.Scales[0].MaxValue = 100;
            circularGaugeInputEffortRate.Scales[0].Value = inputEffortRate;
            circularGaugeInputEffortRate.Scales[1].MaxValue = (float)statisticNumberList[0].SumActualInput;
        }
        #endregion

        #region iteration
        public void BindIterationGrid(List<ProjectSummary> dataSource)
        {
            IterationBindingSource.DataSource = dataSource;
            BindIterationChart(dataSource);
            InitLookUpControl("NameAndDate", "Id", dataSource, IterationLookUp);
            RemainderTimeBurndown.Series.Clear();
            if (dataSource.Count > 0)
            {
                IterationLookUp.EditValue = dataSource.First().Id;
                BindIterationBurnDown(dataSource.First().Id);
            }
        }

        private void BindIterationBurnDown(Guid iterationId)
        {
            if (OnIterationChange != null)
                OnIterationChange(this, new EventArgs<Guid>(iterationId));
        }

        public bool IsEliminateWeekend()
        {
            return eliminateWeekendCheckEdit.Checked;
        }

        public void BindBurnDownData(List<BurnDownData> dataSource)
        {
            RemainderTimeBurndown.Series.Clear();
            Series ideaRemainTimelLine = CreateLineSeries(Properties.Resources.IdealRemainTime, NumericFormat.Number);
            Series remainTimeLine = CreateLineSeries(Properties.Resources.ToDoRemainTime, NumericFormat.Number);
            ideaRemainTimelLine.ArgumentScaleType = ScaleType.Qualitative;
            remainTimeLine.ArgumentScaleType = ScaleType.Qualitative;
            foreach (var item in dataSource)
            {
                SeriesPoint idealPoint = new SeriesPoint(item.currentDate.ToShortDateString(), new object[] { ((object)(item.IdealRemainderTime)) });
                ideaRemainTimelLine.Points.Add(idealPoint);

                if (item.currentDate <= DateTime.Today)
                {
                    SeriesPoint remainPoint = new SeriesPoint(item.currentDate.ToShortDateString(), new object[] { ((object)(item.RemainderTime)) });
                    remainTimeLine.Points.Add(remainPoint);
                }
            }
            RemainderTimeBurndown.Series.Add(ideaRemainTimelLine);
            RemainderTimeBurndown.Series.Add(remainTimeLine);

            XYDiagram diagram = RemainderTimeBurndown.Diagram as XYDiagram;
            if (diagram == null) return;
            diagram.AxisY.Title.Visible = true;
            diagram.AxisY.Title.Text = Properties.Resources.WorkUnit;
            if (diagram.AxisX.Range.MaxValue != null && dataSource.Count > 0 && dataSource[0].currentDate >= DateTime.Parse(diagram.AxisX.Range.MaxValue.ToString()))
            {
                diagram.AxisX.Range.MaxValue = dataSource[0].currentDate.AddDays(1).ToShortDateString();
            }
            if (dataSource.Count > 10)
            {
                diagram.AxisX.Range.MinValue = dataSource[0].currentDate.ToShortDateString();
                diagram.AxisX.Range.MaxValue = dataSource[10].currentDate.ToShortDateString();
                diagram.EnableAxisXScrolling = false;
            }
            else
            {
                diagram.EnableAxisXScrolling = false;
                if (dataSource.Count > 0)
                {
                    diagram.AxisX.Range.MinValue = dataSource[0].currentDate.ToShortDateString();
                    diagram.AxisX.Range.MaxValue = dataSource[dataSource.Count - 1].currentDate.ToShortDateString();
                }
            }
        }

        private Series CreateLineSeries(string seriesName, NumericFormat format)
        {
            LineSeriesView lineView = new LineSeriesView();
            Series lineSeries = new Series();
            lineSeries.Name = seriesName;
            lineSeries.ShowInLegend = true;
            lineSeries.View = lineView;
            lineSeries.Label.PointOptions.ValueNumericOptions.Format = format;
            return lineSeries;
        }

        public void BindScheduler(List<SchedulerData> schedulerDataSource, List<SchedulerResource> resourceDataSource)
        {
            ReSourceBindingSource.DataSource = resourceDataSource;
            SchedulerBindingSource.DataSource = schedulerDataSource;
            if (schedulerDataSource.Count > 0)
                IterationScheduler.Start = schedulerDataSource.Select(c => c.Start).Min();
        }

        public void BindIterationChart(List<ProjectSummary> dataSource)
        {
            IterationChartBar.Series.Clear();
            BarSeriesView effortbarView = new SideBySideBarSeriesView();
            Series effortSeries = new Series();
            effortSeries.Name = Properties.Resources.colSumEffort;
            effortSeries.ShowInLegend = true;
            effortSeries.View = effortbarView;


            Series inputEffortRateSeries = CreateLineSeries(Properties.Resources.colInputEffortRate, NumericFormat.Percent);
            foreach (var item in dataSource)
            {
                SeriesPoint effortSeriesPoint = new SeriesPoint(item.Name, new object[] { ((object)(item.SumEffort)) });
                effortSeries.Points.Add(effortSeriesPoint);

                SeriesPoint inputEffortRateSeriesPoint = new SeriesPoint(item.Name, new object[] { ((object)(item.SumInputEffortRate)) });
                inputEffortRateSeries.Points.Add(inputEffortRateSeriesPoint);
            }
            IterationChartBar.Series.Add(effortSeries);
            IterationChartBar.Series.Add(inputEffortRateSeries);

            XYDiagram diagram = IterationChartBar.Diagram as XYDiagram;
            if (diagram == null) return;
            diagram.AxisY.Title.Visible = true;
            diagram.AxisY.Title.Text = Properties.Resources.WorkUnit;

            if (diagram.SecondaryAxesY.Count <= 0)
            {
                SecondaryAxisY secondAxisY = new SecondaryAxisY();
                diagram.SecondaryAxesY.Add(secondAxisY);
            }
            LineSeriesView inputEffortRateView = inputEffortRateSeries.View as LineSeriesView;
            if (inputEffortRateView != null)
                inputEffortRateView.AxisY = diagram.SecondaryAxesY[0];
        }
        #endregion

        #region member
        public void BindMemberGrid(List<ProjectSummary> dataSource)
        {
            MemberBindingSource.DataSource = dataSource;
            BindMemberChart(dataSource);
        }

        private void InitPieChart(List<ProjectSummary> dataSource, string valueName, ChartControl pieChart)
        {
            // pie chart
            Series pieSeries = new Series();
            pieSeries.ValueScaleType = ScaleType.Numerical;
            pieSeries.LegendPointOptions.PointView = PointView.Argument;
            pieSeries.LegendPointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            PieSeriesView pieView = new PieSeriesView();
            pieView.ExplodedDistancePercentage = 10;
            SeriesTitle title = new SeriesTitle();
            title.Text = Properties.Resources.ResourceManager.GetString(valueName + "Rate");
            pieView.Titles.Add(title);
            pieView.RuntimeExploding = true;
            pieSeries.View = pieView;

            foreach (var item in dataSource)
            {
                SeriesPoint seriesPoint = new SeriesPoint(item.Name, new object[] { ((object)(item.GetType().GetProperty(valueName).GetValue(item, null))) });
                pieSeries.Points.Add(seriesPoint);
            }
            pieChart.Series.Add(pieSeries);


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

        public void BindMemberChart(List<ProjectSummary> dataSource)
        {
            MemberActualInputChartPie.Series.Clear();
            InitPieChart(dataSource, "SumEffort", MemberActualInputChartPie);
            InitPieChart(dataSource, "SumActualInput", MemberActualInputChartPie);
        }
        #endregion

        private void MemberActualInputChartPie_CustomDrawSeries(object sender, CustomDrawSeriesEventArgs e)
        {
            if (MemberActualInputChartPie.Series.Count > 0 && MemberActualInputChartPie.Series[0] != e.Series)
            {
                e.LegendText = string.Empty;
                e.Series.ShowInLegend = false;
            }
        }

        private void DateGaugeControl_Resize(object sender, EventArgs e)
        {
            try
            {
                if (ItemForDate.Width - 104 <= 488)
                    DateGauge.Bounds = new Rectangle(4, 4, ItemForDate.Width - 104, 188);
                else
                    DateGauge.Bounds = new Rectangle(4, 4 - (ItemForDate.Width - 592) / 2, ItemForDate.Width - 104, 188 + (ItemForDate.Width - 592));
            }
            catch
            {

            }
        }

        private void projectNameLookUp_EditValueChanged(object sender, EventArgs e)
        {
            var repository = projectNameLookUp.Properties;
            Context.SetCurrentObject(repository.ValueMember, projectNameLookUp.EditValue);
        }

        private void BurnDownSearch_Click(object sender, EventArgs e)
        {
            if (IterationLookUp.EditValue == null) return;
            if (string.IsNullOrEmpty(IterationLookUp.EditValue.ToString())) return;
            BindIterationBurnDown((Guid)IterationLookUp.EditValue);
        }

        private void IterationLookUp_EditValueChanged(object sender, EventArgs e)
        {
            if (IterationLookUp.EditValue == null) return;
            if (string.IsNullOrEmpty(IterationLookUp.EditValue.ToString())) return;
            BindIterationBurnDown((Guid)IterationLookUp.EditValue);
        }

        private void eliminateWeekendCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (IterationLookUp.EditValue == null) return;
            if (string.IsNullOrEmpty(IterationLookUp.EditValue.ToString())) return;
            BindIterationBurnDown((Guid)IterationLookUp.EditValue);
        }
    }
}
