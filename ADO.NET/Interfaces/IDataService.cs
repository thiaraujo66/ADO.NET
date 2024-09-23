using System.Data;
using System.Data.Common;

namespace ADO.NET.Interfaces
{
    public interface IDataService
    {
        DataSet ExecuteQuery(string query, Dictionary<string, object> parameters = null);
    }
}
