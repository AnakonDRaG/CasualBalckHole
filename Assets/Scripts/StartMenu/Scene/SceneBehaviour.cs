using StartMenu.Services;
using UnityEngine;
using UnityTemplateProjects.StartMenu.Models;

namespace UnityTemplateProjects.StartMenu.Scene
{
    public class SceneBehaviour : MonoBehaviour, IUIScene
    {
        private UISceneModel _model;
        
        public void Next()
        {
            _model.PrevScene = _model;
        }

        public void Prev()
        {
            throw new System.NotImplementedException();
        }
    }
}