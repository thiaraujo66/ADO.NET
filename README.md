# ADO.NET Multi-Database Data Service

Este projeto é uma biblioteca em .NET que fornece uma abstração para operações básicas de banco de dados usando ADO.NET. Ele é projetado para ser utilizado com múltiplos bancos de dados relacionais (SQL Server, MySQL, PostgreSQL, Oracle, etc.) e permite gerenciar transações de forma simples e direta.

## Características

- **Abstração de Conexão**: Suporte para múltiplos tipos de bancos de dados relacionais, como SQL Server, MySQL, PostgreSQL e Oracle.
- **Transações**: Gerenciamento de transações para garantir consistência dos dados.
- **Execução de Consultas**: Métodos simples para executar comandos SQL e retornar os resultados como `DataSet`.
- **Injeção de Dependência**: Suporte para injeção de dependências, permitindo fácil integração com outros projetos.

## Estrutura do Projeto

O projeto é organizado da seguinte maneira:

- **Interfaces**: Define as interfaces que abstraem as conexões e transações.
  - `IConnectionFactory`: Interface para criar conexões de diferentes bancos de dados.
  - `ITransactionManager`: Interface para gerenciar transações, como `BeginTransaction`, `Commit`, e `Rollback`.
- **Implementações**:
  - **Conexões**: Implementações específicas de `IConnectionFactory` para SQL Server, MySQL e PostgreSQL.
  - **Transações**: `TransactionManager` para gerenciar transações de forma genérica.
  - **DataService**: Fornece métodos para executar comandos SQL e retornar resultados como `DataSet`.

## Instalação

### Pré-requisitos

- .NET 8 ou superior
- Instalar os pacotes de dependências para o banco de dados de sua escolha:
  
  Para **SQL Server**:
  bash
  `dotnet add package Microsoft.Data.SqlClien`

  Para **PostgreSQL**:
  bash
  `dotnet add package Npgsql`
