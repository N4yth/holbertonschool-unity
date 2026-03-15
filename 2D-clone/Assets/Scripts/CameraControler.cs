using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform focus;
    [SerializeField] private Camera cam;
    [SerializeField] private float smoothTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Vector3 offset = new Vector3(0, 1, -5);
    [SerializeField] private float zoomMultiplier = 4f;
    [SerializeField] private float minZoom = 4f;
    [SerializeField] private float maxZoom = 7f;
    [SerializeField] private float zoomSmoothTime = 0.2f;

    private float zoomVelocity;
    private float zoom;

    void Start()
    {
        zoom = cam.orthographicSize;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        zoom -= scroll * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        cam.orthographicSize = Mathf.SmoothDamp(
            cam.orthographicSize,
            zoom,
            ref zoomVelocity,
            zoomSmoothTime
        );
    }

    void LateUpdate()
    {
        Vector3 targetPosition = focus.position + offset;
        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref velocity,
            smoothTime
        );
    }
}