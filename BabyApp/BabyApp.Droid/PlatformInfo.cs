using System;
using Android.OS;
using Xamarin.Forms;
using AGS.Toolkit;

[assembly: Dependency( typeof( BabyApp.Droid.PlatformInfo ) )]
namespace BabyApp.Droid
{
	public class PlatformInfo : IPlatformInfo
	{
		public string GetManufacturer()
		{
			return Build.Manufacturer;
		}

		public string GetModel()
		{
			return Build.Model;
		}

		public string GetVersion()
		{
			return Build.VERSION.Release.ToString();
		}

		public string GetOS()
		{
			return "Android";
		}
	}
}
