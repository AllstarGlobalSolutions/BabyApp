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
		private const string EMAIL_ADDRESS = "Email";
		private const string AGE_RANGE = "AgeRange";
		private const string SURNAME = "Surname";
		private const string GIVEN_NAME = "GivenName";
		private const string GENDER = "Gender";
		private const string OCCUPATION = "Occupation";
		private const string SAVED_COUNT = "SavedCount";
		private const string SAVED = "Saved";

		private static IDictionary<string, object> properties = Application.Current.Properties;

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
