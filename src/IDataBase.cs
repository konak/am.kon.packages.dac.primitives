using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using am.kon.packages.dac.primitives.Exceptions;

namespace am.kon.packages.dac.primitives
{
    /// <summary>
    /// Interface describing object to interact with database
    /// </summary>
	public interface IDataBase
	{
        /// <summary>
        /// Connection string of <see cref="IDataBase"/> connection
        /// </summary>
        string ConnectionString { get; }

        #region ExecuteSQLBatch

        /// <summary>
        /// Async execution of provided SQL batch job
        /// </summary>
        /// <typeparam name="T">A generic type of object the batch must return</typeparam>
        /// <param name="batch">SQL batch job object</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="closeConnection">Close connection after batch job execution</param>
        /// <returns>Batch execution result object</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<T> ExecuteSQLBatchAsync<T>(Func<IDbConnection, Task<T>> batch, bool closeConnection = true, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true);

        /// <summary>
        /// Async execution of provided transactional SQL batch job
        /// </summary>
        /// <typeparam name="T">A generic type of object the batch must return</typeparam>
        /// <param name="batch">A transactional SQL batch job object</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="closeConnection">Close connection after batch job execution</param>
        /// <returns>Batch execution result object</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<T> ExecuteTransactionalSQLBatchAsync<T>(Func<IDbTransaction, Task<T>> batch, bool closeConnection = true, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true);

        #endregion

        #region FillData

        /// <summary>
        /// Execute SQL command or stored procedure and fill resultinng data into the dataOut object
        /// </summary>
        /// <typeparam name="T">A generic type of the object that will be filled with values. Type of objects that can be passed: <list type="bullet"><item><description>DataTable</description></item><item><description>DataSet</description></item></list></typeparam>
        /// <param name="dataOut">Object that will be filled with values. Type of objects that can be passed: <list type="bullet"><item><description>DataTable</description></item><item><description>DataSet</description></item></list></param>
        /// <param name="sql">SQL query, stored procedure or table name</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillData<T>(T dataOut, string sql, IDataParameter[] parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Execute SQL command or stored procedure and fill resultinng data into the dataOut object
        /// </summary>
        /// <typeparam name="T">A generic type of the object that will be filled with values. Type of objects that can be passed: <list type="bullet"><item><description>DataTable</description></item><item><description>DataSet</description></item></list></typeparam>
        /// <param name="dataOut">Object that will be filled with values. Type of objects that can be passed: <list type="bullet"><item><description>DataTable</description></item><item><description>DataSet</description></item></list></param>
        /// <param name="sql">SQL query, stored procedure or table name</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillData<T>(T dataOut, string sql, List<KeyValuePair<string, Object>> parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Execute SQL command or stored procedure and fill resultinng data into the dataOut object
        /// </summary>
        /// <typeparam name="T">A generic type of the object that will be filled with values. Type of objects that can be passed: <list type="bullet"><item><description>DataTable</description></item><item><description>DataSet</description></item></list></typeparam>
        /// <param name="dataOut">Object that will be filled with values. Type of objects that can be passed: <list type="bullet"><item><description>DataTable</description></item><item><description>DataSet</description></item></list></param>
        /// <param name="sql">SQL query, stored procedure or table name</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillData<T>(T dataOut, string sql, DacSqlParameters parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Execute SQL command or stored procedure and fill resultinng data into the dataOut object
        /// </summary>
        /// <typeparam name="T">A generic type of the object that will be filled with values. Type of objects that can be passed: <list type="bullet"><item><description>DataTable</description></item><item><description>DataSet</description></item></list></typeparam>
        /// <param name="dataOut">Object that will be filled with values. Type of objects that can be passed: <list type="bullet"><item><description>DataTable</description></item><item><description>DataSet</description></item></list></param>
        /// <param name="sql">SQL query, stored procedure or table name</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillData<T>(T dataOut, string sql, dynamic parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Execute SQL command or stored procedure and fill resultinng data into the dataOut object
        /// </summary>
        /// <typeparam name="T">A generic type of the object that will be filled with values. Type of objects that can be passed: <list type="bullet"><item><description>DataTable</description></item><item><description>DataSet</description></item></list></typeparam>
        /// <typeparam name="TParam">A generic type of the object containing parameters to be passed for SQL command execution</typeparam>
        /// <param name="dataOut">Object that will be filled with values. Type of objects that can be passed: <list type="bullet"><item><description>DataTable</description></item><item><description>DataSet</description></item></list></param>
        /// <param name="sql">SQL query, stored procedure or table name</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillData<T, TParam>(T dataOut, string sql, TParam parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Execute SQL command or stored procedure and fill resultinng data into the dataOut object
        /// </summary>
        /// <typeparam name="T">A generic type of the object that will be filled with values. Type of objects that can be passed: <list type="bullet"><item><description>DataTable</description></item><item><description>DataSet</description></item></list></typeparam>
        /// <param name="dataOut">Object that will be filled with values. Type of objects that can be passed: <list type="bullet"><item><description>DataTable</description></item><item><description>DataSet</description></item></list></param>
        /// <param name="sql">SQL query, stored procedure or table name</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillData<T>(T dataOut, string sql, KeyValuePair<string, Object>[] parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        #endregion

