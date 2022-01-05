using UnityEngine;

namespace UnityTemplateProjects.StartMenu.Models
{
    public class UISceneModel : MonoBehaviour
    {
        [SerializeField] private UISceneModel nextScene;

        public UISceneModel NextScene => nextScene;
        public UISceneModel PrevScene { get; set; }

        public Transform startTransform;

        public UISceneModel()
        {
            startTransform = GetComponent<Transform>();
        }
    }
}