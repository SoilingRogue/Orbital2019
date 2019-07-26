﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapRotation : MonoBehaviour
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
 
        // Actual Camera Rig Transformations - has to be inside of LateUpdate()
        // setting pitch and yaw for rotation
        Quaternion QT = Quaternion.Euler(90, camRotation.x, 0);
        
        // Lerp - linear interpolation btw current rotation at start of frame & animate towards target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, QT, Time.deltaTime * orbitDampening);
 
        // Debug.Log(trans.forward);
        // if ( this.cam.localPosition.z != this.camDistance * -1f )
        // {
        //     this.cam.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this.cam.localPosition.z, this.camDistance * -1f, Time.deltaTime * scrollDampening));
        // }
    }
}
