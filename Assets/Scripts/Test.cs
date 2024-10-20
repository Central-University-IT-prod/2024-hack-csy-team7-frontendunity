using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System;
using Unity.VisualScripting;


public class PlayerData
{
    public string name;
    public int age;
    
}
public class Test : MonoBehaviour
{
    [SerializeField] GameObject c1;
    [SerializeField] GameObject c2;
    
    [SerializeField] TMPro.TMP_InputField p1;
    [SerializeField] TMPro.TMP_InputField p2;
    [SerializeField] TMPro.TMP_InputField p3;
    [SerializeField] TMPro.TMP_InputField p4;

    void Start()
    {
        //StartCoroutine(GetData());
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) { 
            Application.Quit();
        }

    }
    IEnumerator GetData()
    {
        string url = "http://localhost:5000/azy/auth/register";
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                // Получение и обработка JSON-ответа
                string jsonResponse = request.downloadHandler.text;
                Debug.Log("Response: " + jsonResponse);

                // Десериализация JSON (если нужно)
                // Например, если вы ожидаете массив объектов
                PlayerData data = JsonUtility.FromJson<PlayerData>(jsonResponse);
                p3.text = data.name;
                p4.text = data.age.ToString();

            }
        }
    }
    IEnumerator Post()
    {
        string url = "http://localhost:8000/azy/auth/register";
        PlayerData player = new PlayerData();
        player.name = p1.text;
        player.age = Convert.ToInt32(p2.text);
        string json = JsonUtility.ToJson(player);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Instantiate(c2);
            Debug.LogError(request.error);
        }
        else
        {
            Instantiate(c1);
            Debug.Log(request.downloadHandler.text);
            var jsonn = request.downloadHandler.text;
            PlayerData l = JsonUtility.FromJson<PlayerData>(jsonn);
            p3.text = l.name;
            p4.text = l.age.ToString();
            Debug.Log(jsonn);
        }
        StopCoroutine(Post());
    }
    public void asas()
    {
        StartCoroutine(Post());
    }
}
