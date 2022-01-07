using CasualHole.Data;
using CasualHole.Services;
using CasualHole.Setting.Interface;

namespace CasualHole.Setting.Services
{
    public class SettingService : BaseBehaviourService, ISettingService
    {
        private const string _playerPrefsPath = "CasualHole/SavableValue/";

        private SavableValue<float> _musicValue;
        private SavableValue<float> _soundValue;

        public override void Initialize()
        {
            base.Initialize();
            
            _musicValue = new SavableValue<float>($"{_playerPrefsPath}/Audio/Music", 0.5f);
            _soundValue = new SavableValue<float>($"{_playerPrefsPath}/Audio/Sound", 0.5f);
        }
        
        
        
        
    }
}