namespace Game.UI.Interface
{
    public interface IUIGameManager
    {
        void OpenGameMenu();
        void CloseGameMenu();
        void OpenWinNotification();
        void OpenLoseNotification();
        void SetTimeOnTimer(int time);
        void SetScoreText(int score);
        void SetTotalScoreText(int score);
        
        void UpdateScoreLine(float scoreLineLength);

    }
}