# am.kon.packages.dac.primitives

`am.kon.packages.dac.primitives` defines the shared contracts, helpers, and exception types that concrete Data Access Component (DAC) providers build upon. Because it targets `netstandard2.1`, you can reference it from .NET Framework 4.8 as well as current .NET releases.

## Installation

```bash
 dotnet add package am.kon.packages.dac.primitives
```

## Core abstractions

### `IDataBase`

The `IDataBase` interface is the heart of the package. It standardises how providers expose:

- `ExecuteSQLBatchAsync` – open a connection, run arbitrary work, and optionally keep the connection open.
- `ExecuteTransactionalSQLBatchAsync` – execute work inside an ambient transaction with automatic commit/rollback.
- `ExecuteReaderAsync` – return an `IDataReader` for streaming results.
- `ExecuteNonQueryAsync` – execute commands that do not return result sets and capture the affected row count.
- `ExecuteScalarAsync` – retrieve the first column of the first row from a result set.
- `FillData<T>` / `FillDataSet` / `FillDataTable` – populate existing containers.
- `GetDataSet` / `GetDataTable` – allocate and return populated `DataSet`/`DataTable` instances.

Each method exposes optional flags (`throwDBException`, `throwGenericException`, `throwSystemException`) that let you decide whether database-specific, generic, or system exceptions should be re-thrown or suppressed for custom handling.

#### Example: transactional batch

```csharp
using System.Data.Common;

public async Task TransferAsync(IDataBase database, int fromAccount, int toAccount, decimal amount)
{
    await database.ExecuteTransactionalSQLBatchAsync(async transaction =>
    {
        var connection = (DbConnection)transaction.Connection;
        var dbTransaction = (DbTransaction)transaction;

        using var debit = connection.CreateCommand();
        debit.Transaction = dbTransaction;
        debit.CommandText = "UPDATE Accounts SET Balance = Balance - @Amount WHERE AccountId = @Source";
        debit.Parameters.Add(CreateParameter(debit, "@Amount", amount));
        debit.Parameters.Add(CreateParameter(debit, "@Source", fromAccount));
        await debit.ExecuteNonQueryAsync();

        using var credit = connection.CreateCommand();
        credit.Transaction = dbTransaction;
        credit.CommandText = "UPDATE Accounts SET Balance = Balance + @Amount WHERE AccountId = @Target";
        credit.Parameters.Add(CreateParameter(credit, "@Amount", amount));
        credit.Parameters.Add(CreateParameter(credit, "@Target", toAccount));
        await credit.ExecuteNonQueryAsync();

        return true;
    });
}

static DbParameter CreateParameter(DbCommand command, string name, object value)
{
    var parameter = command.CreateParameter();
    parameter.ParameterName = name;
    parameter.Value = value ?? DBNull.Value;
    return parameter;
}
```

The helper receives an `IDbTransaction`; providers are responsible for casting to their concrete implementations when needed.

#### Example: streaming results

```csharp
public async Task<List<Customer>> LoadCustomersAsync(IDataBase database)
{
    var customers = new List<Customer>();

    await using var reader = await database.ExecuteReaderAsync(
        sql: "SELECT CustomerId, DisplayName FROM Sales.Customers WHERE IsActive = 1",
        parameters: Array.Empty<IDataParameter>());

    while (await reader.ReadAsync())
    {
        customers.Add(new Customer
        {
            Id = reader.GetInt32(0),
            DisplayName = reader.GetString(1)
        });
    }

    return customers;
}
```

#### Example: materialising a `DataSet`

```csharp
public DataSet GetDashboardData(IDataBase database)
{
    var parameters = new DacSqlParameters();
    parameters.AddItem("@Date", DateTime.UtcNow.Date);

    return database.GetDataSet(
        sql: "dbo.GetDashboard",
        parameters: parameters,
        commandType: CommandType.StoredProcedure,
        startRecord: 0,
        maxRecords: 0);
}
```

### `DacSqlParameters`

