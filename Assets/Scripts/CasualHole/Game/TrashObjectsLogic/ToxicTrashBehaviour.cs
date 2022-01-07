using CasualHole.Audio.Context;
using Game.TrashObjectsLogic;
using Zenject;

namespace CasualHole.Game.TrashObjectsLogic
{
    public class ToxicTrashBehaviour : BaseTrashGameObject
    {
        [Inject] private AudioGameContext _audioGameContext;

        private void Awake()
        {
            base.Initialize();
        }
    }
}