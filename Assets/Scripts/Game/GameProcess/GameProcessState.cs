using Game.TrashSceneObjects.Interfaces;
using UniRx;
using UnityEngine;
using UnityTemplateProjects.Game.TrashObjectsLogic;

namespace Game
{
    public class GameProcessState : MonoBehaviour
    {
        [SerializeField] private Transform trashObjectsPatent;
        [SerializeField] private int maxTimePerLevel;
        
        public bool GamePaused { get; set; } = false;
        

        public int GameLevel { get; set; }
        public ReactiveProperty<int> CurrentScore { get; } = new ReactiveProperty<int>(0);
        public ReactiveProperty<int> CurrentTimerScore { get; } = new ReactiveProperty<int>(0);
        public int TotalScore { get; private set; }


        public int MAXTimePerLevel => maxTimePerLevel;


        public void InitGameState()
        {
            TotalScore = trashObjectsPatent.GetComponentsInChildren<TrashBehaviour>().Length;
            CurrentTimerScore.SetValueAndForceNotify(MAXTimePerLevel);
        }
    }
}