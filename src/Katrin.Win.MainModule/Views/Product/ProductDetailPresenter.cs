using System;
using System.Linq;
using Katrin.Win.Infrastructure;
using Microsoft.Practices.CompositeUI;
using Katrin.Win.Common.Core;
using Microsoft.Practices.CompositeUI.Commands;
using Katrin.Win.Common;
using System.Collections.Generic;
using System.Collections;
using Katrin.Win.Common.MetadataServiceReference;
namespace Katrin.Win.MainModule.Views.Product
{
    public class ProductDetailPresenter : EntityDetailPresenter<IProductDetailView>
    {
        public ProductDetailPresenter()
        {
            EntityName = "Product";
        }

    }
}
