using System;
namespace am.kon.packages.dac.primitives.Exceptions
{
    /// <summary>
    /// Represents the base exception class for all Data Access Component (DAC) related errors.
    /// This generic exception serves as a foundation for more specific DAC exceptions.
    /// </summary>
    public class DacGenericException : Exception
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="DacGenericException"/> class without any message.
        /// </summary>
        public DacGenericException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DacGenericException"/> class with a specified error message.
        /// </summary>
        /// <param name="errorMessage">Error message describing exception</param>
		public DacGenericException(string errorMessage) : base(errorMessage) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DacGenericException"/> class with a specified
        /// error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="errorMessage">Error message describing exception</param>
        /// <param name="innerException">Inner exception.</param>
        public DacGenericException(string errorMessage, Exception innerException) : base(errorMessage, innerException) { }
    }
}

