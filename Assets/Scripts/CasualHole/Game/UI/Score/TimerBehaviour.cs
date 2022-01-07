using CasualHole.Game.UI.Score.Interface;
using UnityEngine;
using Zenject;

namespace CasualHole.Game.UI.Score
{
    public class TimerBehaviour : MonoBehaviour, ITimerBehaviour, IInitializable
    {
        [SerializeField] private ScoreText _timerScore;

        private Animator _animator;

        public void Initialize()
        {
            _timerScore.Initialize();
            _animator = GetComponent<Animator>();
        }

        public void SetTime(int time)
        {
            _timerScore.SetText(time.ToString());
        }

        public void TimeIsRunningOut()
        {
            
            _animator.Play("TimeIsRunningOut");
 
        }

        public void TimeIsEnd()
        {
            _animator.Play("TimeIsEnd");
     
        }
    }
}