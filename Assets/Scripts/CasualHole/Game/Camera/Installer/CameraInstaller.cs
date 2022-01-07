using CasualHole.Game.Camera.Interface;
using CasualHole.Game.Camera.Model;
using UnityEngine;
using Zenject;

namespace CasualHole.Game.Camera.Installer
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private CameraBehaviour _cameraBehaviour;
        private CameraShakeModel _cameraShakeModel;

        public override void InstallBindings()
        {
            _cameraShakeModel = GetComponent<CameraShakeModel>();

            Container.Bind<ICameraBehaviour>().FromInstance(_cameraBehaviour).AsSingle().NonLazy();
            Container.Bind<CameraShakeModel>().FromInstance(_cameraShakeModel).AsSingle().NonLazy();
        }
    }
}