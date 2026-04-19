using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Audio;

public class OptionsMenu  : MonoBehaviour
{

    public Button BackButton;
    public Button ApplyButton;
    public bool isInvert;
    public Toggle toggleButton;
    private float oldvalue;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private AudioMixer mixer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("ActualScene", 1);

        isInvert = PlayerPrefs.GetInt("isInvert", 0) == 1;
        toggleButton.isOn = isInvert;

        BackButton.onClick.AddListener(Back);
        ApplyButton.onClick.AddListener(Apply);

        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        bgmSlider.value = savedVolume;
        oldvalue = savedVolume;
        

        bgmSlider.onValueChanged.AddListener(SetVolume);
    }   

    public void Back()
    {
        SceneManager.LoadScene(sceneBuildIndex: PlayerPrefs.GetInt("PreviouScene"));
        bgmSlider.value = oldvalue;
    }

    public void Apply()
    {
        if (toggleButton.isOn)
            PlayerPrefs.SetInt("isInvert", 1);
        else
            PlayerPrefs.SetInt("isInvert", 0);
        oldvalue = bgmSlider.value;
        Back();
    }

    public void SetVolume(float value)
    {
        float volume = Mathf.Log10(value) * 20;
        mixer.SetFloat("BGMVolume", volume);

        PlayerPrefs.SetFloat("BGMVolume", value);
    }
}
