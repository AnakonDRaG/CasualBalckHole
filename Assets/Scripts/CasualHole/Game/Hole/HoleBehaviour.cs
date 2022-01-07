using System.Collections.ObjectModel;
using CasualHole.Game.GameProcess;
using CasualHole.Game.Hole.Context;
using CasualHole.Game.Services;
using CasualHole.Game.TrashObjectsLogic;
using CasualHole.GameControl;
using Game.TrashObjectsLogic;
using Game.TrashSceneObjects.Interfaces;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace CasualHole.Game.Hole
{
    public class HoleBehaviour : MonoBehaviour
    {
        private HoleContext _holeModel;
        private HoleBehaviourContext _holeBehaviourModel;
        private GameProcessState _gameProcessState;

        [Inject]
        private void Construct(
            IGameProcessService gameProcessService,
            TouchActions touchPhase,
            GameProcessState gameProcessState)
        {
            _gameProcessState = gameProcessState;

            _holeBehaviourModel = GetComponent<HoleBehaviourContext>();

            _holeModel = new HoleContext()
            {
                RadiusToDetect = _holeBehaviourModel.HoleRadius + 1f,
                HolePerfectRadius = (_holeBehaviourModel.HoleRadius / 2) + _holeBehaviourModel.HoleRadius,
                Mesh = _holeBehaviourModel.HolePlaceMesh.mesh
            };

            InitVerticesFromMesh();

            this.UpdateAsObservable()
                .Where(_ => touchPhase.IsActive && Input.touches.Length > 0)
                .Select(_ => touchPhase.TouchPosition)
                .Subscribe(OnHolePointUpdate);

            _holeBehaviourModel.Collector.OnTriggerEnterAsObservable()
                .Where(obj => obj.GetComponent<TrashBehaviour>())
                .Select(obj => obj.GetComponent<ITrash>())
                .Subscribe(trash =>
                {
                    gameProcessService.OnCollectScoreTrash();
                    trash.DestroyGameObject();
                });

            _holeBehaviourModel.Collector.OnTriggerEnterAsObservable()
                .Where(obj => obj.GetComponent<ToxicTrashBehaviour>())
                .Subscribe(_ => { gameProcessService.OnCollectToxicTrash(); });

            _holeBehaviourModel.HolePoint.position = _holeBehaviourModel.StartPoint.position;
            UpdateVertices();
        }

        private void InitVerticesFromMesh()
        {
            _holeModel.VerticlesIds = new Collection<int>();
            _holeModel.VerticesOffsets = new Collection<Vector3>();

            var vertices = _holeModel.Mesh.vertices;
            for (var i = 0; i < vertices.Length; i++)
            {
                if (Vector2.Distance(
                    new Vector2(_holeBehaviourModel.HolePoint.position.x, _holeBehaviourModel.HolePoint.position.z),
                    vertices[i]) <= _holeModel.RadiusToDetect)
                {
                    _holeModel.VerticlesIds.Add(i);
                    _holeModel.VerticesOffsets.Add((vertices[i] - _holeBehaviourModel.HolePoint.position) *
                                                   _holeBehaviourModel.HoleRadius);
                }
            }

            _holeBehaviourModel.UI_Circle.localScale *= _holeBehaviourModel.HoleRadius;
        }

        private void OnHolePointUpdate(Vector2 deltaPosition)
        {
            UpdateHolePoint(deltaPosition);
            UpdateVertices();
        }

        private void UpdateHolePoint(Vector2 targetPosition)
        {
            var holePointPosition = _holeBehaviourModel.HolePoint.position;

            var touch = Vector3.Lerp(holePointPosition,
                holePointPosition + new Vector3(targetPosition.x, 0f, targetPosition.y),
                0.2f * _holeModel.HoleMovementSpeed * Time.fixedDeltaTime);

            var pointFirst = _holeBehaviourModel.MoveLimitsSecondPoint.position;
            var positionSecond = _holeBehaviourModel.MoveLimitsFirstPoint.position;

            _holeBehaviourModel.HolePoint.position = new Vector3(
                Mathf.Clamp(touch.x,
                    positionSecond.x + _holeModel.HolePerfectRadius + 0.5f,
                    pointFirst.x - _holeModel.HolePerfectRadius - 0.5f),
                touch.y,
                Mathf.Clamp(touch.z,
                    pointFirst.z + _holeModel.HolePerfectRadius + 0.5f,
                    positionSecond.z - _holeModel.HolePerfectRadius - 0.5f)
            );
        }

        private void UpdateVertices()
        {
            var vertices = _holeModel.Mesh.vertices;

            for (var i = 0; i < _holeModel.VerticlesIds.Count; i++)
            {
                var offsetRadius = (_holeBehaviourModel.HolePoint.position + _holeModel.VerticesOffsets[i]);
                vertices[_holeModel.VerticlesIds[i]] =
                    new Vector3(offsetRadius.x, 0, offsetRadius.z);
            }

            _holeModel.Mesh.vertices = vertices;
            _holeBehaviourModel.HolePlaceCollider.sharedMesh = _holeModel.Mesh;
            _holeBehaviourModel.HolePlaceMesh.mesh = _holeModel.Mesh;
        }
    }
}