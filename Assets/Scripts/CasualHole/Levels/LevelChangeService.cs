using UnityEngine;
using UnityEngine.SceneManagement;

namespace CasualHole.Levels
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