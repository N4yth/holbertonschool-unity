using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class OptionsMenu  : MonoBehaviour
{

    public Button BackButton;
    public Button ApplyButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
       PlayerPrefs.SetInt("ActualScene", 1);
       BackButton.onClick.AddListener(Back);
    }   

    public void Back()
    {
        SceneManager.LoadScene(sceneBuildIndex: PlayerPrefs.GetInt("PreviouScene"));
    }
}
