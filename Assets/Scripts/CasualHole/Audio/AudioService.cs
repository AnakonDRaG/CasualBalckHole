using System;
using CasualHole.Audio.Services;
using CasualHole.Services;
using UnityEngine;

namespace CasualHole.Audio
{
    public class AudioService : BaseBehaviourService, IAudioService
    {
        private AudioSource _music;
        private AudioSource _Notification;
        private AudioSource _audioSource;

        public override void Initialize()
        {
            base.Initialize();

            _music = gameObject.AddComponent<AudioSource>();
            _Notification = gameObject.AddComponent<AudioSource>();
            _audioSource = gameObject.AddComponent<AudioSource>();

            _music.volume = 0.1f;
        }

        public void PlaySound2D(AudioClip audioClip)
        {
            //if(_audioSource.isPlaying) _audioSource.Stop();
            
            _audioSource.PlayOneShot(audioClip);
        }

        public void PlayMusic2D(AudioClip music, bool loop = false)
        {
            if(_music.isPlaying) _music.Stop();
            
            _music.loop = loop;
            _music.PlayOneShot(music);
        }

        public void PlayNotification2D(AudioClip notificationSound)
        {
            if(_Notification.isPlaying) _Notification.Stop();
            
            _Notification.clip = notificationSound;
            _Notification.Play();
        }

        public void PlaySound3D(Vector3 position, AudioClip audioClip)
        {
            throw new NotImplementedException();
        }
    }
}