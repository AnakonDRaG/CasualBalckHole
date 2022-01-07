using CasualHole.Game.UI.Score.Interface;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CasualHole.Game.UI.Score
{
    public class ScoreText : MonoBehaviour, IText, IInitializable
    {
        private Text _text;

        public void Initialize()
        {
            _text = GetComponent<Text>();
        }

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}