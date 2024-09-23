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

        public DbConnection Connection => _connection ?? _connectionFactory.CreateConnection();

        public void BeginTransaction()
        {
            if (_connection == null)
            {
                _connection = _connectionFactory.CreateConnection();
                _connection.Open();
            }
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction?.Commit();
            _connection?.Close();
            _connection = null;
            _transaction = null;
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            _connection?.Close();
            _connection = null;
            _transaction = null;
        }

        public DbCommand CreateCommand()
        {
            DbCommand command = Connection.CreateCommand();
            command.Transaction = _transaction;
            return command;
        }

        public bool IsInTransaction => _transaction != null;
    }
}
