using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour
{
    private float rotationSpeed = 180f;
    public Transform camPivot;
    Vector2 input;

    // Update is called once per frame
    void Update()
    {
        /* for free camera rotation */
        // Vector3 rotation = transform.eulerAngles;
        // rotation.x -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        // rotation.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        // transform.eulerAngles = rotation;

        
    }
}