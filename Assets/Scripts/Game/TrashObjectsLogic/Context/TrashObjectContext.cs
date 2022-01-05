using UnityEngine;

namespace Game.TrashObjectsLogic.Context
{
    public class TrashObjectContext
    {
        private const float MINScale = 0.1f;
        public float MinScale => MINScale;
        public Rigidbody Rigidbody { get; set; }
        public Vector3 OriginalLocalScale { get; set; }
    }
}