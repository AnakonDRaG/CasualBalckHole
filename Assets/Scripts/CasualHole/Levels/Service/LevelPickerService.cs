using System.Collections.Generic;
using CasualHole.Data;
using CasualHole.Levels.Models;
using CasualHole.Services;
using UnityEditor;
using UnityEngine;

namespace CasualHole.Levels.Service
{
    public class LevelPickerService : BaseBehaviourService
    {
        [SerializeField] private LevelPickerContent _levelPickerContent;
        [SerializeField] private List<string> _levels;

        private SavableValue<IList<LevelModel>> _levelsSavableValue;

        public override void Initialize()
        {
            base.Initialize();


            _levelsSavableValue = new SavableValue<IList<LevelModel>>("Levels", new List<LevelModel>()
            {
                new LevelModel()
                {
                    Id = "1",
                    SceneName = _levels[0],
                    IsActive = true,
                }
            });

            PreInitLevels();

            _levelPickerContent.Initialize(_levelsSavableValue.Value);
        }

        private void Awake()
        {
            Initialize();
        }

        private void PreInitLevels()
        {
            if (_levelsSavableValue.Value.Count <= 1 ||
                _levelsSavableValue.Value.Count < _levels.Count)
            {
                for (int i = 0; i < _levels.Count; i++)
                {
                    var _level = new LevelModel()
                    {
                        Id = (i + 1).ToString(),
                        SceneName = _levels[i],
                        IsActive = false
                    };

                    if (i == 0) continue;
                    _levelsSavableValue.Value.Add(_level);
                    _levelsSavableValue.Value[i - 1].NextLevel = _level;
                }

                _levelsSavableValue.SaveValuesToPreferences();
            }
        }
    }
}