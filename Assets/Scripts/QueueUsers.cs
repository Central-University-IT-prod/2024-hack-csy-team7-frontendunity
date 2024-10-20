using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class Request
{

    public int userId;
    public int queueId;
    public string time;

}

public class QueueUsers : MonoBehaviour
{
    IEnumerator Post(string url)
    {

        UserInfo info = new UserInfo();

        
        string json = JsonUtility.ToJson(info);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            StopAllCoroutines();
            Debug.LogError(request.error);
        }
        else
        {
            StopAllCoroutines();
            
            Debug.Log(request.downloadHandler.text);
            SceneManager.LoadScene(1);

        }

    }
    public void Create()
    {
        StartCoroutine(Post("http://{{sensitive data}}:8000/queue/create"));

    }
}
