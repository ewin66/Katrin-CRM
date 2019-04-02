using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.MVC.Data;
using Katrin.AppFramework.WinForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework;
using Katrin.AppFramework.WinForms.Grid;
using Katrin.AppFramework.WinForms;
using ICSharpCode.Core;

namespace Katrin.Win.ProductModule
{
    public class ProductController : ListController
    {
        public override string ObjectName
        {
            get
            {
                return "Product";
            }
        }

        protected override string RibbonPath
        {
            get { return "/Product/List/Ribbon"; }
        }
    }
}
