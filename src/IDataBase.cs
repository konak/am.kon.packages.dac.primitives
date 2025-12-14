using System;
using System.Data;
using System.Threading.Tasks;
using am.kon.packages.dac.primitives.Exceptions;

namespace am.kon.packages.dac.primitives
{
	/// <summary>
	/// Represents a database interface for executing SQL queries, managing transactions,
	/// and retrieving data in various formats such as DataSets, DataTables, or IDataReaders.
	/// </summary>
	public interface IDataBase
	{
		/// <summary>
		/// Gets the connection string used to establish a connection to the database.
		/// </summary>
		/// <remarks>
		/// The value of this property is typically a string that contains details such as
		/// the database server address, database name, authentication credentials, and other
		/// configuration parameters necessary for establishing a database connection.
		/// </remarks>
		string ConnectionString { get; }

        #region ExecuteSQLBatch

        /// <summary>
        /// Executes a batch of SQL commands asynchronously within a single database connection.
        /// </summary>
        /// <typeparam name="T">The type of the result returned by the batch execution.</typeparam>
        /// <param name="batch">A function that encapsulates the logic for executing the batch of SQL commands.</param>
        /// <param name="closeConnection">Specifies whether the database connection should be closed after execution.</param>
        /// <param name="throwDBException">Indicates whether a database-related exception should be thrown if an error occurs.</param>
        /// <param name="throwGenericException">Indicates whether a generic exception should be thrown if an error occurs.</param>
        /// <param name="throwSystemException">Indicates whether a system exception should be thrown if an error occurs.</param>
        /// <returns>A task representing the asynchronous operation, with the result of type <typeparamref name="T"/>.</returns>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Thrown when @return_value parameter becomes a nonzero value, indication error code returned by query or stored procedure.</exception>
        /// <exception cref="DacSqlExecutionException">Thrown when a SQL-related error occurs.</exception>
        /// <exception cref="DacGenericException">Thrown when a generic error occurs.</exception>
        Task<T> ExecuteSQLBatchAsync<T>(Func<IDbConnection, Task<T>> batch, bool closeConnection = true, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true);

        /// <summary>
        /// Executes a batch of SQL statements within a transaction asynchronously.
        /// </summary>
        /// <param name="batch">The delegate function representing the batch to be executed, which receives an <see cref="IDbTransaction"/> instance.</param>
        /// <param name="closeConnection">Indicates whether the database connection should be closed after execution. Default is true.</param>
        /// <param name="throwDBException">Indicates whether database-related exceptions should be thrown. Default is true.</param>
        /// <param name="throwGenericException">Indicates whether generic data access exceptions should be thrown. Default is true.</param>
        /// <param name="throwSystemException">Indicates whether system exceptions should be rethrown as a custom wrapped exception. Default is true.</param>
        /// <typeparam name="T">The type of the object returned by the batch function.</typeparam>
        /// <returns>A task that represents the asynchronous operation. The task result contains the object of type <typeparamref name="T"/> returned by the batch function.</returns>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Thrown when @return_value parameter becomes a nonzero value, indication error code returned by query or stored procedure.</exception>
        /// <exception cref="DacSqlExecutionException">Thrown when a SQL-related error occurs.</exception>
        /// <exception cref="DacGenericException">Thrown when a generic error occurs.</exception>
        Task<T> ExecuteTransactionalSQLBatchAsync<T>(Func<IDbTransaction, Task<T>> batch, bool closeConnection = true, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true);

        #endregion

        #region FillData

