using UnityEngine;

namespace Game.TrashObjectsLogic.Model
{
    public class TrashObjectModel
    {
        private const float MINScale = 0.1f;

        public float MinScale => MINScale;

        public Rigidbody Rigidbody { get; }
        public Vector3 OriginalLocalScale { get; }

        public TrashObjectModel(Rigidbody rigidbody, Vector3 originalLocalScale) =>
            (Rigidbody, OriginalLocalScale) = (rigidbody, originalLocalScale);
    }
}