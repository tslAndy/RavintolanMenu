using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Authentication : MonoBehaviour
{
    [SerializeField] TMP_Text loginText, passwordText;
    [SerializeField] private GameObject OrderLoader;

    public void Login()
    {
        if (loginText.text == "admin" &&
        passwordText.text == "admin")
        {
            OrderLoader.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
