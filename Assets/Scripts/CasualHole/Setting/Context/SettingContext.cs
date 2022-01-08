using CasualHole.Data;
using CasualHole.UI.Slider;
using CasualHole.UI.Slider.Interface;
using UnityEngine;
using Zenject;

namespace CasualHole.Setting.Context
{
    public class SettingContext : MonoBehaviour, IInitializable
    {
        public SavableValue<float> MusicValue { get; private set; }
        public SavableValue<float> SoundValue { get; private set; }


        [SerializeField] private CustomSlider _musicValueSlider;
        [SerializeField] private CustomSlider _soundValueSlider;

        public ISlider SliderMusic => _musicValueSlider;
        public ISlider SliderSound => _soundValueSlider;

        public void Initialize()
        {
            MusicValue = new SavableValue<float>("Audio/Music", 0.5f);
            SoundValue = new SavableValue<float>("Audio/Sound", 0.5f);

            SliderMusic.Initialize(MusicValue);
            SliderSound.Initialize(SoundValue);
        }
    }
}