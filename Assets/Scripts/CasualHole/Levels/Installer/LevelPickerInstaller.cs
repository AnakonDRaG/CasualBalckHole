using CasualHole.Levels.Interface;
using CasualHole.Levels.Service;
using UnityEngine;
using Zenject;

namespace CasualHole.Levels.Installer
{
    public class LevelPickerInstaller : MonoInstaller
    {
        [SerializeField] private LevelPickerService _levelPickerService;

        public override void InstallBindings()
        {
            Container.Bind<LevelPickerService>().FromInstance(_levelPickerService).AsSingle().NonLazy();
        }
    }
}