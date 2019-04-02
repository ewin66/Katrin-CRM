using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevExpress.XtraGrid.Views.Grid;

using System.Collections;
using Katrin.AppFramework.WinForms.ViewInterface;
namespace Katrin.Win.QuoteModule
{
    public interface IQuoteDetailView : IObjectDetailView
    {

        void PoppulateProducts(IEnumerable products);
        void DeleteSelectedQuoteLineItem();
        object CurrentQuoteLineItem { get; }

        void AddNewQuoteLineItem();
        event EventHandler NewQuoteLineItem;
        event EventHandler QuoteLineItemSelectProductChanged;
        event EventHandler RemoveQuoteLineItem;
        event EventHandler CalculateTotalAmount;

    }
}
