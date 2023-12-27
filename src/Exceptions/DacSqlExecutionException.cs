using am.kon.packages.dac.primitives.Constants.Exception;

namespace am.kon.packages.dac.primitives.Exceptions
{
    /// <summary>
    /// Exception to be used to control DAC specific exception handling of error during SQL command execution
    /// </summary>
	public class DacSqlExecutionException : DacGenericException
	{
        /// <summary>
        /// Default constructor returning instance of <see cref="DacSqlExecutionException"/>
        /// </summary>
        public DacSqlExecutionException() : base(Messages.SQL_EXECUTION_EXCEPTION) { }

        /// <summary>
        /// Constructor returning instance of <see cref="DacSqlExecutionException"/>
        /// </summary>
        /// <param name="innerException">Inner exception</param>
        public DacSqlExecutionException(System.Exception innerException) : base(Messages.SQL_EXECUTION_EXCEPTION, innerException) { }

        /// <summary>
        /// Constructor returning instance of <see cref="DacSqlExecutionException"/>
        /// </summary>
        /// <param name="message">Error message describing exception</param>
        /// <param name="innerException">Inner exception</param>
        public DacSqlExecutionException(string message, System.Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Constructor returning instance of <see cref="DacSqlExecutionException"/>
        /// </summary>
        /// <param name="message">Error message describing exception</param>
        public DacSqlExecutionException(string message) : base(message) { }
    }
}

