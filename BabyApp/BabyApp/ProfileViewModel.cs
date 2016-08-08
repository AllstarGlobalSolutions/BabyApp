using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGS.Toolkit;

namespace BabyApp
{
	public class ProfileViewModel : ViewModelBase
	{
		string surname, givenName, email, phone, occupation, gender, ageRange;
		bool isValid;

		public string Surname
		{
			get { return surname; }
			set { SetProperty( ref surname, value ); }
		}

		public string GivenName
		{
			get { return givenName; }
			set { SetProperty( ref givenName, value ); }
		}

		public string Email
		{
			get { return email; }
			set
			{
				SetProperty( ref email, value );
				TestIfValid();
			}
		}

		public bool IsValid
		{
			get { return isValid; }
			private set { SetProperty( ref isValid, value ); }
		}

		void TestIfValid()
		{
			IsValid = !String.IsNullOrEmpty( Email );
		}

		public string Phone
		{
			get { return phone; }
			set { SetProperty( ref phone, value ); }
		}

		public string Occupation
		{
			get { return occupation; }
			set { SetProperty( ref occupation, value ); }
		}

		public string Gender
		{
			get { return gender; }
			set { SetProperty( ref gender, value ); }
		}

		public string AgeRange
		{
			get { return ageRange; }
			set { SetProperty( ref ageRange, value ); }
		}
	}
}
