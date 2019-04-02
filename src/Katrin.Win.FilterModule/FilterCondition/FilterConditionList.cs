using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Runtime.Serialization.Formatters.Binary;
using DevExpress.Utils;
using System.Reflection;
using DevExpress.XtraGrid.Views.Base;
using System.Xml.Linq;
using Katrin.AppFramework.WinForms.Context;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms.Grid;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework;
using System.Collections;

namespace Katrin.Win.FilterModule.FilterCondition
{
    public partial class FilterConditionList : XtraForm
    {
        private IActionContext _actionContext;
        private FilterItem _filterItem;
        public event EventHandler<EventArgs<string>> OnSendFilterMessage;
        public event EventHandler Apply;
        public void OnApply()
        {
            if (OnSendFilterMessage != null)
                OnSendFilterMessage(null, new EventArgs<string>(_filterItem.FilterString));
        }

        private string _objectName;
        public string ControllerId
        {
            get;
            set;
        }
        public string ObjectName
        {
            get { return _objectName; }
            set
            {
                if (_objectName != value)
                {
                    _objectName = value;
                    if (string.IsNullOrEmpty(ControllerId)) ControllerId = value;
                    GridControl gridControl = new GridControl();
                    ColumnView currentView = new GridView();
                    gridControl.Visible = false;
                    this.Controls.Add(gridControl);
                    gridControl.MainView = currentView;
                    gridControl.ViewCollection.Add(currentView);
                    currentView.GridControl = gridControl;
                    IObjectSpace objectSpace = new ODataObjectSpace();
                    Type entityType = objectSpace.ResolveType(ControllerId);
                    Type listGenericType = typeof(List<>);
                    Type listType = listGenericType.MakeGenericType(entityType);
                    var list = (IList)Activator.CreateInstance(listType);
                    var entity = Activator.CreateInstance(entityType);
                    list.Add(entity);
                    currentView.InitWithDefaultLayout(ControllerId);
                    gridControl.BeginUpdate();
                    gridControl.DataSource = list;
                    gridControl.EndUpdate();
                    conditionFilterControl.SourceControl = currentView.GridControl;
                }
            }
        }

        private void SaveFilterItem(FilterItem item)
        {
            //_actionContext.SetFilter("GridFilter", condition.Conditions);
            string FiltersDirectory = Path.Combine(Application.StartupPath + "\\AddIns", "Filters");
            string viewFilterDirectory = Path.Combine(FiltersDirectory, ObjectName);
            if (!System.IO.Directory.Exists(viewFilterDirectory))
            {
                System.IO.Directory.CreateDirectory(viewFilterDirectory);
            }
            var filterFile = Path.Combine(viewFilterDirectory, item.FileName + ".xml");
            if (File.Exists(filterFile))
            {
                File.Delete(filterFile);
            }

            var xelement = new XElement("property", item.FilterString);
            xelement.SetAttributeValue("name", "ActiveFilterString");
            var doc = new XDocument(
                new XElement("Filter",
                    new XElement("FilterName", item.DisplayName),
                    xelement,
                    new XElement("order", "1")
                )
            );
            doc.Save(filterFile);
        }

        public FilterConditionList(FilterItem filterItem)
        {
            InitializeComponent();
            _filterItem = filterItem;
            if (string.IsNullOrEmpty(filterItem.DisplayName))
            {
                filterItem.DisplayName = "Untitled";
                filterItem.FileName = Guid.NewGuid().ToString();
            }
            int position = formatConditionBindingSource.Add(filterItem);
            formatConditionBindingSource.Position = position;
            _actionContext = new ActionContext();
        }
        
        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveFilterItem(_filterItem);
            OnApply();
        }
    
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveFilterItem(_filterItem);
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
