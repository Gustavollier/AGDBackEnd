using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace Infrastructure.Data;
public sealed class DbSession : IDisposable
{
    public DbSession(IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("MySqlDb");
        Connection = new MySqlConnection(connectionString);
        Connection.Open();
    }

    public IDbConnection Connection { get;}
   
    public void Dispose() => Connection.Dispose();
}
