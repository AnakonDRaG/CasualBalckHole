using CasualHole.Game.UI;
using UnityEngine;

namespace CasualHole.UI.Buttons
{
    public class WindowHandlerButton : BaseButtonBehaviour
    {
        [SerializeField] private WindowBehaviour _window;

        protected override void OnButtonClick()
        {
            if (!_window.IsShown())
            {
                _window.Show();
                Time.timeScale = 0;
            }
            else
            {
                _window.Hide();
                Time.timeScale = 1;
            }
        }
    }
}