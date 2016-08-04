using System;
using Android.OS;
using Xamarin.Forms;

[assembly: Dependency( typeof( BabyApp.Droid.PlatformSoundPlayer ) )]
namespace BabyApp.Droid
{
	public class PlatformSoundPlayer : IPlatformSoundPlayer
	{
		public void PlaySound( int samplingRate, byte[] pcmData )
		{

		}
	}
}
