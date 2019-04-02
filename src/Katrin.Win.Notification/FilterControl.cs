using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using Katrin.AppFramework.WinForms;
using ICSharpCode.Core;
using Katrin.AppFramework;
using System.Data.Services.Client;
using System.Linq;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.Security;
namespace Katrin.Win.NotificationModule
{
    public partial class FilterControl : DevExpress.XtraEditors.XtraUserControl
    {

        public event EventHandler<EventArgs<string,string>> OnObjectFilterChange;
        public FilterControl()
        {
            InitializeComponent();
        }

        public void InitData(string objectTypeName)
        {
            treeList1.FocusedNodeChanged -= treeList1_FocusedNodeChanged;
            treeList1.Nodes.Clear();
            ImageList columnImageList = new ImageList();
            columnImageList.Images.Add(WinFormsResourceService.GetIcon("all").ToBitmap());
            columnImageList.Images.SetKeyName(0, string.Empty);
            treeList1.SelectImageList = columnImageList;

            var root = treeList1.AppendNode(new object[] { ResourceService.GetString("All"), string.Empty, 0 }, null);
            root.SetValue(colFilters,string.Empty);
            IObjectSpace objectSpace = new ODataObjectSpace();

            var notificationQuery = (List<NotificationDTO>)AuthorizationManager.NotificationList.List;
            var objectTypes = notificationQuery.Select(c => c.ObjectTypeEn).Distinct().ToList();
            if (objectTypes.Contains("sysMsg"))
            {
                objectTypes.Remove("sysMsg");
                objectTypes.Insert(0, "sysMsg");
            }
            
            int imageIndex = 1;
            List<string> noteType = new List<string>();
            foreach (var item in objectTypes)
            {
                columnImageList.Images.Add(WinFormsResourceService.GetIcon(item.ToLower()).ToBitmap());
                columnImageList.Images.SetKeyName(imageIndex, string.Empty);
                int ncount = notificationQuery.Where(c => c.ObjectTypeEn == item && c.NotificationStatus == 1).Count();
                var node = treeList1.AppendNode(new object[] { ResourceService.GetString(item) + "(" + ncount + ")", string.Empty, string.Empty, imageIndex }, root);
                if (item == objectTypeName) node.Selected = true;
                node.SetValue(colFilters,"[ObjectTypeEn] = '" + item + "'");
                node.SetValue(colNodeName, item);
                imageIndex++;
            }
            treeList1.ExpandAll();
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.GetValue(colFilters) == null) return;
            if (OnObjectFilterChange != null)
                OnObjectFilterChange(null, new EventArgs<string,string>(e.Node.GetValue(colFilters).ToString(),
                    e.Node.GetValue(colNodeName).ToString()));
        }

    }
}
