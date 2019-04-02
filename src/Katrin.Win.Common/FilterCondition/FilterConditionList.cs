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
using Microsoft.Practices.ObjectBuilder;
using DevExpress.XtraGrid.Views.Base;
using Microsoft.Practices.CompositeUI.SmartParts;
using System.Xml.Linq;
using Katrin.Win.Common.Core;


namespace Katrin.Win.Common.FilterCondition
{
    [SmartPart]
    public partial class FilterConditionList : XtraForm, IFilterConditionView
    {

        private FilterConditionListPresenter _presenter;

        /// <summary>
        /// Sets the presenter.
        /// </summary>
        /// <value>The presenter.</value>
        [CreateNew]
        public FilterConditionListPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        private ColumnView _currentView;
        private Katrin.Win.Common.Core.View _view;

        public event EventHandler Apply;

        public void OnApply(EventArgs e)
        {
            EventHandler handler =Apply;
            if (handler != null) handler(this, e);
        }

        public event EventHandler OK;

        public void OnOK(EventArgs e)
        {
            EventHandler handler = OK;
            if (handler != null)
            {
                handler(this, e);
                SaveLayout(true);
            }
        }

        public void SaveLayout(bool saveFile)
        {
            foreach (FilterCondition condition in Conditions)
            {
                if (saveFile)
                {
                    string FiltersDirectory = Path.Combine(Application.StartupPath, "Filters");
                    string viewFilterDirectory = Path.Combine(FiltersDirectory, EntityTypeName);
                    if (!System.IO.Directory.Exists(viewFilterDirectory))
                    {
                        System.IO.Directory.CreateDirectory(viewFilterDirectory);
                    }
                    string filterFile = Path.Combine(viewFilterDirectory,Guid.NewGuid() + ".xml");
                    if (condition.Name != null && condition.Name != "")
                    {
                        filterFile = Path.Combine(viewFilterDirectory, condition.Name + ".xml");
                    }
                    if (File.Exists(filterFile))
                    {
                        File.Delete(filterFile);
                    }

                    var xelement = new XElement("property", condition.Conditions);
                    xelement.SetAttributeValue("name", "ActiveFilterString");
                    var doc = new XDocument(
                        new XElement("Filter",
                            new XElement("FilterName", condition.FilteName),
                            xelement,
                            new XElement("order", "1")
                        )
                    );
                    doc.Save(filterFile);
                }
                _view.Context.SetFilter("GridFilter", condition.Conditions);
            }
        }

         public void SaveLayoutToStream(Stream stream)
        {
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, Conditions.ToList());
        }

        public IEnumerable<FilterCondition> Conditions
        {
            get { return formatConditionBindingSource.List.Cast<FilterCondition>(); }
        }

        public FilterConditionList()
        {
            InitializeComponent();
            
        }

        public void SetGridView(EntityListView contentView, string fileName, string filterName, string filterString)
        {
            _currentView = contentView.EntityGridView;
            _view = contentView;
            SetFontSizeAndName();
            formatConditionBindingSource.Clear();
            FilterCondition condtion = new FilterCondition();
            if (fileName != "")
            {
                condtion.FilteName = filterName;
                condtion.Name = fileName;
                condtion.Conditions = filterString;
            }
            else
            {
                condtion.FilteName = "Untitled";
            }

            int position = formatConditionBindingSource.Add(condtion);
            formatConditionBindingSource.Position = position;
        }

        public string EntityTypeName { get; set; }

        public void AddCondition(StyleFormatCondition condition)
        {
            //_currentView.FormatConditions.Add(condition);
        }

        private void SetFontSizeAndName()
        {
            GridView gridView = _currentView as GridView;
            conditionFilterControl.SourceControl = _currentView.GridControl;
            nametextEdit.Focus();
        }

        private void formatConditionGrid_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            formatLayoutControl.Enabled = true;
            btnApply.Enabled = true;
            btnOK.Enabled = true;
            SetFontSizeAndName();
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
           OnApply(e);
           SaveLayout(false);
        }
    
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FilterCondition condtion = new FilterCondition();
            condtion.Name = "Untitled";
            int position = formatConditionBindingSource.Add(condtion);
            formatConditionBindingSource.Position = position;
            SetFontSizeAndName();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (formatConditionBindingSource.Current != null)
                formatConditionBindingSource.RemoveCurrent();
        }

        public void ShowMessage(string message)
        {
            XtraMessageBox.Show(this, message, Properties.Resources.Katrin, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }


        public void RestoreLayoutFromStream(Stream stream)
        {
            BinaryFormatter bformatter = new BinaryFormatter();
            var list = (List<FilterCondition>)bformatter.Deserialize(stream);
            formatConditionBindingSource.DataSource = list;
        }

       

        public void ClearConditions()
        {
            //_currentView.FormatConditions.Clear();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            OnOK(e);
            Close();
        }

        


        public void RestoreLayout(string _formatConditionFileName)
        {
            var fileFullName = _formatConditionFileName;
            if (File.Exists(fileFullName))
            {
                Stream tream = new FileStream(fileFullName, FileMode.Open, FileAccess.Read);
                this.RestoreLayoutFromStream(tream);
            }
        }

        private void formatConditionGrid_RowCountChanged(object sender, EventArgs e)
        {
            //if (formatConditionGrid.DataRowCount <= 0)
            //{
            //    btnApply.Enabled = false;
            //    btnOK.Enabled = false;
            //    formatLayoutControl.Enabled = false;
            //}
            //else
            //{
            //    btnApply.Enabled = true;
            //    btnOK.Enabled = true;
            //}
        }
    }
}
