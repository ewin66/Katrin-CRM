using System;
using System.Linq;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.WinForms.Views;
using Katrin.Win.ProductModule.Detail;
namespace Katrin.Win.ProductModule.Detail
{
    public partial class ProductDetailView : DetailView, IProductDetailView
    {
        public ProductDetailView()
        {
            InitializeComponent();
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
            TransactionCurrencyLookUpEdit.BindLookupList(entity,true);
            ProductTypeCodeLookUpEdit.BindPickList(entity);
            StatusCodeLookUpEdit.BindPickList(entity);
        }
             
        public override void InitValidation()
        {
            SetValidationRule(NameTextEdit, ValidationRules.IsNotBlankRule(ItemForName.Text));
            SetValidationRule(ProductNumberTextEdit, ValidationRules.IsNotBlankRule(ItemForProductNumber.Text));
        }
    }
}