        /// <summary>
        /// Executes the specified SQL command or stored procedure and fills the provided data object with the resulting data.
        /// </summary>
        /// <typeparam name="T">The type of the object that will be populated with data. Supported types include DataTable and DataSet.</typeparam>
        /// <param name="dataOut">The object to populate with the data retrieved from the database. Supported types include DataTable and DataSet.</param>
        /// <param name="sql">The SQL command, stored procedure name, or table name to execute or query.</param>
        /// <param name="parameters">The parameters to pass to the SQL command.</param>
        /// <param name="commandType">The type of the SQL command being executed, such as Text or StoredProcedure. Default is Text.</param>
        /// <param name="throwDBException">If true, database-specific exceptions will be thrown; otherwise, they will be suppressed. Default is true.</param>
        /// <param name="throwGenericException">If true, generic exceptions will be thrown; otherwise, they will be suppressed. Default is true.</param>
        /// <param name="throwSystemException">If true, system-level exceptions will be thrown; otherwise, they will be suppressed. Default is true.</param>
        /// <param name="startRecord">The zero-based record number from which to start retrieving data. Default is 0.</param>
        /// <param name="maxRecords">The maximum number of records to retrieve. Default is 0, which retrieves all records.</param>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Thrown when @return_value parameter becomes a nonzero value, indication error code returned by query or stored procedure.</exception>
        /// <exception cref="DacSqlExecutionException">Thrown when a SQL-related error occurs.</exception>
        /// <exception cref="DacGenericException">Thrown when a generic error occurs.</exception>
        void FillData<T>(T dataOut, string sql, IDataParameter[] parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);
        
