using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ActiveTeleporterHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Exit());
        }
    }

    private IEnumerator Exit()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}