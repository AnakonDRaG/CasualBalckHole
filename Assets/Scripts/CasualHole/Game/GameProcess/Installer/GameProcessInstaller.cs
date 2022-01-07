using CasualHole.Game.Services;
using CasualHole.GameControl;
using UnityEngine;
using Zenject;

namespace CasualHole.Game.GameProcess.Installer
{
    public class GameProcessInstaller: MonoInstaller
    {
        private TouchActions _touchActions;
        [SerializeField] private GameProcessState _gameProcessState;
        private GameProcessService _gameProcessService;
       
        
        public override void InstallBindings()
        {
            _gameProcessService = GetComponent<GameProcessService>();
            
            _touchActions = new TouchActions();
            
            Container.Bind<TouchActions>().FromInstance(_touchActions).AsSingle().NonLazy();

            Container.Bind<GameProcessState>().FromInstance(_gameProcessState).AsSingle();
            Container.Bind<IGameProcessService>().FromInstance(_gameProcessService).AsSingle();
            
        }
    }
}