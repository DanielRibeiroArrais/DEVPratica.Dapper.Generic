using DEVPratica.Dapper.Generic.Domain.Services;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;

namespace DEVPratica.Dapper.Generic.Infra.Services
{
    public sealed class DbContext : IDisposable
    {
        public SqlConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }
        private ILogger<DbContext> _logger { get; set; }

        public DbContext(IConnectionConfig connectionConfig, ILogger<DbContext> logger)
        {
            logger.LogDebug("Criando Conexão");
            var stringConnection = connectionConfig.GetConnectionString();
            Connection = new SqlConnection(stringConnection);
            Connection.Open();
            _logger = logger;
        }

        public void Dispose()
        {
            _logger.LogDebug("Fechando Conexão");
            Connection?.Dispose();
        }
    }
}