using System;
using System.Linq;
using Microsoft.Practices.ObjectBuilder;
using Katrin.Win.Common.MetadataServiceReference;
using Katrin.Win.Common.Core;
using Katrin.Win.MainModule.Views.User;
using Katrin.Win.Common.Controls;
namespace Katrin.Win.MainModule.Views.Lead
{
    public partial class LeadDetailView : AbstractDetailView, ILeadDetailView
    {
        private LeadDetailPresenter _presenter;
        /// <summary>
        /// Sets the presenter. The dependency injection system will automatically
        /// create a new presenter for you.
        /// </summary>
        [CreateNew]
        public LeadDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        public LeadDetailView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _presenter.OnViewReady();
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
            DepartmentIdLookUpEdit.BindLookupList(entity, true);
            OwnerIdSearchLookUpEdit.InitEdit("User", "Department", false);
            //OwnerIdSearchLookUpEdit.Bind(entity);
            OwnerIdSearchLookUpEdit.AddDetailButton<UserDetailView>(OpenDetail, "User");
            LeadSourceCodeLookUpEdit.BindPickList(entity);
            CountryLookUpEdit.BindComboBoxList(entity, "CountryCode");
            PriorityCodeLookUpEdit.BindPickList(entity);
            StatusCodeLookUpEdit.BindPickList(entity);
            technologyCodeLookUpEdit.BindPickList(entity);
        }

        public override void InitValidation()
        {
            SetValidationRule(SubjectTextEdit, ValidationRules.IsNotBlankRule(ItemForSubject.Text));
            SetValidationRule(FirstNameTextEdit, ValidationRules.IsNotBlankRule(ItemForFirstName.Text));
            SetValidationRule(LastNameTextEdit, ValidationRules.IsNotBlankRule(ItemForLastName.Text));
            SetValidationRule(OwnerIdSearchLookUpEdit, ValidationRules.IsGuidNotBlankRule(ItemForOwnerId.Text));
            SetValidationRule(StatusCodeLookUpEdit, ValidationRules.IsNotZeroRule(ItemForStatusCode.Text));
        }
    }
}
