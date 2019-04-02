using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Web;

namespace Katrin.Services
{
    public class KatrinDbContext : DbContext
    {
        public Action NotificationAction;

        public override int SaveChanges()
        {
            int result =  base.SaveChanges();
            if (NotificationAction != null)
                NotificationAction();
            return result;
        }


        protected KatrinDbContext()
        {
            
        }
        
        protected KatrinDbContext(DbCompiledModel model):base(model)
        {
           
        }

        public KatrinDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        public KatrinDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }
        
        public KatrinDbContext(ObjectContext objectContext, bool dbContextOwnsObjectContext)
            : base(objectContext, dbContextOwnsObjectContext)
        {

        }
        
        public KatrinDbContext(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {

        }

        public KatrinDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

    }
}
