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
		private const string BASE_URL = "BaseUrl";
		public static string BaseUrl
		{
			get
			{
				if ( properties.ContainsKey( BASE_URL ) )
					return ( string )properties[ BASE_URL ];
				return @"http://192.168.1.6:3000";
			}
			set
			{
				properties[ BASE_URL ] = value;
			}
		}

		private const string LOGIN_URL = "LoginUrl";
		public static string LoginUrl
		{
			get
			{
				if ( properties.ContainsKey( LOGIN_URL ) )
					return ( string )properties[ LOGIN_URL ]; // "/token"
				return @"/token";
			}
			set
			{
				properties[ LOGIN_URL ] = value;
			}
		}

		private const string REGISTER_URL = "RegisterUrl";
		public static string RegisterUrl
		{
			get
			{
				if ( properties.ContainsKey( REGISTER_URL ) )
					return ( string )properties[ REGISTER_URL ]; // "/api/Account/Register"
				return @"/api/Account/Register";
			}
			set
			{
				properties[ REGISTER_URL ] = value;
			}
		}

		private const string NEXT_NEED_URL = "NextNeedUrl";
		public static string NextNeedUrl
		{
			get
			{
				if ( properties.ContainsKey( NEXT_NEED_URL ) )
					return ( string )properties[ NEXT_NEED_URL ]; // "/api/Needs/Next/{0}"
				return @"/api/Needs/Next/{0}";
			}
			set
			{
				properties[ NEXT_NEED_URL ] = value;
			}
		}

		private const string NEXT_AD_URL = "NextAdUrl";
		public static string NextAdUrl
		{
			get
			{
				if ( properties.ContainsKey( NEXT_AD_URL ) )
					return ( string )properties[ NEXT_AD_URL ]; // "/api/Advertisements/Next/{0}"
				return @"/api/Advertisements/Next/{0}";
			}
			set
			{
				properties[ NEXT_AD_URL ] = value;
			}
		}

		private const string IMAGE_URL = "ImageUrl";
		public static string ImageUrl
		{
			get
			{
				if ( properties.ContainsKey( IMAGE_URL ) )
					return ( string )properties[ IMAGE_URL ]; // "/api/Files/{0}"
				return @"/api/Files/{0}";
			}
			set
			{
				properties[ IMAGE_URL ] = value;
			}
		}

		private const string ACTIVITY_URL = "ActivityUrl";
		public static string ActivityUrl
		{
			get
			{
				if ( properties.ContainsKey( ACTIVITY_URL ) )
					return ( string )properties[ ACTIVITY_URL ]; // "/api/NeedActivity"
				return @"/api/NeedActivity";
			}
			set
			{
				properties[ ACTIVITY_URL ] = value;
			}
		}

		private const string DEVICE_URL = "DeviceUrl";
		public static string DeviceUrl
		{
			get
			{
				if ( properties.ContainsKey( DEVICE_URL ) )
					return ( string )properties[ DEVICE_URL ]; // "/api/DeviceInfoes"
				return @"/api/DeviceInfoes";
			}
			set
			{
				properties[ DEVICE_URL ] = value;
			}
		}

		private const string NEED_TYPE_URL = "NeedTypesUrl";
		public static string NeedTypeUrl
		{
			get
			{
				if ( properties.ContainsKey( NEED_TYPE_URL ) )
					return ( string )properties[ NEED_TYPE_URL ]; // "/api/NeedTypes"
				return @"/api/NeedTypes";
			}
			set
			{
				properties[ NEED_TYPE_URL ] = value;
			}
		}

		private const string REGION_URL = "RegionUrl";
		public static string RegionUrl
		{
			get
			{
				if ( properties.ContainsKey( REGION_URL ) )
					return ( string )properties[ REGION_URL ]; // "/api/Regions"
				return @"/api/Regions";
			}
			set
			{
				properties[ REGION_URL ] = value;
			}
		}

		private const string COUNTRY_URL = "CountryUrl";
		public static string CountryUrl
		{
			get
			{
				if ( properties.ContainsKey( COUNTRY_URL ) )
					return ( string )properties[ COUNTRY_URL ]; // "/api/Countries"
				return @"/api/Countries";
			}
			set
			{
				properties[ COUNTRY_URL ] = value;
			}
		}

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
