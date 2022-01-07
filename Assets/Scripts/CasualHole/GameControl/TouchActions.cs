using UniRx;
using UnityEngine;

namespace CasualHole.GameControl
{
    public class TouchActions
    {
   
        private Vector2 _touchPosition { get; set; }

        public Vector2 TouchPosition => _touchPosition;
        public bool IsActive { get; set; } = true;

        public TouchActions()
        {
            _touchPosition = new Vector2();

            Observable.EveryUpdate()
                .Where(_ => IsActive)
                .Subscribe(_ =>
                {
                    Debug.Log("qwe");
                    _touchPosition = Input.touchCount > 0 ? Input.GetTouch(0).deltaPosition : Vector2.zero;
                });
        }
    }
}