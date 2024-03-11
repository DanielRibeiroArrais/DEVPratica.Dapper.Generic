using AutoMapper;
using DEVPratica.Dapper.Generic.Api.Mapper;
using DEVPratica.Dapper.Generic.Domain.Domain;
using DEVPratica.Dapper.Generic.Domain.Repositories;
using DEVPratica.Dapper.Generic.Domain.Services;
using DEVPratica.Dapper.Generic.Infra.Repositories;
using DEVPratica.Dapper.Generic.Infra.Services;
using System.Text;

namespace DEVPratica.Dapper.Generic.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("ConnectionStrings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();

            // BD
            Environment.SetEnvironmentVariable("SQLSERVER_HOST", appSettings.SQLSERVER_HOST);
            Environment.SetEnvironmentVariable("SQLSERVER_DATABASE", appSettings.SQLSERVER_DATABASE);
            Environment.SetEnvironmentVariable("SQLSERVER_USER", appSettings.SQLSERVER_USER);
            Environment.SetEnvironmentVariable("SQLSERVER_PASSWORD", appSettings.SQLSERVER_PASSWORD);
            Environment.SetEnvironmentVariable("SQLSERVER_ADDITIONAL_CONFIGS", appSettings.SQLSERVER_ADDITIONAL_CONFIGS);
        }

        public static void RepositoryMap(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionConfig, ConnectionConfig>(sp =>
            {
                return new(
                    GetDBConnectionString()
                );
            });

            services.AddScoped<DbContext>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }

        public static string GetDBConnectionString()
        {
            StringBuilder sbConnectionString = new();

            sbConnectionString.Append("server=");
            sbConnectionString.Append(Environment.GetEnvironmentVariable("SQLSERVER_HOST"));
            sbConnectionString.Append(';');
            sbConnectionString.Append("database=");
            sbConnectionString.Append(Environment.GetEnvironmentVariable("SQLSERVER_DATABASE"));
            sbConnectionString.Append(';');
            sbConnectionString.Append("user id=");
            sbConnectionString.Append(Environment.GetEnvironmentVariable("SQLSERVER_USER"));
            sbConnectionString.Append(';');
            sbConnectionString.Append("password=");
            sbConnectionString.Append(Environment.GetEnvironmentVariable("SQLSERVER_PASSWORD"));
            sbConnectionString.Append(';');
            sbConnectionString.Append(Environment.GetEnvironmentVariable("SQLSERVER_ADDITIONAL_CONFIGS"));

            return sbConnectionString.ToString();
        }

        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            var config = AutoMapperConfig.RegisterMapper();

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
