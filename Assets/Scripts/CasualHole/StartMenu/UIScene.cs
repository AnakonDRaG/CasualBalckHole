using CasualHole.Audio.Context;
using CasualHole.Audio.Services;
using CasualHole.Services;
using CasualHole.Setting.Interface;
using Zenject;

namespace CasualHole.StartMenu
{
    public class UIScene : BaseBehaviourService
    {
        private IAudioService _audioService;
        private ISettingService _settingService;

        [Inject]
        private void Construct(
            IAudioService audioService,
            ISettingService settingService)
        {
            _audioService = audioService;
            _settingService = settingService;
        }

        public override void Initialize()
        {
            base.Initialize();

            _audioService.Initialize();
            _settingService.Initialize();
        }

        private void Awake()
        {
            Initialize();
        }
    }
}