using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Tooltip("player info")]    
    [SerializeField]

    public GameObject player;

    private Vector3 offset;

    void Start()
    {
    }

    public void FixedUpdate()
    {
        transform.position = new Vector3 (player.transform.position.x, 26 , player.transform.position.z);
    }

    
}
