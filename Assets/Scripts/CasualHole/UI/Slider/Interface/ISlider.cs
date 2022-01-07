using System;
using CasualHole.Data;

namespace CasualHole.UI.Slider.Interface
{
    public interface ISlider
    {
        void Initialize(SavableValue<float> savableValue);
    }
}