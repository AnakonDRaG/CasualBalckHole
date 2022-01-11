using System.Collections.ObjectModel;
using UnityEngine;

namespace CasualHole.Game.Hole.Context
{
    public class HoleContext
    {
        private const float _holeMovementSpeed = 2.8f;

        public Collection<int> VerticlesIds { get; set; }
        public Collection<Vector3> VerticesOffsets { get; set; }
        public Collection<Vector3> MoveLimits { get; set; }
        public Mesh Mesh { get; set; }
        public float HolePerfectRadius { get;  set; }
        public float RadiusToDetect { get; set; }

        public float HoleMovementSpeed => _holeMovementSpeed;
    }
}