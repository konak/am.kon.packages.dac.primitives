using System;
namespace am.kon.packages.dac.primitives.Exceptions
{
	/// <summary>
	/// Generic Exception thrown from DAC
	/// </summary>
	public class DacGenericException : Exception
	{
        /// <summary>
        /// Default constructor to create instance of <see cref="DacGenericException"/>.
        /// </summary>
        public DacGenericException() : base() { }

        /// <summary>
        /// Constructor creating instance of the <see cref="DacGenericException"/>.
        /// </summary>
        /// <param name="errorMessage">Error message describing exception</param>
		public DacGenericException(string errorMessage) : base(errorMessage) { }

        /// <summary>
        /// Constructor creating instance of the <see cref="DacGenericException"/>.
        /// </summary>
        /// <param name="errorMessage">Error message describing exception</param>
        /// <param name="innerException">Inner exception.</param>
        public DacGenericException(string errorMessage, Exception innerException) : base(errorMessage, innerException) { }
    }
}

