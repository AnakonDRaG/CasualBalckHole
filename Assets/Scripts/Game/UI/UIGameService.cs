using Game.UI.Interface;
using Services;
using UnityEngine;

namespace Game.UI
{
    public class UIGameService: BaseBehaviourService, IUIGameService
    {
        [SerializeField] private WindowBehaviour _winWindow;
        [SerializeField] private WindowBehaviour _loseWindow;
        [SerializeField] private WindowBehaviour _gameMenuWindow;

        public IWindow WinWindow => _winWindow;
        public IWindow LoseWindow => _loseWindow;
        public IWindow GameMenuWindow => _gameMenuWindow;
        
    }
}