using System;
namespace Katrin.Win.ProjectModule.Chart
{
    partial class ProjectChartView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            //if (RemoveListener != null)
            //    RemoveListener(null, null);
            _context.BindingSource.DataSource = null;
            EntityBindingSource.DataSource = null;
            StatisticNumberBindingSource.DataSource = null;
            IterationBindingSource.DataSource = null;
            MemberBindingSource.DataSource = null;
            SchedulerBindingSource.DataSource = null;
            ReSourceBindingSource.DataSource = null;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            GC.Collect();
            //GC.SuppressFinalize(this);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectChartView));
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel1 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PiePointOptions piePointOptions1 = new DevExpress.XtraCharts.PiePointOptions();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange1 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange2 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange3 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange4 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange5 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange6 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange7 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange8 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange9 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange10 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange11 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange12 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel2 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.eliminateWeekendCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.IterationLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.RemainderTimeBurndown = new DevExpress.XtraCharts.ChartControl();
            this.DateGaugeControl = new DevExpress.XtraGauges.Win.GaugeControl();
            this.DateGauge = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearGauge();
            this.labelComponent1 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.labelComponent2 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.labelComponent3 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.labelComponent4 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.linearScaleRangeBarComponent4 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleRangeBarComponent();
            this.DateLinearScale = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent();
            this.resourcesTree1 = new DevExpress.XtraScheduler.UI.ResourcesTree();
            this.colResourceId = new DevExpress.XtraScheduler.Native.ResourceTreeColumn();
            this.colCaption = new DevExpress.XtraScheduler.Native.ResourceTreeColumn();
            this.MemberActualInputChartPie = new DevExpress.XtraCharts.ChartControl();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.circularGaugeInputEffortRate = new DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge();
            this.arcScaleBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent();
            this.arcInputEffortRate = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent();
            this.arcScaleNeedleComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent();
            this.arcScaleComponent4 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent();
            this.gaugeControl2 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.circularGaugeEvaluateExactlyRate = new DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge();
            this.arcScaleBackgroundLayerComponent2 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent();
            this.arcEvaluateExactlyRate = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent();
            this.arcScaleNeedleComponent2 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent();
            this.arcEvaluateExactltyRate = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent();
            this.IterationChartBar = new DevExpress.XtraCharts.ChartControl();
            this.textEdit10 = new DevExpress.XtraEditors.TextEdit();
            this.EntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ManagerName = new DevExpress.XtraEditors.TextEdit();
            this.saleServiceName = new DevExpress.XtraEditors.TextEdit();
            this.textEdit6 = new DevExpress.XtraEditors.TextEdit();
            this.StatisticNumberBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textEdit5 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.MemberBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ProjectMember = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MemberQuoteWorkHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MemberActualWorkHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MemberActualInput = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MemberEffort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MemberEvaluateExactlyRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MemberInputEffortRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.IterationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IterationName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QuoteWorkHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ActualWorkHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ActualInput = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Effort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EvaluateExactlyRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.InputEffortRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.projectNameLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.iterationGridGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.IterationPieChartGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.IterationBarChart = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.IterationBurndown = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIterationList = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.tabbedControlGroup2 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.PersonGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.MemberActualInputGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.projectSummaryGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForSumEffort = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSale = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEvaluateExactlyRate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForInputEffortRate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForManager = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSumQuoteWorkHours = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSumActualWorkHours = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSumOvertime = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem4 = new DevExpress.XtraLayout.SplitterItem();
            this.ItemForDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem3 = new DevExpress.XtraLayout.SplitterItem();
            this.ItemForProjectName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForContact = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSumActualInput = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSumRemainderTime = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.SchedulerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReSourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.linearScaleLevelComponent1 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent();
            this.linearScaleComponent1 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent();
            this.linearScaleBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eliminateWeekendCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IterationLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemainderTimeBurndown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateGauge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleRangeBarComponent4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateLinearScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesTree1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemberActualInputChartPie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularGaugeInputEffortRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcInputEffortRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleComponent4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularGaugeEvaluateExactlyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcEvaluateExactlyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcEvaluateExactltyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IterationChartBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit10.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManagerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleServiceName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatisticNumberBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemberBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IterationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectNameLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationGridGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IterationPieChartGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IterationBarChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IterationBurndown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIterationList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemberActualInputGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectSummaryGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSumEffort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEvaluateExactlyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForInputEffortRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSumQuoteWorkHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSumActualWorkHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSumOvertime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProjectName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSumActualInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSumRemainderTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SchedulerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReSourceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleLevelComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleBackgroundLayerComponent1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.eliminateWeekendCheckEdit);
            this.dataLayoutControl1.Controls.Add(this.IterationLookUp);
            this.dataLayoutControl1.Controls.Add(this.RemainderTimeBurndown);
            this.dataLayoutControl1.Controls.Add(this.DateGaugeControl);
            this.dataLayoutControl1.Controls.Add(this.resourcesTree1);
            this.dataLayoutControl1.Controls.Add(this.MemberActualInputChartPie);
            this.dataLayoutControl1.Controls.Add(this.gaugeControl1);
            this.dataLayoutControl1.Controls.Add(this.gaugeControl2);
            this.dataLayoutControl1.Controls.Add(this.IterationChartBar);
            this.dataLayoutControl1.Controls.Add(this.textEdit10);
            this.dataLayoutControl1.Controls.Add(this.ManagerName);
            this.dataLayoutControl1.Controls.Add(this.saleServiceName);
            this.dataLayoutControl1.Controls.Add(this.textEdit6);
            this.dataLayoutControl1.Controls.Add(this.textEdit5);
            this.dataLayoutControl1.Controls.Add(this.textEdit4);
            this.dataLayoutControl1.Controls.Add(this.textEdit3);
            this.dataLayoutControl1.Controls.Add(this.textEdit2);
            this.dataLayoutControl1.Controls.Add(this.gridControl2);
            this.dataLayoutControl1.Controls.Add(this.gridControl1);
            this.dataLayoutControl1.Controls.Add(this.textEdit1);
            this.dataLayoutControl1.Controls.Add(this.projectNameLookUp);
            resources.ApplyResources(this.dataLayoutControl1, "dataLayoutControl1");
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(295, 323, 448, 642);
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            // 
            // eliminateWeekendCheckEdit
            // 
            resources.ApplyResources(this.eliminateWeekendCheckEdit, "eliminateWeekendCheckEdit");
            this.eliminateWeekendCheckEdit.Name = "eliminateWeekendCheckEdit";
            this.eliminateWeekendCheckEdit.Properties.Caption = resources.GetString("eliminateWeekendCheckEdit.Properties.Caption");
            this.eliminateWeekendCheckEdit.Properties.GlyphAlignment = ((DevExpress.Utils.HorzAlignment)(resources.GetObject("eliminateWeekendCheckEdit.Properties.GlyphAlignment")));
            this.eliminateWeekendCheckEdit.StyleController = this.dataLayoutControl1;
            this.eliminateWeekendCheckEdit.CheckedChanged += new System.EventHandler(this.eliminateWeekendCheckEdit_CheckedChanged);
            // 
            // IterationLookUp
            // 
            resources.ApplyResources(this.IterationLookUp, "IterationLookUp");
            this.IterationLookUp.Name = "IterationLookUp";
            this.IterationLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("IterationLookUp.Properties.Buttons"))))});
            this.IterationLookUp.StyleController = this.dataLayoutControl1;
            this.IterationLookUp.EditValueChanged += new System.EventHandler(this.IterationLookUp_EditValueChanged);
            // 
            // RemainderTimeBurndown
            // 
            resources.ApplyResources(this.RemainderTimeBurndown, "RemainderTimeBurndown");
            this.RemainderTimeBurndown.Name = "RemainderTimeBurndown";
            this.RemainderTimeBurndown.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            pointSeriesLabel1.LineVisible = true;
            this.RemainderTimeBurndown.SeriesTemplate.Label = pointSeriesLabel1;
            this.RemainderTimeBurndown.SeriesTemplate.View = lineSeriesView1;
            // 
            // DateGaugeControl
            // 
            this.DateGaugeControl.AutoLayout = false;
            this.DateGaugeControl.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.DateGauge});
            resources.ApplyResources(this.DateGaugeControl, "DateGaugeControl");
            this.DateGaugeControl.Name = "DateGaugeControl";
            this.DateGaugeControl.Resize += new System.EventHandler(this.DateGaugeControl_Resize);
            // 
            // DateGauge
            // 
            this.DateGauge.AutoSize = DevExpress.Utils.DefaultBoolean.False;
            this.DateGauge.Bounds = new System.Drawing.Rectangle(11, 4, 430, 188);
            this.DateGauge.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.labelComponent1,
            this.labelComponent2,
            this.labelComponent3,
            this.labelComponent4});
            this.DateGauge.Name = "DateGauge";
            this.DateGauge.Orientation = DevExpress.XtraGauges.Core.Model.ScaleOrientation.Horizontal;
            this.DateGauge.RangeBars.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleRangeBarComponent[] {
            this.linearScaleRangeBarComponent4});
            this.DateGauge.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent[] {
            this.DateLinearScale});
            // 
            // labelComponent1
            // 
            this.labelComponent1.AppearanceText.Font = new System.Drawing.Font("Tahoma", 5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelComponent1.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.labelComponent1.Name = "DateGauge_Label1";
            this.labelComponent1.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(0F, 40F);
            resources.ApplyResources(this.labelComponent1, "labelComponent1");
            this.labelComponent1.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;
            this.labelComponent1.ZOrder = -1001;
            // 
            // labelComponent2
            // 
            this.labelComponent2.AppearanceText.Font = new System.Drawing.Font("Tahoma", 5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelComponent2.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.labelComponent2.Name = "DateGauge_Label2";
            this.labelComponent2.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(250F, 40F);
            resources.ApplyResources(this.labelComponent2, "labelComponent2");
            this.labelComponent2.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;
            this.labelComponent2.ZOrder = -1001;
            // 
            // labelComponent3
            // 
            this.labelComponent3.AppearanceText.Font = new System.Drawing.Font("Tahoma", 5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelComponent3.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.labelComponent3.Name = "DateGauge_Label3";
            this.labelComponent3.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(130F, 80F);
            resources.ApplyResources(this.labelComponent3, "labelComponent3");
            this.labelComponent3.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;
            this.labelComponent3.ZOrder = -1001;
            // 
            // labelComponent4
            // 
            this.labelComponent4.AppearanceText.Font = new System.Drawing.Font("Tahoma", 5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelComponent4.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.labelComponent4.Name = "DateGauge_Label4";
            this.labelComponent4.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 40F);
            this.labelComponent4.ZOrder = -1001;
            // 
            // linearScaleRangeBarComponent4
            // 
            this.linearScaleRangeBarComponent4.AppearanceRangeBar.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.linearScaleRangeBarComponent4.EndOffset = 2F;
            this.linearScaleRangeBarComponent4.LinearScale = this.DateLinearScale;
            this.linearScaleRangeBarComponent4.Name = "avgOrderRange";
            this.linearScaleRangeBarComponent4.StartOffset = -2F;
            this.linearScaleRangeBarComponent4.ZOrder = -100;
            // 
            // DateLinearScale
            // 
            this.DateLinearScale.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 6F);
            this.DateLinearScale.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.DateLinearScale.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(50F, 0F);
            this.DateLinearScale.MajorTickCount = 7;
            this.DateLinearScale.MajorTickmark.FormatString = resources.GetString("DateLinearScale.MajorTickmark.FormatString");
            this.DateLinearScale.MajorTickmark.ShapeOffset = 10F;
            this.DateLinearScale.MajorTickmark.ShapeScale = new DevExpress.XtraGauges.Core.Base.FactorF2D(0.65F, 1F);
            this.DateLinearScale.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Default3;
            this.DateLinearScale.MajorTickmark.TextOffset = 22F;
            this.DateLinearScale.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.BottomToTop;
            this.DateLinearScale.MaxValue = 600F;
            this.DateLinearScale.MinorTickCount = 0;
            this.DateLinearScale.Name = "avgOrder";
            this.DateLinearScale.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(50F, 250F);
            this.DateLinearScale.Value = 320F;
            // 
            // resourcesTree1
            // 
            this.resourcesTree1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colResourceId,
            this.colCaption});
            this.resourcesTree1.KeyFieldName = "ResourceId";
            resources.ApplyResources(this.resourcesTree1, "resourcesTree1");
            this.resourcesTree1.Name = "resourcesTree1";
            this.resourcesTree1.ParentFieldName = "ParentId";
            // 
            // colResourceId
            // 
            this.colResourceId.FieldName = "ResourceId";
            this.colResourceId.Name = "colResourceId";
            resources.ApplyResources(this.colResourceId, "colResourceId");
            // 
            // colCaption
            // 
            this.colCaption.FieldName = "Caption";
            this.colCaption.Name = "colCaption";
            resources.ApplyResources(this.colCaption, "colCaption");
            // 
            // MemberActualInputChartPie
            // 
            resources.ApplyResources(this.MemberActualInputChartPie, "MemberActualInputChartPie");
            this.MemberActualInputChartPie.Name = "MemberActualInputChartPie";
            this.MemberActualInputChartPie.PaletteName = "Trek";
            this.MemberActualInputChartPie.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            pieSeriesLabel1.LineVisible = true;
            this.MemberActualInputChartPie.SeriesTemplate.Label = pieSeriesLabel1;
            piePointOptions1.PointView = DevExpress.XtraCharts.PointView.Argument;
            this.MemberActualInputChartPie.SeriesTemplate.LegendPointOptions = piePointOptions1;
            this.MemberActualInputChartPie.SeriesTemplate.SynchronizePointOptions = false;
            pieSeriesView1.RuntimeExploding = false;
            this.MemberActualInputChartPie.SeriesTemplate.View = pieSeriesView1;
            this.MemberActualInputChartPie.CustomDrawSeries += new DevExpress.XtraCharts.CustomDrawSeriesEventHandler(this.MemberActualInputChartPie_CustomDrawSeries);
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.circularGaugeInputEffortRate});
            resources.ApplyResources(this.gaugeControl1, "gaugeControl1");
            this.gaugeControl1.Name = "gaugeControl1";
            // 
            // circularGaugeInputEffortRate
            // 
            this.circularGaugeInputEffortRate.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent[] {
            this.arcScaleBackgroundLayerComponent1});
            this.circularGaugeInputEffortRate.Bounds = new System.Drawing.Rectangle(6, 6, 241, 184);
            this.circularGaugeInputEffortRate.Name = "circularGaugeInputEffortRate";
            this.circularGaugeInputEffortRate.Needles.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent[] {
            this.arcScaleNeedleComponent1});
            this.circularGaugeInputEffortRate.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent[] {
            this.arcInputEffortRate,
            this.arcScaleComponent4});
            // 
            // arcScaleBackgroundLayerComponent1
            // 
            this.arcScaleBackgroundLayerComponent1.ArcScale = this.arcInputEffortRate;
            this.arcScaleBackgroundLayerComponent1.Name = "bg1";
            this.arcScaleBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.CircularFull_Style11;
            this.arcScaleBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // arcInputEffortRate
            // 
            this.arcInputEffortRate.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 12F);
            this.arcInputEffortRate.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.arcInputEffortRate.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 125F);
            this.arcInputEffortRate.EndAngle = 60F;
            this.arcInputEffortRate.MajorTickmark.FormatString = resources.GetString("arcInputEffortRate.MajorTickmark.FormatString");
            this.arcInputEffortRate.MajorTickmark.ShapeOffset = -5F;
            this.arcInputEffortRate.MajorTickmark.ShapeScale = new DevExpress.XtraGauges.Core.Base.FactorF2D(0.6F, 0.8F);
            this.arcInputEffortRate.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style11_4;
            this.arcInputEffortRate.MajorTickmark.TextOffset = -17F;
            this.arcInputEffortRate.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;
            this.arcInputEffortRate.MaxValue = 100F;
            this.arcInputEffortRate.MinorTickCount = 4;
            this.arcInputEffortRate.MinorTickmark.ShapeOffset = -2.5F;
            this.arcInputEffortRate.MinorTickmark.ShapeScale = new DevExpress.XtraGauges.Core.Base.FactorF2D(0.6F, 1F);
            this.arcInputEffortRate.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style11_3;
            this.arcInputEffortRate.Name = "scale1";
            this.arcInputEffortRate.RadiusX = 107F;
            this.arcInputEffortRate.RadiusY = 107F;
            arcScaleRange1.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Red");
            arcScaleRange1.EndValue = 50F;
            arcScaleRange1.Name = "Range0";
            arcScaleRange2.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Yellow");
            arcScaleRange2.EndValue = 70F;
            arcScaleRange2.Name = "Range1";
            arcScaleRange2.StartValue = 50F;
            arcScaleRange3.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:GreenYellow");
            arcScaleRange3.EndValue = 90F;
            arcScaleRange3.Name = "Range2";
            arcScaleRange3.StartValue = 70F;
            arcScaleRange4.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Green");
            arcScaleRange4.EndValue = 110F;
            arcScaleRange4.Name = "Range3";
            arcScaleRange4.StartValue = 90F;
            arcScaleRange5.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:GreenYellow");
            arcScaleRange5.EndValue = 130F;
            arcScaleRange5.Name = "Range4";
            arcScaleRange5.StartValue = 110F;
            arcScaleRange6.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Yellow");
            arcScaleRange6.EndValue = 150F;
            arcScaleRange6.Name = "Range5";
            arcScaleRange6.StartValue = 130F;
            this.arcInputEffortRate.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] {
            arcScaleRange1,
            arcScaleRange2,
            arcScaleRange3,
            arcScaleRange4,
            arcScaleRange5,
            arcScaleRange6});
            this.arcInputEffortRate.StartAngle = -240F;
            // 
            // arcScaleNeedleComponent1
            // 
            this.arcScaleNeedleComponent1.ArcScale = this.arcInputEffortRate;
            this.arcScaleNeedleComponent1.EndOffset = 5F;
            this.arcScaleNeedleComponent1.Name = "needle1";
            this.arcScaleNeedleComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.NeedleShapeType.CircularFull_Style11;
            this.arcScaleNeedleComponent1.StartOffset = -9.5F;
            this.arcScaleNeedleComponent1.ZOrder = -50;
            // 
            // arcScaleComponent4
            // 
            this.arcScaleComponent4.AppearanceTickmarkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.arcScaleComponent4.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.arcScaleComponent4.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 125F);
            this.arcScaleComponent4.EndAngle = 60F;
            this.arcScaleComponent4.MajorTickmark.FormatString = resources.GetString("arcScaleComponent4.MajorTickmark.FormatString");
            this.arcScaleComponent4.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style11_2;
            this.arcScaleComponent4.MajorTickmark.TextOffset = -15F;
            this.arcScaleComponent4.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;
            this.arcScaleComponent4.MaxValue = 700F;
            this.arcScaleComponent4.MinorTickCount = 4;
            this.arcScaleComponent4.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style11_1;
            this.arcScaleComponent4.Name = "scale2";
            this.arcScaleComponent4.RadiusX = 70F;
            this.arcScaleComponent4.RadiusY = 70F;
            this.arcScaleComponent4.StartAngle = -240F;
            this.arcScaleComponent4.ZOrder = -1;
            // 
            // gaugeControl2
            // 
            this.gaugeControl2.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.circularGaugeEvaluateExactlyRate});
            resources.ApplyResources(this.gaugeControl2, "gaugeControl2");
            this.gaugeControl2.Name = "gaugeControl2";
            // 
            // circularGaugeEvaluateExactlyRate
            // 
            this.circularGaugeEvaluateExactlyRate.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent[] {
            this.arcScaleBackgroundLayerComponent2});
            this.circularGaugeEvaluateExactlyRate.Bounds = new System.Drawing.Rectangle(6, 6, 252, 184);
            this.circularGaugeEvaluateExactlyRate.Name = "circularGaugeEvaluateExactlyRate";
            this.circularGaugeEvaluateExactlyRate.Needles.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent[] {
            this.arcScaleNeedleComponent2});
            this.circularGaugeEvaluateExactlyRate.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent[] {
            this.arcEvaluateExactlyRate,
            this.arcEvaluateExactltyRate});
            // 
            // arcScaleBackgroundLayerComponent2
            // 
            this.arcScaleBackgroundLayerComponent2.ArcScale = this.arcEvaluateExactlyRate;
            this.arcScaleBackgroundLayerComponent2.Name = "bg1";
            this.arcScaleBackgroundLayerComponent2.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.CircularFull_Style11;
            this.arcScaleBackgroundLayerComponent2.ZOrder = 1000;
            // 
            // arcEvaluateExactlyRate
            // 
            this.arcEvaluateExactlyRate.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 12F);
            this.arcEvaluateExactlyRate.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.arcEvaluateExactlyRate.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 125F);
            this.arcEvaluateExactlyRate.EndAngle = 60F;
            this.arcEvaluateExactlyRate.MajorTickmark.FormatString = resources.GetString("arcEvaluateExactlyRate.MajorTickmark.FormatString");
            this.arcEvaluateExactlyRate.MajorTickmark.ShapeOffset = -5F;
            this.arcEvaluateExactlyRate.MajorTickmark.ShapeScale = new DevExpress.XtraGauges.Core.Base.FactorF2D(0.6F, 0.8F);
            this.arcEvaluateExactlyRate.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style11_4;
            this.arcEvaluateExactlyRate.MajorTickmark.TextOffset = -17F;
            this.arcEvaluateExactlyRate.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;
            this.arcEvaluateExactlyRate.MaxValue = 100F;
            this.arcEvaluateExactlyRate.MinorTickCount = 4;
            this.arcEvaluateExactlyRate.MinorTickmark.ShapeOffset = -2.5F;
            this.arcEvaluateExactlyRate.MinorTickmark.ShapeScale = new DevExpress.XtraGauges.Core.Base.FactorF2D(0.6F, 1F);
            this.arcEvaluateExactlyRate.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style11_3;
            this.arcEvaluateExactlyRate.Name = "scale1";
            this.arcEvaluateExactlyRate.RadiusX = 107F;
            this.arcEvaluateExactlyRate.RadiusY = 107F;
            arcScaleRange7.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Red");
            arcScaleRange7.EndValue = 50F;
            arcScaleRange7.Name = "Range0";
            arcScaleRange8.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Yellow");
            arcScaleRange8.EndValue = 70F;
            arcScaleRange8.Name = "Range1";
            arcScaleRange8.StartValue = 50F;
            arcScaleRange9.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:GreenYellow");
            arcScaleRange9.EndValue = 90F;
            arcScaleRange9.Name = "Range2";
            arcScaleRange9.StartValue = 70F;
            arcScaleRange10.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Green");
            arcScaleRange10.EndValue = 100F;
            arcScaleRange10.Name = "Range3";
            arcScaleRange10.StartValue = 90F;
            arcScaleRange11.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:GreenYellow");
            arcScaleRange11.EndValue = 0F;
            arcScaleRange11.Name = "Range4";
            arcScaleRange12.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Yellow");
            arcScaleRange12.EndValue = 0F;
            arcScaleRange12.Name = "Range5";
            this.arcEvaluateExactlyRate.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] {
            arcScaleRange7,
            arcScaleRange8,
            arcScaleRange9,
            arcScaleRange10,
            arcScaleRange11,
            arcScaleRange12});
            this.arcEvaluateExactlyRate.StartAngle = -240F;
            // 
            // arcScaleNeedleComponent2
            // 
            this.arcScaleNeedleComponent2.ArcScale = this.arcEvaluateExactlyRate;
            this.arcScaleNeedleComponent2.EndOffset = 5F;
            this.arcScaleNeedleComponent2.Name = "needle1";
            this.arcScaleNeedleComponent2.ShapeType = DevExpress.XtraGauges.Core.Model.NeedleShapeType.CircularFull_Style11;
            this.arcScaleNeedleComponent2.StartOffset = -9.5F;
            this.arcScaleNeedleComponent2.ZOrder = -50;
            // 
            // arcEvaluateExactltyRate
            // 
            this.arcEvaluateExactltyRate.AppearanceTickmarkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.arcEvaluateExactltyRate.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.arcEvaluateExactltyRate.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 125F);
            this.arcEvaluateExactltyRate.EndAngle = 60F;
            this.arcEvaluateExactltyRate.MajorTickmark.FormatString = resources.GetString("arcEvaluateExactltyRate.MajorTickmark.FormatString");
            this.arcEvaluateExactltyRate.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style11_4;
            this.arcEvaluateExactltyRate.MajorTickmark.TextOffset = -15F;
            this.arcEvaluateExactltyRate.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;
            this.arcEvaluateExactltyRate.MaxValue = 1000F;
            this.arcEvaluateExactltyRate.MinorTickCount = 4;
            this.arcEvaluateExactltyRate.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style11_1;
            this.arcEvaluateExactltyRate.Name = "scale2";
            this.arcEvaluateExactltyRate.RadiusX = 70F;
            this.arcEvaluateExactltyRate.RadiusY = 70F;
            this.arcEvaluateExactltyRate.StartAngle = -240F;
            this.arcEvaluateExactltyRate.ZOrder = -1;
            // 
            // IterationChartBar
            // 
            resources.ApplyResources(this.IterationChartBar, "IterationChartBar");
            this.IterationChartBar.Name = "IterationChartBar";
            this.IterationChartBar.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            pointSeriesLabel2.LineVisible = true;
            this.IterationChartBar.SeriesTemplate.Label = pointSeriesLabel2;
            this.IterationChartBar.SeriesTemplate.View = lineSeriesView2;
            // 
            // textEdit10
            // 
            this.textEdit10.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Contact", true));
            resources.ApplyResources(this.textEdit10, "textEdit10");
            this.textEdit10.Name = "textEdit10";
            this.textEdit10.Properties.ReadOnly = true;
            this.textEdit10.StyleController = this.dataLayoutControl1;
            // 
            // ManagerName
            // 
            resources.ApplyResources(this.ManagerName, "ManagerName");
            this.ManagerName.Name = "ManagerName";
            this.ManagerName.Properties.ReadOnly = true;
            this.ManagerName.StyleController = this.dataLayoutControl1;
            // 
            // saleServiceName
            // 
            resources.ApplyResources(this.saleServiceName, "saleServiceName");
            this.saleServiceName.Name = "saleServiceName";
            this.saleServiceName.Properties.ReadOnly = true;
            this.saleServiceName.StyleController = this.dataLayoutControl1;
            // 
            // textEdit6
            // 
            this.textEdit6.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.StatisticNumberBindingSource, "SumRemainderTime", true));
            resources.ApplyResources(this.textEdit6, "textEdit6");
            this.textEdit6.Name = "textEdit6";
            this.textEdit6.Properties.ReadOnly = true;
            this.textEdit6.StyleController = this.dataLayoutControl1;
            // 
            // textEdit5
            // 
            this.textEdit5.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.StatisticNumberBindingSource, "SumOvertime", true));
            resources.ApplyResources(this.textEdit5, "textEdit5");
            this.textEdit5.Name = "textEdit5";
            this.textEdit5.Properties.ReadOnly = true;
            this.textEdit5.StyleController = this.dataLayoutControl1;
            // 
            // textEdit4
            // 
            this.textEdit4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.StatisticNumberBindingSource, "SumEffort", true));
            resources.ApplyResources(this.textEdit4, "textEdit4");
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Properties.ReadOnly = true;
            this.textEdit4.StyleController = this.dataLayoutControl1;
            // 
            // textEdit3
            // 
            this.textEdit3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.StatisticNumberBindingSource, "SumActualInput", true));
            resources.ApplyResources(this.textEdit3, "textEdit3");
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.ReadOnly = true;
            this.textEdit3.StyleController = this.dataLayoutControl1;
            // 
            // textEdit2
            // 
            this.textEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.StatisticNumberBindingSource, "SumActualWorkHours", true));
            resources.ApplyResources(this.textEdit2, "textEdit2");
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.ReadOnly = true;
            this.textEdit2.StyleController = this.dataLayoutControl1;
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.MemberBindingSource;
            resources.ApplyResources(this.gridControl2, "gridControl2");
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ProjectMember,
            this.MemberQuoteWorkHours,
            this.MemberActualWorkHours,
            this.MemberActualInput,
            this.MemberEffort,
            this.MemberEvaluateExactlyRate,
            this.MemberInputEffortRate});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // ProjectMember
            // 
            this.ProjectMember.FieldName = "Name";
            this.ProjectMember.Name = "ProjectMember";
            resources.ApplyResources(this.ProjectMember, "ProjectMember");
            // 
            // MemberQuoteWorkHours
            // 
            this.MemberQuoteWorkHours.FieldName = "SumQuoteWorkHours";
            this.MemberQuoteWorkHours.Name = "MemberQuoteWorkHours";
            resources.ApplyResources(this.MemberQuoteWorkHours, "MemberQuoteWorkHours");
            // 
            // MemberActualWorkHours
            // 
            this.MemberActualWorkHours.FieldName = "SumActualWorkHours";
            this.MemberActualWorkHours.Name = "MemberActualWorkHours";
            resources.ApplyResources(this.MemberActualWorkHours, "MemberActualWorkHours");
            // 
            // MemberActualInput
            // 
            this.MemberActualInput.FieldName = "SumActualInput";
            this.MemberActualInput.Name = "MemberActualInput";
            resources.ApplyResources(this.MemberActualInput, "MemberActualInput");
            // 
            // MemberEffort
            // 
            this.MemberEffort.FieldName = "SumEffort";
            this.MemberEffort.Name = "MemberEffort";
            resources.ApplyResources(this.MemberEffort, "MemberEffort");
            // 
            // MemberEvaluateExactlyRate
            // 
            this.MemberEvaluateExactlyRate.DisplayFormat.FormatString = "{0:0.00%}";
            this.MemberEvaluateExactlyRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.MemberEvaluateExactlyRate.FieldName = "SumEvaluateExactlyRate";
            this.MemberEvaluateExactlyRate.Name = "MemberEvaluateExactlyRate";
            resources.ApplyResources(this.MemberEvaluateExactlyRate, "MemberEvaluateExactlyRate");
            // 
            // MemberInputEffortRate
            // 
            this.MemberInputEffortRate.DisplayFormat.FormatString = "{0:0.00%}";
            this.MemberInputEffortRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.MemberInputEffortRate.FieldName = "SumInputEffortRate";
            this.MemberInputEffortRate.Name = "MemberInputEffortRate";
            resources.ApplyResources(this.MemberInputEffortRate, "MemberInputEffortRate");
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.IterationBindingSource;
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IterationName,
            this.QuoteWorkHours,
            this.ActualWorkHours,
            this.ActualInput,
            this.Effort,
            this.EvaluateExactlyRate,
            this.InputEffortRate});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // IterationName
            // 
            this.IterationName.FieldName = "Name";
            this.IterationName.Name = "IterationName";
            resources.ApplyResources(this.IterationName, "IterationName");
            // 
            // QuoteWorkHours
            // 
            this.QuoteWorkHours.FieldName = "SumQuoteWorkHours";
            this.QuoteWorkHours.Name = "QuoteWorkHours";
            resources.ApplyResources(this.QuoteWorkHours, "QuoteWorkHours");
            // 
            // ActualWorkHours
            // 
            this.ActualWorkHours.FieldName = "SumActualWorkHours";
            this.ActualWorkHours.Name = "ActualWorkHours";
            resources.ApplyResources(this.ActualWorkHours, "ActualWorkHours");
            // 
            // ActualInput
            // 
            this.ActualInput.FieldName = "SumActualInput";
            this.ActualInput.Name = "ActualInput";
            resources.ApplyResources(this.ActualInput, "ActualInput");
            // 
            // Effort
            // 
            this.Effort.FieldName = "SumEffort";
            this.Effort.Name = "Effort";
            resources.ApplyResources(this.Effort, "Effort");
            // 
            // EvaluateExactlyRate
            // 
            this.EvaluateExactlyRate.DisplayFormat.FormatString = "{0:0.00%}";
            this.EvaluateExactlyRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.EvaluateExactlyRate.FieldName = "SumEvaluateExactlyRate";
            this.EvaluateExactlyRate.Name = "EvaluateExactlyRate";
            resources.ApplyResources(this.EvaluateExactlyRate, "EvaluateExactlyRate");
            // 
            // InputEffortRate
            // 
            this.InputEffortRate.DisplayFormat.FormatString = "{0:0.00%}";
            this.InputEffortRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.InputEffortRate.FieldName = "SumInputEffortRate";
            this.InputEffortRate.Name = "InputEffortRate";
            resources.ApplyResources(this.InputEffortRate, "InputEffortRate");
            // 
            // textEdit1
            // 
            this.textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.StatisticNumberBindingSource, "SumQuoteWorkHours", true));
            resources.ApplyResources(this.textEdit1, "textEdit1");
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.StyleController = this.dataLayoutControl1;
            // 
            // projectNameLookUp
            // 
            this.projectNameLookUp.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "ProjectId", true));
            resources.ApplyResources(this.projectNameLookUp, "projectNameLookUp");
            this.projectNameLookUp.Name = "projectNameLookUp";
            this.projectNameLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("projectNameLookUp.Properties.Buttons"))))});
            this.projectNameLookUp.Properties.NullText = resources.GetString("projectNameLookUp.Properties.NullText");
            this.projectNameLookUp.StyleController = this.dataLayoutControl1;
            this.projectNameLookUp.EditValueChanged += new System.EventHandler(this.projectNameLookUp_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1,
            this.tabbedControlGroup2,
            this.projectSummaryGroup});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1219, 862);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            resources.ApplyResources(this.tabbedControlGroup1, "tabbedControlGroup1");
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 340);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.iterationGridGroup;
            this.tabbedControlGroup1.SelectedTabPageIndex = 0;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(1199, 251);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.iterationGridGroup,
            this.IterationPieChartGroup,
            this.IterationBarChart,
            this.IterationBurndown});
            this.tabbedControlGroup1.SelectedPageChanged += new DevExpress.XtraLayout.LayoutTabPageChangedEventHandler(this.tabbedControlGroup1_SelectedPageChanged);
            // 
            // iterationGridGroup
            // 
            resources.ApplyResources(this.iterationGridGroup, "iterationGridGroup");
            this.iterationGridGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.iterationGridGroup.Location = new System.Drawing.Point(0, 0);
            this.iterationGridGroup.Name = "iterationGridGroup";
            this.iterationGridGroup.Size = new System.Drawing.Size(1175, 204);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            resources.ApplyResources(this.layoutControlItem2, "layoutControlItem2");
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1175, 204);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // IterationPieChartGroup
            // 
            resources.ApplyResources(this.IterationPieChartGroup, "IterationPieChartGroup");
            this.IterationPieChartGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem6,
            this.splitterItem1});
            this.IterationPieChartGroup.Location = new System.Drawing.Point(0, 0);
            this.IterationPieChartGroup.Name = "IterationPieChartGroup";
            this.IterationPieChartGroup.Size = new System.Drawing.Size(1175, 204);
            // 
            // layoutControlItem1
            // 
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Location = new System.Drawing.Point(185, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(990, 204);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.resourcesTree1;
            resources.ApplyResources(this.layoutControlItem6, "layoutControlItem6");
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(180, 204);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            resources.ApplyResources(this.splitterItem1, "splitterItem1");
            this.splitterItem1.Location = new System.Drawing.Point(180, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 204);
            // 
            // IterationBarChart
            // 
            resources.ApplyResources(this.IterationBarChart, "IterationBarChart");
            this.IterationBarChart.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.IterationBarChart.Location = new System.Drawing.Point(0, 0);
            this.IterationBarChart.Name = "IterationBarChart";
            this.IterationBarChart.Size = new System.Drawing.Size(1175, 204);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.IterationChartBar;
            resources.ApplyResources(this.layoutControlItem4, "layoutControlItem4");
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1175, 204);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // IterationBurndown
            // 
            resources.ApplyResources(this.IterationBurndown, "IterationBurndown");
            this.IterationBurndown.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7,
            this.ItemForIterationList,
            this.layoutControlItem8,
            this.emptySpaceItem2});
            this.IterationBurndown.Location = new System.Drawing.Point(0, 0);
            this.IterationBurndown.Name = "IterationBurndown";
            this.IterationBurndown.Size = new System.Drawing.Size(1175, 204);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.RemainderTimeBurndown;
            resources.ApplyResources(this.layoutControlItem7, "layoutControlItem7");
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(1175, 180);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // ItemForIterationList
            // 
            this.ItemForIterationList.Control = this.IterationLookUp;
            resources.ApplyResources(this.ItemForIterationList, "ItemForIterationList");
            this.ItemForIterationList.Location = new System.Drawing.Point(0, 0);
            this.ItemForIterationList.Name = "ItemForIterationList";
            this.ItemForIterationList.Size = new System.Drawing.Size(358, 24);
            this.ItemForIterationList.TextSize = new System.Drawing.Size(119, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.eliminateWeekendCheckEdit;
            resources.ApplyResources(this.layoutControlItem8, "layoutControlItem8");
            this.layoutControlItem8.Location = new System.Drawing.Point(358, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(132, 24);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem2, "emptySpaceItem2");
            this.emptySpaceItem2.Location = new System.Drawing.Point(490, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(685, 24);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // tabbedControlGroup2
            // 
            resources.ApplyResources(this.tabbedControlGroup2, "tabbedControlGroup2");
            this.tabbedControlGroup2.Location = new System.Drawing.Point(0, 591);
            this.tabbedControlGroup2.Name = "tabbedControlGroup2";
            this.tabbedControlGroup2.SelectedTabPage = this.PersonGroup;
            this.tabbedControlGroup2.SelectedTabPageIndex = 0;
            this.tabbedControlGroup2.Size = new System.Drawing.Size(1199, 251);
            this.tabbedControlGroup2.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.PersonGroup,
            this.MemberActualInputGroup});
            // 
            // PersonGroup
            // 
            resources.ApplyResources(this.PersonGroup, "PersonGroup");
            this.PersonGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.PersonGroup.Location = new System.Drawing.Point(0, 0);
            this.PersonGroup.Name = "PersonGroup";
            this.PersonGroup.Size = new System.Drawing.Size(1175, 204);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl2;
            resources.ApplyResources(this.layoutControlItem3, "layoutControlItem3");
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1175, 204);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // MemberActualInputGroup
            // 
            resources.ApplyResources(this.MemberActualInputGroup, "MemberActualInputGroup");
            this.MemberActualInputGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5});
            this.MemberActualInputGroup.Location = new System.Drawing.Point(0, 0);
            this.MemberActualInputGroup.Name = "MemberActualInputGroup";
            this.MemberActualInputGroup.Size = new System.Drawing.Size(1175, 204);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.MemberActualInputChartPie;
            resources.ApplyResources(this.layoutControlItem5, "layoutControlItem5");
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(0, 204);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(104, 204);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(1175, 204);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // projectSummaryGroup
            // 
            resources.ApplyResources(this.projectSummaryGroup, "projectSummaryGroup");
            this.projectSummaryGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForSumEffort,
            this.ItemForSale,
            this.ItemForEvaluateExactlyRate,
            this.ItemForInputEffortRate,
            this.ItemForManager,
            this.ItemForSumQuoteWorkHours,
            this.ItemForSumActualWorkHours,
            this.ItemForSumOvertime,
            this.splitterItem4,
            this.ItemForDate,
            this.splitterItem3,
            this.ItemForProjectName,
            this.ItemForContact,
            this.ItemForSumActualInput,
            this.ItemForSumRemainderTime,
            this.emptySpaceItem1});
            this.projectSummaryGroup.Location = new System.Drawing.Point(0, 0);
            this.projectSummaryGroup.Name = "projectSummaryGroup";
            this.projectSummaryGroup.Size = new System.Drawing.Size(1199, 340);
            // 
            // ItemForSumEffort
            // 
            this.ItemForSumEffort.Control = this.textEdit4;
            resources.ApplyResources(this.ItemForSumEffort, "ItemForSumEffort");
            this.ItemForSumEffort.Location = new System.Drawing.Point(0, 72);
            this.ItemForSumEffort.Name = "ItemForSumEffort";
            this.ItemForSumEffort.Size = new System.Drawing.Size(396, 24);
            this.ItemForSumEffort.TextSize = new System.Drawing.Size(119, 14);
            // 
            // ItemForSale
            // 
            this.ItemForSale.Control = this.saleServiceName;
            resources.ApplyResources(this.ItemForSale, "ItemForSale");
            this.ItemForSale.Location = new System.Drawing.Point(0, 24);
            this.ItemForSale.Name = "ItemForSale";
            this.ItemForSale.Size = new System.Drawing.Size(397, 24);
            this.ItemForSale.TextSize = new System.Drawing.Size(119, 14);
            // 
            // ItemForEvaluateExactlyRate
            // 
            this.ItemForEvaluateExactlyRate.Control = this.gaugeControl2;
            resources.ApplyResources(this.ItemForEvaluateExactlyRate, "ItemForEvaluateExactlyRate");
            this.ItemForEvaluateExactlyRate.Location = new System.Drawing.Point(401, 96);
            this.ItemForEvaluateExactlyRate.MinSize = new System.Drawing.Size(226, 200);
            this.ItemForEvaluateExactlyRate.Name = "ItemForEvaluateExactlyRate";
            this.ItemForEvaluateExactlyRate.Size = new System.Drawing.Size(390, 200);
            this.ItemForEvaluateExactlyRate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForEvaluateExactlyRate.TextSize = new System.Drawing.Size(119, 14);
            // 
            // ItemForInputEffortRate
            // 
            this.ItemForInputEffortRate.Control = this.gaugeControl1;
            resources.ApplyResources(this.ItemForInputEffortRate, "ItemForInputEffortRate");
            this.ItemForInputEffortRate.Location = new System.Drawing.Point(796, 96);
            this.ItemForInputEffortRate.MinSize = new System.Drawing.Size(226, 24);
            this.ItemForInputEffortRate.Name = "ItemForInputEffortRate";
            this.ItemForInputEffortRate.Size = new System.Drawing.Size(379, 200);
            this.ItemForInputEffortRate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForInputEffortRate.TextSize = new System.Drawing.Size(119, 14);
            // 
            // ItemForManager
            // 
            this.ItemForManager.Control = this.ManagerName;
            resources.ApplyResources(this.ItemForManager, "ItemForManager");
            this.ItemForManager.Location = new System.Drawing.Point(397, 24);
            this.ItemForManager.Name = "ItemForManager";
            this.ItemForManager.Size = new System.Drawing.Size(391, 24);
            this.ItemForManager.TextSize = new System.Drawing.Size(119, 14);
            // 
            // ItemForSumQuoteWorkHours
            // 
            this.ItemForSumQuoteWorkHours.Control = this.textEdit1;
            resources.ApplyResources(this.ItemForSumQuoteWorkHours, "ItemForSumQuoteWorkHours");
            this.ItemForSumQuoteWorkHours.Location = new System.Drawing.Point(0, 48);
            this.ItemForSumQuoteWorkHours.Name = "ItemForSumQuoteWorkHours";
            this.ItemForSumQuoteWorkHours.Size = new System.Drawing.Size(396, 24);
            this.ItemForSumQuoteWorkHours.TextSize = new System.Drawing.Size(119, 14);
            // 
            // ItemForSumActualWorkHours
            // 
            this.ItemForSumActualWorkHours.Control = this.textEdit2;
            resources.ApplyResources(this.ItemForSumActualWorkHours, "ItemForSumActualWorkHours");
            this.ItemForSumActualWorkHours.Location = new System.Drawing.Point(396, 48);
            this.ItemForSumActualWorkHours.Name = "ItemForSumActualWorkHours";
            this.ItemForSumActualWorkHours.Size = new System.Drawing.Size(393, 24);
            this.ItemForSumActualWorkHours.TextSize = new System.Drawing.Size(119, 14);
            // 
            // ItemForSumOvertime
            // 
            this.ItemForSumOvertime.Control = this.textEdit5;
            resources.ApplyResources(this.ItemForSumOvertime, "ItemForSumOvertime");
            this.ItemForSumOvertime.Location = new System.Drawing.Point(396, 72);
            this.ItemForSumOvertime.Name = "ItemForSumOvertime";
            this.ItemForSumOvertime.Size = new System.Drawing.Size(393, 24);
            this.ItemForSumOvertime.TextSize = new System.Drawing.Size(119, 14);
            // 
            // splitterItem4
            // 
            this.splitterItem4.AllowHotTrack = true;
            resources.ApplyResources(this.splitterItem4, "splitterItem4");
            this.splitterItem4.Location = new System.Drawing.Point(791, 96);
            this.splitterItem4.Name = "splitterItem4";
            this.splitterItem4.Size = new System.Drawing.Size(5, 200);
            // 
            // ItemForDate
            // 
            this.ItemForDate.Control = this.DateGaugeControl;
            resources.ApplyResources(this.ItemForDate, "ItemForDate");
            this.ItemForDate.Location = new System.Drawing.Point(0, 96);
            this.ItemForDate.MinSize = new System.Drawing.Size(1, 24);
            this.ItemForDate.Name = "ItemForDate";
            this.ItemForDate.Size = new System.Drawing.Size(396, 200);
            this.ItemForDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForDate.TextSize = new System.Drawing.Size(119, 14);
            // 
            // splitterItem3
            // 
            this.splitterItem3.AllowHotTrack = true;
            resources.ApplyResources(this.splitterItem3, "splitterItem3");
            this.splitterItem3.Location = new System.Drawing.Point(396, 96);
            this.splitterItem3.Name = "splitterItem3";
            this.splitterItem3.Size = new System.Drawing.Size(5, 200);
            // 
            // ItemForProjectName
            // 
            this.ItemForProjectName.Control = this.projectNameLookUp;
            resources.ApplyResources(this.ItemForProjectName, "ItemForProjectName");
            this.ItemForProjectName.Location = new System.Drawing.Point(0, 0);
            this.ItemForProjectName.Name = "ItemForProjectName";
            this.ItemForProjectName.Size = new System.Drawing.Size(788, 24);
            this.ItemForProjectName.TextSize = new System.Drawing.Size(119, 14);
            // 
            // ItemForContact
            // 
            this.ItemForContact.Control = this.textEdit10;
            resources.ApplyResources(this.ItemForContact, "ItemForContact");
            this.ItemForContact.Location = new System.Drawing.Point(788, 24);
            this.ItemForContact.Name = "ItemForContact";
            this.ItemForContact.Size = new System.Drawing.Size(387, 24);
            this.ItemForContact.TextSize = new System.Drawing.Size(119, 14);
            // 
            // ItemForSumActualInput
            // 
            this.ItemForSumActualInput.Control = this.textEdit3;
            resources.ApplyResources(this.ItemForSumActualInput, "ItemForSumActualInput");
            this.ItemForSumActualInput.Location = new System.Drawing.Point(789, 48);
            this.ItemForSumActualInput.Name = "ItemForSumActualInput";
            this.ItemForSumActualInput.Size = new System.Drawing.Size(386, 24);
            this.ItemForSumActualInput.TextSize = new System.Drawing.Size(119, 14);
            // 
            // ItemForSumRemainderTime
            // 
            this.ItemForSumRemainderTime.Control = this.textEdit6;
            resources.ApplyResources(this.ItemForSumRemainderTime, "ItemForSumRemainderTime");
            this.ItemForSumRemainderTime.Location = new System.Drawing.Point(789, 72);
            this.ItemForSumRemainderTime.Name = "ItemForSumRemainderTime";
            this.ItemForSumRemainderTime.Size = new System.Drawing.Size(386, 24);
            this.ItemForSumRemainderTime.TextSize = new System.Drawing.Size(119, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem1, "emptySpaceItem1");
            this.emptySpaceItem1.Location = new System.Drawing.Point(788, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(387, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // schedulerStorage1
            // 
            this.schedulerStorage1.AppointmentDependencies.Mappings.DependentId = "ResourceId";
            this.schedulerStorage1.AppointmentDependencies.Mappings.ParentId = "ParentId";
            this.schedulerStorage1.AppointmentDependencies.Mappings.Type = "ParentId";
            this.schedulerStorage1.Appointments.DataSource = this.SchedulerBindingSource;
            this.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerStorage1.Appointments.Mappings.End = "End";
            this.schedulerStorage1.Appointments.Mappings.Label = "Lable";
            this.schedulerStorage1.Appointments.Mappings.PercentComplete = "PercentComplete";
            this.schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceId";
            this.schedulerStorage1.Appointments.Mappings.Start = "Start";
            this.schedulerStorage1.Appointments.Mappings.Status = "Status";
            this.schedulerStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerStorage1.Resources.DataSource = this.ReSourceBindingSource;
            this.schedulerStorage1.Resources.Mappings.Caption = "Caption";
            this.schedulerStorage1.Resources.Mappings.Color = "ResourceColor";
            this.schedulerStorage1.Resources.Mappings.Id = "ResourceId";
            this.schedulerStorage1.Resources.Mappings.ParentId = "ParentId";
            // 
            // linearScaleLevelComponent1
            // 
            this.linearScaleLevelComponent1.LinearScale = this.linearScaleComponent1;
            this.linearScaleLevelComponent1.Name = "level1";
            this.linearScaleLevelComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.LevelShapeSetType.Style11;
            this.linearScaleLevelComponent1.ZOrder = -50;
            // 
            // linearScaleComponent1
            // 
            this.linearScaleComponent1.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.linearScaleComponent1.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 20F);
            this.linearScaleComponent1.MajorTickCount = 6;
            this.linearScaleComponent1.MajorTickmark.FormatString = resources.GetString("linearScaleComponent1.MajorTickmark.FormatString");
            this.linearScaleComponent1.MajorTickmark.ShapeOffset = 6F;
            this.linearScaleComponent1.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style11_2;
            this.linearScaleComponent1.MajorTickmark.TextOffset = 35F;
            this.linearScaleComponent1.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.BottomToTop;
            this.linearScaleComponent1.MaxValue = 500F;
            this.linearScaleComponent1.MinorTickCount = 4;
            this.linearScaleComponent1.MinorTickmark.ShapeOffset = 6F;
            this.linearScaleComponent1.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style11_1;
            this.linearScaleComponent1.Name = "scale1";
            this.linearScaleComponent1.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 230F);
            this.linearScaleComponent1.Value = 250F;
            // 
            // linearScaleBackgroundLayerComponent1
            // 
            this.linearScaleBackgroundLayerComponent1.LinearScale = this.linearScaleComponent1;
            this.linearScaleBackgroundLayerComponent1.Name = "bg1";
            this.linearScaleBackgroundLayerComponent1.ScaleEndPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.508F, 0.08F);
            this.linearScaleBackgroundLayerComponent1.ScaleStartPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.508F, 0.92F);
            this.linearScaleBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.Linear_Style11;
            this.linearScaleBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // ProjectChartView
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "ProjectChartView";
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eliminateWeekendCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IterationLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemainderTimeBurndown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateGauge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleRangeBarComponent4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateLinearScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesTree1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemberActualInputChartPie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularGaugeInputEffortRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcInputEffortRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleComponent4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularGaugeEvaluateExactlyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcEvaluateExactlyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcEvaluateExactltyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IterationChartBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit10.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManagerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleServiceName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatisticNumberBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemberBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IterationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectNameLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationGridGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IterationPieChartGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IterationBarChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IterationBurndown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIterationList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemberActualInputGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectSummaryGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSumEffort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEvaluateExactlyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForInputEffortRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSumQuoteWorkHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSumActualWorkHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSumOvertime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProjectName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSumActualInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSumRemainderTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SchedulerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReSourceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleLevelComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleBackgroundLayerComponent1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup PersonGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlGroup MemberActualInputGroup;
        private DevExpress.XtraCharts.ChartControl IterationChartBar;
        private DevExpress.XtraEditors.TextEdit textEdit6;
        private DevExpress.XtraEditors.TextEdit textEdit5;
        private DevExpress.XtraGrid.Columns.GridColumn IterationName;
        private DevExpress.XtraGrid.Columns.GridColumn QuoteWorkHours;
        private DevExpress.XtraGrid.Columns.GridColumn ActualWorkHours;
        private DevExpress.XtraGrid.Columns.GridColumn ActualInput;
        private DevExpress.XtraGrid.Columns.GridColumn Effort;
        private DevExpress.XtraGrid.Columns.GridColumn ProjectMember;
        private DevExpress.XtraGrid.Columns.GridColumn MemberQuoteWorkHours;
        private DevExpress.XtraGrid.Columns.GridColumn MemberActualWorkHours;
        private DevExpress.XtraGrid.Columns.GridColumn MemberActualInput;
        private DevExpress.XtraGrid.Columns.GridColumn MemberEffort;
        private DevExpress.XtraEditors.TextEdit saleServiceName;
        private DevExpress.XtraEditors.TextEdit ManagerName;
        private DevExpress.XtraEditors.TextEdit textEdit10;
        private DevExpress.XtraLayout.LayoutControlGroup projectSummaryGroup;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSumQuoteWorkHours;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSumActualWorkHours;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSumActualInput;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSumEffort;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSumOvertime;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSumRemainderTime;
        private DevExpress.XtraLayout.LayoutControlItem ItemForProjectName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSale;
        private DevExpress.XtraLayout.LayoutControlItem ItemForManager;
        private DevExpress.XtraLayout.LayoutControlItem ItemForContact;
        private System.Windows.Forms.BindingSource EntityBindingSource;
        private System.Windows.Forms.BindingSource StatisticNumberBindingSource;
        private System.Windows.Forms.BindingSource IterationBindingSource;
        private System.Windows.Forms.BindingSource MemberBindingSource;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl2;
        private DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge circularGaugeEvaluateExactlyRate;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent arcScaleBackgroundLayerComponent2;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent arcEvaluateExactlyRate;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent arcScaleNeedleComponent2;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent arcEvaluateExactltyRate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEvaluateExactlyRate;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge circularGaugeInputEffortRate;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent arcScaleBackgroundLayerComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent arcInputEffortRate;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent arcScaleNeedleComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent arcScaleComponent4;
        private DevExpress.XtraLayout.LayoutControlItem ItemForInputEffortRate;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent linearScaleLevelComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent linearScaleComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent linearScaleBackgroundLayerComponent1;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private DevExpress.XtraCharts.ChartControl MemberActualInputChartPie;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn EvaluateExactlyRate;
        private DevExpress.XtraGrid.Columns.GridColumn MemberEvaluateExactlyRate;
        private DevExpress.XtraGrid.Columns.GridColumn MemberInputEffortRate;
        private DevExpress.XtraGrid.Columns.GridColumn InputEffortRate;
        private System.Windows.Forms.BindingSource SchedulerBindingSource;
        private System.Windows.Forms.BindingSource ReSourceBindingSource;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup IterationPieChartGroup;
        private DevExpress.XtraLayout.LayoutControlGroup iterationGridGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup IterationBarChart;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraScheduler.UI.ResourcesTree resourcesTree1;
        private DevExpress.XtraScheduler.SchedulerControl IterationScheduler;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraScheduler.Native.ResourceTreeColumn colCaption;
        private DevExpress.XtraScheduler.Native.ResourceTreeColumn colResourceId;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.SplitterItem splitterItem4;
        private DevExpress.XtraGauges.Win.GaugeControl DateGaugeControl;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearGauge DateGauge;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleRangeBarComponent linearScaleRangeBarComponent4;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent DateLinearScale;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDate;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent1;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent2;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent3;
        private DevExpress.XtraLayout.SplitterItem splitterItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LookUpEdit projectNameLookUp;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent4;
        private DevExpress.XtraLayout.LayoutControlGroup IterationBurndown;
        private DevExpress.XtraEditors.LookUpEdit IterationLookUp;
        private DevExpress.XtraCharts.ChartControl RemainderTimeBurndown;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIterationList;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.CheckEdit eliminateWeekendCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;

    }
}
