using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Text;
using UnityEditor.Experimental.GraphView;



public class UnityTonode : MonoBehaviour
{

    public Button btnPostExample;
    public Button bthGetExample;
    public Button bthResDataExample;

    public string host;
    public int port;
    public string route;

    public string postUrl;
    public string resUrl;
    public int id;
    public string data;



    public void Start()
    {
        bthGetExample.onClick.AddListener(() =>
        {
            var url = string.Format("{0}:{1}/{2}", host, port, route);

            Debug.Log(url);
            StartCoroutine(Getdata(url, (raw) =>
            {
                var res = JsonConvert.DeserializeObject<Protocols.Packets.common>(raw);
                Debug.LogFormat("{0},{1}", res.cmd, res.message);
            }));
        });

        btnPostExample.onClick.AddListener(() =>
        {
            var url = string.Format("{0}:{1}/{2}", host, port, postUrl);
            Debug.Log(url);
            var req = new Protocols.Packets.req_data();
            req.cmd = 1000;
            req.id = id;
            req.data = data;
            var json = JsonConvert.SerializeObject(req);

            StartCoroutine(Postdata(url, json, (raw) =>
            {
                Protocols.Packets.common res = JsonConvert.DeserializeObject<Protocols.Packets.common>(raw);
                Debug.LogFormat("{0},{1}", res.cmd, res.message);
            }));
        });

        bthResDataExample.onClick.AddListener(() =>
        {
            var url = string.Format("{0}:{1}/{2}", host, port, resUrl);
            Debug.Log(url);
            StartCoroutine(Getdata(url, (raw) =>
            {
                var res = JsonConvert.DeserializeObject<Protocols.Packets.res_data>(raw);

                foreach (var user in res.result)
                {
                    Debug.LogFormat("{0},{1}", user.id, user.data);
                }
            }));

        });
           
    }
    private IEnumerator Getdata(string url  , System .Action<string> callback)      // Get ��û�ϴ� �ڷ�ƾ �Լ�
    {
        var webRequest = UnityWebRequest.Get(url);          // ����û GET
        yield return webRequest.SendWebRequest();           // ��û�� ���ƿö����� ���

        Debug.Log("Get : " + webRequest.downloadHandler.text);
        if(webRequest.result == UnityWebRequest.Result.ConnectionError
            ||webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("��Ʈ��ũ ȯ���� �����ʾ� ��� �Ұ����̴� �Ӹ�");

        }
        else
        {
            callback(webRequest.downloadHandler.text);
        }

    }

    private IEnumerator Postdata(string url,string json, System.Action<string> callback)      // Get ��û�ϴ� �ڷ�ƾ �Լ�
    {
        var webRequest = new UnityWebRequest(url, "POST");          // ����û GET
        var bodyRaw = Encoding.UTF8.GetBytes(json);


        webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");
            
        yield return webRequest.SendWebRequest();

        
        if (webRequest.result == UnityWebRequest.Result.ConnectionError
            || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("��Ʈ��ũ ȯ���� �����ʾ� ��� �Ұ����̴� ���ڽľ�");

        }
        else
        {
            callback(webRequest.downloadHandler.text);
        }

        webRequest.Dispose();
    }
}
