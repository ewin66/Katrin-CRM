using System;
using System.Data.SqlClient;

namespace DBConfigAction
{
    public class Helper
    {
        public static bool DatabaseConnectionTest(string sqlString)
        {
            var mySqlConnection = new SqlConnection(sqlString);
            bool isCanConnectioned;
            try
            {
                mySqlConnection.Open();
                isCanConnectioned = true;
            }
            catch (Exception)
            {
                isCanConnectioned = false;
            }
            finally
            {
                mySqlConnection.Close();
            }
            return isCanConnectioned;
        }
    }
}
