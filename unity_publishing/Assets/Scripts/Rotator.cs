using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{

    void Start()
    {
        
    }

    public Vector3 rotationSpeed = new Vector3(100f, 0f, 0f);

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
