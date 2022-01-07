using CasualHole.Audio.Context;

namespace CasualHole.Audio.Registrar.Installers
{
    public class AudioGameInstaller: BaseAudioInstaller
    {
        private AudioGameContext _audioGameContext;

        protected override void Binding()
        {
            _audioGameContext = GetComponent<AudioGameContext>();
            Container.Bind<AudioGameContext>().FromInstance(_audioGameContext).AsSingle().NonLazy();
        }
    }
}