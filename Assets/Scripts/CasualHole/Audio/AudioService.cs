using System;
using CasualHole.Audio.Services;
using CasualHole.Services;
using UnityEngine;

namespace CasualHole.Audio
{
    public class AudioService : BaseBehaviourService, IAudioService
    {
        private AudioSource _music;
        private AudioSource _notification;
        private AudioSource _audioSource;

        public override void Initialize()
        {
            base.Initialize();

            _music = gameObject.AddComponent<AudioSource>();
            _notification = gameObject.AddComponent<AudioSource>();
            _audioSource = gameObject.AddComponent<AudioSource>();

            _music.volume = 0.1f;
        }

        public void PlaySound2D(AudioClip audioClip)
        {
            _audioSource.PlayOneShot(audioClip);
        }

        public void SetSoundVolume(float volume)
        {
            _audioSource.volume = volume;
        }

        public void PlayMusic2D(AudioClip music, bool loop = false)
        {
            if (_music.isPlaying) _music.Stop();

            _music.loop = loop;
            _music.PlayOneShot(music);
        }

        public void SetMusicVolume(float volume)
        {
            _music.volume = volume;
        }

        public void PlayNotification2D(AudioClip notificationSound)
        {
            if (_notification.isPlaying) _notification.Stop();

            _notification.clip = notificationSound;
            _notification.Play();
        }

        public void SetNotificationVolume(float volume)
        {
            _notification.volume = volume;
        }
    }
}