using Services;

namespace Game.UI.Score.Interface
{
    public interface IScoreService: IService
    {
        void SetScore(int score);
        void SetTotalScore(int score);
        
        void StartTimer();
        void StopTimer();
        
        ITimerBehaviour Timer { get; }
    }
}