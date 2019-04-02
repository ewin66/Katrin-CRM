using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Katrin.Win.Common.Core;
using Microsoft.Practices.CompositeUI.EventBroker;
using Katrin.Win.Common.MetadataServiceReference;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Linq;
using System.Text.RegularExpressions;
namespace Katrin.Win.MetadataManager.OptionSetView
{
    public partial class OptionSetDetailView : DevExpress.XtraEditors.XtraUserControl,IOptionSetDetailView
    {
        OptionSetDetailPresenter _presenter;
        public event EventHandler SaveOptionSet;

        public OptionSetDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
            get { return _presenter; }
        }

        public OptionSetDetailView()
        {
            InitializeComponent();
        }

        [EventPublication("CloseOptionDetailView", PublicationScope.WorkItem)]
        public event EventHandler CloseOptionDetailView;

        public void Bind(object entity)
        {
            EntityBindingSource.DataSource = entity;
            OptionListBindingSource.DataMember = "OptionList";
            listOption.Focus();
        }

        public bool IsSave
        {
            get;
            set;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;
            if (SaveOptionSet != null)
            {
                SaveOptionSet(this,e);
                CloseOptionDetailView(this, e);
                IsSave = true;
            }
        }

        protected void SetValidationRule(Control control, ValidationRuleBase rule)
        {
            DXValidationProvider provider = ValidationProvider;
            provider.SetValidationRule(control, rule);
            provider.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
        }

        public void InitValidation()
        {
            SetValidationRule(displayNameTextEdit, ValidationRules.IsNotBlankRule(displayNameLayoutControlItem.Text));
            SetValidationRule(nameTextEdit, ValidationRules.IsNotBlankRule(nameLayoutControlItem.Text));
        }

        public bool ValidateData()
        {
            var result = ValidationProvider.Validate();
            var invalidControls = ValidationProvider.GetInvalidControls();
            var firstInvalideControl = invalidControls.FirstOrDefault();

            if (firstInvalideControl != null)
            {
                var layoutItem = attributeDetailLayoutControl.GetItemByControl(firstInvalideControl);
                if (layoutItem != null && layoutItem.Parent.ParentTabbedGroup != null)
                {
                    layoutItem.Parent.ParentTabbedGroup.SelectedTabPage = layoutItem.Parent;
                }
            }
            return result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
        private Guid editItemId = Guid.Empty;
        private void BtnNewOption_Click(object sender, EventArgs e)
        {
            txtLabel.Text = "";
            txtValue.Text = "";
            MemoDescription.Text = "";
            editItemId = Guid.Empty;
        }

        private void BtnDeleteOption_Click(object sender, EventArgs e)
        {
            OptionDTO option = OptionListBindingSource.Current as OptionDTO;
            if (option != null)
            {
                OptionListBindingSource.Remove(option);
            }
        }

        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex("\\d+");
            if (!reg.IsMatch(txtValue.Text))
            {
                txtValue.Text = "0";
                return;
            }
            if (editItemId == Guid.Empty)
            {
                OptionDTO option = new OptionDTO();
                option.DisplayName = txtLabel.Text;
                option.Value = int.Parse(txtValue.Text);
                option.Description = MemoDescription.Text;
                option.OptionId = Guid.NewGuid();
                option.DisplayOrder = OptionListBindingSource.Count + 1;
                OptionListBindingSource.Add(option);
            }
            else
            {
                OptionDTO option = OptionListBindingSource.Current as OptionDTO;
                if (option != null && option.OptionId == editItemId)
                {
                    option.DisplayName = txtLabel.Text;
                    option.Value = int.Parse(txtValue.Text);
                    option.Description = MemoDescription.Text;
                    option.DisplayOrder = OptionListBindingSource.IndexOf(option);
                }
            }

        }

        private void listOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            OptionDTO option = OptionListBindingSource.Current as OptionDTO;
            if (option != null)
            {
                txtLabel.Text = option.DisplayName;
                txtValue.Text = option.Value.ToString();
                MemoDescription.Text = option.Description;
                editItemId = option.OptionId;
            }
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            
            OptionDTO option = OptionListBindingSource.Current as OptionDTO;
            if (option != null)
            {
                OptionListBindingSource.MovePrevious();
                var preOption = OptionListBindingSource.Current as OptionDTO;
                if (preOption != null)
                {
                    int orderIndex = preOption.DisplayOrder??0;
                    preOption.DisplayOrder = option.DisplayOrder;
                    option.DisplayOrder = orderIndex;
                    ListSort(option, preOption);
                }
            }
            
        }

        private void ListSort(OptionDTO option, OptionDTO preOption)
        {
            List<OptionSetDTO> optionSetList = EntityBindingSource.DataSource as List<OptionSetDTO>;

            if (optionSetList != null && optionSetList.Count > 0)
            {
                int index = optionSetList[0].OptionList.IndexOf(option);
                int preIndex = optionSetList[0].OptionList.IndexOf(preOption);
                optionSetList[0].OptionList[index] = preOption;
                optionSetList[0].OptionList[preIndex] = option;
                EntityBindingSource.DataSource = optionSetList;
            }
            
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            OptionDTO option = OptionListBindingSource.Current as OptionDTO;
            if (option != null)
            {
                OptionListBindingSource.MoveNext();
                var nextOption = OptionListBindingSource.Current as OptionDTO;
                if (nextOption != null)
                {
                    int orderIndex = nextOption.DisplayOrder ?? 0;
                    nextOption.DisplayOrder = option.DisplayOrder;
                    option.DisplayOrder = orderIndex;
                    ListSort(nextOption, option);
                }
            }
        }
    }
}
