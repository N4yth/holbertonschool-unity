using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class OptionsMenu  : MonoBehaviour
{

    [SerializeField] private Button BackButton;
    [SerializeField] private Button GeneralButton;
    [SerializeField] private Button ControleButton;
    [SerializeField] private GameObject GeneralPanel;
    [SerializeField] private GameObject ControlePanel;
    private bool isInvert;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
       PlayerPrefs.SetInt("ActualScene", 1);
       BackButton.onClick.AddListener(Back);
       GeneralButton.onClick.AddListener(generalSetting);
       ControleButton.onClick.AddListener(controleSetting);
    }   

    public void Back()
    {
        SceneManager.LoadScene(sceneBuildIndex: PlayerPrefs.GetInt("PreviouScene"));
    }

    public void generalSetting()
    {
        GeneralPanel.SetActive(true);
        ControlePanel.SetActive(false);
    }

    public void controleSetting()
    {
        GeneralPanel.SetActive(false);
        ControlePanel.SetActive(true);
    }
}
