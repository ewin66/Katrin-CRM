using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Katrin.Win.Common.MetadataServiceReference;
using DevExpress.Utils;
using Katrin.Win.Common;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Data.Edm;
using System.Data.Services.Client;
using Microsoft.Data.Edm.Validation;
using Microsoft.Data.Edm.Csdl;
using Katrin.Win.Common.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using Microsoft.Practices.CompositeUI;
using CABDevExpress.SmartPartInfos;
using Katrin.Win.Common.Constants;
using Katrin.Win.MetadataManager.Grid;
using DevExpress.XtraGrid.Views.Grid.Customization;

namespace Katrin.Win.MetadataManager
{
    public partial class SavedQueryDetailView : DevExpress.XtraEditors.XtraUserControl
    {
        private SavedQuery _savedQuery;

        [ServiceDependency]
        public WorkItem WorkItem
        {
            get;
            set;
        }

        public SavedQueryDetailView()
        {
            InitializeComponent();
            viewGridView.ShowCustomization(customizationPanel);
            viewGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            viewGridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            viewGridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            viewGridView.OptionsView.ShowIndicator = false;
            viewGridView.OptionsView.WaitAnimationOptions = WaitAnimationOptions.Panel;
            viewGridView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;

            CustomizationForm customForm = customizationPanel.Controls[0] as CustomizationForm;
            ColumnCustomizationListBox listBox = customForm.Controls[0] as ColumnCustomizationListBox;
            listBox.MouseClick += (sender, e) =>
                {
                    if (listBox.SelectedIndex < 0) return;
                    var item = listBox.Items[listBox.SelectedIndex];
                    GridColumn columnItem = item as GridColumn;
                    if (columnItem == null) return;
                    ShowColumnProperty(columnItem);
                };
        }

        public void Bind(SavedQuery savedQuery)
        {
            Guard.ArgumentNotNull(savedQuery, "savedQuery");
            _savedQuery = savedQuery;
            nameTextEdit.Text = savedQuery.Name;
            descriptionMemoEdit.Text = savedQuery.Description;
            defaultCheck.Checked = savedQuery.IsDefault;
            if (!string.IsNullOrEmpty(savedQuery.LayoutXml))
            {
                viewGridView.RestoreLayoutFromString(savedQuery.LayoutXml);
            }
            viewGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            viewGridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            viewGridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            viewGridView.OptionsView.ShowIndicator = false;
            viewGridView.OptionsView.WaitAnimationOptions = WaitAnimationOptions.Panel;
            viewGridView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            BindProperityData();
        }


       
        private void BindProperityData()
        {
            ColumnProperTityBindSource.DataSource = new GridColumn();
            GridProperTityBindSource.DataSource = viewGridView;
            viewNameTxt.EditValue = viewGridView.Name;
            ChAutoExpandAllGroups.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.GridProperTityBindSource, "OptionsBehavior.AutoExpandAllGroups", true,DataSourceUpdateMode.OnPropertyChanged));
            ChColumnAutoWidth.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.GridProperTityBindSource, "OptionsView.ColumnAutoWidth", true, DataSourceUpdateMode.OnPropertyChanged));
            ChShowIndicator.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.GridProperTityBindSource, "OptionsView.ShowIndicator", true, DataSourceUpdateMode.OnPropertyChanged));
            ChShowGroupPlanel.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.GridProperTityBindSource, "OptionsView.ShowGroupPanel", true, DataSourceUpdateMode.OnPropertyChanged));
            ChShowFooter.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.GridProperTityBindSource, "OptionsView.ShowFooter", true, DataSourceUpdateMode.OnPropertyChanged));
            CbShowFilterPanelMode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.GridProperTityBindSource, "OptionsView.ShowFilterPanelMode", true, DataSourceUpdateMode.OnPropertyChanged));
            CbShowGroupedColumns.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.GridProperTityBindSource, "OptionsView.ShowGroupedColumns", true, DataSourceUpdateMode.OnPropertyChanged));
            ChAllowCellMerge.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.GridProperTityBindSource, "OptionsView.AllowCellMerge", true, DataSourceUpdateMode.OnPropertyChanged));

            //
            ChAllowEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ColumnProperTityBindSource, "OptionsColumn.AllowEdit", true, DataSourceUpdateMode.OnPropertyChanged));
            ChAllowFocus.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ColumnProperTityBindSource, "OptionsColumn.AllowFocus", true, DataSourceUpdateMode.OnPropertyChanged));
            ChReadOnly.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ColumnProperTityBindSource, "OptionsColumn.ReadOnly", true, DataSourceUpdateMode.OnPropertyChanged));
            SummaryLookUp.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ColumnProperTityBindSource, "SummaryItem.SummaryType", true, DataSourceUpdateMode.OnPropertyChanged));
            summaryFormatTxt.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ColumnProperTityBindSource, "SummaryItem.DisplayFormat", true, DataSourceUpdateMode.OnPropertyChanged));
            FormatStringTxt.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ColumnProperTityBindSource, "DisplayFormat.FormatString", true, DataSourceUpdateMode.OnPropertyChanged));
            CbFormatType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ColumnProperTityBindSource, "DisplayFormat.FormatType", true, DataSourceUpdateMode.OnPropertyChanged));
            
            //ChAutoExpandAllGroups.DataBindings.Add
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (ParentForm != null) ParentForm.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;

            _savedQuery.Name = nameTextEdit.Text;
            _savedQuery.Description = descriptionMemoEdit.Text;
            StringBuilder layout = new StringBuilder();
            viewGridView.SaveLayoutToString(layout);
            _savedQuery.LayoutXml = layout.ToString();
            _savedQuery.IsDefault = defaultCheck.Checked;
            var metadataService = MetadataProvider.CreateServiceClient();
            metadataService.SaveSavedQuery(_savedQuery);

            if (ParentForm != null) ParentForm.Close();
        }

        private void chooseColumnsButton_Click(object sender, EventArgs e)
        {
            var columnChooser = WorkItem.Items.AddNew<ViewColumnChooser>();
            columnChooser.Init(_savedQuery.ReturnedTypeId, viewGridView);
            var info = new XtraWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Icon = Properties.Resources.ri_Katrin,
                Modal = true,
                Title = "Column Chooser"
            };
            WorkItem.Workspaces[WorkspaceNames.ModalWindows].Show(columnChooser, info);
            columnChooser.Dispose();
        }

        private void viewGridControl_Click(object sender, EventArgs e)
        {
            
            
        }

        private void ShowColumnProperty(GridColumn column)
        {
            if (column.ColumnEdit == null && !string.IsNullOrEmpty(column.ColumnEditName))
            {
                column.ColumnEdit = new RepositoryItem() { Name = column.ColumnEditName };
            }
            ColumnProperTityBindSource.DataSource = column;
            columnNameTxt.EditValue = column.Name;
            ColumnPropertyLayOutControl.Visible = true;
            GridPropertyLayOutControl.Visible = false;
        }
        private void viewGridControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (viewGridView.CalcHitInfo(e.Location).InColumn)
            {
                ShowColumnProperty(viewGridView.CalcHitInfo(e.Location).Column);
            }
            else
            {
                ColumnPropertyLayOutControl.Visible = false;
                GridPropertyLayOutControl.Visible = true;
            }
            
        }

        private void columnPreviewPanel_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void customizationPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (viewGridView.CalcHitInfo(e.Location).InColumn)
            {

            }
        }
    }
}
