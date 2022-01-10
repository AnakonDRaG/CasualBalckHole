using System;

namespace CasualHole.Levels.Models
{
    [Serializable]
    public class LevelModel
    {
        public string Id { get; set; }
        public string SceneName { get; set; }
        public bool IsActive { get; set; }

        public LevelModel NextLevel { get; set; }
    }
}