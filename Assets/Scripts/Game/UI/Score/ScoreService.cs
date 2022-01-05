using System.Collections;
using Cysharp.Threading.Tasks;
using Game.UI.Score.Interface;
using Services;
using UniRx;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

namespace Game.UI.Score
{
    public class ScoreService : BaseBehaviourService, IScoreService
    {
        [Inject] private GameProcessState _gameProcessState;
        [SerializeField] private ScoreText _score;
        [SerializeField] private ScoreText _totalScore;
        [SerializeField] private TimerBehaviour _timer;
        [SerializeField] private ScoreLine _scoreLine;
        private IEnumerator _updateLine;

        public ITimerBehaviour Timer => _timer;

        public override void Initialize()
        {
            base.Initialize();

            _score.Initialize();
            _totalScore.Initialize();
            _scoreLine.Initialize();

            _timer.Initialize();
        }

        public void SetScore(int score)
        {
            _score.SetText(score.ToString());
            _scoreLine.SetLineWidth((float) score / _gameProcessState.TotalScore);
        }

        public void SetTotalScore(int score)
        {
            _totalScore.SetText(score.ToString());
        }

        public void StartTimer()
        {
            throw new System.NotImplementedException();
        }

        public void StopTimer()
        {
            throw new System.NotImplementedException();
        }
    }
}