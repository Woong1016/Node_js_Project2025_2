using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using Newtonsoft.Json;
using System;
using UnityEngine.UIElements;
using UnityEditor.PackageManager.Requests;

public class GameApi : MonoBehaviour
{
    private string baseUrl = "http://localhost:4000/api";

    public IEnumerator RegitsterPlayer(string playername, string password)
    {
        var requsetData = new { name = playername, password = password };
        string jsonData = JsonConvert.SerializeObject(requsetData);
        Debug.Log($"Regitstering player :{jsonData}");

        using (UnityWebRequest requset = new UnityWebRequest($"{baseUrl}/regitster", "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            requset.uploadHandler = new UploadHandlerRaw(bodyRaw);
            requset.downloadHandler = new DownloadHandlerBuffer();
            requset.SetRequestHeader("Content-Type", "application/json");

            yield return requset.SendWebRequest();
            if (requset.result != UnityWebRequest.Result.Success)

            {
                Debug.LogError($"Error regitstering player : {requset.result}");
            }
            else
            {
                Debug.Log("Player regitstered successfully");

            } 


        }






    }

    public IEnumerator LoginPlayer(string playerName, string password, Action<PlayerModel> onSuccess)
    {
        var requsetData = new { name = playerName, password = password };
        string jsonData = JsonConvert.SerializeObject(requsetData);


        using (UnityWebRequest request = new UnityWebRequest($"{baseUrl}/login", "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

           
            if (request.result != UnityWebRequest.Result.Success)

            {
                Debug.LogError($"Error regitstering player : {request.result}");
            }
            else
            {
                string responseBody = request.downloadHandler.text;

                try
                {
                    var responseData = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);

                    PlayerModel playerModel = new PlayerModel(responseData["playerName"].ToString())
                    {
                        metal = Convert.ToInt32(responseData["metal"]),
                        crystal = Convert.ToInt32(responseData["crystal"]),
                        deuturium = Convert.ToInt32(responseData["deuteriurm"]),
                        planets = new List<PlanetModel>()
                    };

                    onSuccess?.Invoke(playerModel);
                    Debug.Log("Login successful");
                }

                catch (Exception ex)

                {
                    Debug.LogError($"Error processing login responce : { ex.Message}");
                }

            }

            }



        }
    }


