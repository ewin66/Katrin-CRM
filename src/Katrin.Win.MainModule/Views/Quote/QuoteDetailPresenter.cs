using System;
using System.Linq;
using System.Linq.Dynamic;
using Katrin.Win.Common.Core;
using System.Collections;

namespace Katrin.Win.MainModule.Views.Quote
{
    public class QuoteDetailPresenter : EntityDetailPresenter<IQuoteDetailView>
    {
        private IList productList;

        public QuoteDetailPresenter()
        {
            EntityName = "Quote";
        }

        void ViewQuoteLineItemSelectProductChanged(object sender, EventArgs e)
        {
            dynamic currentLineItem = new SysBits.DynamicProxies.DynamicProxy(View.CurrentQuoteLineItem);
            object productId = currentLineItem.ProductId;
            var product = productList.AsQueryable().Where("ProductId = @0", productId)._First();
            if(product !=null)
            {
                dynamic dynamicProduct = new SysBits.DynamicProxies.DynamicProxy(product);
                currentLineItem.UnitPrice = dynamicProduct.Price;
            }
            UpdateQuoteRelationAmount();
        }

        void ViewCalculateTotalAmount(object sender, EventArgs e)
        {
            UpdateQuoteRelationAmount();
        }

        void UpdateQuoteRelationAmount()
        {
            View.PostEditors();
            IEnumerable quoteLineItems = DynamicEntity.QuoteLineItems;
            decimal totalLineItemAmount = 0;
            foreach (object item in quoteLineItems)
            {
                dynamic currentLineItem = new SysBits.DynamicProxies.DynamicProxy(item);
                decimal unitPrice = currentLineItem.UnitPrice??0;
                decimal quantity = currentLineItem.Quantity??0;

                decimal totalPrice = unitPrice*quantity;
                currentLineItem.TotalPrice = totalPrice;
                currentLineItem.QuoteId = EntityId;
                totalLineItemAmount += totalPrice;
            }
            DynamicEntity.TotalLineItemAmount = totalLineItemAmount;
            decimal totalDiscountAmount = DynamicEntity.TotalDiscountAmount??0;
            decimal totalTax = DynamicEntity.TotalTax??0;
            DynamicEntity.TotalAmount = totalLineItemAmount - totalDiscountAmount + totalTax;
        }

        protected override object GetEntity()
        {
            var entity = DynamicDataServiceContext.GetOrNew(EntityName, EntityId, "QuoteLineItems,BillTo_Address,CreatedBy,ModifiedBy");
            return entity;
        }

        protected override void OnViewSet()
        {
            base.OnViewSet();

            View.NewQuoteLineItem += View_NewQuoteLineItem;
            View.RemoveQuoteLineItem += ViewRemoveQuoteLineItem;
            View.CalculateTotalAmount += ViewCalculateTotalAmount;
            View.QuoteLineItemSelectProductChanged += ViewQuoteLineItemSelectProductChanged;

            productList = DynamicDataServiceContext.GetObjects("Product");
            View.PoppulateProducts(productList);
        }


        void ViewRemoveQuoteLineItem(object sender, EventArgs e)
        {
            View.DeleteSelectedQuoteLineItem();
            UpdateQuoteRelationAmount();
        }

        void View_NewQuoteLineItem(object sender, EventArgs e)
        {
            View.AddNewQuoteLineItem();
        }
    }
}
