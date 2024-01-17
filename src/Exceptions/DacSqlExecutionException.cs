using am.kon.packages.dac.primitives.Constants.Exception;

namespace am.kon.packages.dac.primitives.Exceptions
{
    /// <summary>
    /// Specialized exception for handling errors specifically related to the execution of SQL commands within the DAC.
    /// Inherits from DacGenericException to provide more context-specific error information.
    /// </summary>
	public class DacSqlExecutionException : DacGenericException
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="DacSqlExecutionException"/> class without any message.
        /// </summary>
        public DacSqlExecutionException() : base(Messages.SQL_EXECUTION_EXCEPTION) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DacSqlExecutionException"/>class
        /// with a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="innerException">Inner exception</param>
        public DacSqlExecutionException(System.Exception innerException) : base(Messages.SQL_EXECUTION_EXCEPTION, innerException) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DacSqlExecutionException"/> class with a specified
        /// error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">Error message describing exception</param>
        /// <param name="innerException">Inner exception</param>
        public DacSqlExecutionException(string message, System.Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DacSqlExecutionException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">Error message describing exception</param>
        public DacSqlExecutionException(string message) : base(message) { }
    }
}

