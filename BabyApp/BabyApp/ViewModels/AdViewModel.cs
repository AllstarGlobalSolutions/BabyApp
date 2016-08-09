using System;
using AGS.Toolkit;

namespace BabyApp.ViewModels
{
	public class AdViewModel : ViewModelBase
	{
		string adImageUrl, adClickurl;

		public string AdImageUrl
		{
			get { return adImageUrl; }
			set { SetProperty( ref adImageUrl, value ); }
		}

		public string AdClickUrl
		{
			get { return adClickurl; }
			set { SetProperty( ref adClickurl, value ); }
		}
	}
}

