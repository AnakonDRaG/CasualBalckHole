using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Levels
{
    public class LevelChangeService : MonoBehaviour
    {
       
        public void OpenScene(int sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }

        public void RestartCurrentScene()
        {
            throw new System.NotImplementedException();
        }
    }
}