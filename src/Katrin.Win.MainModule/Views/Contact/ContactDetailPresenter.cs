using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.Infrastructure;
using Microsoft.Practices.CompositeUI;
using Katrin.Win.Common.Core;
using Microsoft.Practices.CompositeUI.Commands;
using Katrin.Win.Common;
using System.Collections;
using Katrin.Win.Common.MetadataServiceReference;
namespace Katrin.Win.MainModule.Views.Contact
{
    public class ContactDetailPresenter : EntityDetailPresenter<IContactDetailView>
    {
        public ContactDetailPresenter()
        {
            EntityName = "Contact";
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            string firstName = DynamicEntity.FirstName;
            string lastName = DynamicEntity.LastName;
            DynamicEntity.FullName = firstName + " " + lastName;
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
