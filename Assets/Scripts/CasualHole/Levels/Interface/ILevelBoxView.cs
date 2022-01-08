using CasualHole.Levels.Models;

namespace CasualHole.Levels.Interface
{
    public interface ILevelBoxView
    {
        void Initialize(LevelModel level);
        void SetActive(bool status);
    }
}