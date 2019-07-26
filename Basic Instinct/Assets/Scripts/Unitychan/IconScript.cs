using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconScript : MonoBehaviour
{
    protected Vector2 camRotation;
    public float mouseSensitivity = 4f;
    protected float orbitDampening = 10f;

    // LateUpdate called after Update() on every game object in the scene, for rendering
    void LateUpdate()
    {
       // Rotation of the Camera based on Mouse Coordinates
            if (Input.GetAxis("Mouse X") != 0)
            {
                camRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
            }

        Quaternion QT = Quaternion.Euler(90, camRotation.x, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, QT, Time.deltaTime * orbitDampening);
    }
}
