using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.Metadata;

namespace Katrin.Win.AccountModule.Detail
{
    public class AccountDetailController:ObjectDetailController
    {
        private const int AccountStatusCodeDefaultValue = 1;
        public override string ObjectName
        {
            get
            {
                return "Account";
            }
        }
        protected override bool OnSaving()
        {
            base.OnSaving();
            var account = (Katrin.Domain.Impl.Account)ObjectEntity;
            account.StatusCode = AccountStatusCodeDefaultValue;
            if (account.OriginatingLeadId == null) return true;
            var leadEntity = (Katrin.Domain.Impl.Lead)_objectSpace.GetOrNew("Lead", account.OriginatingLeadId ?? Guid.Empty, null);
            leadEntity.StatusCode = 4;
            _objectSpace.SaveChanges();
            return true;
        }
    }
}
