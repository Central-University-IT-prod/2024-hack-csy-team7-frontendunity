using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Narehate
{
    public int id_user;
}
[System.Serializable]
public class UserInfo
{

    public int[] users;
    

}
[System.Serializable]
public class UserInfoArray
{

    public UserInfo[] users;

}
public class UserList : MonoBehaviour
{
    public GameObject selectedUser;
    public int selectedId;
    public int selectedNumber;
    public int[] users;
    public UserInfo[] userList;
    public GameObject listElement;
    public GameObject listContainer;
    private UserInfo a;
    private UserInfo b;

    // Start is called before the first frame update
    void Start()
    {
        
        Reload();
        Debug.Log("pap");
    }

    IEnumerator Post(string url)
    {

        Narehate info = new Narehate();
        info.id_user = 0;

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
            var jsonn = request.downloadHandler.text;
            UserInfo gettedinfo = JsonUtility.FromJson<UserInfo>(jsonn);
            Debug.Log(gettedinfo.users);
            users = gettedinfo.users;
            UpdateList();
        }

    }
    public void Reload()
    {
        Debug.Log("reol");
        StartCoroutine(Post("http://{{sensitive data}}:8000/queue/users"));

    }

    void UpdateList()
    {
        for (int i = transform.childCount - 1; i >= 0; i--) { 
            Destroy(transform.GetChild(i).gameObject);
        }
        if (users.Length > 0)

        {
            
            foreach (var user in users)
            {
                GameObject a = Instantiate(listElement, transform);
                
                a.GetComponent<User>().userNumber = user;
            }
        }
    }

    public void ToEdit()
    {
        SceneManager.LoadScene(2);

    }
    public void creat()
    {
        Instantiate(listElement, transform);
    }
}
