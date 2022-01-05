using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class OpenScreenButton : BaseButtonBehaviour
    {
        [SerializeField] private string _screenName;

        protected override void OnButtonClick()
        {
            SceneManager.LoadScene(_screenName);
        }
    }
}