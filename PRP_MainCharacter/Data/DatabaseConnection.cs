using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace PRP.Data {
    public class DatabaseConnection
{
    private readonly IConfiguration _config;

    public DatabaseConnection()
    {
        _config = new ConfigurationBuilder()
            .AddUserSecrets<DatabaseConnection>()
            .Build();
    }

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(
            $"server=localhost;" +
            $"database=world;" +
            $"uid=root;" +
            $"pwd={_config["DBPassword"]};" +
            "Port=3306;" +
            "SslMode=Required;");
    }
}
}