`DacSqlParameters` is a lightweight `List<KeyValuePair<string, object>>` with an `AddItem` helper for building parameter collections without referencing a provider-specific type.

```csharp
var parameters = new DacSqlParameters();
parameters.AddItem("@Id", 42);
parameters.AddItem("@Name", "Example");
```

Provider packages typically expose extension methods (for example, `ToDataParameters`) that translate `DacSqlParameters` into the native `IDataParameter` implementations they use.

### `DacConfig`

`DacConfig` models the configuration block that provider services (such as `am.kon.packages.services.dac.mssql`) bind to. The `SectionDefaultName` constant is `"am.kon.dac"`, and the `DefaultConnection` property identifies which named connection string should be treated as the default database.

### Exception hierarchy

- `DacGenericException` – base class for DAC-specific errors. Use it when wrapping unexpected failures so consumers can catch a single type.
- `DacSqlExecutionException` – thrown for SQL-provider failures (for example, when `SqlException` bubbles out of command execution).
- `DacSqlExecutionReturnedErrorCodeException` – emitted when a stored procedure returns a non-zero return value. It exposes the integer `RetCode` and the `ReturnedObject` (reader, scalar, etc.) for additional context.

Providers should throw these exceptions to keep error-handling consistent across implementations. Consumers can catch them to differentiate between SQL return codes, SQL execution failures, and generic/system failures.

## Implementing a provider

To build a new provider (for example, PostgreSQL):

1. Reference `am.kon.packages.dac.primitives` and implement `IDataBase`.
2. Translate the shared primitives (`DacSqlParameters`, exception types) into provider-native constructs.
3. Honour the optional flags so consumers can choose whether to receive exceptions.
4. Make sure `ExecuteSQLBatchAsync`/`ExecuteTransactionalSQLBatchAsync` manage connection and transaction lifetimes exactly once per call.

A minimal starting point is included below:

```csharp
public sealed class PgDataBase : IDataBase
{
    public string ConnectionString { get; }

    public PgDataBase(string connectionString) => ConnectionString = connectionString;

    public Task<T> ExecuteSQLBatchAsync<T>(Func<IDbConnection, Task<T>> batch, bool closeConnection = true,
        bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true)
    {
        // open NpgsqlConnection, invoke batch, honour flags, close connection
        throw new NotImplementedException();
    }

    public Task<T> ExecuteTransactionalSQLBatchAsync<T>(Func<IDbTransaction, Task<T>> batch, bool closeConnection = true,
        bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true)
    {
        // begin transaction, invoke batch, commit/rollback, honour flags
        throw new NotImplementedException();
    }

    // Implement the remaining members
}
```

## Creating derived database classes

Many consumers build thin wrappers on top of an existing provider to codify domain-specific operations while reusing the base implementation. When the provider exposes a concrete type (such as the `DataBase` in `am.kon.packages.dac.mssql`), you can derive from it and add strongly typed helpers without reimplementing `IDataBase`.

```csharp
public sealed class AccountingDatabase : DataBase
{
    public AccountingDatabase(string connectionString, CancellationToken token)
        : base(connectionString, token) { }

    public Task<int> PersistLedgerEntryAsync(Guid entryId, decimal amount)
    {
        var parameters = new DacMsSqlParameters()
            .AddItem("@EntryId", entryId)
            .AddItem("@Amount", amount);

        return ExecuteNonQueryAsync(
            sql: "dbo.ledger_upsert",
            parameters: parameters.ToArray(),
            commandType: CommandType.StoredProcedure);
    }
}
```

This pattern keeps extension code focused on business logic while the base provider continues handling connection management, transactions, exception guarding, and return-code inspection.

## Implementing a provider (service layer)

Reusing the shared primitives keeps provider packages uniform, simplifies documentation, and enables higher-level wrappers (like the service packages) to work across multiple database engines. When you ship a service wrapper on top of your `IDataBase` implementation, mirror the method surface from `DatabaseConnectionService` in the MSSQL package and forward each call to your underlying database instance.
