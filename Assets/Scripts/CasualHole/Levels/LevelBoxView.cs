using System;
using CasualHole.Levels.Interface;
using CasualHole.Levels.Models;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace CasualHole.Levels
{
    public class LevelBoxView : MonoBehaviour, ILevelBoxView
    {
        private Button _button;
            
        [SerializeField] private GameObject _lockedState;

        [SerializeField] private Text _title;


        public void Initialize(LevelModel level)
        {
            _button = GetComponent<Button>();
            
            _title.text = level.Id;

            SetActive(level.IsActive);


            _button.OnClickAsObservable()
                .Where(_ => level.IsActive)
                .Subscribe(_ =>
                {
                    Debug.Log(level.SceneName);
                    SceneManager.LoadScene(level.SceneName);
                });
        }

        public void SetActive(bool status)
        {
            _lockedState.SetActive(!status);
        }
    }
}