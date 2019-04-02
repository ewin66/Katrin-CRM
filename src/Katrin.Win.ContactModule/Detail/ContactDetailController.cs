using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.Metadata;

namespace Katrin.Win.ContactModule.Detail
{
    public class ContactDetailController : ObjectDetailController
    {
        private const int ContactStatusCodeDefaultValue = 1;
        public override string ObjectName
        {
            get
            {
                return "Contact";
            }
        }
        protected override bool OnSaving()
        {
            base.OnSaving();
            var contact = (Katrin.Domain.Impl.Contact)ObjectEntity;
            contact.StatusCode = ContactStatusCodeDefaultValue;
            string firstName = contact.FirstName;
            string lastName = contact.LastName;
            contact.FullName = firstName + " " + lastName;
            if (contact.OriginatingLeadId == null) return true;
            var leadEntity = (Katrin.Domain.Impl.Lead)_objectSpace.GetOrNew("Lead", contact.OriginatingLeadId ?? Guid.Empty, null);
            leadEntity.StatusCode = 4;
            _objectSpace.SaveChanges();
            return true;
        }
    }
}
