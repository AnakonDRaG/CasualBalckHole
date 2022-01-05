using System.Collections;
using Cysharp.Threading.Tasks;
using Services;

namespace Game.Services
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