using Audio.Context;
using Audio.Services;
using UnityEngine;
using Zenject;

namespace Audio.Registrar.Installers
{
    public abstract class BaseAudioInstaller : MonoInstaller
    {
        private AudioService _audioService;


        public override void InstallBindings()
        {
            _audioService = GetComponent<AudioService>();

            Container.Bind<IAudioService>().FromInstance(_audioService).AsSingle().NonLazy();
            Binding();
        }

        protected abstract void Binding();
    }
}