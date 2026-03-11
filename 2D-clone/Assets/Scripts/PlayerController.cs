using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D player;
    [SerializeField] private float jumpDuration;

    [SerializeField] private SpriteRenderer playerSprite;
    private bool isJumping = false;
    private Vector2 lastDirection = Vector2.down;
    private Vector2 movement;

    void Start()
    {
        player.gravityScale = 0f;
    }

    void Update()
    {
        if (isJumping) return;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero)
        {
            lastDirection = movement.normalized;
        }

        movement = movement.normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 landingPos = (Vector2)player.position + lastDirection * moveSpeed;

            Collider2D hit = Physics2D.OverlapCircle(landingPos, 0.3f, wallLayer);

            if(hit == null)
            {
                StartCoroutine(Jump());
            }
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 8f;
        }
        else
        {
            moveSpeed = 5f;
        }
    }

    void FixedUpdate()
    {
        player.linearVelocity = movement * moveSpeed;
    }

    IEnumerator Jump()
    {
        isJumping = true;
        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + (Vector3)(lastDirection * moveSpeed);
        float time = 0;
        while (time < jumpDuration)
        {
            float progress = time / jumpDuration;
            Vector3 position = Vector3.Lerp(startPos, targetPos, progress);
            float height = Mathf.Sin(progress * Mathf.PI) * 0.5f; position.y += height;
            transform.position = position; 
            time += Time.deltaTime;
            yield return null;
        }

    }
}

