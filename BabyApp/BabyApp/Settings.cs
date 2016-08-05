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

		public string Email
		{
			get
			{
				if ( Application.Current.Properties.ContainsKey( EMAIL_ADDRESS ) )
				{
					return Application.Current.Properties[ EMAIL_ADDRESS ];
				}
				return null;
			}
			set
			{
				Application.Current.Properties[ EMAIL_ADDRESS ] = value;
			}
		}


	}
}
