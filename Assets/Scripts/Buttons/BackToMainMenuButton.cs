using System.Collections;
using System.Collections.Generic;
using Buttons;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenuButton : BaseButtonBehaviour
{
    protected override void OnButtonClick()
    {
        SceneManager.LoadScene("LevelsScreen");
    }
}
