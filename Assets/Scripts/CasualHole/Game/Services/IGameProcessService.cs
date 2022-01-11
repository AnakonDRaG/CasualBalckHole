using System.Collections;
using CasualHole.Services;

namespace CasualHole.Game.Services
{
    public interface IGameProcessService : IService
    {
        IEnumerator OnGameWin();
        IEnumerator OnGameLose();
        void GameProcessPause(bool paused);
    }
}