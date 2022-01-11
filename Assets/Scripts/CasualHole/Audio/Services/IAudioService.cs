using CasualHole.Services;
using UnityEngine;

namespace CasualHole.Audio.Services
{
    public interface IAudioService : IService
    {
        void PlaySound2D(AudioClip audioClip);
        void SetSoundVolume(float volume);

        void PlayMusic2D(AudioClip music, bool loop = false);
        void SetMusicVolume(float volume);
    }
}