using ADO.NET.Interfaces;
using System.Data;
using System.Data.Common;

namespace ADO.NET.Helpers
{
    public class DataService : IDataService
    {
        private readonly ITransactionManager _transactionFactory;

        public DataService(ITransactionManager transactionFactory)
        {
            _transactionFactory = transactionFactory;
        }

        public DataSet ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (DbCommand command = _transactionFactory.CreateCommand())
            {
                command.CommandText = query;

                // Adiciona os parâmetros à consulta, se houver
                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> param in parameters)
                    {
                        DbParameter dbParam = command.CreateParameter();
                        dbParam.ParameterName = param.Key;
                        dbParam.Value = param.Value ?? DBNull.Value;
                        command.Parameters.Add(dbParam);
                    }
                }

                using (DbDataAdapter adapter = CreateDataAdapter(command))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }
        }

        private DbDataAdapter CreateDataAdapter(DbCommand command)
        {
            // Cria um adaptador compatível com o tipo de banco de dados
            if (command is System.Data.SqlClient.SqlCommand)
            {
                return new System.Data.SqlClient.SqlDataAdapter((System.Data.SqlClient.SqlCommand)command);
            }
            else if (command is MySql.Data.MySqlClient.MySqlCommand)
            {
                return new MySql.Data.MySqlClient.MySqlDataAdapter((MySql.Data.MySqlClient.MySqlCommand)command);
            }
            else if (command is Npgsql.NpgsqlCommand)
            {
                return new Npgsql.NpgsqlDataAdapter((Npgsql.NpgsqlCommand)command);
            }
            else
            {
                throw new NotSupportedException("Banco de dados não suportado pelo DataService.");
            }
        }
    }
}
