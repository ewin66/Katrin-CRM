using System;
using System.Linq;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.WinForms.Views;
using DevExpress.XtraEditors;
using ICSharpCode.Core;
using System.Windows.Forms;

namespace Katrin.Win.LeadModule.Detail
{
    public partial class LeadDetailView : DetailView, ILeadDetailView
    {
        private LeadDetailController _presenter;
        /// <summary>
        /// Sets the presenter. The dependency injection system will automatically
        /// create a new presenter for you.
        /// </summary>
        //public LeadDetailController Presenter
        //{
        //    set
        //    {
        //        _presenter = value;
        //        _presenter.View = this;
        //    }
        //}

        //public override void ShowView()
        //{
        //    ObjectViewModel viewModal = this.Model as ObjectViewModel;
        //    LeadDetailController leadPresenter = new LeadDetailController();
        //    leadPresenter.ConvertEntiy = null;
        //    leadPresenter.ConvertName = null;
        //    leadPresenter.ObjectId = viewModal.ObjectId;
        //    leadPresenter.ObjectName = viewModal.ObjectName;
        //    leadPresenter.WorkingMode = viewModal.WorkMode;
        //    Presenter = leadPresenter;
        //    base.ShowView();
        //}

        public LeadDetailView()
        {
            // this._presenter
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //_presenter.OnViewReady();
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
            DepartmentIdLookUpEdit.BindLookupList(entity, true);
            OwnerIdSearchLookUpEdit.InitEdit("User", "Department", false);
            OwnerIdSearchLookUpEdit.AddDetailButton("User");
            LeadSourceCodeLookUpEdit.BindPickList(entity);
            CountryLookUpEdit.BindComboBoxList(entity, "CountryCode");
            PriorityCodeLookUpEdit.BindPickList(entity);
            StatusCodeLookUpEdit.BindPickList(entity);
            technologyCodeLookUpEdit.BindComboBoxList(entity, "TechnologyCode");
        }

        public override void InitValidation()
        {
            SetValidationRule(SubjectTextEdit, ValidationRules.IsNotBlankRule(ItemForSubject.Text));
            SetValidationRule(FirstNameTextEdit, ValidationRules.IsNotBlankRule(ItemForFirstName.Text));
            SetValidationRule(LastNameTextEdit, ValidationRules.IsNotBlankRule(ItemForLastName.Text));
            SetValidationRule(OwnerIdSearchLookUpEdit, ValidationRules.IsGuidNotBlankRule(ItemForOwnerId.Text));
            SetValidationRule(StatusCodeLookUpEdit, ValidationRules.IsNotZeroRule(ItemForStatusCode.Text));
        }

        private void SetClosingTime()
        {
            if (closingTimeDateEdit != null && closingTimeDateEdit.EditValue == System.DBNull.Value)
            {
                if (EntityBindingSource.Current is Katrin.Domain.Impl.Lead)
                {
                    var lead = (Katrin.Domain.Impl.Lead)EntityBindingSource.Current;
                    if (StatusCodeLookUpEdit.ItemIndex != -1)
                        lead.StatusCode = StatusCodeLookUpEdit.ItemIndex + 1;
                }
                closingTimeDateEdit.EditValue = DateTime.Now;
            }
        }
        private void ClearClosingTime()
        {
            if (closingTimeDateEdit != null && !string.IsNullOrEmpty(closingTimeDateEdit.Text))
            {
                if (EntityBindingSource.Current is Katrin.Domain.Impl.Lead)
                {
                    var lead = (Katrin.Domain.Impl.Lead)EntityBindingSource.Current;
                    if (StatusCodeLookUpEdit.ItemIndex != -1)
                        lead.StatusCode = StatusCodeLookUpEdit.ItemIndex + 1;
                }
                closingTimeDateEdit.EditValue = System.DBNull.Value;
            }
        }
        private void StatusCodeLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (StatusCodeLookUpEdit.ItemIndex == 5 || StatusCodeLookUpEdit.ItemIndex == 3)
            {
                SetClosingTime();
            }
            else
            {
                ClearClosingTime();
            }
        }
    }
}
