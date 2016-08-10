using System;
using Android.Media;
using Xamarin.Forms;
using BabyApp.Helpers;

[assembly: Dependency( typeof( BabyApp.Droid.PlatformSoundPlayer ) )]
namespace BabyApp.Droid
{
	public class PlatformSoundPlayer : IPlatformSoundPlayer
	{
		AudioTrack previousAudioTrack;

		public void PlaySound( int samplingRate, byte[] pcmData )
		{
			if ( previousAudioTrack != null )
			{
				previousAudioTrack.Stop();
				previousAudioTrack.Release();
			}

			AudioTrack audioTrack = new AudioTrack( Stream.Music, samplingRate, ChannelOut.Mono, Android.Media.Encoding.Pcm16bit, pcmData.Length * sizeof( short ), AudioTrackMode.Stream );
			audioTrack.Write( pcmData, 0, pcmData.Length );
			audioTrack.Play();

			previousAudioTrack = audioTrack;
		}
	}
}
