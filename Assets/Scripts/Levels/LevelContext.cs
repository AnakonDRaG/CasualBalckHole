using System;

namespace Game.Levels
{
    [Serializable]
    public class LevelContext
    {
        public int Id { get; set; }
        public int TotalTime { get; private set; } = 0;
        public int CompletedTime { get; private set; } = 0;


        public void SetLevelState(int completedTime) => CompletedTime = completedTime;
        
    }
}