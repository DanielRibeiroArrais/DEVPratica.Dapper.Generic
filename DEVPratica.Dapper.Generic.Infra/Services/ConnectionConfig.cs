using DEVPratica.Dapper.Generic.Domain.Services;

namespace DEVPratica.Dapper.Generic.Infra.Services
{
    public class ConnectionConfig : IConnectionConfig
    {
        private readonly string _connection;

        public ConnectionConfig(string connection)
        {
            _connection = connection;
        }

        public string GetConnectionString()
        {
            return _connection;
        }
    }
}