using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.MetadataServiceReference;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Katrin.Win.Common.Controls;
namespace Katrin.Win.MainModule.Views.Contact
{
    [SmartPart]
    public partial class ContactDetailView : AbstractDetailView, IContactDetailView
    {
        private ContactDetailPresenter _presenter;

        [CreateNew]
        public ContactDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

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
            //OwnerIdLookUpEdit.BindLookupList(entity, false);
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
