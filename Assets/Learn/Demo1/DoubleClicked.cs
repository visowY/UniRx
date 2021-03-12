using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class DoubleClicked : MonoBehaviour
{
    private void Start()
    {
        var clickdStream = Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0));

        clickdStream.Buffer(clickdStream.Throttle(TimeSpan.FromMilliseconds(250)))
            .Where(xs => xs.Count > 2)
            .Subscribe(xs => Debug.Log("Double click detected Count:" + xs.Count));
    }
}