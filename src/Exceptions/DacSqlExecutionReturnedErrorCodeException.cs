using System;
using System.Resources;
using am.kon.packages.dac.primitives.Constants.Exception;

namespace am.kon.packages.dac.primitives.Exceptions
{
    /// <summary>
    /// Exception fired when the stored procedure returns not zero code,
    /// and it means that an error has accured during storedprocedure execution
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
        /// Constructor returning instance of <see cref="DacSqlExecutionReturnedErrorCodeException"/>
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

