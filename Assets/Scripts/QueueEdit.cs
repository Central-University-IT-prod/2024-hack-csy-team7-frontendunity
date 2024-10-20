using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueEdit : MonoBehaviour
{
    [SerializeField] TMPro.TMP_InputField queueName;
    [SerializeField] TMPro.TMP_InputField timePerUser;
    // Start is called before the first frame update
    void Start()
    {
        queueName.text = LocalDB.queueName;
        timePerUser.text = LocalDB.timePerUser.ToString();
    }

}
