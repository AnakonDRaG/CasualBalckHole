using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Game.Services;
using Game.TrashSceneObjects.Interfaces;
using UniRx;
using UniRx.Triggers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;


public class HoleController : MonoBehaviour
{
    [SerializeField, Range(0.1f, 1.8f)] private float holeRadius = 1f;

    [SerializeField] private Transform holePoint;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform UI_Circle;
    [SerializeField] private MeshFilter holePlaceMesh;
    [SerializeField] private MeshCollider holePlaceCollider;
    [SerializeField] private Collider collector;

    [SerializeField] private Transform moveLimitsFirstPoint;
    [SerializeField] private Transform moveLimitsSecondPoint;


    private Collection<int> _verticesIds;
    private Collection<Vector3> _verticesOffsets;
    private Collection<Vector3> _moveLimits;
    private Mesh _mesh;

    private const float RadiusToDetect = 2;
    private float _holePerfectRadius;


    [Inject]
    private void Construct(IGameProcessService gameProcessService, TouchActions touchPhase)
    {
        _holePerfectRadius = (holeRadius / 2) + holeRadius;
        _mesh = holePlaceMesh.mesh;
        InitVerticesFromMesh();
        this.UpdateAsObservable()
            .Where(_ => Input.touches.Length > 0)
            .Select(_ => touchPhase.TouchPosition)
            .Subscribe(OnHolePointUpdate);

        collector.OnTriggerEnterAsObservable()
            .Where(obj => obj.GetComponent<ITrash>() != null)
            .Select(obj => obj.GetComponent<ITrash>())
            .Subscribe(trash => trash.DestroyGameObject());
        
        collector.OnTriggerEnterAsObservable()
            .Where(obj => obj.GetComponent<IToxicTrash>() != null)
            .Subscribe(_ =>
            {
                gameProcessService.StartWarningAnimation();
            });

        holePoint.position = startPoint.position;
        UpdateVertices();
    }

    private void InitVerticesFromMesh()
    {
        _verticesIds = new Collection<int>();
        _verticesOffsets = new Collection<Vector3>();

        var vertices = _mesh.vertices;
        for (var i = 0; i < vertices.Length; i++)
        {
            if (Vector3.Distance(holePoint.position, vertices[i]) <= RadiusToDetect)
            {
                _verticesIds.Add(i);
                _verticesOffsets.Add((vertices[i] - holePoint.position) * holeRadius);
            }
        }

        UI_Circle.localScale *= holeRadius;
    }

    private void OnHolePointUpdate(Vector2 deltaPosition)
    {
        UpdateHolePoint(deltaPosition);
        UpdateVertices();
    }

    private void UpdateHolePoint(Vector2 targetPosition)
    {
        var holePointPosition = holePoint.position;

        var touch = Vector3.Lerp(holePointPosition,
            holePointPosition + new Vector3(targetPosition.x, 0f, targetPosition.y),
            0.2f * Time.fixedDeltaTime);

        var pointFirst = moveLimitsSecondPoint.position;
        var positionSecond = moveLimitsFirstPoint.position;

        holePoint.position = new Vector3(
            Mathf.Clamp(touch.x,
                positionSecond.x + _holePerfectRadius + 0.5f,
                pointFirst.x - _holePerfectRadius - 0.5f),
            touch.y,
            Mathf.Clamp(touch.z,
                pointFirst.z + _holePerfectRadius + 0.5f,
                positionSecond.z - _holePerfectRadius - 0.5f)
        );
    }

    private void UpdateVertices()
    {
        var vertices = _mesh.vertices;
        for (var i = 0; i < _verticesIds.Count; i++)
        {
            var offsetRadius = (holePoint.position + _verticesOffsets[i])
                ;
            vertices[_verticesIds[i]] =
                new Vector3(offsetRadius.x, 0, offsetRadius.z);
        }

        _mesh.vertices = vertices;
        holePlaceCollider.sharedMesh = _mesh;
        holePlaceMesh.mesh = _mesh;
    }
}