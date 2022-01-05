using Game.GameProcess;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Buttons
{
    public class RestartLevelButton : BaseButtonBehaviour
    {
        protected override void OnButtonClick()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}