using System;
using System.Linq;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.WinForms.Views;

namespace Katrin.Win.AccountModule.Detail
{
    public partial class AccountDetailView : DetailView, IAccountDetailView
    {
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
