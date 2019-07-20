using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRotate : MonoBehaviour {
    public float rotateSpeed;

    void Update() {
        // transform.localRotation *= Quaternion.Euler(0, 90 * Time.deltaTime, 0);
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
        // transform.Rotate(0, 30, 0, Space.Self);
        // transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 10, transform.eulerAngles.z);
        // Quaternion fromRotation = transform.rotation;
        // Quaternion toRotation = 
        // transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * rotateSpeed);
    }
}
