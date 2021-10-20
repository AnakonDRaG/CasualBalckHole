using System;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

public class TouchActions
{
    private Vector2 _touchPosition;

    public Vector2 TouchPosition { get; private set; }

    public TouchActions()
    {
        TouchPosition = new Vector2();

        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                TouchPosition = Input.touchCount > 0 ? Input.GetTouch(0).deltaPosition : Vector2.zero;
                
            });
    }
}