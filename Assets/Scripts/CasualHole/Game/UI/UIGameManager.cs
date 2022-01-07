using CasualHole.Game.UI.Interface;
using UnityEngine;
using Zenject;

namespace CasualHole.Game.UI
{
    public class UIGameManager : MonoBehaviour, IUIGameManager
    {
        [Inject] private UIGameContext _context;


        public void OpenGameMenu()
        {
            Time.timeScale = 0;
            _context.UIGameMenu.SetActive(true);
        }

        public void CloseGameMenu()
        {
            Time.timeScale = 1;
            _context.UIGameMenu.SetActive(false);
        }

        public void OpenWinNotification()
        {
            _context.UIWinNotificationWindow.SetActive(true);
        }

        public void OpenLoseNotification()
        {
            _context.UILoseNotificationWindow.SetActive(true);
        }

        public void SetTimeOnTimer(int time)
        {
            _context.TimerText.text = time.ToString();
        }

        public void SetScoreText(int score)
        {
            _context.CurrentScoreText.text = score.ToString();
        }

        public void SetTotalScoreText(int score)
        {
            _context.TotalScoreText.text = score.ToString();
        }

        public void UpdateScoreLine(float scoreLineLength)
        {
            _context.ScoreLine.fillAmount = scoreLineLength;
        }
    }
}