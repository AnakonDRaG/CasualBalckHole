using System.Collections;
using CasualHole.Services;

namespace CasualHole.Game.Services
{
    public interface IGameProcessService : IService
    {
        void OnCollectScoreTrash();
        void OnCollectToxicTrash(); 
        IEnumerator OnGameWin();
        IEnumerator OnGameLose();
        void GameProcessPause(bool paused);
        void SetPause(bool status);
    }
}