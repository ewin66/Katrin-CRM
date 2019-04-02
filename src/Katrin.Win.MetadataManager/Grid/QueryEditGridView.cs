using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.Drawing;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.Customization;

namespace Katrin.Win.MetadataManager.Grid
{
    public class QueryEditGridView : GridView
    {
        private Control parentControl;



        protected override string ViewName
        {
            get { return "QueryEditGridView"; }
        }

        public QueryEditGridView()
            : this(null)
        {
        }


        public QueryEditGridView(GridControl grid)
            : base(grid)
        {
            parentControl = null;
        }


        public void ShowCustomization(Point location)
        {
            parentControl = null;
            ColumnsCustomization(location);
        }

        public void ShowCustomization(Control parent)
        {
            parentControl = parent;
            ColumnsCustomization(BaseViewInfo.EmptyPoint);
        }

        protected override CustomizationForm CreateCustomizationForm()
        {
            return (parentControl != null ? new QueryEditCustomizationForm(this, parentControl) : new QueryEditCustomizationForm(this)) as CustomizationForm;
        }
    }
}
