using System;
namespace BabyApp
{
	public interface IPlatformSoundPlayer
	{
		void PlaySound( int samplingRate, byte[] pcmData );
	}
}

