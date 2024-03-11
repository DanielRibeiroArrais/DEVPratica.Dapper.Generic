namespace DEVPratica.Dapper.Generic.Domain.Domain
{
    public class AppSettings
    {
        public required string SQLSERVER_HOST { get; set; }
        public required string SQLSERVER_DATABASE { get; set; }
        public required string SQLSERVER_USER { get; set; }
        public required string SQLSERVER_PASSWORD { get; set; }
        public required string SQLSERVER_ADDITIONAL_CONFIGS { get; set; }
    }
}
