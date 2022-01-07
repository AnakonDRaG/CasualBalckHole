using UnityEngine;
using UnityEngine.UI;

namespace CasualHole.Game.UI
{
    public class UIGameContext : MonoBehaviour
    {
        [SerializeField] private GameObject _UIWinNotificationWindow;
        [SerializeField] private GameObject _UILoseNotificationWindow;
        [SerializeField] private GameObject _UIGameMenu;
        
        [SerializeField] private Image _scoreLine;
        
        [SerializeField] private Text _currentScoreText;
        [SerializeField] private Text _totalScoreText;
        [SerializeField] private Text _timerText;
        
        
        public GameObject UIWinNotificationWindow => _UIWinNotificationWindow;
        public GameObject UILoseNotificationWindow => _UILoseNotificationWindow;
        public GameObject UIGameMenu => _UIGameMenu;
        public Image ScoreLine => _scoreLine;
        public Text CurrentScoreText => _currentScoreText;
        public Text TotalScoreText => _totalScoreText;
        public Text TimerText => _timerText;
    }
}