using System.Data.SqlClient;

namespace SpeedTyperDataAccess
{
    class DBConnection
    {
        internal static SqlConnection GetConnection()
        {
            var connString = @"Data Source=localhost;Initial Catalog=SpeedTyperDB;Integrated Security=True";
            var conn = new SqlConnection(connString);
            return conn;
        }
    }
}
