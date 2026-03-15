using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CredieMenu : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ReturnToMenu());
    }

    private IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(sceneName: "MainMenu");
    }
}
