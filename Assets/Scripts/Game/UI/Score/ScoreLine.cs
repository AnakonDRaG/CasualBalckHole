using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using Game.UI.Score.Interface;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI.Score
{
    public class ScoreLine : MonoBehaviour, IScoreLine, IInitializable
    {
        private Image _line;
        private float _needScore = 0;

        public void Initialize()
        {
            _line = GetComponent<Image>();

            StartCoroutine(UpdateScoreLine());
        }

        public void SetLineWidth(float score)
        {
            _needScore = score;
        }


        private IEnumerator UpdateScoreLine()
        {
            while (true)
            {
                var fill = _line.fillAmount;

                if (fill != _needScore)
                    _line.fillAmount = Mathf.Lerp(fill, _needScore, 0.05f);

                yield return null;
            }
        }
    }
}