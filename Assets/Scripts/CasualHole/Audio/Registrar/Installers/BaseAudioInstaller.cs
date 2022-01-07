using CasualHole.Audio.Services;
using Zenject;

namespace CasualHole.Audio.Registrar.Installers
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