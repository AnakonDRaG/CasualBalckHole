using CasualHole.Game.UI.Interface;
using UnityEngine;

namespace CasualHole.Game.UI
{
    public class WindowBehaviour : MonoBehaviour, IWindow
    {
        private bool _isShow = false;

        public void Hide()
        {
            _isShow = false;
            gameObject.SetActive(_isShow);
        }

        public void Show()
        {
            _isShow = true;
            gameObject.SetActive(_isShow);
        }

        public bool IsShown() => _isShow;
    }
}