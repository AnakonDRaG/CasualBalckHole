using Game.UI.Interface;
using Game.UI.Model;
using Game.UI.Score;
using Game.UI.Score.Interface;
using UnityEngine;
using Zenject;

namespace Game.UI.Installer
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private UIGameContext _uiGameContext;
        [SerializeField] private UIGameManager _uiGameManager;
        [SerializeField] private UIAnimatorController _uiAnimatorController;

        private UIGameService _uiGameService;
        [SerializeField] private ScoreService _scoreService;

        public override void InstallBindings()
        {
            _uiGameService = GetComponent<UIGameService>();

            Container.Bind<IScoreService>().FromInstance(_scoreService).AsSingle().NonLazy();
            Container.Bind<IUIGameService>().FromInstance(_uiGameService).AsSingle().NonLazy();

            Container.Bind<UIGameContext>().FromInstance(_uiGameContext).AsSingle().NonLazy();
            Container.Bind<IUIGameManager>().FromInstance(_uiGameManager).AsSingle().NonLazy();
            Container.Bind<UIAnimatorController>().FromInstance(_uiAnimatorController).AsSingle().NonLazy();
        }
    }
}