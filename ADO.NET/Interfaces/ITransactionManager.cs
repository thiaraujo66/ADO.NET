using System.Data.Common;

namespace ADO.NET.Interfaces
{
    public interface ITransactionManager
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        DbCommand CreateCommand();
    }

}
