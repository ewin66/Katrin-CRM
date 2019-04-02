using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.Common.Core;
using DevExpress.XtraGrid.Views.Grid;
using Katrin.Win.Common.MetadataServiceReference;
using System.Collections;
namespace Katrin.Win.MainModule.Views.Quote
{
    public interface IQuoteDetailView : IEntityDetailView
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
