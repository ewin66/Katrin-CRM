using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;

namespace Katrin.Win.MetadataManager.Grid
{
    public class QueryEditGridViewInfoRegistrator : GridInfoRegistrator
    {
        public override string ViewName
        {
            get { return "QueryEditGridView"; }
        }

        public override BaseView CreateView(GridControl grid)
        {
            return new QueryEditGridView(grid as GridControl);
        }
    }
}
