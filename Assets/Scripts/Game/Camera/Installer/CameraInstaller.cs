using Game.CameraScripts;
using Game.CameraScripts.Interface;
using Game.CameraScripts.Model;
using UnityEngine;
using Zenject;

namespace Game.Registrar.Installers
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