using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Services.Providers;
using System.Data.Services;
using System.Data.Services.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections;
using System.ServiceModel;
using Katrin.Services.Metadata;
using System.Web;

namespace Katrin.Services
{

    public class EntityDataService : DataService<DbContext>
    {

        protected override void HandleException(HandleExceptionArgs args)
        {
            base.HandleException(args);
        }

        public EntityDataService()
        {
            
            this.ProcessingPipeline.ProcessingRequest += new EventHandler<DataServiceProcessingPipelineEventArgs>(ProcessingPipeline_ProcessingRequest);
        }


        protected override DbContext CreateDataSource()
        {
            return DynamicModelBuilder.CreateDataSource();
        }

        void ProcessingPipeline_ProcessingRequest(object sender, DataServiceProcessingPipelineEventArgs e)
        {
            var name = HttpContext.Current.User.Identity.Name;
            //if (!HttpContext.Current.Request.IsAuthenticated)
            //    throw new DataServiceException(401, "401 Unauthorized");
        }

        


        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
            config.DataServiceBehavior.AcceptProjectionRequests = true;
            config.DataServiceBehavior.AcceptCountRequests = true;
            config.UseVerboseErrors = true;
        }
    }
}
