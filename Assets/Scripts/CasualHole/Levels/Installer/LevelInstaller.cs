using CasualHole.Levels.Interface;
using CasualHole.Levels.Service;
using UnityEngine;
using Zenject;

namespace CasualHole.Levels.Installer
{
    public class LevelInstaller : MonoInstaller
    {

        [SerializeField] private LevelService _levelService;
        public override void InstallBindings()
        {
            Container.Bind<ILevelService>().FromInstance(_levelService).AsSingle().NonLazy();
        }
    }
}