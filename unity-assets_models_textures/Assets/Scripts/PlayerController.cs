using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Speed of the player")]
    [SerializeField] 
    private float speed = 5f;

    [SerializeField] 
    private float jumpForce = 6f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
