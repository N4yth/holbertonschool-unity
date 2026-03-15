using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button StartButton;
    public Button QuitButton;
    public Button OptionButton;

    void Start()
    {
        PlayerPrefs.SetInt("PreviouScene", 0);
        OptionButton.onClick.AddListener(Options);
        QuitButton.onClick.AddListener(QuitGame);
        StartButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene(sceneName: "Level01");
    }

    void Options()
    {
        SceneManager.LoadScene(sceneName: "Option");
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
