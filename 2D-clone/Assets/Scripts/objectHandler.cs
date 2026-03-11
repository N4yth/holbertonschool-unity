using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private SpriteRenderer objectSprite;
    [SerializeField] private Rigidbody2D rb;

    private bool canPick = false;
    private bool picked = false;

    void Update()
    {
        if (canPick && Input.GetKeyDown(KeyCode.E))
        {
            picked = !picked;

            if (picked)
            {
                rb.simulated = false;
                objectSprite.sortingOrder = 6;
            }
            else
            {
                rb.simulated = true;
                objectSprite.sortingOrder = 3;
            }
        }

        if (picked)
        {
            transform.position = player.position + new Vector3(0, 0.5f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPick = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !picked)
        {
            canPick = false;
        }
    }
}