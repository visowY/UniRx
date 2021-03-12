using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Network_test : MonoBehaviour
{
    void Start()
    {
//       Test2();
        Test3();
    }

    private void Test1()
    {
        ObservableWWW.Get("http://baidu.com/")
            .Subscribe(
                _ => Debug.Log(_.Substring(0, 10)),
                _ => Debug.LogException(_));
    }

    private void Test2()
    {
        var query = from google in ObservableWWW.Get("http://google.com/")
            from bing in ObservableWWW.Get("http://bing.com/")
            from unknown in ObservableWWW.Get(google + bing)
            select new { google, bing, unknown };

        var cancel = query.Subscribe(x => Debug.Log(x.ToString().Substring(0,10)));

        cancel.Dispose();
    }

    private void Test3()
    {
        var parallel = Observable.WhenAll(
            ObservableWWW.Get("http://google.com/"),
            ObservableWWW.Get("http://bing.com/"),
            ObservableWWW.Get("http://unity3d.com/"));

        parallel.Subscribe(xs =>
        {
            Debug.Log(xs[0].Substring(0, 100)); // google
            Debug.Log(xs[1].Substring(0, 100)); // bing
            Debug.Log(xs[2].Substring(0, 100)); // unity
        });
    }

}
