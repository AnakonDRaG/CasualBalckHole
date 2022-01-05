using System.Collections.Generic;
using UnityEngine;

namespace Audio.Context
{
    public class AudioGameContext : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> _timerOutSound;
        [SerializeField] private AudioClip _winSound;
        [SerializeField] private AudioClip _loseSound;
        [SerializeField] private AudioClip _backgroundMusic;
        
        [SerializeField] private AudioClip _collectSound;
        [SerializeField] private AudioClip _collectToxicSound;

        public List<AudioClip> TimeOutSound => _timerOutSound;
        public AudioClip WinSound => _winSound;
        public AudioClip LoseSound => _loseSound;
        public AudioClip BackgroundMusic => _backgroundMusic;
        public AudioClip CollectSound => _collectSound;
        public AudioClip CollectToxicSound => _collectToxicSound;
    }
}