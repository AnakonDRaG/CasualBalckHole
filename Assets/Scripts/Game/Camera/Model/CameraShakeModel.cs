using UnityEngine;

namespace Game.CameraScripts.Model
{
    public class CameraShakeModel : MonoBehaviour
    {
        [SerializeField] [Range(0.1f, 2f)] private float _duration = 0.5f;
        [SerializeField] [Range(0.1f, 2f)] private float _magnitude = 0.5f;
        public float Duration => _duration;
        public float Magnitude => _magnitude;
    }
}