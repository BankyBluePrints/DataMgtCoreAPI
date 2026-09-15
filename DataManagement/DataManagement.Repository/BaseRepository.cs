using System.Data;
using Microsoft.Data.SqlClient;

namespace DataManagement.Repository;

public abstract class BaseRepository : IDisposable
{
    protected readonly IDbConnection Connection;

    protected BaseRepository(string connectionString)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);
        Connection = new SqlConnection(connectionString);
    }

    public void Dispose()
    {
        Connection.Dispose();
        GC.SuppressFinalize(this);
    }
}
