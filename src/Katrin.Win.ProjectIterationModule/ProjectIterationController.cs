using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.MVC.Data;
using Katrin.AppFramework.WinForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework;
using Katrin.AppFramework.WinForms.Grid;
using Katrin.AppFramework.WinForms;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms.Messages;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using Katrin.AppFramework.Data;

namespace Katrin.Win.ProjectIterationModule
{
    public class ProjectController : ListController, IObjectWidget, IListener<SelectedObjectChangedMessage>
    {

        protected override List<string> IncludingPath
        {
            get { return new List<string> { "ProjectTasks" }; }
        }

        protected override  string RibbonPath
        {
            get { return "/ProjectIteration/List/Ribbon"; }
        }

        public string ParentObjectName
        {
            get;
            set;
        }


        public ProjectController()
        {
            ObjectName = "ProjectIteration";
        }

        public override IActionResult Execute(ActionParameters parameters)
        {
            _listView = CreateListView("DefaultListView");
            _listView.ObjectName = ObjectName;
            var result = new PartialViewResult();
            result.View = _listView;
            InitCustomDrawCell();
            return result;
        }

        private void InitCustomDrawCell()
        {
            if (!(_listView.ObjectGridView is GridView)) return;
            GridView gridView = (GridView)_listView.ObjectGridView;
            gridView.CustomDrawCell += gridView_CustomDrawCell;
        }

        private void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            object projectiteration = view.GetRow(e.RowHandle);
            if (projectiteration == null) return;
            var iteration = ConvertData.Convert<Katrin.Domain.Impl.ProjectIteration>(projectiteration);
            DateTime? startDate = iteration.StartDate;
            DateTime? endDate = iteration.Deadline;
            Brush interestBrush = new SolidBrush(Color.FromArgb(235, 236, 240));
            if (startDate <= DateTime.Today && endDate >= DateTime.Today)
            {
                interestBrush = new SolidBrush(Color.FromArgb(240, 226, 181));
            }
            Rectangle r = e.Bounds;
            Rectangle ri = new Rectangle(r.X, r.Y, r.Width + 5, r.Height);
            e.Graphics.FillRectangle(interestBrush, ri);
        }

        void IListener<SelectedObjectChangedMessage>.Handle(SelectedObjectChangedMessage message)
        {
            if (message.ObjectName == ParentObjectName)
            {
                if (message.SelectedObject == null)
                {
                    _listView.ClearData();
                    return;
                }

                var id = _objectSpace.GetObjectId(message.ObjectName, message.SelectedObject);

                FixedFilter = new BinaryOperator("ProjectId", id);

                BindListData();
            }
        }


    }
}
