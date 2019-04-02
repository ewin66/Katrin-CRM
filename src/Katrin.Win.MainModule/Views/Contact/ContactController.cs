using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;

namespace Katrin.Win.MainModule.Views.Contact
{
    public class ContactController:EntityListController<ContactListView,ContactDetailView>
    {
        protected override string EntityName
        {
            get { return "Contact"; }
        }
    }
}