        #region ExecuteReader

        /// <summary>
        /// Execute SQL command asyncronously and return <see cref="IDataAdapter"/> object to read data.
        /// </summary>
        /// <param name="sql">SQL command, stored procedure or table name</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Parameter indicating whether to throw exeption when an error is happening on SQL command execution.</param>
        /// <param name="throwGenericException">Parapeter indicating whether to trow DAC generic exception in case of an error during SQL command execution.</param>
        /// <param name="throwSystemException">Parameter indicating whether to throw System exception in case of error during SQL command execution.</param>
        /// <returns>Data reader object to read data</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code.</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<IDataReader> ExecuteReaderAsync(string sql, IDataParameter[] parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true);

        /// <summary>
        /// Execute SQL command asyncronously and return <see cref="IDataReader"/> object to read data
        /// </summary>
        /// <param name="sql">SQL command, stored procedure or table name</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Parameter indicating whether to throw exeption when an error is happening on SQL command execution.</param>
        /// <param name="throwGenericException">Parapeter indicating whether to trow DAC generic exception in case of an error during SQL command execution.</param>
        /// <param name="throwSystemException">Parameter indicating whether to throw System exception in case of error during SQL command execution.</param>
        /// <returns>Data reader object to read data</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<IDataReader> ExecuteReaderAsync(string sql, KeyValuePair<string, Object>[] parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true);

        /// <summary>
        /// Execute SQL command asyncronously and return <see cref="IDataReader"/> object to read data
        /// </summary>
        /// <param name="sql">SQL command, stored procedure or table name</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Parameter indicating whether to throw exeption when an error is happening on SQL command execution.</param>
        /// <param name="throwGenericException">Parapeter indicating whether to trow DAC generic exception in case of an error during SQL command execution.</param>
        /// <param name="throwSystemException">Parameter indicating whether to throw System exception in case of error during SQL command execution.</param>
        /// <returns>Data reader object to read data</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<IDataReader> ExecuteReaderAsync(string sql, List<KeyValuePair<string, Object>> parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true);

        /// <summary>
        /// Execute SQL command asyncronously and return <see cref="IDataReader"/> object to read data
        /// </summary>
        /// <param name="sql">SQL command, stored procedure or table name</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Parameter indicating whether to throw exeption when an error is happening on SQL command execution.</param>
        /// <param name="throwGenericException">Parapeter indicating whether to trow DAC generic exception in case of an error during SQL command execution.</param>
        /// <param name="throwSystemException">Parameter indicating whether to throw System exception in case of error during SQL command execution.</param>
        /// <returns>Data reader object to read data</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<IDataReader> ExecuteReaderAsync(string sql, DacSqlParameters parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true);

        /// <summary>
        /// Execute SQL command asyncronously and return <see cref="IDataReader"/> object to read data
        /// </summary>
        /// <param name="sql">SQL command, stored procedure or table name</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Parameter indicating whether to throw exeption when an error is happening on SQL command execution.</param>
        /// <param name="throwGenericException">Parapeter indicating whether to trow DAC generic exception in case of an error during SQL command execution.</param>
        /// <param name="throwSystemException">Parameter indicating whether to throw System exception in case of error during SQL command execution.</param>
        /// <returns>Data reader object to read data</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<IDataReader> ExecuteReaderAsync(string sql, dynamic parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true);

