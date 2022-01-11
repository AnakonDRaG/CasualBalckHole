using System;
using Zenject;

namespace CasualHole.Game.Hole.Interface
{
    public interface IHoleBehaviour : IInitializable
    {
        public Action OnCollectScoreObject { get; set; }
        public Action OnCollectTrashObject { get; set; }
    }
}