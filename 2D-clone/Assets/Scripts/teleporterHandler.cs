using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class TeleporterHandler : MonoBehaviour
{
    [SerializeField] private List<interruptor> plaque;
    [SerializeField] private SpriteRenderer door;
    private bool isActived = false;

    void FixedUpdate()
    {
        bool allActivated = plaque.All(p => p.requierement);

        if (allActivated && isActived == false)
        {
            isActived = true;
            door.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && isActived == true)
        {
            StartCoroutine(Exit());  
        }
    }

    private IEnumerator Exit()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}