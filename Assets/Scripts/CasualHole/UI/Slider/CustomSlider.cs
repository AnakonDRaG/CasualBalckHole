using System;
using CasualHole.UI.Slider.Interface;
using UnityEngine;


namespace CasualHole.UI.Slider
{
    public class CustomSlider : MonoBehaviour, ISlider
    {
        private UnityEngine.UI.Slider _slider;
        public float Value { get; private set; } = 0;

        private void Awake()
        {
            _slider = GetComponent<UnityEngine.UI.Slider>();
        }

        public void OnValueChange(float value) => Value = value;

        public void Initialize(float value)
        {
            Value = value;
            _slider.value = value;
            _slider.onValueChanged.AddListener(OnValueChange);
        }
    }
}