using System.Data.SqlClient;

namespace App.Repositories
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            var sqlConnection = new SqlConnection(_connectionString);

            sqlConnection.Open();

            return sqlConnection;
        }
    }

    public interface ISqlConnectionFactory
    {
        SqlConnection GetConnection();
    }
}
