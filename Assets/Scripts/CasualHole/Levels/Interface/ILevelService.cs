using CasualHole.Services;

namespace CasualHole.Levels.Interface
{
    public interface ILevelService: IService
    {
        void SetLevelAsCompleted(string id);
    }
}