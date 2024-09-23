using ADO.NET.Connection;
using ADO.NET.Helpers;
using ADO.NET.Interfaces;
using ADO.NET.Transaction;
using System.Data;
using System.Data.Common;

namespace ADO.NET.Test
{
    public class SqlConnectionTests
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly ITransactionManager _transactionFactory;

        public SqlConnectionTests()
        {
            // Configure sua string de conexão aqui
            string connectionString = "Server=DESKTOP-R7HBS56\\SQLEXPRESS;Database=testedb;User Id=sa;Password=123456;Encrypt=False";
            _connectionFactory = new SqlConnectionFactory(connectionString);
            _transactionFactory = new TransactionManager(_connectionFactory);
        }

        [Fact]
        public void ExecuteQuery_Returns_DataSet_When_QueryIsValid()
        {
            _transactionFactory.BeginTransaction();

            // Limpe a tabela antes do teste
            DbCommand cleanCommand = _transactionFactory.CreateCommand();
            cleanCommand.CommandText = "CREATE TABLE Users(Id INT PRIMARY KEY, Name Varchar(50))";
            cleanCommand.ExecuteNonQuery();

            // Insira dados de teste
            DbCommand insertCommand = _transactionFactory.CreateCommand();
            insertCommand.CommandText = "INSERT INTO Users (Id, Name) VALUES (1, 'Alice'), (2, 'Bob')";
            insertCommand.ExecuteNonQuery();

            DataService dataService = new(_transactionFactory);

            // Act
            DataSet result = dataService.ExecuteQuery("SELECT * FROM Users");

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.Tables);
            Assert.Equal(2, result.Tables[0].Rows.Count);
            Assert.Equal("Alice", result.Tables[0].Rows[0]["Name"]);

            _transactionFactory.Rollback();
        }
    }
}
