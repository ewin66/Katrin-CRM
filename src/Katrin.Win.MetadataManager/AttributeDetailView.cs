using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using Katrin.Win.Common.MetadataServiceReference;
using Microsoft.Practices.CompositeUI.EventBroker;
using Katrin.Win.Infrastructure;
using Microsoft.Practices.CompositeUI.SmartParts;
using DevExpress.XtraEditors.DXErrorProvider;
using Katrin.Win.Common.Core;
using Katrin.Win.MetadataManager.OptionSetView;
using Microsoft.Practices.CompositeUI;
using CABDevExpress.SmartPartInfos;
using Katrin.Win.Common.Constants;
using Microsoft.Practices.CompositeUI.Utility;
using Katrin.Win.Infrastructure.Services;

namespace Katrin.Win.MetadataManager
{
    [SmartPart]
    public partial class AttributeDetailView : DevExpress.XtraEditors.XtraUserControl
    {
        public AttributeDetailView()
        {
            InitializeComponent();
            InitValidation();
        }

        public void BindData(EntityAttribute attribute,List<EntityRelationshipRole> relationList)
        {
            if (attribute.AttributeTypeId != null)
            {
                var filterList = FormatTypeList.Where(c => c.FormatParentId == attribute.AttributeTypeId);
                var formatType = filterList.FirstOrDefault();
                if(filterList.Count() > 1)
                    formatType = filterList.Where(c=>c.FormatName == attribute.LogicalType).FirstOrDefault();
                if (formatType != null)
                {
                    typeLookUpEdit.EditValue = formatType.FormatId;
                    LookUpChanged(formatType.FormatName);
                    if (formatType.FormatName == AttributeTypeEnum.Lookup.ToString())
                    {
                        var relation = relationList.Where(c => c.EntityRelationship.EntityRelationshipRelationships.First().Relationship.ReferencingAttributeId == attribute.AttributeId);
                        if (relation.Any())
                        {
                            lookupTargetTypeLookUpEdit.EditValue = relation.First().EntityId;
                            lookupRelationshipTextEdit.Text = relation.First().EntityRelationship.SchemaName;
                        }
                    }
                }
            }
            EntityBindingSource.DataSource = attribute;
        }

        private BaseLayoutItem preItem = null;
        void typeLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (typeLookUpEdit.Text == "") return;
            LookUpChanged(typeLookUpEdit.Text);
        }
        private void LookUpChanged(string editText)
        {
            var type = (AttributeTypeEnum)Enum.Parse(typeof(AttributeTypeEnum), editText);
            string itemName = type.ToString();
            if (itemName.Length > 0)
            {
                char firstChar = itemName[0];
                itemName = itemName.TrimStart(firstChar);
                itemName = firstChar.ToString().ToLower() + itemName + "Group";
                BaseLayoutItem item = typeLayoutControlGroup.Items.FindByName(itemName);
                if (item != null)
                {
                    if (preItem != null && preItem.Name != item.Name) preItem.Visibility = LayoutVisibility.Never;
                    preItem = item;
                    item.Visibility = LayoutVisibility.Always;
                }
            }
        }

        #region singleLine
        void InitSingleLineTextFormat()
        {
            var singleLine = FormatTypeList.Where(c => c.FormatName == AttributeTypeEnum.SingleLineText.ToString()).Select(c => c.FormatId).First();
            var singleLineTextFormatItems = FormatTypeList.Where(c => c.FormatParentId == (Guid)singleLine).ToList();
            var items = singleLineTextFormatItems.Select(name => new LookupListItem<string>
            {
                DisplayName = name.FormatName,
                Value = name.FormatName
            }).ToList();
            signleLineTextFormatLookUpEdit.Properties.InitializeLookUpEdit(items);
        }

        

        
        #endregion

