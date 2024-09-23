using ADO.NET.Interfaces;
using System.Data.Common;

namespace ADO.NET.Transaction
{
    public class TransactionManager : ITransactionManager
    {
        private readonly IConnectionFactory _connectionFactory;
        private DbTransaction _transaction;
        private DbConnection _connection;

        public TransactionManager(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void BeginTransaction()
        {
            _connection = _connectionFactory.CreateConnection();
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction?.Commit();
            _connection?.Close();
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            _connection?.Close();
        }

        public DbCommand CreateCommand()
        {
            DbCommand command = _connection.CreateCommand();
            command.Transaction = _transaction;
            return command;
        }
    }

}
