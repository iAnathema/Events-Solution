using System.ComponentModel;

namespace EventsPortal.AppSettings
{
    public class Settings
    {
        public static ConnectionSettings ConnectionSettings { get; set; }
        public static Cors Cors { get; set; }
        public static Authentication Authentication { get; set; }
        public static string BLLAssembly { get; set; }
    }

    public class Authentication
    {
        public string Audience { get; set; }
        public bool RequireHttpsMetadata { get; set; }
        public string Authority { get; set; }
    }

    public class Cors
    {
        public string[] Hubs { get; set; }
        public string[] Headers { get; set; }
    }
    public class ConnectionSettings
    {
        public string DBConnectionString { get; set; }
        public ConnectionType DBConnectionType { get; set; }
        public string MigrationAssemblyName { get; set; }
    }

    public enum ConnectionType{
        [Description("SqlServer")]
        SqlServer,
        [Description("SqlLite")]
        SqlLite
    }
}
