using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    [Tooltip("Menu to display")]
    [SerializeField]
    public GameObject PauseCanvas;

    [Tooltip("Script player movement")]
    [SerializeField]
    public PlayerController PlayerScript;

    [Tooltip("Script camera movement")]
    [SerializeField]
    public CameraController CameraScript;

    [Tooltip("Timer to pause")]
    [SerializeField]
    public Timer TimeScript;

    [Tooltip("Button to resume game")]
    [SerializeField]
    public Button ResumeButton;
    
    void Start()
    {
        ResumeButton.onClick.AddListener(Resume);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PauseCanvas.activeInHierarchy == true) {
            Resume();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && PauseCanvas.activeInHierarchy == false)
        {
            Pause();
        }
    }

    void Pause()
    {
        CameraScript.enabled = false;
        PlayerScript.enabled = false;
        TimeScript.enabled = false;
        PauseCanvas.gameObject.SetActive(true);
    }

    void Resume()
    {
        CameraScript.enabled = true;
        PlayerScript.enabled = true;
        TimeScript.enabled = true;
        PauseCanvas.gameObject.SetActive(false);
    }
}
