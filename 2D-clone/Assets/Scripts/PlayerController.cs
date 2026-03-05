using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D player;
    private Vector2 movement;

    void Start()
    {
        player.gravityScale = 0f;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        player.linearVelocity = movement * moveSpeed;
    }
}
