using System.Collections.Generic;
using System.IO;
using System.Linq;
using CasualHole.Data;
using CasualHole.Levels.Models;
using CasualHole.Services;
using UnityEngine;
using Application = UnityEngine.Application;

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
            var directoryInfo = new DirectoryInfo($"{Application.dataPath}/Scenes/Levels/");
            var allFileInfos = directoryInfo.GetFiles("*.unity", SearchOption.AllDirectories);

            var levelScenes = allFileInfos.Select(levels => levels.Name.Split('.')[0]).ToArray();

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