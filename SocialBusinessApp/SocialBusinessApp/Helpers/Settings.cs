// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace SocialBusinessApp.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

		private const string LongitudKey = "LongitudKey_key";
		private static readonly double LongitudKeyDefault = 0;

		#endregion


		public static double LongitudSettings
		{
			get
			{
				return AppSettings.GetValueOrDefault(LongitudKey, LongitudKeyDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(LongitudKey, value);
			}
		}

        #region Setting Constants

        private const string LatitudKey = "LatitudKey_key";
        private static readonly double LatitudKeyDefault = 0;

        #endregion


        public static double LatitudSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(LatitudKey, LatitudKeyDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LatitudKey, value);
            }
        }

    }
}