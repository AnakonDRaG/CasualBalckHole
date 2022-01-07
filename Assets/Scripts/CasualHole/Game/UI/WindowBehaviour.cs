using CasualHole.Game.UI.Interface;
using UnityEngine;

namespace CasualHole.Game.UI
{
    public class WindowBehaviour: MonoBehaviour, IWindow
    {
        
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
        
    }
}