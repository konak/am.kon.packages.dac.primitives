using System;
using System.Resources;
using am.kon.packages.dac.primitives.Constants.Exception;

namespace am.kon.packages.dac.primitives.Exceptions
{
	public class DacSqlExecutionException : DacGenericException
	{
        public DacSqlExecutionException() : base(Messages.SQL_EXECUTION_EXCEPTION) { }
        public DacSqlExecutionException(System.Exception innerException) : base(Messages.SQL_EXECUTION_EXCEPTION, innerException) { }
        public DacSqlExecutionException(string message, System.Exception innerException) : base(message, innerException) { }
        public DacSqlExecutionException(string message) : base(message) { }
    }
}

