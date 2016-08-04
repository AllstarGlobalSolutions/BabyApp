using System;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency( typeof( BabyApp.iOS.DeviceInfo ) )]
namespace BabyApp.iOS
{
	public class DeviceInfo : IDeviceInfo
	{
		UIDevice device = new UIDevice();

		public string GetModel()
		{
			return device.Model.ToString();
		}

		public string GetVersion()
		{
			return String.Format( "{0} {1}", device.SystemName, device.SystemVersion );
		}
	}
}

