using System.Data.Common;

namespace ADO.NET.Interfaces
{
    public interface IConnectionFactory
    {
        DbConnection CreateConnection();
    }
}
