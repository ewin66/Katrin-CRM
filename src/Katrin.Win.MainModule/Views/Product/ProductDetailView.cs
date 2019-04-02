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
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI.SmartParts;
using Katrin.Win.Common.Controls;
using Katrin.Win.Common.Controls;
namespace Katrin.Win.MainModule.Views.Product
{
    [SmartPart]
    public partial class ProductDetailView : AbstractDetailView, IProductDetailView
    {
        private  ProductDetailPresenter _presenter;

        [CreateNew]
        public ProductDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }
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
