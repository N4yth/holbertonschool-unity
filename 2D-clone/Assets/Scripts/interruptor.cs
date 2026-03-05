using UnityEngine;

public class interruptor : MonoBehaviour
{
    public bool requierement = false;
    [SerializeField] private Sprite newSprite;
    [SerializeField] private SpriteRenderer interruptorSprite;
    [SerializeField] private GameObject targetObject;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && requierement == false)
        {
            requierement = true;
            interruptorSprite.sprite = newSprite;
        }
    }
}
