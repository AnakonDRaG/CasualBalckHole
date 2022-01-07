using System;
using CasualHole.Data;
using CasualHole.UI.Slider.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;


namespace CasualHole.UI.Slider
{
    public class CustomSlider : MonoBehaviour, ISlider
    {
        private UnityEngine.UI.Slider _slider;

        private float _value = 0;


        public void Initialize(SavableValue<float> savableValue)
        {
            _slider = GetComponent<UnityEngine.UI.Slider>();

            _value = savableValue.Value;
            _slider.SetValueWithoutNotify(_value);

            _slider
                .onValueChanged
                .AddListener(value => _value = value);

            _slider
                .OnPointerUpAsObservable()
                .Subscribe(_ =>
                {
                    savableValue.Value = _value;
                    Debug.Log(savableValue.Value);
                });
        }
    }
}