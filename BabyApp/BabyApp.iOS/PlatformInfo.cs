using System;
using UIKit;
using Xamarin.Forms;
using AGS.Toolkit;

[assembly: Dependency( typeof( BabyApp.iOS.PlatformInfo ) )]
namespace BabyApp.iOS
{
	public class PlatformInfo : IPlatformInfo
	{
		UIDevice device = new UIDevice();

		public string GetManufacturer()
		{
			return "Apple";
		}

		public string GetModel()
		{
			return device.Model.ToString();
		}

		public string GetVersion()
		{
			return String.Format( "{0} {1}", device.SystemName, device.SystemVersion );
		}

		public string GetOS()
		{
			return "iOS";
		}
	}
}

