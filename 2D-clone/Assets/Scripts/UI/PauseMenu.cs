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

    [Tooltip("Button to resume game")]
    [SerializeField]
    public Button ResumeButton;

    [Tooltip("Button to go to the menu")]
    [SerializeField]
    public Button MenuButton;

    [Tooltip("Button to go to the Option")]
    [SerializeField]
    public Button OptionsButton;

    [Tooltip("Player to stop")]
    [SerializeField]
    public Rigidbody2D playerRb;
    
    void Start()
    {
        ResumeButton.onClick.AddListener(Resume);
        MenuButton.onClick.AddListener(MainMenu);
        OptionsButton.onClick.AddListener(Options);
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
        PauseCanvas.gameObject.SetActive(true);
        playerRb.linearVelocity = Vector2.zero;
        playerRb.angularVelocity = 0f;
    }

    void Resume()
    {
        CameraScript.enabled = true;
        PlayerScript.enabled = true;
        PauseCanvas.gameObject.SetActive(false);
    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu() 
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
    }

    public void Options()
    {
        PlayerPrefs.SetInt("PreviouScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(sceneName: "Option");
    }
}
