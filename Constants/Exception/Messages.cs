using System;
namespace am.kon.packages.dac.primitives.Constants.Exception
{
	/// <summary>
	/// Static class containing messages used in exceptions of the DAC component
	/// </summary>
	public static class Messages
	{
		public const string SQL_CONNECTION_CLOSE_EXCEPTION = "Exception during SQL connnection close.";
		public const string SQL_EXECUTION_EXCEPTION = "SQL execution exception";
        public const string SYSTEM_EXCEPTION_ON_EXECUTE_SQL_BATCH_LEVEL = "System Exception on ExecuteSQLBatch level";
		public const string SQL_EXECUTION_RETURNED_NON_ZERO_CODE = "SQL execution returned non zero code:";
		public const string FILL_DATA_INVALID_TYPE_PASSED = "Invalid type passed to FillData method: ";
    }
}

