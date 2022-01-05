using Game.UI.Score.Interface;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI.Score
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