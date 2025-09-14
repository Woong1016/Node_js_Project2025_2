using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Runtime.CompilerServices;

public class BasicMain : MonoBehaviour
{

    public Button Hello;
    public string host;             //IP 주소 로컬에서 127.0.0.1
    public int port;                //포트주소 (3000번으로 express 동작)
    public string route;            // about 주소


    private void Start()
    {
        this.Hello.onClick.AddListener(()=>
        {
            var url = string.Format("{0}:{1}/{2}", host, port, route);
            Debug.Log(url);

            StartCoroutine(this.GetBasic(url, (raw) =>
            {
                Debug.LogFormat("{0}", raw);
            }));
        });
    }
    private IEnumerator GetBasic(string url , System.Action<string>callback)
    {
        var webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();

        if(webRequest.result == UnityWebRequest.Result.ConnectionError
            || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("네트워크 환경이 좋지 않아서 통신불가");
        }
        else
        {
            callback(webRequest.downloadHandler.text);
        }
       
    }
   
}
