using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.MVC.Data;
using Katrin.AppFramework.WinForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework;
using Katrin.AppFramework.WinForms.Grid;
using Katrin.AppFramework.WinForms;
using ICSharpCode.Core;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using System.Collections;
using DevExpress.Utils;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.Data;
using DevExpress.XtraGrid.Columns;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
namespace Katrin.Win.ProjectModule
{
    public class ProjectController : ListController
    {

        protected override List<string> IncludingPath
        {
            get { return new List<string> { "ProjectTasks"}; }
        }

        public override string ObjectName
        {
            get
            {
                
                return "Project";
            }
        }

        protected override  string RibbonPath
        {
            get { return "/Project/List/Ribbon"; }
        }

        public override IActionResult Execute(ActionParameters parameters)
        {
            IActionResult result =  base.Execute(parameters);
            InitCustomDrawCell();
            return result;
        }


        private void InitCustomDrawCell()
        {
            if(!(_listView.ObjectGridView is GridView)) return;
            GridView gridView = (GridView)_listView.ObjectGridView;
            gridView.CustomDrawCell += gridView_CustomDrawCell;
           
        }
        public override void Dispose()
        {
            if (this._listView != null)
            {
                GridView gridView = (GridView)_listView.ObjectGridView;
                gridView.CustomDrawCell -= gridView_CustomDrawCell;
                this._listView = null;
            }
        }
       

       

        Font cellFont = new Font(AppearanceObject.DefaultFont, FontStyle.Regular);
        Pen paymentPen = Pens.Green;
        Brush interestBrush = Brushes.Green;
        Brush principalBrush = Brushes.LightGreen;
        Brush interestForeBrush = Brushes.White;
        Brush principalForeBrush = Brushes.Black;
        void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            object obj = view.GetRow(e.RowHandle);
            if (obj == null) return;
            var project = ConvertData.Convert<Katrin.Domain.Impl.Project>(obj); 
            if (project == null) return;
            if (e.Column.FieldName == "ActualProgress")
            {
                if (project.ActualProgress == null)
                {
                    var tasks = project.ProjectTasks.ToList();
                    tasks = tasks.Where(c => c.IsDeleted == false).ToList();
                    var effort = tasks.AsQueryable().Select("Effort").Cast<double?>().Sum();
                    var actualWorkHours = tasks.AsQueryable().Select("ActualWorkHours").Cast<double?>().Sum();
                    if (actualWorkHours > 0)
                        project.ActualProgress = Convert.ToInt32(effort * 100 / actualWorkHours);
                    else
                        project.ActualProgress = 0;
                }
                double progress = (project.ActualProgress ?? 0) / 100.0;
                progress = progress > 1 ? 1 : progress;

                Rectangle r = e.Bounds;
                r.Inflate(-3, -3);
                int interestWidth = (int)(r.Width * progress);
                int principalWidth = (int)(r.Width * (1 - progress));
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
                view.GetRow(e.RowHandle).GetType().GetProperty("ActualProgress").SetValue(view.GetRow(e.RowHandle), (int)(progress*100), null);
                e.Handled = true;
            }
            else if (e.Column.FieldName == "")
            {
                string valueFormat = "{0:0.00}";
                var taskList = project.ProjectTasks.ToList();
                taskList = taskList.Where(c => c.IsDeleted == false).ToList();
                double? result = 0d;
                if (e.Column.Name == "colSumRemainderTime")
                {
                    result = taskList.Select(c=>c.ActualWorkHours).Cast<double?>().Sum() -
                        taskList.Select(c=>c.Effort).Cast<double?>().Sum();
                }
                else if (e.Column.Name == "colInputEffortRate")
                {
                    valueFormat = "{0:0%}";
                    double? sumActualInput = taskList.Select(c=>c.ActualInput).Cast<double?>().Sum();
                    result = sumActualInput > 0 ? taskList.Select(c=>c.Effort).Cast<double?>().Sum() / sumActualInput : 0d;
                }
                else if (e.Column.Name == "colEvaluateExactlyRate")
                {
                    valueFormat = "{0:0%}";
                    double? sumActualWorkHours = taskList.Select(c=>c.ActualWorkHours).Cast<double?>().Sum();
                    result = sumActualWorkHours > 0 ? taskList.Select(c=>c.QuoteWorkHours).Cast<double?>().Sum() / sumActualWorkHours : 0d;
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
            
        }
    }
}
