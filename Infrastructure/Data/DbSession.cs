using Oracle.ManagedDataAccess.Client;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Data;
public sealed class DbSession : IDisposable
{
    public DbSession(IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("OracleDb");
        Connection = new OracleConnection(connectionString);
        Connection.Open();
    }

    public IDbConnection Connection { get;}
   
    public void Dispose() => Connection.Dispose();
}
