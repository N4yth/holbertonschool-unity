using UnityEngine;

public class JumpController : MonoBehaviour
{
    public bool isGrounded = false;

    void OnTriggerEnter(Collider collider)
    {
        isGrounded = true;
    }

    void OnTriggerExit(Collider collider)
    {
        isGrounded = false;
    }
}