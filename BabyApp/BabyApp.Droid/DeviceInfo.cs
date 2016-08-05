using System;
using Android.OS;
using Xamarin.Forms;

[assembly: Dependency( typeof( BabyApp.Droid.DeviceInfo ) )]
namespace BabyApp.Droid
{
	public class DeviceInfo : IDeviceInfo
	{
		public string GetModel()
		{
			return String.Format( "{0} {1}", Build.Manufacturer, Build.Model );
		}

		public string GetVersion()
		{
			return Build.VERSION.Release.ToString();
		}
	}
}
