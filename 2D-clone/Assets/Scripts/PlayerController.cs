using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 8f;

    [Header("Smoothing")]
    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private float deceleration = 0.05f;

    [Header("References")]
    [SerializeField] private Rigidbody2D player;

    private Vector2 input;
    private Vector2 currentVelocity;
    private Vector2 velocitySmooth;

    void Awake()
    {
        player.gravityScale = 0f;
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input = input.normalized;
    }

    void FixedUpdate()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

        Vector2 targetVelocity = input * speed;

        float smoothTime = input.magnitude > 0 ? acceleration : deceleration;

        currentVelocity = Vector2.SmoothDamp(
            currentVelocity,
            targetVelocity,
            ref velocitySmooth,
            smoothTime
        );

        player.linearVelocity = currentVelocity;
    }
}