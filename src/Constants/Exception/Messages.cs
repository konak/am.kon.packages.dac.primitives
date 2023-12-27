namespace am.kon.packages.dac.primitives.Constants.Exception
{
	/// <summary>
	/// Static class containing messages used in exceptions of the DAC component
	/// </summary>
	public static class Messages
	{
		/// <summary>
		/// Constant containing message about error happening on connection close process.
		/// </summary>
		public const string SQL_CONNECTION_CLOSE_EXCEPTION = "Exception during SQL connnection close.";

        /// <summary>
        /// Constant containing message about error happening on SQL command execution.
        /// </summary>
        public const string SQL_EXECUTION_EXCEPTION = "SQL execution exception";

        /// <summary>
        /// Constant containing message about error happening on SQL batch command execution.
        /// </summary>
        public const string SYSTEM_EXCEPTION_ON_EXECUTE_SQL_BATCH_LEVEL = "System Exception on ExecuteSQLBatch level";

        /// <summary>
        /// Constant containing message about non zero returned code happening on SQL command execution.
        /// </summary>
		public const string SQL_EXECUTION_RETURNED_NON_ZERO_CODE = "SQL execution returned non zero code:";

        /// <summary>
        /// Constant containing message about invalid type passed to the FillData method
        /// </summary>
		public const string FILL_DATA_INVALID_TYPE_PASSED = "Invalid type passed to FillData method: ";
    }
}

