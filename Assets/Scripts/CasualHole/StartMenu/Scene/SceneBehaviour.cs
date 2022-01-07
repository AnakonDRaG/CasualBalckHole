using CasualHole.StartMenu.Scene.Models;
using CasualHole.StartMenu.Services;
using UnityEngine;

namespace CasualHole.StartMenu.Scene
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