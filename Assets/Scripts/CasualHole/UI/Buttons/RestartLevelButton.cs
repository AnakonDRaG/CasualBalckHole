using UnityEngine;
using UnityEngine.SceneManagement;

namespace CasualHole.UI.Buttons
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