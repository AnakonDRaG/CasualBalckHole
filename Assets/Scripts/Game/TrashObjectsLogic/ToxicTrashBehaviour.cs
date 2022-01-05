using System;
using Audio;
using Audio.Context;
using Game.TrashSceneObjects.Interfaces;
using Zenject;

namespace Game.TrashObjectsLogic
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