        #region optionSet
        private List<AttributePicklistValue> AttributePickList = new List<AttributePicklistValue>();
        private List<FormatTypeItem> FormatTypeList = new List<FormatTypeItem>();
        private List<Entity> EntityList = new List<Entity>();
        public void InitOptionSetUpEdit(List<OptionSet> optionSetList, List<AttributePicklistValue> attributePickList, List<FormatTypeItem> formatTypeList,List<Entity> entityList)
        {
            
            FormatTypeList = formatTypeList;
            EntityList = entityList;

            FreshOptionSetLookUp(Guid.Empty, optionSetList, attributePickList);
            singleLineTextGroup.Tag = AttributeTypeEnum.SingleLineText;
            this.optionSetGroup.Tag = AttributeTypeEnum.OptionSet;
            this.integerGroup.Tag = AttributeTypeEnum.Integer;
            this.floatGroup.Tag = AttributeTypeEnum.Float;
            this.decimalGroup.Tag = AttributeTypeEnum.Decimal;
            this.currencyGroup.Tag = AttributeTypeEnum.Currency;
            this.multipleLineTextGroup.Tag = AttributeTypeEnum.MultipleLineText;
            this.dateTimeGroup.Tag = AttributeTypeEnum.DateTime;
            this.lookupGroup.Tag = AttributeTypeEnum.Lookup;

            typeLayoutControlGroup.Items.OfType<LayoutControlGroup>().ToList()
                .ForEach(i => i.Visibility = LayoutVisibility.Never);

            var atrributeTypeNames = Enum.GetNames(typeof(AttributeTypeEnum));
            var typeItems = atrributeTypeNames
                .Select(name => new LookupListItem<Guid>
                {
                    DisplayName = name,
                    Value = FormatTypeList.Where(c => c.FormatName == name).Select(c => c.FormatId).First()
                }).ToList();
            typeLookUpEdit.Properties.InitializeLookUpEdit(typeItems);
            typeLookUpEdit.EditValueChanged += new EventHandler(typeLookUpEdit_EditValueChanged);
            if (typeItems.Any())
            {
                typeLookUpEdit.EditValue = typeItems[0].Value;
                LookUpChanged(typeItems[0].DisplayName);
            }
            InitCurrencyPrecisionLookUpEdit();
            InitDateFormatLookUpEdit();
            InitDecimalPrecisionLookUpEdit();
            InitFloatingPointPrecisionLookUpEdit();
            InitLookupTargetTypeLookUpEdit();
            InitSingleLineTextFormat();
            
        }

        private void BindDefaultValueLookUpEdit(Guid optionSetId)
        {
            optionSetDefaultValueLookUpEdit.Properties.Columns.Clear();
            var pickUpList = AttributePickList.Where(c => c.OptionSetId == optionSetId && c.Value != null);
            var items = pickUpList
                .Select(pickUp => new LookupListItem<int>
                {
                    DisplayName = pickUp.Value.ToString(),
                    Value = pickUp.Value??0
                }).ToList();
            optionSetDefaultValueLookUpEdit.Properties.InitializeLookUpEdit(items);
            if (items.Count > 0)
                optionSetDefaultValueLookUpEdit.EditValue = items[0].Value;
        }
        public WorkItem WorkItem
        {
            get;
            set;
        }
        private void EditOptionSet_Click(object sender, EventArgs e)
        {
            if (optionSetLookUpEdit.EditValue.ToString() == "") return;
            Guid optionSetId = (Guid)optionSetLookUpEdit.EditValue;
            ShowOptionSet(optionSetId, EntityDetailWorkingMode.Edit);
        }

        private void NewOptionSet_Click(object sender, EventArgs e)
        {
            ShowOptionSet(Guid.NewGuid(), EntityDetailWorkingMode.Add);
        }

        [EventSubscription("CloseOptionDetailView", Thread = ThreadOption.UserInterface)]
        public void CloseOptionDetailView(object sender, EventArgs e)
        {
            IWorkspaceLocatorService locator = WorkItem.Services.Get<IWorkspaceLocatorService>();
            IWorkspace wks = locator.FindContainingWorkspace(WorkItem, sender);
            if (wks != null)
                wks.Close(sender);
        }

        [EventPublication("FreshOptionSet", PublicationScope.WorkItem)]
        public event EventHandler<DataEventArgs<Guid>> FreshOptionSet;

