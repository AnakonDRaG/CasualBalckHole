using UnityEngine;

namespace Game.Hole.Context
{
    public class HoleBehaviourContext : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 1.8f)] private float holeRadius = 1f;
        
        [SerializeField] private Transform holePoint;
        [SerializeField] private Transform startPoint;
        [SerializeField] private Transform ui_Circle;
        [SerializeField] private MeshFilter holePlaceMesh;
        [SerializeField] private MeshCollider holePlaceCollider;
        [SerializeField] private Collider collector;

        [SerializeField] private Transform moveLimitsFirstPoint;
        [SerializeField] private Transform moveLimitsSecondPoint;
        
        public Transform HolePoint => holePoint;
        public Transform StartPoint => startPoint;
        public Transform UI_Circle => ui_Circle;
        public MeshFilter HolePlaceMesh => holePlaceMesh;
        public MeshCollider HolePlaceCollider => holePlaceCollider;
        public Collider Collector => collector;
        
        public Transform MoveLimitsFirstPoint => moveLimitsFirstPoint;
        public Transform MoveLimitsSecondPoint => moveLimitsSecondPoint;

        public float HoleRadius => holeRadius;
    }
}