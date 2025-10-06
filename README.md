# am.kon.packages.dac.primitives

`am.kon.packages.dac.primitives` contains the cross-package contracts that the DAC implementations build upon. It ships the `IDataBase` abstraction, parameter helpers, and the custom exception hierarchy used across the ecosystem. Targeting `netstandard2.1` keeps it consumable from both .NET Framework and modern .NET applications.

## Key types

- `IDataBase` – contract that concrete database providers implement. It exposes async helpers for executing SQL batches, transactional work, and retrieving data in multiple formats.
- `DacSqlParameters` – lightweight key/value collection for building parameter lists without referencing a specific ADO.NET provider.
- Exception hierarchy (`DacGenericException`, `DacSqlExecutionException`, `DacSqlExecutionReturnedErrorCodeException`) – ensures consistent error handling and messaging.

## Installation

```bash
 dotnet add package am.kon.packages.dac.primitives
```

## Example: wrapping a provider

```csharp
using am.kon.packages.dac.primitives;

public class MyDatabase : IDataBase
{
    public string ConnectionString { get; }

    public MyDatabase(string connectionString)
    {
        ConnectionString = connectionString;
    }

    // Forward the required members to your concrete provider (am.kon.packages.dac.mssql, etc.)
    public Task<T> ExecuteSQLBatchAsync<T>(Func<IDbConnection, Task<T>> batch,
        bool closeConnection = true,
        bool throwDBException = true,
        bool throwGenericException = true,
        bool throwSystemException = true) => throw new NotImplementedException();

    // Implement the rest of the IDataBase members following your provider's capabilities
}
```

## Building parameter collections

```csharp
using am.kon.packages.dac.primitives;

var parameters = new DacSqlParameters();
parameters.AddItem("@Id", 42);
parameters.AddItem("@Name", "Example");

// Pass the bag to a provider that knows how to translate it into its native SqlParameter instances
```

Use the shared exception types in your provider to keep error handling uniform across packages.
