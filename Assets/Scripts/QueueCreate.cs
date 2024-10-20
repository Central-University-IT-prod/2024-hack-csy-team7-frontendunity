using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class QueueInfo
{
    
    public string queueName;
    public int timePerUser;

}
public class QueueCreate : MonoBehaviour
{
    [SerializeField] TMPro.TMP_InputField queueName;
    [SerializeField] TMPro.TMP_InputField timePerUser;
    [SerializeField] TMPro.TMP_InputField queueName2;
    [SerializeField] TMPro.TMP_InputField timePerUser2;
    IEnumerator Post(string url)
    {
        
        QueueInfo info = new QueueInfo();
        float aspectRatio = (float)Screen.width / (float)Screen.height;

        // ��������� ���������� ������ � ���������� ������ Canvas
        if (aspectRatio < 1f) // ��������, ����������� ��� ��������� (4:3 ��� ��������)
        {
            info.queueName = queueName.text;
            info.timePerUser = Convert.ToInt32(timePerUser.text);
        }
        else
        {
            info.queueName = queueName2.text;
            info.timePerUser = Convert.ToInt32(timePerUser2.text);
        }
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
            LocalDB.queueName = info.queueName;
            LocalDB.timePerUser = info.timePerUser;
            Debug.Log(request.downloadHandler.text);
            SceneManager.LoadScene(1);
            
        }
        
    }
    public void Create()
    {
        StartCoroutine(Post("http://{{sensitive data}}:8000/queue/create"));

    }
    public void Edit()
    {
        StartCoroutine(Post("http://{{sensitive data}}:8000/queue/edit"));

    }
    public void Cancel()
    {
        SceneManager.LoadScene(1);
    }
}
