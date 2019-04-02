using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;

namespace Katrin.Win.MainModule.Views.Account
{
    public class AccountController:EntityListController<AccountListView,AccountDetailView>
    {
        protected override string EntityName
        {
            get { return "Account"; }
        }
    }
}
