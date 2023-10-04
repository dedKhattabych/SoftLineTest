using Microsoft.Extensions.Configuration;

namespace SoftLineTest.DAL
{
    public class ConnectionDb
    {
        public static string ConnectionString()
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            return connectionString;
        }
    }
}
