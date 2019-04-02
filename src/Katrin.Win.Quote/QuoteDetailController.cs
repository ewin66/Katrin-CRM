using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Collections;
using Katrin.Win.DetailViewModule;
using Katrin.Domain.Impl;
using Katrin.AppFramework;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.Extensions;

namespace Katrin.Win.QuoteModule
{
    public class QuoteDetailController : ObjectDetailController
    {
        private IList productList;

        public QuoteDetailController()
        {
          
        }

        public override string ObjectName
        {
            get
            {
                return "Quote";
            }
        }

        void ViewQuoteLineItemSelectProductChanged(object sender, EventArgs e)
        {
            QuoteDetailView view = this._detailView as QuoteDetailView;
            QuoteLineItem currentLineItem = view.CurrentQuoteLineItem as QuoteLineItem;
    
            Guid? productId = currentLineItem.ProductId;


            var product = productList.AsQueryable().Where("ProductId = @0", productId)._First();
      
            if (product != null)
            {            
                Product pro = product as Product;
                currentLineItem.UnitPrice = pro.Price;
            }
            UpdateQuoteRelationAmount();
        }

        void ViewCalculateTotalAmount(object sender, EventArgs e)
        {
            UpdateQuoteRelationAmount();
        }

        void UpdateQuoteRelationAmount()
        {
            QuoteDetailView view = this._detailView as QuoteDetailView;
            view.PostEditors();
           Quote quote = this.ObjectEntity as Quote;

            var quoteLineItems = quote.QuoteLineItems;
            decimal totalLineItemAmount = 0;
            foreach (QuoteLineItem item in quoteLineItems)
            {
                QuoteLineItem currentLineItem = item;               
                decimal unitPrice = currentLineItem.UnitPrice ?? 0;
                decimal quantity = currentLineItem.Quantity ?? 0;

                decimal totalPrice = unitPrice * quantity;
                currentLineItem.TotalPrice = totalPrice;
                currentLineItem.QuoteId = this.ObjectId;
                totalLineItemAmount += totalPrice;
            }
            quote.TotalLineItemAmount = totalLineItemAmount;
            decimal totalDiscountAmount = quote.TotalDiscountAmount ?? 0;
            decimal totalTax = quote.TotalTax ?? 0;
            quote.TotalAmount = totalLineItemAmount - totalDiscountAmount + totalTax;
        }

        protected override object GetEntity()
        {
            var entity = this._objectSpace.GetOrNew(this.ObjectName, this.ObjectId, "QuoteLineItems,BillTo_Address,CreatedBy,ModifiedBy");
            return entity;
        }

        protected override void OnViewSet()
        {
            base.OnViewSet();
            QuoteDetailView view = this._detailView as QuoteDetailView;
            view.NewQuoteLineItem += View_NewQuoteLineItem;
            view.RemoveQuoteLineItem += ViewRemoveQuoteLineItem;
            view.CalculateTotalAmount += ViewCalculateTotalAmount;
            view.QuoteLineItemSelectProductChanged += ViewQuoteLineItemSelectProductChanged;

            productList = this._objectSpace.GetObjects("Product");
            view.PoppulateProducts(productList);
        }


        void ViewRemoveQuoteLineItem(object sender, EventArgs e)
        {
            QuoteDetailView view = this._detailView as QuoteDetailView;
            view.DeleteSelectedQuoteLineItem();
            UpdateQuoteRelationAmount();
        }

        void View_NewQuoteLineItem(object sender, EventArgs e)
        {
            QuoteDetailView view = this._detailView as QuoteDetailView;
            view.AddNewQuoteLineItem();
        }
    }
}
