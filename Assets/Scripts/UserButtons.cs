using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PassRequest
{
    public int id_user;
    
}
public class DelRequest
{
    public int id_user;
    
}

public class UserButtons : MonoBehaviour
{
    IEnumerator Post(string url)
    {

        PassRequest info = new PassRequest();
        
        info.id_user = transform.parent.GetComponent<User>().userNumber;
        
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
            gameObject.transform.parent.GetComponent<User>().OnPointerD();
            Destroy(gameObject.transform.parent.gameObject);
        }

    }
    IEnumerator Post1(string url)
    {

        PassRequest info = new PassRequest();
        
        info.id_user = transform.parent.GetComponent<User>().userNumber;
        
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
            gameObject.transform.parent.GetComponent<User>().OnPointerD();
            Destroy(gameObject.transform.parent.gameObject);
        }

    }
    public void Pass()
    {
        StartCoroutine(Post("http://{{sensitive data}}:8000/queue/user/pass"));

    }
    public void Delete()
    {
        StartCoroutine(Post1("http://{{sensitive data}}:8000/queue/user/delete"));

    }
}
