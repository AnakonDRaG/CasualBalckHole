using System.Collections;
using CasualHole.Game.Camera.Interface;
using CasualHole.Game.Camera.Model;
using UnityEngine;
using Zenject;

namespace CasualHole.Game.Camera
{
    public class CameraBehaviour : MonoBehaviour, ICameraBehaviour
    {
        private CameraShakeModel _cameraShakeModel;

        [Inject]
        private void Construct(CameraShakeModel cameraShakeModel)
        {
            _cameraShakeModel = cameraShakeModel;
        }

        public IEnumerator ShakeCamera()
        {
            var originalPosition = transform.localPosition;
            var elapsed = 0.0f;

            while (elapsed < _cameraShakeModel.Duration)
            {
                var xRandom = Random.Range(-1f, 1f) * _cameraShakeModel.Magnitude;
                var yRandom = Random.Range(-1f, 1f) * _cameraShakeModel.Magnitude;

                transform.localPosition =
                    new Vector3(originalPosition.x + xRandom, originalPosition.y + yRandom, originalPosition.z);
                elapsed += Time.deltaTime;

                yield return null;
            }

            transform.localPosition = originalPosition;
        }
    }
}