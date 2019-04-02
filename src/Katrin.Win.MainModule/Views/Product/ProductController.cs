using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;
namespace Katrin.Win.MainModule.Views.Product
{
    public class ProductController:EntityListController<ProductListView,ProductDetailView>
    {
        protected override string EntityName
        {
            get { return "Product"; }
        }
    }
}
