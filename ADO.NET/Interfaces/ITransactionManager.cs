using System.Data.Common;

namespace ADO.NET.Interfaces
{
    public interface ITransactionManager
    {
        bool IsInTransaction { get; }
        DbConnection Connection { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();
        DbCommand CreateCommand();
    }

}
