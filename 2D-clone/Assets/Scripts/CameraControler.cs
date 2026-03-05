using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform focus;
    [SerializeField] private float smoothSpeed = 10f;

    private Vector3 offset = new Vector3(0, 1, -5);

    private float zoom;
    private float zoomMultiplier = 4f;
    private float minZoom = 4f;
    private float maxZoom = 7f;
    private float velocity = 1f;
    private float smoothTime = 0.25f;

    [SerializeField] private Camera cam;

    void Update () {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scroll * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
    }

    void LateUpdate()
    {
        Vector3 targetPosition = focus.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }


}