        /// <summary>
        /// Executes the specified SQL command or stored procedure and fills the provided data object with the resulting data.
        /// </summary>
        /// <typeparam name="T">The type of the object to populate with the data. Supported types include DataTable and DataSet.</typeparam>
        /// <param name="dataOut">The object to populate with the data retrieved from the database.</param>
        /// <param name="sql">The SQL command, stored procedure name, or table name to execute or query.</param>
        /// <param name="parameters">The parameters to pass to the SQL command.</param>
        /// <param name="commandType">The type of the SQL command being executed, such as Text or StoredProcedure. Default is Text.</param>
        /// <param name="throwDBException">If true, database-specific exceptions will be thrown; otherwise, they will be suppressed. Default is true.</param>
        /// <param name="throwGenericException">If true, generic exceptions will be thrown; otherwise, they will be suppressed. Default is true.</param>
        /// <param name="throwSystemException">If true, system-level exceptions will be thrown; otherwise, they will be suppressed. Default is true.</param>
        /// <param name="startRecord">The zero-based record number from which to start retrieving data. Default is 0.</param>
        /// <param name="maxRecords">The maximum number of records to retrieve. Default is 0, which retrieves all records.</param>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Thrown when @return_value parameter becomes a nonzero value, indication error code returned by query or stored procedure.</exception>
        /// <exception cref="DacSqlExecutionException">Thrown when a SQL-related error occurs.</exception>
        /// <exception cref="DacGenericException">Thrown when a generic error occurs.</exception>
        void FillData<T>(T dataOut, string sql, DacSqlParameters parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        #endregion

        #region ExecuteReader

        /// <summary>
        /// Executes an SQL query or stored procedure asynchronously and returns an <see cref="IDataReader"/> object for reading the resulting data.
        /// </summary>
        /// <param name="sql">The SQL query or stored procedure to be executed.</param>
        /// <param name="parameters">The parameters to be applied to the SQL query or stored procedure.</param>
        /// <param name="commandType">Indicates whether the SQL query is a text command or a stored procedure. Default is CommandType.Text.</param>
        /// <param name="throwDBException">Indicates whether to throw database-specific exceptions. Default is true.</param>
        /// <param name="throwGenericException">Indicates whether to throw generic exceptions. Default is true.</param>
        /// <param name="throwSystemException">Indicates whether to throw general system exceptions. Default is true.</param>
        /// <returns>An <see cref="IDataReader"/> object for reading the results of the query.</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Thrown when the SQL query or stored procedure returns a non-zero error code.</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<IDataReader> ExecuteReaderAsync(string sql, IDataParameter[] parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true);
        
        /// <summary>
        /// Executes the specified SQL query or stored procedure and returns a data reader object to read the resulting data.
        /// </summary>
        /// <param name="sql">The SQL query or stored procedure to execute.</param>
        /// <param name="parameters">The parameters to pass to the SQL query or stored procedure.</param>
        /// <param name="commandType">Specifies the type of the command being executed (Text, StoredProcedure, etc.).</param>
        /// <param name="throwDBException">Indicates whether to throw a database-specific exception if an error occurs.</param>
        /// <param name="throwGenericException">Indicates whether to throw a generic exception if an error occurs.</param>
        /// <param name="throwSystemException">Indicates whether to throw a system-level exception if an error occurs.</param>
        /// <returns>A task that represents the asynchronous operation, which upon completion contains a data reader object to read the query results.</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Thrown when the SQL query or stored procedure returns a non-zero error code.</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<IDataReader> ExecuteReaderAsync(string sql, DacSqlParameters parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true);

        #endregion

        #region GetDataSet

        /// <summary>
        /// Retrieves a new DataSet for the specified SQL command or stored procedure with parameters and execution options.
        /// </summary>
        /// <param name="sql">The SQL command text, stored procedure name, or table name.</param>
        /// <param name="parameters">The parameters of the SQL command.</param>
        /// <param name="commandType">The type of SQL command to execute (Text, StoredProcedure, or TableDirect).</param>
        /// <param name="throwDBException">Indicates whether to throw database-specific exceptions during SQL execution.</param>
        /// <param name="throwGenericException">Indicates whether to throw general exceptions encountered during execution.</param>
        /// <param name="throwSystemException">Indicates whether to throw system-level exceptions encountered during execution.</param>
        /// <param name="startRecord">The zero-based index of the first record to retrieve.</param>
        /// <param name="maxRecords">The maximum number of records to retrieve.</param>
        /// <returns>A new DataSet containing the results of the SQL command execution.</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Thrown when the SQL query or stored procedure returns a non-zero error code.</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        DataSet GetDataSet(string sql, IDataParameter[] parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Retrieves a DataSet based on the provided SQL command, parameters, and execution options.
        /// </summary>
        /// <param name="sql">The SQL command text, stored procedure name, or table name.</param>
        /// <param name="parameters">The parameters to be passed to the SQL command, represented as DacSqlParameters.</param>
        /// <param name="commandType">The type of SQL command to execute (Text, StoredProcedure, or TableDirect).</param>
        /// <param name="throwDBException">Indicates whether database-specific exceptions should be thrown during SQL execution.</param>
        /// <param name="throwGenericException">Indicates whether general exceptions encountered during execution should be thrown.</param>
        /// <param name="throwSystemException">Indicates whether to throw system-level exceptions encountered during execution.</param>
        /// <param name="startRecord">The zero-based index of the first record to retrieve.</param>
        /// <param name="maxRecords">The maximum number of records to retrieve. If set to 0, retrieves all records.</param>
        /// <returns>A DataSet containing the result of the SQL command execution.</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Thrown when the SQL query or stored procedure returns a non-zero error code.</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        DataSet GetDataSet(string sql, DacSqlParameters parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        #endregion

        #region FillDataSet

        /// <summary>
        /// Fills the specified DataSet object with data obtained from executing a SQL command with provided parameters.
        /// </summary>
        /// <param name="ds">The DataSet instance to be populated with retrieved data.</param>
        /// <param name="sql">The SQL query or command text to execute.</param>
        /// <param name="parameters">An array of IDataParameter objects to supply parameters to the SQL command.</param>
        /// <param name="commandType">Specifies how the SQL command is interpreted, such as Text for raw queries or StoredProcedure. Default is CommandType.Text.</param>
        /// <param name="throwDBException">Specifies whether database-related exceptions should be thrown when errors occur. Default is true.</param>
        /// <param name="throwGenericException">Specifies whether generic exceptions should be thrown when errors occur. Default is true.</param>
        /// <param name="throwSystemException">Specifies whether system-level exceptions should be thrown when errors occur. Default is true.</param>
        /// <param name="startRecord">The zero-based index indicating the starting point for retrieving data. Default is 0.</param>
        /// <param name="maxRecords">The maximum number of records to retrieve. Default is 0, which means no record limit.</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Thrown when the SQL query or stored procedure returns a non-zero error code.</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillDataSet(DataSet ds, string sql, IDataParameter[] parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Fill provided DataSet item with values from executed SQL command
        /// </summary>
        /// <param name="ds">A DatSet item that must be filled with data</param>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Indicates whether database-specific exceptions should be thrown. Default is true.</param>
        /// <param name="throwGenericException">Indicates whether generic exceptions should be thrown. Default is true.</param>
        /// <param name="throwSystemException">Indicates whether system-level exceptions should be thrown. Default is true.</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillDataSet(DataSet ds, string sql, DacSqlParameters parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        #endregion

        #region GetDataTable

        /// <summary>
        /// Retrieves a new DataTable for a specified SQL command.
        /// </summary>
        /// <param name="sql">The SQL command text to be executed.</param>
        /// <param name="parameters">The parameters to be passed to the SQL command.</param>
        /// <param name="commandType">The type of the SQL command to execute. Default is CommandType.Text.</param>
        /// <param name="throwDBException">Specifies whether to throw SQL execution exceptions or suspend them. Default is true.</param>
        /// <param name="throwGenericException">Specifies whether to throw generic exceptions or suspend them. Default is true.</param>
        /// <param name="throwSystemException">Specifies whether to throw system exceptions or suspend them. Default is true.</param>
        /// <param name="startRecord">The zero-based record number to start with. Default is 0.</param>
        /// <param name="maxRecords">The maximum number of records to retrieve. Default is 0.</param>
        /// <returns>A DataTable populated with the results of the SQL command.</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Thrown when the SQL query or stored procedure returns a non-zero error code.</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        DataTable GetDataTable(string sql, IDataParameter[] parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Retrieves a DataTable based on a specified SQL command and parameters.
        /// </summary>
        /// <param name="sql">The SQL command text to be executed.</param>
        /// <param name="parameters">The DacSqlParameters containing the parameters for the SQL command.</param>
        /// <param name="commandType">The type of SQL command to execute. Default is CommandType.Text.</param>
        /// <param name="throwDBException">Specifies whether to throw database-related exceptions. Default is true.</param>
        /// <param name="throwGenericException">Specifies whether to throw generic exceptions. Default is true.</param>
        /// <param name="throwSystemException">Specifies whether to throw system-related exceptions. Default is true.</param>
        /// <param name="startRecord">The zero-based record number to start retrieving from. Default is 0.</param>
        /// <param name="maxRecords">The maximum number of records to retrieve. Default is 0.</param>
        /// <returns>A DataTable containing the results of the executed SQL command.</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Thrown when the SQL query or stored procedure returns a non-zero error code.</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        DataTable GetDataTable(string sql, DacSqlParameters parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);
        
        #endregion

        #region FillDataTable

        /// <summary>
        /// Fills the provided DataTable with data retrieved from the execution of the specified SQL command.
        /// </summary>
        /// <param name="dt">The DataTable to populate with data.</param>
        /// <param name="sql">The SQL command text to execute.</param>
        /// <param name="parameters">The collection of SQL parameters used for the command execution.</param>
        /// <param name="commandType">Specifies the type of SQL command, such as Text, StoredProcedure, etc. Defaults to Text.</param>
        /// <param name="throwDBException">Indicates whether to throw a database-specific exception when an error occurs during execution. Defaults to true.</param>
        /// <param name="throwGenericException">Indicates whether to throw a generic exception when an error occurs during execution. Defaults to true.</param>
        /// <param name="throwSystemException">Indicates whether to throw a system-level exception when an error occurs during execution. Defaults to true.</param>
        /// <param name="startRecord">The zero-based index of the first record to begin fetching. Defaults to 0.</param>
        /// <param name="maxRecords">The maximum number of records to fetch. Defaults to 0 (fetch all records).</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Thrown when the SQL query or stored procedure returns a non-zero error code.</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillDataTable(DataTable dt, string sql, IDataParameter[] parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);
        
        /// <summary>
        /// Fills the provided DataTable with data retrieved from the execution of a SQL command.
        /// </summary>
        /// <param name="dt">The DataTable to populate with the data retrieved from the SQL command.</param>
        /// <param name="sql">The SQL command text to execute for retrieving the data.</param>
        /// <param name="parameters">The collection of DacSqlParameters to use as input parameters for the SQL command.</param>
        /// <param name="commandType">Specifies the type of the SQL command, such as Text or StoredProcedure. Default is CommandType.Text.</param>
        /// <param name="throwDBException">Determines whether to throw a database-specific exception (e.g., SqlException) if an error occurs during execution. Default is true.</param>
        /// <param name="throwGenericException">Determines whether to throw a generic exception in case of errors during execution. Default is true.</param>
        /// <param name="throwSystemException">Determines whether to throw a system-level exception in case of unexpected errors. Default is true.</param>
        /// <param name="startRecord">The zero-based index of the first record to retrieve. Default is 0.</param>
        /// <param name="maxRecords">The maximum number of records to return. A value of 0 means no limit. Default is 0.</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Thrown when the SQL query or stored procedure returns a non-zero error code.</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillDataTable(DataTable dt, string sql, DacSqlParameters parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);
        
        #endregion

        #region ExecuteNonQuery

        /// <summary>
        /// Executes a SQL non-query and returns the number of affected rows.
        /// </summary>
        /// <param name="sql">The SQL command text to execute.</param>
        /// <param name="parameters">The parameters of the SQL command.</param>
        /// <param name="commandType">The type of the SQL command.</param>
        /// <returns>The number of affected rows.</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Thrown when the SQL query or stored procedure returns a non-zero error code.</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<int> ExecuteNonQueryAsync(string sql, IDataParameter[] parameters, CommandType commandType = CommandType.Text);
        
        /// <summary>
        /// Executes a SQL non-query and returns the number of affected rows.
        /// </summary>
        /// <param name="sql">The SQL command text to execute.</param>
        /// <param name="parameters">The parameters of the SQL command provided as an instance of DacSqlParameters.</param>
        /// <param name="commandType">The type of the SQL command.</param>
        /// <returns>The number of affected rows.</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Thrown when the SQL query or stored procedure returns a non-zero error code.</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<int> ExecuteNonQueryAsync(string sql, DacSqlParameters parameters, CommandType commandType = CommandType.Text);
        
        #endregion

        #region ExecuteScalar

        /// <summary>
        /// Executes a SQL command asynchronously and retrieves the value of the first column of the first row from the result set.
        /// </summary>
        /// <param name="sql">The SQL command text to be executed.</param>
        /// <param name="parameters">The parameters to pass to the SQL command.</param>
        /// <param name="commandType">The type of the SQL command, such as Text, StoredProcedure, or TableDirect. Default is Text.</param>
        /// <returns>The value of the first column of the first row from the result set.</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Thrown when the SQL query or stored procedure returns a non-zero error code.</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<object> ExecuteScalarAsync(string sql, IDataParameter[] parameters, CommandType commandType = CommandType.Text);
        
        /// <summary>
        /// Execute SQL command and return value of first column of the first row from results
        /// </summary>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <returns>Value of first column of the first row</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<object> ExecuteScalarAsync(string sql, DacSqlParameters parameters, CommandType commandType = CommandType.Text);
        
        #endregion
    }
}
