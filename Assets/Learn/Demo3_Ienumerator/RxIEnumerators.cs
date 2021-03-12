using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class RxIEnumerators : MonoBehaviour
{
    private void Start()
    {
        var cancel = Observable.FromCoroutine(AsyncA)
            .SelectMany(AsyncB)
            .Subscribe();
        
        cancel.Dispose();
    }

    IEnumerator AsyncA()
    {
        Debug.Log("a start");
        yield return new WaitForSeconds(1);
        Debug.Log("a end");
    }

    IEnumerator AsyncB()
    {
        Debug.Log("b start");
        yield return new WaitForEndOfFrame();
        Debug.Log("b end");
    }
}
