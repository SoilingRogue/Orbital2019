using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRotate : MonoBehaviour {
    public float rotateSpeed;

    void Update() {
        Quaternion.Euler(0, 90, 0);
        Quaternion fromRotation = transform.rotation;
        // Quaternion toRotation = 
        // transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * rotateSpeed);
    }
}
