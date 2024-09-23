using ADO.NET.Connection;
using ADO.NET.Helpers;
using ADO.NET.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using static ADO.NET.Helpers.BaseConnection;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDatabaseServices(this IServiceCollection services, string connectionString, DataBase dataBase)
    {
        switch (dataBase)
        {
            case DataBase.Sql:
                // Registrando a implementação da interface IConnectionFactory
                services.AddScoped<IConnectionFactory>(provider => new SqlConnectionFactory(connectionString));
                break;
            case DataBase.MySql:
                break;
            case DataBase.PostgreSql:
                break;
            case DataBase.Oracle:
                break;
            default:
                break;
        }

        // Registrar outros serviços se necessário
        services.AddScoped<IDataService, DataService>();

        return services;
    }
}