        /// <summary>
        /// Execute SQL command asyncronously and return <see cref="IDataReader"/> object to read data
        /// </summary>
        /// <param name="sql">SQL command, stored procedure or table name</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Parameter indicating whether to throw exeption when an error is happening on SQL command execution.</param>
        /// <param name="throwGenericException">Parapeter indicating whether to trow DAC generic exception in case of an error during SQL command execution.</param>
        /// <param name="throwSystemException">Parameter indicating whether to throw System exception in case of error during SQL command execution.</param>
        /// <returns>Data reader object to read data</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<IDataReader> ExecuteReaderAsync<T>(string sql, T parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true);

        #endregion

        #region GetDataSet

        /// <summary>
        /// Get new dataset for specified SQL command or stored procedure
        /// </summary>
        /// <param name="sql">SQL command text, stored procedure or table name</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <returns>New DataSet of results of SQL command</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        DataSet GetDataSet(string sql, IDataParameter[] parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Get new dataset for specified SQL command or stored procedure
        /// </summary>
        /// <param name="sql">SQL command text, stored procedure or table name</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <returns>New DataSet of results of SQL command</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        DataSet GetDataSet(string sql, KeyValuePair<string, Object>[] parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Get new dataset for specified SQL command or stored procedure
        /// </summary>
        /// <param name="sql">SQL command text, stored procedure or table name</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <returns>New DataSet of results of SQL command</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        DataSet GetDataSet(string sql, List<KeyValuePair<string, Object>> parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Get new dataset for specified SQL command or stored procedure
        /// </summary>
        /// <param name="sql">SQL command text, stored procedure or table name</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <returns>New DataSet of results of SQL command</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        DataSet GetDataSet(string sql, DacSqlParameters parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Get new dataset for specified SQL command or stored procedure
        /// </summary>
        /// <param name="sql">SQL command text, stored procedure or table name</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <returns>New DataSet of results of SQL command</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        DataSet GetDataSet(string sql, dynamic parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Get new dataset for specified SQL command or stored procedure
        /// </summary>
        /// <param name="sql">SQL command text, stored procedure or table name</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <returns>New DataSet of results of SQL command</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        DataSet GetDataSet<T>(string sql, T parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        #endregion

        #region FillDataSet

        /// <summary>
        /// Fill provided DataSet item with values from executed SQL command
        /// </summary>
        /// <param name="ds">A DatSet item that must be filled with data</param>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillDataSet(DataSet ds, string sql, IDataParameter[] parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Fill provided DataSet item with values from executed SQL command
        /// </summary>
        /// <param name="ds">A DatSet item that must be filled with data</param>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillDataSet(DataSet ds, string sql, KeyValuePair<string, Object>[] parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Fill provided DataSet item with values from executed SQL command
        /// </summary>
        /// <param name="ds">A DatSet item that must be filled with data</param>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillDataSet(DataSet ds, string sql, List<KeyValuePair<string, Object>> parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Fill provided DataSet item with values from executed SQL command
        /// </summary>
        /// <param name="ds">A DatSet item that must be filled with data</param>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillDataSet(DataSet ds, string sql, DacSqlParameters parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Fill provided DataSet item with values from executed SQL command
        /// </summary>
        /// <param name="ds">A DatSet item that must be filled with data</param>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillDataSet(DataSet ds, string sql, dynamic parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Fill provided DataSet item with values from executed SQL command
        /// </summary>
        /// <param name="ds">A DatSet item that must be filled with data</param>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillDataSet<T>(DataSet ds, string sql, T parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);
        #endregion

        #region GetDataTable

        /// <summary>
        /// Get new DataTable for specified sql command
        /// </summary>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <returns>New DataTable item with results of the SQL command</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        DataTable GetDataTable(string sql, IDataParameter[] parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Get new DataTable for specified sql command
        /// </summary>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <returns>New DataTable item with results of the SQL command</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        DataTable GetDataTable(string sql, KeyValuePair<string, Object>[] parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Get new DataTable for specified sql command
        /// </summary>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <returns>New DataTable item with results of the SQL command</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        DataTable GetDataTable(string sql, List<KeyValuePair<string, Object>> parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Get new DataTable for specified sql command
        /// </summary>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <returns>New DataTable item with results of the SQL command</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        DataTable GetDataTable(string sql, DacSqlParameters parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Get new DataTable for specified sql command
        /// </summary>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <returns>New DataTable item with results of the SQL command</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        DataTable GetDataTable(string sql, dynamic parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Get new DataTable for specified sql command
        /// </summary>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <returns>New DataTable item with results of the SQL command</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        DataTable GetDataTable<T>(string sql, T parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        #endregion

        #region FillDataTable

