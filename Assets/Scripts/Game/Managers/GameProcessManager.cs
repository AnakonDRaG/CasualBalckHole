using Game.CameraScripts.Interface;
using Game.Services;
using UnityEngine;
using Zenject;

namespace Game.Managers
{
    public class GameProcessManager : MonoBehaviour, IGameProcessService
    {
        private ICameraBehaviour _cameraBehaviour;

        [Inject]
        public void Construct(ICameraBehaviour cameraBehaviour)
        {
            _cameraBehaviour = cameraBehaviour;
        }

        public void StartWarningAnimation()
        {
            StartCoroutine(_cameraBehaviour.ShakeCamera());
        }
    }
}