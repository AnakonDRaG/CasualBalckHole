using CasualHole.Setting.Interface;
using CasualHole.Setting.Services;
using UnityEngine;
using Zenject;

namespace CasualHole.Setting.Registrar.Installer
{
    public class SettingInstaller: MonoInstaller
    {

        [SerializeField] private SettingService _settingService;
        public override void InstallBindings()
        {
            Container.Bind<ISettingService>().FromInstance(_settingService).AsSingle();
        }
    }
}