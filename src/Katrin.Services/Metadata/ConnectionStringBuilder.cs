using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.EntityClient;

namespace Katrin.Services.Metadata
{
    public partial class KatrinEntities
    {
        public KatrinEntities(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public static KatrinEntities CreateInstance()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Katrin"].ConnectionString;
            var entityBuilder = new EntityConnectionStringBuilder
                                    {
                                        Provider = "System.Data.SqlClient",
                                        ProviderConnectionString = connectionString,
                                        Metadata =
                                            "res://*/Metadata.MetadataModel.csdl|res://*/Metadata.MetadataModel.ssdl|res://*/Metadata.MetadataModel.msl"
                                    };

            string entityConnectionString = entityBuilder.ToString();

            return new KatrinEntities(entityConnectionString);
        }
    }
}
