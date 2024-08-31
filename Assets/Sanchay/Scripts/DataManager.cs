using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataManager : MonoBehaviour
{
    /*[SerializeField] string UserName;
    public TMP_InputField Name;

    public void updateUserName()
    {
        UserName = Name.text;
    }*/


    public TMP_InputField Name;
    

    // This method is called when the user enters their name and confirms it.
    public void UpdateUserName()
    {
        // Store the entered username in PlayerPrefs
        PlayerPrefs.SetString("UserName", Name.text);

        // Optionally, you can immediately save to disk, but it's usually automatic
        PlayerPrefs.Save();

        Debug.Log("saved username "+ Name.text);    
    }

    // This method can be called to retrieve the username from PlayerPrefs
    public static string GetUserName()
    {
        // Retrieve the username. If it doesn't exist, return a default value.
        return PlayerPrefs.GetString("UserName", "Guest");
    }
}


