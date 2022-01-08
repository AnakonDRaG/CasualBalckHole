using System.Collections.Generic;
using CasualHole.Levels.Interface;
using CasualHole.Levels.Models;
using UnityEngine;

namespace CasualHole.Levels
{
    public class LevelPickerContent : MonoBehaviour
    {
        [SerializeField] private LevelBoxView _levelBoxPrefab;

        public void Initialize(IList<LevelModel> levels)
        {
            foreach (var level in levels)
            {
                ILevelBoxView levelBoxView = Instantiate(_levelBoxPrefab, gameObject.transform);
                levelBoxView.Initialize(level);
            }
        }
    }
}