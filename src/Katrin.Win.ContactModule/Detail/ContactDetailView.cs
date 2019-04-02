using System;
using System.Linq;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.WinForms.Views;

namespace Katrin.Win.ContactModule.Detail
{
    public partial class ContactDetailView : DetailView, IContactDetailView
    {
        public ContactDetailView()
        {
            InitializeComponent();
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
            AccountRoleCodeLookUpEdit.BindPickList(entity);
            GenderCodeLookUpEdit.BindPickList(entity);
            HasChildrenCodeLookUpEdit.BindPickList(entity);
            EducationCodeLookUpEdit.BindPickList(entity);
            FamilyStatusCodeLookUpEdit.BindPickList(entity);
            OwnerIdLookUpEdit.InitEdit("User", "Department", false);
            ParentCustomerIdLookUpEdit.BindLookupList(entity, false);
            OriginatingLeadIdLookUpEdit.BindLookupList(entity, false);
        }
   
        public override void InitValidation()
        {

            SetValidationRule(FirstNameTextEdit, ValidationRules.IsNotBlankRule(ItemForFirstName.Text));
            SetValidationRule(LastNameTextEdit, ValidationRules.IsNotBlankRule(ItemForLastName.Text));
            SetValidationRule(OwnerIdLookUpEdit, ValidationRules.IsNotBlankRule(ItemForOwnerId.Text));
            SetValidationRule(OwnerIdLookUpEdit, ValidationRules.IsGuidNotBlankRule(ItemForOwnerId.Text));
        }
    }
}
