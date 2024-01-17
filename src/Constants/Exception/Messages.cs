namespace am.kon.packages.dac.primitives.Constants.Exception
{
	/// <summary>
	/// Static class containing messages used in exceptions of the DAC component
	/// </summary>
	public static class Messages
	{
        /// <summary>
        /// Message indicating an exception occurred during the closing of an SQL connection.
        /// </summary>
        public const string SQL_CONNECTION_CLOSE_EXCEPTION = "An error occurred while closing the SQL connection.";

        /// <summary>
        /// Message for a generic SQL command execution exception, used when an unspecified error occurs during SQL execution.
        /// </summary>
        public const string SQL_EXECUTION_EXCEPTION = "A generic error occurred during SQL command execution.";

        /// <summary>
        /// Message used when a system-level exception occurs during the execution of an SQL batch command.
        /// </summary>
        public const string SYSTEM_EXCEPTION_ON_EXECUTE_SQL_BATCH_LEVEL = "A system-level error occurred during the execution of an SQL batch command.";

        /// <summary>
        /// Message prefix for indicating that SQL execution resulted in a non-zero return code, signaling an error.
        /// </summary>
		public const string SQL_EXECUTION_RETURNED_NON_ZERO_CODE = "SQL command execution resulted in an error with return code: ";

        /// <summary>
        /// Message indicating that an invalid type was passed to the FillData method, used to flag data type mismatches or unexpected types.
        /// </summary>
		public const string FILL_DATA_INVALID_TYPE_PASSED = "An invalid type was passed to the FillData method: ";
    }
}