        /// <summary>
        /// Fill provided DataTable item with SQL command values
        /// </summary>
        /// <param name="dt"> DataTable item</param>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillDataTable(DataTable dt, string sql, IDataParameter[] parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Fill provided DataTable item with SQL command values
        /// </summary>
        /// <param name="dt"> DataTable item</param>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillDataTable(DataTable dt, string sql, KeyValuePair<string, Object>[] parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Fill provided DataTable item with SQL command values
        /// </summary>
        /// <param name="dt"> DataTable item</param>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillDataTable(DataTable dt, string sql, List<KeyValuePair<string, Object>> parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Fill provided DataTable item with SQL command values
        /// </summary>
        /// <param name="dt"> DataTable item</param>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillDataTable(DataTable dt, string sql, DacSqlParameters parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Fill provided DataTable item with SQL command values
        /// </summary>
        /// <param name="dt"> DataTable item</param>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillDataTable(DataTable dt, string sql, dynamic parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        /// <summary>
        /// Fill provided DataTable item with SQL command values
        /// </summary>
        /// <param name="dt"> DataTable item</param>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <param name="startRecord">The zero based record number to start with</param>
        /// <param name="maxRecords">The maximum number of records to retrive</param>
        /// <param name="throwDBException">Throw SQL execution exceptions or suspend them</param>
        /// <param name="throwGenericException">Throw Generic exceptions or suspend them</param>
        /// <param name="throwSystemException">Throw System exceptions or suspend them</param>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        void FillDataTable<T>(DataTable dt, string sql, T parameters, CommandType commandType = CommandType.Text, bool throwDBException = true, bool throwGenericException = true, bool throwSystemException = true, int startRecord = 0, int maxRecords = 0);

        #endregion

        #region ExecuteNonQuery

        /// <summary>
        /// Execute SQL query and return the number of affected values
        /// </summary>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <returns>Number of affected rows</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<int> ExecuteNonQueryAsync(string sql, IDataParameter[] parameters, CommandType commandType = CommandType.Text);

        /// <summary>
        /// Execute SQL query and return the number of affected values
        /// </summary>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <returns>Number of affected rows</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<int> ExecuteNonQueryAsync(string sql, KeyValuePair<string, Object>[] parameters, CommandType commandType = CommandType.Text);

        /// <summary>
        /// Execute SQL query and return the number of affected values
        /// </summary>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <returns>Number of affected rows</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<int> ExecuteNonQueryAsync(string sql, List<KeyValuePair<string, Object>> parameters, CommandType commandType = CommandType.Text);

        /// <summary>
        /// Execute SQL query and return the number of affected values
        /// </summary>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <returns>Number of affected rows</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<int> ExecuteNonQueryAsync(string sql, DacSqlParameters parameters, CommandType commandType = CommandType.Text);

        /// <summary>
        /// Execute SQL query and return the number of affected values
        /// </summary>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <returns>Number of affected rows</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<int> ExecuteNonQueryAsync(string sql, dynamic parameters, CommandType commandType = CommandType.Text);

        /// <summary>
        /// Execute SQL query and return the number of affected values
        /// </summary>
        /// <param name="sql">SQL command text to be executed</param>
        /// <param name="commandType">SQL command type to execute</param>
        /// <param name="parameters">Parameters of the SQL command</param>
        /// <returns>Number of affected rows</returns>
        /// <exception cref="DacSqlExecutionException">Throws if any SqlException has accured</exception>
        /// <exception cref="DacSqlExecutionReturnedErrorCodeException">Throws if SQL query or stored procedure has returned non zero code</exception>
        /// <exception cref="DacGenericException">Throws if any Generic exception has accured</exception>
        Task<int> ExecuteNonQueryAsync<T>(string sql, T parameters, CommandType commandType = CommandType.Text);

        #endregion

        #region ExecuteScalar

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
        Task<object> ExecuteScalarAsync(string sql, KeyValuePair<string, Object>[] parameters, CommandType commandType = CommandType.Text);

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
        Task<object> ExecuteScalarAsync(string sql, List<KeyValuePair<string, Object>> parameters, CommandType commandType = CommandType.Text);

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
        Task<object> ExecuteScalarAsync(string sql, dynamic parameters, CommandType commandType = CommandType.Text);

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
        Task<object> ExecuteScalarAsync<T>(string sql, T parameters, CommandType commandType = CommandType.Text);

        #endregion
    }
}

