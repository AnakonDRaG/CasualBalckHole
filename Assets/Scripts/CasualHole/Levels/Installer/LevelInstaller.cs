using UnityEngine;
using Zenject;

namespace CasualHole.Levels.Installer
{
    public class LevelInstaller : MonoInstaller
    {

        [SerializeField] private LevelService _levelService;
        public override void InstallBindings()
        {
            Container.Bind<LevelService>().FromInstance(_levelService).AsSingle().NonLazy();
        }
    }
}