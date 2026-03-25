using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float jumphigh = 3f;

    private Rigidbody rb;
    public JumpController Jump;

    private Quaternion targetRotation;

    [SerializeField] private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 move = (camForward * v + camRight * h) * speed * Time.deltaTime;

        Vector3 inputDir = camForward * v + camRight * h;
        bool isMoving = inputDir != Vector3.zero;
        animator.SetBool("isRunning", isMoving);  
        
        transform.Translate(move, Space.World);

        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            targetRotation *= Quaternion.Euler(0, -90f, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Space) && Jump.isGrounded){
            rb.AddForce(new Vector3(0.0f, jumphigh, 0.0f) * jumpForce, ForceMode.Impulse);
        }

        if (FallingLimit())
        {
            transform.position = new Vector3(0, 40f, 0);
        }
    }

    public bool FallingLimit()
    {
        if (rb.position.y < -25)
        {
            return true;
        }
        return false;
    }
}
