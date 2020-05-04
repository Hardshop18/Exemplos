using System.Data.Common;
using System.Data.SqlClient;
using VfpClient;

namespace SyncWooCommerce.Ef
{
    public class GetEntityConnectionString
    {
        public static DbConnection EntityConnection(string conectar, string connectionString)
        {
            DbConnection dbConnection;
            switch (conectar)
            {
                case "VFP":
                    connectionString = connectionString.Replace("&quot;", "\"");
                    dbConnection = new VfpConnection(connectionString);
                    break;
                case "MSSQL":
                    dbConnection = new SqlConnection(connectionString);
                    break;
                /*case "MYSQL":
                    dbConnection = new MySqlConnection(connectionString);
                    break;
                case "POSTGRESQL":
                    dbConnection = new NpgsqlConnection(connectionString);
                    break;
                case "SQLITE":
                    dbConnection = new SQLiteConnection(connectionString);
                    break;*/
                default:
                    dbConnection = new SqlConnection("");
                    break;

            }
            return dbConnection;
        }
    }
}
