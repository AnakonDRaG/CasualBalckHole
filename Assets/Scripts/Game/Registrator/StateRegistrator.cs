using Game.CameraScripts;
using Game.CameraScripts.Interface;
using Game.CameraScripts.Model;
using Game.Managers;
using Game.Services;
using UnityEngine;
using Zenject;


public class StateRegistrator : MonoInstaller
{
    [SerializeField] private GameProcessManager _gameProcessManager;
    [SerializeField] private CameraShakeModel _cameraShakeModel;

    [SerializeField] private CameraBehaviour _cameraBehaviour;


    private TouchActions _touchActions;

    public override void InstallBindings()
    {
        _touchActions = new TouchActions();
        Container.Bind<TouchActions>().FromInstance(_touchActions).AsSingle();
        Container.Bind<IGameProcessService>().FromInstance(_gameProcessManager).AsSingle();
        
        Container.Bind<ICameraBehaviour>().FromInstance(_cameraBehaviour).AsSingle();

        BindModels();
    }

    private void BindModels()
    {
        Container.Bind<CameraShakeModel>().FromInstance(_cameraShakeModel).AsSingle();
    }
}