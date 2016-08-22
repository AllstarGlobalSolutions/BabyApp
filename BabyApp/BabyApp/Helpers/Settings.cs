using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BabyApp.Helpers
{
	public class Settings
	{
		public const string REGISTER_URL = @"http://192.168.1.6:3000/api/Account/Register";
		public const string LOGIN_URL = @"http://192.168.1.6:3000/Token";
		public const string NEXT_NEED_URL = @"http://192.168.1.6:3000/api/Needs/Next/{0}";
		public const string NEXT_AD_URL = @"http://192.168.1.6:3000/api/Advertiserments/Next/{0}";
		public const string IMAGE_URL = @"http://192.168.1.6:3000/api/Files/{0}";
		public const string ACTIVITY_URL = @"http://192.168.1.6:3000/api/NeedActivity";
		public const string DEVICE_URL = @"http://192.168.1.6:3000/api/DeviceInfoes";
		public const string NEED_TYPES_URL = @"http://192.168.1.6:3000/api/NeedTypes";
		public const string REGIONS_URL = @"http://192.168.1.6:3000/api/Regions";
		public const string COUNTRIES_URL = @"http://192.168.1.6:3000/api/Countries";
		private const string USER_ID = "UserId";
		private const string EMAIL_ADDRESS = "Email";
		private const string AGE_RANGE = "AgeRange";
		private const string SURNAME = "Surname";
		private const string GIVEN_NAME = "GivenName";
		private const string GENDER = "Gender";
		private const string OCCUPATION = "Occupation";
		private const string SAVED_COUNT = "SavedCount";
		private const string SAVED = "Saved";
		private const string ACCESS_TOKEN = "AccessToken";
		private const string DEVICE_SAVED = "DeviceSaved";
		private const string SAVED_NEED_TYPES = "NeedTypes";
		private const string SAVED_REGIONS = "Regions";
		private const string SAVED_COUNTRIES = "Countries";

		private static IDictionary<string, object> properties = Application.Current.Properties;

		public static string UserId
		{
			get
			{
				if ( properties.ContainsKey( USER_ID ) )
				{
					return ( string )properties[ USER_ID ];
				}
				return null;
			}
			set
			{
				properties[ USER_ID ] = value;
			}
		}

		public static string Email
		{
			get
			{
				if ( properties.ContainsKey( EMAIL_ADDRESS ) )
				{
					return ( string )properties[ EMAIL_ADDRESS ];
				}
				return null;
			}
			set
			{
				properties[ EMAIL_ADDRESS ] = value;
			}
		}

		public static string Surname
		{
			get
			{
				if ( properties.ContainsKey( SURNAME ) )
				{
					return ( string )properties[ SURNAME ];
				}
				return null;
			}
			set
			{
				properties[ SURNAME ] = value;
			}
		}

		public static string GivenName
		{
			get
			{
				if ( properties.ContainsKey( GIVEN_NAME ) )
				{
					return ( string )properties[ GIVEN_NAME ];
				}
				return null;
			}
			set
			{
				properties[ GIVEN_NAME ] = value;
			}
		}

		public static string AgeRange
		{
			get
			{
				if ( properties.ContainsKey( AGE_RANGE ) )
				{
					return ( string )properties[ AGE_RANGE ];
				}
				return null;
			}
			set
			{
				properties[ AGE_RANGE ] = value;
			}
		}

		public static string Gender
		{
			get
			{
				if ( properties.ContainsKey( GENDER ) )
				{
					return ( string )properties[ GENDER ];
				}
				return null;
			}
			set
			{
				properties[ GENDER ] = value;
			}
		}

		public static string Occupation
		{
			get
			{
				if ( properties.ContainsKey( OCCUPATION ) )
				{
					return ( string )properties[ OCCUPATION ];
				}
				return null;
			}
			set
			{
				properties[ OCCUPATION ] = value;
			}
		}

		public static string AccessToken
		{
			get
			{
				if ( properties.ContainsKey( ACCESS_TOKEN ) )
				{
					return ( string )properties[ ACCESS_TOKEN ];
				}

				return null;
			}

			set
			{
				properties[ ACCESS_TOKEN ] = value;
			}
		}

		public static bool DeviceSaved
		{
			get
			{
				if ( properties.ContainsKey( DEVICE_SAVED ) )
				{
					return ( bool )properties[ DEVICE_SAVED ];
				}

				return false;
			}
			set
			{
				properties[ DEVICE_SAVED ] = value;
			}
		}

		public static string NeedTypes
		{
			get
			{
				if ( properties.ContainsKey( SAVED_NEED_TYPES ) )
				{
					return ( string )properties[ SAVED_NEED_TYPES ];
				}

				return null;
			}
			set
			{
				properties[ SAVED_NEED_TYPES ] = value;
			}
		}

		public static string Regions
		{
			get
			{
				if ( properties.ContainsKey( SAVED_REGIONS ) )
				{
					return ( string )properties[ SAVED_REGIONS ];
				}

				return null;
			}
			set
			{
				properties[ SAVED_REGIONS ] = value;
			}
		}

		public static string Countries
		{
			get
			{
				if ( properties.ContainsKey( SAVED_COUNTRIES ) )
				{
					return ( string )properties[ SAVED_COUNTRIES ];
				}

				return null;
			}
			set
			{
				properties[ SAVED_COUNTRIES ] = value;
			}
		}

		public static int SavedCount
		{
			get
			{
				if ( properties.ContainsKey( SAVED_COUNT ) )
				{
					return ( int )properties[ SAVED_COUNT ];
				}
				return 0;
			}
			set
			{
				properties[ SAVED_COUNT ] = value;
			}
		}

		public static void SaveNextNeed( string need )
		{
			if ( SavedCount < 10 )
			{
				properties[ "Saved" + SavedCount ] = need;
				SavedCount++;
			}
		}

		public static string GetSavedNeedAsString( int index )
		{
			if ( index < 0 || index > SavedCount - 1 )
			{
				throw new IndexOutOfRangeException();
			}

			return ( string )properties[ SAVED + index.ToString() ];
		}

		public static void RemoveSavedNeed( int index )
		{
			if ( index < 0 || index > SavedCount - 1 )
			{
				throw new IndexOutOfRangeException();
			}

			for ( int i = index; i < SavedCount - 1; i++ )
			{
				properties[ SAVED + i.ToString() ] = properties[ SAVED + ( i + 1 ).ToString() ];
			}

			SavedCount--;
		}
	}
}
