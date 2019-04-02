using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Katrin.AppFramework.WinForms.Controller;
namespace Katrin.Win.QuoteModule
{
    public class QuoteController : ListController
    {
       
        public override string ObjectName
        {
            get
            {
                return "Quote";
            }
        }
    }
}
