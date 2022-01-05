using System;
using System.Collections.Generic;
using Game.GameProcess;
using Game.Hole.Interface;
using Game.TrashSceneObjects.Interfaces;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Game.Hole
{
    public class HoleForceBehaviour : MonoBehaviour, IHoleForce
    {
        private List<ITrash> _detectedTrash;
        private GameProcessState _gameProcessState;

        [Inject]
        private void Construct(GameProcessState gameProcessState) => (_gameProcessState) = (gameProcessState);

        public void Awake()
        {
            _detectedTrash = new List<ITrash>();
        }

        public void Start()
        {
            this.OnTriggerEnterAsObservable()
                .Where(obj => obj.GetComponent<ITrash>() != null)
                .Select(obj => obj.GetComponent<ITrash>())
                .Subscribe(trashObj => _detectedTrash.Add(trashObj));

            this.OnTriggerExitAsObservable()
                .Where(obj => obj.GetComponent<ITrash>() != null)
                .Select(obj => obj.GetComponent<ITrash>())
                .Subscribe(trashObj => _detectedTrash.Remove(trashObj));

            this.UpdateAsObservable()
                .Where(_ => _detectedTrash.Count > 0 && !_gameProcessState.GamePaused)
                .Subscribe(_ => ForceDetectedTrash());
        }

        public void ForceDetectedTrash() =>
            _detectedTrash.ForEach(trashObj => trashObj.ForceTo(transform.position));
    }
}