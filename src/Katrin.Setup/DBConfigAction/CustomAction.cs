using Microsoft.Deployment.WindowsInstaller;

namespace DBConfigAction
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult ConnectDataBase(Session session)
        {
            var databaseName = session["DBNAME"];
            var serverName = session["SERVERNAME"];
            var authentication = session["SETUPCONNECTIONLIST"];
            var username = session["DBUSERNAME"];
            var password = session["DBPASSWORD"];

            string connectionString;
            if (authentication == "WINDOWS")
            {
                connectionString = "Server=" + serverName + ";Initial Catalog=" + databaseName + ";Integrated Security=SSPI";
            }
            else
            {
                connectionString = "Data Source=" + serverName + ";Initial Catalog=" + databaseName + ";User Id=" + username + ";Password=" + password;
            }

            if (Helper.DatabaseConnectionTest(connectionString))
            {
                session["CONNECTIONSTRING"] = connectionString;
                session["CONNECTSUCCESS"] = "1";
            }
            return ActionResult.Success;
        }
    }
}
