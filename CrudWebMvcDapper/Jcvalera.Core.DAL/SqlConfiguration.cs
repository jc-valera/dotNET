using System.Data.SqlClient;

namespace Jcvalera.Core.DAL
{
    public class SqlConfiguration
    {
        public string ConnectionString;

        public SqlConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        } 

        public async Task<SqlConnection> GetConnection()
        {
            var connection = new SqlConnection(ConnectionString);

            await connection.OpenAsync();

            return connection;
        }
    }
}
