using CasualHole.Audio.Services;
using CasualHole.Services;
using CasualHole.Setting.Context;
using CasualHole.Setting.Interface;
using UnityEngine;
using Zenject;

namespace CasualHole.Setting.Services
{
    public class SettingService : BaseBehaviourService, ISettingService
    {
        [Inject] private IAudioService _audioService;

        [SerializeField] private SettingContext _context;


        public override void Initialize()
        {
            base.Initialize();
            _context.Initialize();

            _context.MusicValue.OnChange += _audioService.SetMusicVolume;
            _context.SoundValue.OnChange += _audioService.SetSoundVolume;
        }
    }
}