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


        public void Initialize(SavableValue<float> savableValue)
        {
            _slider = GetComponent<UnityEngine.UI.Slider>();
            _slider.SetValueWithoutNotify(savableValue.Value);

            _slider
                .onValueChanged
                .AddListener(value => savableValue.Value = value);

            _slider
                .OnPointerUpAsObservable()
                .Subscribe(_  => savableValue.SaveValuesToPreferences());
        }
    }
}