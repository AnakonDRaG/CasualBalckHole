namespace CasualHole.Game.UI.Score.Interface
{
    public interface ITimerBehaviour
    {
        void SetTime(int time);
        
        void TimeIsRunningOut();
        void TimeIsEnd();
    }
}