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


namespace Katrin.Win.Common.FormatCondition
{
    [SmartPart]
    public partial class FormatConditionList : XtraForm, IFormatConditionView
    {

        private FormatConditionListPresenter _presenter;

        /// <summary>
        /// Sets the presenter.
        /// </summary>
        /// <value>The presenter.</value>
        [CreateNew]
        public FormatConditionListPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        private ColumnView _currentView;

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
            if (handler != null) handler(this, e);
        }

        public IEnumerable<FormatCondition> Conditions
        {
            get { return formatConditionBindingSource.List.Cast<FormatCondition>(); }
        }

        public FormatConditionList()
        {
            InitializeComponent();
            
        }

        public void SetGridView(ColumnView gridView)
        {
            _currentView = gridView;
            btnAdd.Glyph = Properties.Resources.overlay_add;
            btnDelete.Glyph = Properties.Resources.overlay_delete;
            SetFontSizeAndName();
            if (formatConditionGrid.DataRowCount <= 0)
            {
                btnApply.Enabled = false;
                btnOK.Enabled = false;
                conditionFilterControl.FilterString = "";
                formatLayoutControl.Enabled = false;
                btnDelete.Enabled = false;
            }
            Apply += _presenter.ViewApply;
            OK += _presenter.ViewOK;
            RestoreLayout(_presenter._formatConditionFileName);
        }

        public string EntityTypeName { get; set; }

        public void AddCondition(StyleFormatCondition condition)
        {
            _currentView.FormatConditions.Add(condition);
        }

        private void SetFontSizeAndName()
        {
            GridView gridView = _currentView as GridView;
            if (gridView != null)
            {
                sizeSpinEdit.EditValue = gridView.PaintAppearance.Row.Font.Size;
                fontNameEdit.EditValue = gridView.PaintAppearance.Row.Font.Name;
            }
            conditionFilterControl.SourceControl = _currentView.GridControl;
            nametextEdit.Focus();
        }

        private void formatConditionGrid_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            formatLayoutControl.Enabled = true;
            btnDelete.Enabled = true;
            btnApply.Enabled = true;
            btnOK.Enabled = true;
            SetFontSizeAndName();
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
           OnApply(e);
        }
    
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormatCondition condtion = new FormatCondition();
            condtion.Name = "Untitled";
            GridView gridView = _currentView as GridView;
            if (gridView != null)
            {

                condtion.Size = gridView.PaintAppearance.Row.Font.Size.ToString();
                condtion.FontName = gridView.PaintAppearance.Row.Font.Name;
            }
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
            //BinaryFormatter bformatter = new BinaryFormatter();
            if (stream.Length <= 0) return;
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<FormatCondition>));
            var list = (List<FormatCondition>)xmlFormatter.Deserialize(stream);//;bformatter.Deserialize(stream);
            formatConditionBindingSource.DataSource = list;
        }

        public void SaveLayoutToStream(Stream stream)
        {
            //BinaryFormatter bformatter = new BinaryFormatter();
            try
            {
                XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<FormatCondition>));
                xmlFormatter.Serialize(stream, Conditions.ToList());
            }
            catch
            {

            }
        }

        public void ClearConditions()
        {
            _currentView.FormatConditions.Clear();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            OnOK(e);
            Close();
        }
        public void PostEdit()
        {
            FormatGroup.Controls[0].Controls.OfType<BaseEdit>().ToList().ForEach(edit =>
            {
                edit.Focus();
                edit.DoValidate(PopupCloseMode.Normal); 
            });
        }

        private string GetFileName()
        {
            string formatsDirectory = Path.Combine(Application.StartupPath, "Formats");
            string viewFormatDirectory = Path.Combine(formatsDirectory, EntityTypeName);
            if (!Directory.Exists(viewFormatDirectory)) Directory.CreateDirectory(viewFormatDirectory);
            var fileFullName = viewFormatDirectory + "\\FormatCondition.xml";
            return fileFullName;
        }
        public void SaveLayout(string _formatConditionFileName)
        {
            var fileFullName = GetFileName();
            if (File.Exists(fileFullName)) File.Delete(fileFullName);
            Stream tream = new FileStream(fileFullName,FileMode.CreateNew,FileAccess.Write);
            this.SaveLayoutToStream(tream);
            tream.Close();
        }


        public void RestoreLayout(string _formatConditionFileName)
        {
            var fileFullName = GetFileName();
            if (File.Exists(fileFullName))
            {
                Stream tream = new FileStream(fileFullName, FileMode.Open, FileAccess.Read);
                this.RestoreLayoutFromStream(tream);
                tream.Close();
            }
        }

        private void formatConditionGrid_RowCountChanged(object sender, EventArgs e)
        {
            if (formatConditionGrid.DataRowCount <= 0)
            {
                btnApply.Enabled = false;
                //btnOK.Enabled = false;
                formatLayoutControl.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnApply.Enabled = true;
                btnOK.Enabled = true;
            }
        }
    }
}
