using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class monoTriggersExam : MonoBehaviour
{
    private void Start()
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

//        cube.AddComponent<ObservableUpdateTrigger>()
//            .UpdateAsObservable()
//            .SampleFrame(30)
//            .Subscribe(x => Debug.Log("cube"), () => Debug.Log("destory"));

        cube.UpdateAsObservable()
            .SampleFrame(30)
            .Subscribe(
                _ => Debug.Log("x"));
        
//        GameObject.Destroy(cube,3f);
    }
}
