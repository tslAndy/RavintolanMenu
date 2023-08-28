using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Authentication : MonoBehaviour
{
    [SerializeField] TMP_InputField login, password;
    [SerializeField] private GameObject OrderLoader;

    public void Login()
    {

        if (login.text == "admin" &&
        password.text == "admin")
        {
            OrderLoader.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
