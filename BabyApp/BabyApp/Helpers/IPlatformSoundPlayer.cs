using System;
namespace BabyApp.Helpers
{
	public interface IPlatformSoundPlayer
	{
		void PlaySound( int samplingRate, byte[] pcmData );
	}
}

