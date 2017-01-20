using DataAccess.Mappers;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;

namespace DataAccess.Connection
{
    public class DataConnection : IDataConnection
    {
        private ISession _connection;
        private readonly string _connectionString;

        public DataConnection(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public ISession Connection
        {
            get
            {
                if (_connection == null)
                {
                    var cfg = new Configuration();
                    var mapper = new ModelMapper();
                    mapper.AddMapping(typeof(PatientMap));
                    mapper.AddMapping(typeof(PatientNameMap));

                    cfg.DataBaseIntegration(c =>
                    {
                        c.ConnectionString = this._connectionString;

                        c.Driver<NHibernate.Driver.OracleManagedDataClientDriver>();
                        c.Dialect<NHibernate.Dialect.Oracle10gDialect>();
                    });
                    cfg.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());
                    _connection = cfg.BuildSessionFactory().OpenSession();
                }
                return _connection;
            }
        }

        public void Dispose()
        {
            if (this._connection != null)
            {
                this._connection.Close();
            }
        }
    }
}
