using System;
using System.Collections.Generic;
using System.Linq;
using CasualHole.Data;
using CasualHole.Levels.Interface;
using CasualHole.Levels.Models;
using CasualHole.Services;
using UnityEditor;
using UnityEngine;

namespace CasualHole.Levels.Service
{
    public class LevelPickerService : BaseBehaviourService
    {
        [SerializeField] private LevelPickerContent _levelPickerContent;

        private SavableValue<IList<LevelModel>> _levelsSavableValue;

        public override void Initialize()
        {
            base.Initialize();

            _levelsSavableValue = new SavableValue<IList<LevelModel>>("Levels", new List<LevelModel>()
            {
                new LevelModel()
                {
                    Id = "1",
                    IsActive = true
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
            var levelScenes = EditorBuildSettings.scenes
                .Where(scene => scene.enabled)
                .Select(scene => scene.path)
                .Where(level => level.Contains("Levels/"))
                .Select(level =>
                {
                    var _level = level.Substring(level.LastIndexOf('/') + 1);
                    _level = _level.Substring(0, _level.Length - 6);
                    return _level;
                })
                .ToArray();

            if (_levelsSavableValue.Value.Count <= 1 ||
                _levelsSavableValue.Value.Count < levelScenes.Length)
            {
                for (int i = 1; i < levelScenes.Length; i++)
                {
                    var _level = new LevelModel() {Id = levelScenes[i], IsActive = false};
                    _levelsSavableValue.Value[i - 1].NextLevel = _level;

                    _levelsSavableValue.Value.Add(_level);
                }

                _levelsSavableValue.SaveValuesToPreferences();
            }
        }
    }
}