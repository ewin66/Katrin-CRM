using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;
namespace Katrin.Win.MainModule.Views.Quote
{
    public class QuoteController : EntityListController<QuoteListView, QuoteDetailView>
    {
        protected override string EntityName
        {
            get { return "Quote"; }
        }
    }
}
