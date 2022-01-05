using UnityEngine;
using Zenject;

namespace Game.TrashSceneObjects.Interfaces
{
    public interface ITrash: IInitializable
    {
        void ForceTo(Vector3 position);
        void DestroyGameObject();
    }
}