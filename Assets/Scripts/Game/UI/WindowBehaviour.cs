using System;
using Cysharp.Threading.Tasks;
using Game.UI.Interface;
using UnityEditor.Animations;
using UnityEngine;

namespace Game.UI
{
    public class WindowBehaviour: MonoBehaviour, IWindow
    {
        
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
        
    }
}