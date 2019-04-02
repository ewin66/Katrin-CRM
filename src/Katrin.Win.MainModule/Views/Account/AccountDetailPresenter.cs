using System;
using System.Linq;
using System.Windows.Forms;
using Katrin.Win.Infrastructure;
using Microsoft.Practices.CompositeUI;
using Katrin.Win.Common.Core;
using Microsoft.Practices.CompositeUI.Commands;
using Katrin.Win.Common;
using System.Collections.Generic;
using System.Collections;
using Katrin.Win.Common.MetadataServiceReference;
namespace Katrin.Win.MainModule.Views.Account
{
    public class AccountDetailPresenter : EntityDetailPresenter<IAccountDetailView>
    {

        private const int AccountStatusCodeDefaultValue = 1;

        public AccountDetailPresenter()
        {
            EntityName = "Account";
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            DynamicEntity.StatusCode = AccountStatusCodeDefaultValue;
        }

        protected override void OnSaved()
        {
            base.OnSaved();
            if (DynamicEntity.OriginatingLeadId == null) return;
            var leadEntity = DynamicDataServiceContext.GetOrNew("Lead", DynamicEntity.OriginatingLeadId);
            leadEntity.StatusCode = 4;
            DynamicDataServiceContext.SaveChanges();
        }
    }
}
