using Oracle.ManagedDataAccess.Client;
using System.Data.Common;
using System.Data;

namespace DataAccess.Connection
{
    public class DataConnection : IDataConnection
    {
        private DbConnection _connection;
        private readonly string _connectionString;

        public DataConnection(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public DbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new OracleConnection(this._connectionString);
                    _connection.Open();
                }
                return _connection;

            }
        }

        public void Dispose()
        {
            if (this._connection != null &&
                this._connection.State == ConnectionState.Open)
            {
                this._connection.Close();
            }
        }
    }
}
