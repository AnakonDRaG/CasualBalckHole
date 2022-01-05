using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class GoToNextLevelButton : BaseButtonBehaviour
    {
        protected override void OnButtonClick()
        {
            Time.timeScale = 1;
            var lvl = int.Parse(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene($"Scenes/Levels/{lvl + 1}");
        }
    }
}