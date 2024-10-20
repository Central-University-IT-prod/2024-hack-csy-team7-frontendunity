using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class User : MonoBehaviour
{
    public int userId;
    public int userNumber;
    bool isSelected = false;
    public GameObject buttons;
    private UserList userList;
    [SerializeField] TMP_Text numberText;
    private void OnEnable()
    {
        userList = gameObject.transform.parent.GetComponent<UserList>();
        numberText.text = userNumber.ToString();
    }
    private void Start()
    {
        userList = gameObject.transform.parent.GetComponent<UserList>();
        numberText.text = userNumber.ToString();
    }
    public void OnPointerD()
    {
        if (!isSelected) {
            if (userList.selectedUser != null)
            {
                userList.selectedUser.GetComponent<User>().isSelected = false;
                userList.selectedUser.GetComponent<User>().buttons.SetActive(false);
            }
            
            isSelected = true;
            userList.selectedUser = gameObject;
            userList.selectedId = userId;
            userList.selectedNumber = userNumber;
            buttons.SetActive(true);
            
        }
        else
        {
            isSelected = false;
            userList.selectedUser = null;
            userList.selectedId = 0;
            userList.selectedNumber = 0;
            buttons.SetActive(false);
        }
        Debug.Log("lol");

    }
}
