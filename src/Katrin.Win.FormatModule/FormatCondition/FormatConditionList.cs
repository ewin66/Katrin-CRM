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
using Katrin.AppFramework.WinForms;
using ICSharpCode.Core;

namespace Katrin.Win.FormatModule.FormatCondition
{
    public partial class FormatConditionList : XtraForm, IFormatConditionView
    {

        private ColumnView _currentView;

        public event EventHandler Apply;

        public void OnApply(EventArgs e)
        {
            EventHandler handler = Apply;
            if (handler != null) handler(this, e);
        }

        public IEnumerable<FormatCondition> Conditions
        {
            get { return formatConditionBindingSource.List.Cast<FormatCondition>(); }
        }

        public FormatConditionList()
        {
            InitializeComponent();
            enableBackColorCheckEdit_CheckedChanged(null,null);
            enableForeColorCheckEdit_CheckedChanged(null,null);
            enableFontCheckEdit_CheckedChanged(null,null);
        }

        public void SetGridView(ColumnView gridView, string formatConditionFileName)
        {
            _currentView = gridView;
            btnAdd.Glyph = WinFormsResourceService.GetBitmap("overlay_add");
            btnDelete.Glyph = WinFormsResourceService.GetBitmap("overlay_delete");
            SetFontSizeAndName();
            if (formatConditionGrid.DataRowCount <= 0)
            {
                btnApply.Enabled = false;
                btnOK.Enabled = false;
                conditionFilterControl.FilterString = "";
                formatLayoutControl.Enabled = false;
                btnDelete.Enabled = false;
            }
            RestoreLayout(formatConditionFileName);
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

                if (sizeSpinEdit.EditValue == null)
                    sizeSpinEdit.EditValue = gridView.PaintAppearance.Row.Font.Size;
                if (fontNameEdit.EditValue == null)
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

            int position = formatConditionBindingSource.List.IndexOf(formatConditionGrid.GetFocusedRow());
            formatConditionBindingSource.Position = position;
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
            XtraMessageBox.Show(this, message, "Katrin", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }


        public void RestoreLayoutFromStream(Stream stream)
        {
            //BinaryFormatter bformatter = new BinaryFormatter();
            if (stream.Length <= 0) return;
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<FormatCondition>));
            var list = (List<FormatCondition>)xmlFormatter.Deserialize(stream);//;bformatter.Deserialize(stream);
            foreach (var condtion in list)
            {
                if (!string.IsNullOrEmpty(condtion.ConditionName))
                    condtion.Name = ResourceService.GetString(condtion.ConditionName);
                if (!string.IsNullOrEmpty(condtion.FontName))
                    fontNameEdit.EditValue = condtion.FontName;
                if (!string.IsNullOrEmpty(condtion.Size))
                    sizeSpinEdit.EditValue = condtion.Size;
            }
            list = list.OrderBy(c => c.Name).ToList();
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
            OnApply(e);
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


        public void SaveLayout(string formatConditionFileName)
        {
            if (File.Exists(formatConditionFileName)) File.Delete(formatConditionFileName);
            Stream stream = new FileStream(formatConditionFileName, FileMode.CreateNew, FileAccess.Write);
            this.SaveLayoutToStream(stream);
            stream.Close();
        }


        public void RestoreLayout(string formatConditionFileName)
        {
            if (File.Exists(formatConditionFileName))
            {
                Stream stream = new FileStream(formatConditionFileName, FileMode.Open, FileAccess.Read);
                this.RestoreLayoutFromStream(stream);
                stream.Close();
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

        #region IView

        public string ViewType
        {
            get;
            set;

        }
        public AppFramework.WinForms.MVC.IControllerManager ControllerManager
        {
            get;
            set;
        }

        public bool IsChildForm
        {
            get;
            set;
        }

        public object Model
        {
            get;
            set;
        }

        public string ViewName
        {
            get;
            set;
        }

        public void BindDataToView()
        {

        }

        public void ShowView()
        {

        }

        public void ActiveView()
        {

        }

        public void CloseView()
        {

        }
        public Guid WorkSpaceID
        {
            get;
            set;
        }
        #endregion

        private void enableBackColorCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            backcolorEdit.Enabled = enableBackColorCheckEdit.Checked;
        }

        private void enableForeColorCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            forecolorEdit.Enabled = enableForeColorCheckEdit.Checked;
        }

        private void enableFontCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            fontNameEdit.Enabled = enableFontCheckEdit.Checked;
            sizeSpinEdit.Enabled = enableFontCheckEdit.Checked;
            boldCheckEdit.Enabled = enableFontCheckEdit.Checked;
            italicCheckEdit.Enabled = enableFontCheckEdit.Checked;
            underlineCheckEdit.Enabled = enableFontCheckEdit.Checked;
        }


        public AppFramework.WinForms.Context.IWorkSpaceContext Context
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private void FormatConditionList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
