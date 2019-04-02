using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using DevExpress.XtraGrid.Views.Grid.Customization;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

namespace Katrin.Win.MetadataManager.Grid
{
    [ToolboxItem(false)]
    public class QueryEditCustomizationForm : CustomizationForm
    {
        private Control parentControl;

        public QueryEditCustomizationForm(GridView view)
            : base(view)
        {
            parentControl = null;
        }

        public QueryEditCustomizationForm(GridView view, Control parent)
            : this(view)
        {
            parentControl = parent;
        }

        public override void ShowCustomization(Point location)
        {
            if (parentControl != null)
            {
                ShowCustomization(parentControl);
                return;
            }

            base.ShowCustomization(location);
        }
    }
}
