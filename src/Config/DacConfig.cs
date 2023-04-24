using System;
namespace am.kon.packages.dac.primitives.Config
{
	/// <summary>
	/// Class used to work with configuration of Data Access Component
	/// </summary>
	public class DacConfig
	{
		/// <summary>
		/// Data Access Component configuration default name
		/// </summary>
		public const string SectionDefaultName = "am.kon.dac";

		/// <summary>
		/// Property identifying the default connection string registered in configuration file
		/// </summary>
		public string DefaultConnection { get; set; }
	}
}

