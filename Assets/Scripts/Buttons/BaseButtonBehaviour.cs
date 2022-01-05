using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{
    public abstract class BaseButtonBehaviour: MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.OnClickAsObservable()
                .Subscribe(_ => OnButtonClick());
        }


        protected abstract void OnButtonClick();
    }
}