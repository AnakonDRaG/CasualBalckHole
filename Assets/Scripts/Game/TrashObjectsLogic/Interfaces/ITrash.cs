using UnityEngine;

namespace Game.TrashSceneObjects.Interfaces
{
    public interface ITrash
    {
        void ForceTo(Vector3 position);
        void DestroyGameObject();
    }
}