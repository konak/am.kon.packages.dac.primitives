using am.kon.packages.dac.primitives.Constants.Exception;

namespace am.kon.packages.dac.primitives.Exceptions
{
    /// <summary>
    /// Exception thrown when a SQL stored procedure executed within the
    /// DAC returns a non-zero error code, indicating an execution failure.
    /// This exception provides additional details such as the return code and any object returned by the procedure.
    /// </summary>
	public class DacSqlExecutionReturnedErrorCodeException : DacSqlExecutionException
	{
        /// <summary>
        /// Code returned after executing SQL stored procedure
        /// </summary>
        public int RetCode { get; }

        /// <summary>
        /// Object returned from the stored procedure
        /// </summary>
        public object ReturnedObject { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DacSqlExecutionReturnedErrorCodeException"/> class
        /// with the specified return code from the SQL command and an optional object returned from the stored procedure.
        /// </summary>
        /// <param name="retCode">Return code after SQL command execution</param>
        /// <param name="returnedObject">Object returned after SQL command execution</param>
        public DacSqlExecutionReturnedErrorCodeException(int retCode, object returnedObject = null)
            : base(Messages.SQL_EXECUTION_RETURNED_NON_ZERO_CODE + retCode)
        {
            RetCode = retCode;
            ReturnedObject = returnedObject;
        }
    }
}

