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
namespace Katrin.Win.ProjectWeekReportModule
{
    public class ProjectWeekReportController : ListController
    {
        public override string ObjectName
        {
            get
            {
                return "ProjectWeekReport";
            }
        }

        //protected override System.Collections.Generic.List<string> IncludingPath
        //{
        //    get
        //    {
        //        return new List<string>() { "CreatedBy" };
        //    }
        //}
    }
}
