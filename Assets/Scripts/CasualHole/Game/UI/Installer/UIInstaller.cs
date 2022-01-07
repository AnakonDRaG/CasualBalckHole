using CasualHole.Game.UI.Interface;
using CasualHole.Game.UI.Score;
using CasualHole.Game.UI.Score.Interface;
using UnityEngine;
using Zenject;

namespace CasualHole.Game.UI.Installer
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private UIGameContext _uiGameContext;

        private UIGameService _uiGameService;
        [SerializeField] private ScoreService _scoreService;

        public override void InstallBindings()
        {
            _uiGameService = GetComponent<UIGameService>();

            Container.Bind<IScoreService>().FromInstance(_scoreService).AsSingle().NonLazy();
            Container.Bind<IUIGameService>().FromInstance(_uiGameService).AsSingle().NonLazy();

            Container.Bind<UIGameContext>().FromInstance(_uiGameContext).AsSingle().NonLazy();
        }
    }
}