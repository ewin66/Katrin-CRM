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
using Katrin.Win.Infrastructure;
using Microsoft.Practices.CompositeUI;

namespace Katrin.Win.MainModule.Views.ProjectManagement
{
    public partial class ProjectListView : EntityListView
    {

        public ProjectListView()
        {
            InitializeComponent();
        }


        protected override void OnContextChanging(ContextChangingEventArgs e)
        {
            base.OnContextChanging(e);
            if (e.Original != null) e.Original.BindingSource.DataSourceChanged -= OnDataSourceChanged;
            if (e.New != null) e.New.BindingSource.DataSourceChanged += OnDataSourceChanged;
        }

        protected override Dictionary<string, string> IncludingPath
        {
            get { return new Dictionary<string, string> { { "ProjectTasks", "ProjectTasks" }}; }
        }

        void OnDataSourceChanged(object sender, EventArgs e)
        {
            var projects = ((BindingSource)sender).List;
            if (projects == null) return;
            foreach (var project in projects)
            {
                dynamic dynamicProject = project.AsDyanmic();
                IList tasks = dynamicProject.ProjectTasks;
                tasks = tasks.AsQueryable().Where("IsDeleted=@0",false).ToArrayList();
                var effort = tasks.AsQueryable().Select("Effort").Cast<double?>().Sum();
                var actualWorkHours = tasks.AsQueryable().Select("ActualWorkHours").Cast<double?>().Sum();
                if (actualWorkHours > 0)
                    dynamicProject.ActualProgress = Convert.ToInt32(effort * 100 / actualWorkHours);
                else
                    dynamicProject.ActualProgress = 0;
            }
        }

        Font cellFont = new Font(AppearanceObject.DefaultFont, FontStyle.Regular);
        Pen paymentPen = Pens.Green;
        Brush interestBrush = Brushes.Green;
        Brush principalBrush = Brushes.LightGreen;
        Brush interestForeBrush = Brushes.White;
        Brush principalForeBrush = Brushes.Black;

        public override void Bind(string entityName)
        {
            base.Bind(entityName);
            GridColumnCollection columns = gridView1.Columns;
            foreach (GridColumn column in columns)
            {
                if (column.Caption == "") column.Caption = GetLocalizedCaption(column.Name);
            }
        }

        protected override ColumnView CreateDataView()
        {
            gridView1.CustomDrawCell += (sender, e) =>
                {
                    GridView view = sender as GridView;
                    object project = view.GetRow(e.RowHandle);
                    if (project == null) return;
                    if (project.AsDyanmic().ActualProgress == null) return;
                    double progress = project.AsDyanmic().ActualProgress/100.0;
                    progress = progress > 1 ? 1 : progress;
                    if (e.Column.FieldName == "ActualProgress")
                    {
                        Rectangle r = e.Bounds;
                        r.Inflate(-3, -3);
                        int interestWidth = (int)(r.Width * progress);
                        int principalWidth = (int)(r.Width * (1-progress));
                        Rectangle interestRect = new Rectangle(r.X, r.Y, interestWidth, r.Height);
                        Rectangle principalRect = new Rectangle(r.X + interestWidth, r.Y, principalWidth, r.Height);
                        e.Graphics.FillRectangle(interestBrush, interestRect);
                        e.Graphics.FillRectangle(principalBrush, principalRect);
                        string format = "{0:0.00%}";
                        using (StringFormat sf = new StringFormat())
                        {
                            sf.Alignment = StringAlignment.Near;
                            sf.LineAlignment = StringAlignment.Center;
                             e.Graphics.DrawString(string.Format(format, progress), cellFont, interestForeBrush, r, sf);
                        }
                        e.Graphics.DrawRectangle(paymentPen, new Rectangle(interestRect.X, interestRect.Y - 1, (interestRect.Width + principalRect.Width), interestRect.Height + 1));
                        e.Handled = true;
                    }
                    else if (e.Column.FieldName == "")
                    {
                        string valueFormat = "{0:0.00}";
                        IList taskList = project.AsDyanmic().ProjectTasks;
                        double? result = 0d;
                        if (e.Column.Name == "colSumRemainderTime")
                        {
                            result = taskList.AsQueryable().Select("ActualWorkHours").Cast<double?>().Sum() -
                                taskList.AsQueryable().Select("Effort").Cast<double?>().Sum();
                        }
                        else if (e.Column.Name == "colInputEffortRate")
                        {
                            valueFormat = "{0:0%}";
                            double? sumActualInput = taskList.AsQueryable().Select("ActualInput").Cast<double?>().Sum();
                            result = sumActualInput>0?taskList.AsQueryable().Select("Effort").Cast<double?>().Sum() /sumActualInput:0d;
                        }
                        else if (e.Column.Name == "colEvaluateExactlyRate")
                        {
                            valueFormat = "{0:0%}";
                            double? sumActualWorkHours = taskList.AsQueryable().Select("ActualWorkHours").Cast<double?>().Sum();
                            result = sumActualWorkHours>0?taskList.AsQueryable().Select("QuoteWorkHours").Cast<double?>().Sum() / sumActualWorkHours:0d;
                        }
                        else
                        {
                            result = taskList.AsQueryable().Select(e.Column.Name.Replace("colSum", "")).Cast<double?>().Sum();
                        }
                        double sumResult = result ?? 0d;
                        using (StringFormat sf = new StringFormat())
                        {
                            sf.Alignment = StringAlignment.Near;
                            sf.LineAlignment = StringAlignment.Center;
                            e.Graphics.DrawString(string.Format(valueFormat, sumResult), cellFont, Brushes.Black, e.Bounds, sf);
                        }
                        
                        e.Handled = true;
                    }
                };
            return gridView1;
        }

       
    }
}
