using System;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.MetadataServiceReference;
using System.Collections.Generic;
using Microsoft.Practices.ObjectBuilder;
using Katrin.Win.Common.Controls;
namespace Katrin.Win.MainModule.Views.Account
{
    public partial class AccountDetailView : AbstractDetailView, IAccountDetailView
    {
        private AccountDetailPresenter _presenter;

        [CreateNew]
        public AccountDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        public AccountDetailView()
        {
            InitializeComponent();
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
            CustomerTypeCodeTextEdit.BindPickList(entity);
            AccountClassificationCodeTextEdit.BindPickList(entity);
            AccountCategoryCodeTextEdit.BindPickList(entity);
            IndustryCodeTextEdit.BindPickList(entity);
            AccountRatingCodeTextEdit.BindPickList(entity);
            OwnershipCodeTextEdit.BindPickList(entity);
            CountryLookUpEdit.BindComboBoxList(entity, "CountryCode");
            //OwnerIdLookUpEdit.Bind(entity);
            OwnerIdLookUpEdit.InitEdit("User", "Department", false);
            PrimaryContactIdLookUpEdit.Bind(entity);
            OriginatingLeadIdLookUpEdit.Bind(entity);
            DepartmentIdLookUpEdit.BindLookupList(entity, true);
            
        }

        public override void InitValidation()
        {
            SetValidationRule(NameTextEdit, ValidationRules.IsNotBlankRule(ItemForName.Text));
            SetValidationRule(OwnerIdLookUpEdit, ValidationRules.IsNotBlankRule(ItemForOwnerId.Text));
            SetValidationRule(OwnerIdLookUpEdit, ValidationRules.IsGuidNotBlankRule(ItemForOwnerId.Text));
        }
    }
}
