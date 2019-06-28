using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this on Camera
public class MouseMovement : MonoBehaviour {
    float heading = 0;

    void Update() {
        float hori = Input.GetAxis("Mouse X");
        float vert = Input.GetAxis("Mouse Y");
        heading += hori * Time.deltaTime * 180;
        
        Debug.Log("Hori: " + hori);
        Debug.Log("Vert: " + vert);
        transform.rotation = Quaternion.Euler(0, heading, 0);
    }
}       
