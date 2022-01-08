using System.Collections.Generic;
using System.Linq;
using CasualHole.Data;
using CasualHole.Levels.Interface;
using CasualHole.Levels.Models;
using CasualHole.Services;
using UnityEngine;

namespace CasualHole.Levels.Service
{
    public class LevelService : BaseBehaviourService, ILevelService
    {
        private SavableValue<IList<LevelModel>> _levels;

        public override void Initialize()
        {
            base.Initialize();

            _levels = new SavableValue<IList<LevelModel>>("Levels");
        }

        public void SetLevelAsCompleted(string id)
        {
            var level = _levels.Value.FirstOrDefault(level => level.Id == id);

            if (level?.NextLevel != null && !level.NextLevel.IsActive)
            {
                level.NextLevel.IsActive = true;
                _levels.SaveValuesToPreferences();
            }
        }
    }
}