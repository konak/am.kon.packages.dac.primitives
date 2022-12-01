using System;
namespace am.kon.packages.dac.primitives.Exceptions
{
	/// <summary>
	/// Generic Exception thrown from DAC
	/// </summary>
	public class DacGenericException : Exception
	{
		public DacGenericException() : base() { }
		public DacGenericException(string errorMesssage) : base(errorMesssage) { }
        public DacGenericException(string errorMesssage, Exception innerException) : base(errorMesssage, innerException) { }
    }
}

