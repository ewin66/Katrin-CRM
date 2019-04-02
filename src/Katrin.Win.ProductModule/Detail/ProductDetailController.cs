using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using Katrin.Win.DetailViewModule;
namespace Katrin.Win.ProductModule.Detail
{
    public class ProductDetailController : ObjectDetailController
    {
        public override string ObjectName
        {
            get
            {
                return "Product";
            }
        }
    }
}
