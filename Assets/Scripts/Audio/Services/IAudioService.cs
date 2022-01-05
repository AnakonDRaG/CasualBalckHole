using Services;
using UnityEngine;

namespace Audio.Services
{
    public interface IAudioService : IService
    {
        void PlaySound2D(AudioClip audioClip);

        void PlayMusic2D(AudioClip music, bool loop = false);
        void PlayNotification2D(AudioClip notificationSound);
        void PlaySound3D(Vector3 position, AudioClip audioClip);
    }
}