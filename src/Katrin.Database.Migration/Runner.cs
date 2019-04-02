using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Katrin.Database.Migrations
{
    public class Runner
    {
        [STAThread]
        static void Main()
        {
            string connectionString=  ConfigurationManager.ConnectionStrings["Deploy"].ConnectionString;
            //var builder = new SqlConnectionStringBuilder(connectionString);

            //CreateDatabase(connectionString, builder);

            MigrateToLatest(connectionString);
        }

        private static void CreateDatabase(string connectionString, SqlConnectionStringBuilder builder)
        {

            var masterConnectionBuilder = new SqlConnectionStringBuilder(connectionString);
            masterConnectionBuilder.InitialCatalog = "master";

            using (SqlConnection myConn = new SqlConnection(masterConnectionBuilder.ConnectionString))
            {
                String str = "CREATE DATABASE " + builder.InitialCatalog;
                myConn.Open();
                bool isDBExists = CheckDatabaseExists(myConn, builder.InitialCatalog);
                if (isDBExists) return;
                SqlCommand myCommand = new SqlCommand(str, myConn);
                myCommand.ExecuteNonQuery();
            }
        }

        private static bool CheckDatabaseExists(SqlConnection tmpConn, string databaseName)
        {
            string sqlCreateDBQuery;
            bool result = false;

            sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);

            using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
            {
                int databaseID = (int)sqlCmd.ExecuteScalar();

                result = (databaseID > 0);
            }
            return result;
        }

        public class MigrationOptions : IMigrationProcessorOptions
        {
            public bool PreviewOnly { get; set; }
            public int Timeout { get; set; }
        }

        public static void MigrateToLatest(string connectionString)
        {
            var announcer = new TextWriterAnnouncer(s => Console.WriteLine(s));
            var assembly = Assembly.GetExecutingAssembly();

            var migrationContext = new RunnerContext(announcer)
            {
                Namespace = "Katrin.Database.Migrations"
            };

            var options = new MigrationOptions { PreviewOnly = false, Timeout = 60 };
            var factory = new FluentMigrator.Runner.Processors.SqlServer.SqlServer2008ProcessorFactory();
            var processor = factory.Create(connectionString, announcer, options);
            var runner = new MigrationRunner(assembly, migrationContext, processor);
            runner.MigrateUp(true);
        }
    }
}
