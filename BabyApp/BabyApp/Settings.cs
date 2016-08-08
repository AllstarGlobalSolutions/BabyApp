using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BabyApp
{
	public class Settings
	{
		private const string EMAIL_ADDRESS = "Email";
		private const string AGE_RANGE = "AgeRange";
		private const string SURNAME = "Surname";
		private const string GIVEN_NAME = "GivenName";
		private const string GENDER = "Gender";
		private const string OCCUMPATION = "Occupation";	

		public static string Email
		{
			get
			{
				if ( Application.Current.Properties.ContainsKey( EMAIL_ADDRESS ) )
				{
					return Application.Current.Properties[ EMAIL_ADDRESS ].ToString();
				}
				return null;
			}
			set
			{
				Application.Current.Properties[ EMAIL_ADDRESS ] = value;
			}
		}

		public static string Surname
		{
			get
			{
				if ( Application.Current.Properties.ContainsKey( SURNAME ) )
				{
					return Application.Current.Properties[ SURNAME ].ToString();
				}
				return null;
			}
			set
			{
				Application.Current.Properties[ SURNAME ] = value;
			}
		}

		public static string GivenName
		{
			get
			{
				if ( Application.Current.Properties.ContainsKey( GIVEN_NAME ) )
				{
					return Application.Current.Properties[ GIVEN_NAME ].ToString();
				}
				return null;
			}
			set
			{
				Application.Current.Properties[ GIVEN_NAME ] = value;
			}
		}

		public static string AgeRange
		{
			get
			{
				if ( Application.Current.Properties.ContainsKey( AGE_RANGE ) )
				{
					return Application.Current.Properties[ AGE_RANGE ].ToString();
				}
				return null;
			}
			set
			{
				Application.Current.Properties[ AGE_RANGE ] = value;
			}
		}

		public static string Gender
		{
			get
			{
				if ( Application.Current.Properties.ContainsKey( GENDER ) )
				{
					return Application.Current.Properties[ GENDER ].ToString();
				}
				return null;
			}
			set
			{
				Application.Current.Properties[ GENDER ] = value;
			}
		}

		public static string Occupation
		{
			get
			{
				if ( Application.Current.Properties.ContainsKey( OCCUMPATION ) )
				{
					return Application.Current.Properties[ AGE_RANGE ].ToString();
				}
				return null;
			}
			set
			{
				Application.Current.Properties[ OCCUMPATION ] = value;
			}
		}

	}
}
