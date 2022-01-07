using CasualHole.Game.UI.Interface;
using CasualHole.Services;
using UnityEngine;

namespace CasualHole.Game.UI
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