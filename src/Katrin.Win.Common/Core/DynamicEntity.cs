using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Katrin.Win.Common.Core
{
    public class DynamicEntity : DynamicObject
    {
        private object _entity;
        public DynamicEntity(object entity)
        {
            _entity = entity;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return base.TryGetMember(binder, out result);
        }
    }
}