        private void ShowOptionSet(Guid optionSetId,EntityDetailWorkingMode workMode)
        {

            var optionView = WorkItem.Items.AddNew<OptionSetDetailView>();
            var presenter = WorkItem.Items.AddNew<OptionSetDetailPresenter>();
            presenter.optionSetId = optionSetId;
            presenter.WorkingMode = workMode;
            optionView.Presenter = presenter;
            var info = new XtraWindowSmartPartInfo { StartPosition = FormStartPosition.CenterParent, Icon=Properties.Resources.ri_Katrin, Modal = true, Title = "OptionSet" };
            WorkItem.Workspaces[WorkspaceNames.ModalWindows].Show(optionView, info);
            if (optionView.IsSave && FreshOptionSet != null)
            {
                FreshOptionSet(this,new DataEventArgs<Guid>(optionSetId));
            }

        }

        public void FreshOptionSetLookUp(Guid optionSetId, List<OptionSet> optionSetList, List<AttributePicklistValue> attributePickList)
        {
            AttributePickList = attributePickList;
             var items = optionSetList
                .Select(optionSet => new LookupListItem<Guid>
                {
                    DisplayName = optionSet.Name,
                    Value = optionSet.OptionSetId
                }).ToList();
            optionSetLookUpEdit.Properties.InitializeLookUpEdit(items);
            if (optionSetList.Count > 0)
            {
                if (optionSetId != Guid.Empty)
                {
                    optionSetLookUpEdit.EditValue = optionSetId;
                    BindDefaultValueLookUpEdit(optionSetId);
                }
                else
                {
                    optionSetLookUpEdit.EditValue = optionSetList[0].OptionSetId;
                    BindDefaultValueLookUpEdit(optionSetList[0].OptionSetId);
                }
            }
        }
        private void optionSetLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (optionSetLookUpEdit.EditValue.ToString() == "") return;
            Guid optionSetId = (Guid)optionSetLookUpEdit.EditValue;
            BindDefaultValueLookUpEdit(optionSetId);
        }
        #endregion

        #region float
        void InitFloatingPointPrecisionLookUpEdit()
        {
            int[] precisionList = { 1,2,3,4,5};
            var items = precisionList.Select(name => new LookupListItem<int>
            {
                DisplayName = name.ToString(),
                Value = name
            }).ToList();
            floatingPointPrecisionLookUpEdit.Properties.InitializeLookUpEdit(items);
            floatingPointPrecisionLookUpEdit.EditValue = 1;
        }
        #endregion

        #region decimal
        void InitDecimalPrecisionLookUpEdit()
        {
            int[] precisionList = { 1, 2, 3, 4, 5,6,7,8,9,10 };
            var items = precisionList.Select(name => new LookupListItem<int>
            {
                DisplayName = name.ToString(),
                Value = name
            }).ToList();
            decimalPrecisionLookUpEdit.Properties.InitializeLookUpEdit(items);
            decimalPrecisionLookUpEdit.EditValue = 1;
        }
        #endregion

        #region currency
        void InitCurrencyPrecisionLookUpEdit()
        {
            var precision = FormatTypeList.Where(c => c.FormatName == AttributeTypeEnum.Currency.ToString()).Select(c => c.FormatId).First();
            var precisionList = FormatTypeList.Where(c => c.FormatParentId == (Guid)precision).ToList();
            var items = precisionList.Select(name => new LookupListItem<string>
            {
                DisplayName = name.FormatName,
                Value = name.FormatName
            }).ToList();
            currencyPrecisionLookUpEdit.Properties.InitializeLookUpEdit(items);
            currencyPrecisionLookUpEdit.EditValue = -1;
        }
        #endregion

        #region dateTime
        void InitDateFormatLookUpEdit()
        {
            var format = FormatTypeList.Where(c => c.FormatName == AttributeTypeEnum.DateTime.ToString()).Select(c => c.FormatId).First();
            var formatList = FormatTypeList.Where(c => c.FormatParentId == (Guid)format).ToList();
            var items = formatList.Select(name => new LookupListItem<string>
            {
                DisplayName = name.FormatName,
                Value = name.FormatName
            }).ToList();
            dateFormatLookUpEdit.Properties.InitializeLookUpEdit(items);
            if(items.Any())
            dateFormatLookUpEdit.EditValue = items.First().Value;
        }
        #endregion

        #region lookUp
        void InitLookupTargetTypeLookUpEdit()
        {
            //string[] formatList = { "Account", "Appointment","Article" };
            var items = EntityList.Select(name => new LookupListItem<Guid>
            {
                DisplayName = name.PhysicalName,
                Value = name.EntityId
            }).ToList();
            lookupTargetTypeLookUpEdit.Properties.InitializeLookUpEdit(items);
            if (items.Count > 0)
            {
                lookupTargetTypeLookUpEdit.EditValue = items[0].Value;
                BindDisplayList(items[0].Value);
            }
        }
        private void lookupTargetTypeLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            var targetEntityId = (Guid)lookupTargetTypeLookUpEdit.EditValue;
            if (targetEntityId != null)
                BindDisplayList(targetEntityId);
        }
        private void BindDisplayList(Guid entityId)
        {
            var entity = EntityList.Where(c=>c.EntityId == entityId).FirstOrDefault();
            if (entity != null)
            {
                var items = entity.Attributes.Select(name => new LookupListItem<Guid>
                {
                    DisplayName = name.TableColumnName,
                    Value = name.AttributeId
                }).ToList();
                lookupTargetDisplayLookUpEdit.Properties.InitializeLookUpEdit(items);
            }
        }
        #endregion

        public bool IsSave
        {
            get;
            set;
        }

        public Relationship RelationShip
        {
            get;
            set;
        }

        [EventPublication("CloseAttributeDetailView", PublicationScope.WorkItem)]
        public event EventHandler CloseAttributeDetailView;


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }
            EntityAttribute attribute = EntityBindingSource.DataSource as EntityAttribute;
            if (attribute != null && typeLookUpEdit.EditValue.ToString() != "")
            {
                var formatType = FormatTypeList.Where(c => c.FormatName == typeLookUpEdit.Text).FirstOrDefault();
                if (formatType != null) attribute.AttributeTypeId = formatType.FormatParentId;
                var logical = FormatTypeList.Where(c => c.FormatName == attribute.LogicalType).FirstOrDefault();
                if (logical != null) logical = FormatTypeList.Where(c => c.FormatId == logical.FormatParentId).FirstOrDefault();
                if (logical != null)
                {
                    if (logical.FormatName != typeLookUpEdit.Text)
                        attribute.LogicalName = typeLookUpEdit.Text;
                }
                else
                {
                    attribute.LogicalType = typeLookUpEdit.Text;
                }

                #region confirm relation
                if (typeLookUpEdit.Text == AttributeTypeEnum.Lookup.ToString())
                {
                    if (!attribute.TableColumnName.EndsWith("Id"))
                    {
                        XtraMessageBox.Show("Display Name Must End With 'Id'!", Properties.Resources.Katrin, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (lookupTargetTypeLookUpEdit.Text != "")
                    {
                        var targetEntityId = (Guid)lookupTargetTypeLookUpEdit.EditValue;
                        var targetEntity = EntityList.Single(c => c.EntityId == targetEntityId);
                        var targetAttribute = targetEntity.Attributes.Where(c => c.IsPKAttribute ==true).FirstOrDefault();
                        if (targetAttribute != null)
                        {
                            Relationship relationShip = new Relationship();
                            relationShip.Name = lookupRelationshipTextEdit.Text.Trim();
                            relationShip.ReferencedEntityId = targetAttribute.EntityId;
                            relationShip.ReferencedAttributeId = targetAttribute.AttributeId;
                            relationShip.RelationshipType = 1;
                            relationShip.CascadeDelete = 1;
                            RelationShip = relationShip;
                        }
                        else
                        {
                            XtraMessageBox.Show("this target can't create relation!", Properties.Resources.Katrin, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                #endregion
            }
            IsSave = true;
            if (CloseAttributeDetailView != null)
                CloseAttributeDetailView(this, e);
        }

        protected  void SetValidationRule(Control control, ValidationRuleBase rule)
        {
            DXValidationProvider provider = ValidationProvider;
            provider.SetValidationRule(control, rule);
            provider.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
        }

        public  void InitValidation()
        {
            SetValidationRule(displayNameTextEdit, ValidationRules.IsNotBlankRule(displayNameLayoutControlItem.Text));
            SetValidationRule(nameTextEdit, ValidationRules.IsNotBlankRule(nameLayoutControlItem.Text));
        }

        public  bool ValidateData()
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

       
    }
}
