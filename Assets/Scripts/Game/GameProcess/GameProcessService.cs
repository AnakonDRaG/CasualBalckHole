using System;
using System.Collections;
using Audio.Context;
using Audio.Services;
using Cysharp.Threading.Tasks;
using Game.CameraScripts.Interface;
using Game.Services;
using Game.UI.Interface;
using Game.UI.Score.Interface;
using GameControl;
using Services;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.GameProcess
{
    public class GameProcessService : BaseBehaviourService, IGameProcessService
    {
        private IAudioService _audioService;
        private IUIGameService _uiGameService;
        private IScoreService _scoreService;

        private AudioGameContext _audioGameContext;

        private IUIGameManager _uiGameManager;


        private ICameraBehaviour _cameraBehaviour;

        private GameProcessState _gameProcessState;
        private TouchActions _touchActions;

        [Inject]
        private void Construct(
            IAudioService audioService,
            IUIGameManager uiGameManager,
            IUIGameService uiGameService,
            IScoreService scoreService,
            ICameraBehaviour cameraBehaviour,
            GameProcessState gameProcessState,
            AudioGameContext audioGameContext,
            TouchActions touchActions)
        {
            _audioService = audioService;
            _audioGameContext = audioGameContext;

            _touchActions = touchActions;
            _gameProcessState = gameProcessState;

            _uiGameManager = uiGameManager;

            _uiGameService = uiGameService;
            _scoreService = scoreService;
            _cameraBehaviour = cameraBehaviour;

            _scoreService.Initialize();
            _uiGameService.Initialize();
            _audioService.Initialize();


            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();
            _gameProcessState.InitGameState();
            _gameProcessState.CurrentTimerScore
                .Subscribe(time => _scoreService.Timer.SetTime(time));

            _gameProcessState.CurrentScore
                .Subscribe(score => _scoreService.SetScore(score));

            _scoreService.SetTotalScore(_gameProcessState.TotalScore);

            InitGameLogic();
        }

        private void InitGameLogic()
        {
            _audioService.PlayMusic2D(_audioGameContext.BackgroundMusic, true);

            var timer = new CompositeDisposable();

            Observable
                .Timer(TimeSpan.FromSeconds(1))
                .Repeat()
                .Subscribe(_ =>
                {
                    var time = _gameProcessState.CurrentTimerScore.Value;

                    _gameProcessState
                        .CurrentTimerScore
                        .SetValueAndForceNotify(time - 1);


                    if (time <= 6 && time > 1)
                    {
                        _scoreService.Timer.TimeIsRunningOut();
                        _audioService.PlaySound2D(
                            _audioGameContext.TimeOutSound[time % _audioGameContext.TimeOutSound.Count]);
                    }
                }).AddTo(timer);

            _gameProcessState.CurrentScore
                .Where(i => i == _gameProcessState.TotalScore)
                .Subscribe(_ =>
                {
                    MainThreadDispatcher.StartCoroutine(OnGameWin());
                    StopAllCoroutines();
                    timer.Dispose();
                });


            _gameProcessState
                .CurrentTimerScore
                .Where(time => time == 0)
                .Subscribe(_ =>
                {
                    _scoreService.Timer.TimeIsEnd();
                    MainThreadDispatcher.StartCoroutine(OnGameLose());
                    timer.Dispose();
                });
        }


        public void StartWarningAnimation()
        {
            throw new NotImplementedException();
        }

        public void OnCollectScoreTrash()
        {
            if (_gameProcessState.GamePaused) return;

            _audioService.PlaySound2D(_audioGameContext.CollectSound);
            _gameProcessState.CurrentScore.SetValueAndForceNotify(_gameProcessState.CurrentScore.Value + 1);
        }

        public void OnCollectToxicTrash()
        {
            if (_gameProcessState.GamePaused) return;

            _audioService.PlaySound2D(_audioGameContext.CollectToxicSound);
            MainThreadDispatcher.StartCoroutine(_cameraBehaviour.ShakeCamera());
            MainThreadDispatcher.StartCoroutine(OnGameLose());
        }

        public IEnumerator OnGameWin()
        {
            _audioService.PlayNotification2D(_audioGameContext.WinSound);
            GamePause(true);
            _touchActions.IsActive = false;
            _uiGameService.WinWindow.Show();


            yield break;
        }

        public IEnumerator OnGameLose()
        {
            _audioService.PlayNotification2D(_audioGameContext.LoseSound);
            _touchActions.IsActive = false;


            yield return new WaitForSeconds(2);

            GamePause(true);

            _uiGameService.LoseWindow.Show();

            yield break;
        }

        public void SetPause(bool status)
        {
            _gameProcessState.GamePaused = status;
            _touchActions.IsActive = !status;
            Time.timeScale = status ? 0 : 1;
        }

        public void RestartGame()
        {
            SetPause(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void BackToMenu()
        {
            throw new NotImplementedException();
        }

        public void GamePause(bool paused) => Time.timeScale = paused ? 1 : 0;
    }
}