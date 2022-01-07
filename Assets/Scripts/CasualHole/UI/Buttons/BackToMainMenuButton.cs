using UnityEngine.SceneManagement;

namespace CasualHole.UI.Buttons
{
    public class BackToMainMenuButton : BaseButtonBehaviour
    {
        protected override void OnButtonClick()
        {
            SceneManager.LoadScene("LevelsScreen");
        }
    }
}
