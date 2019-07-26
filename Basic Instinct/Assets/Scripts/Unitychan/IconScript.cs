using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconScript : MonoBehaviour
{
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate called after Update() on every game object in the scene, for rendering
    void LateUpdate()
    {
        transform.rotation = Quaternion.AngleAxis(cam.transform.rotation.eulerAngles.y, Vector3.up);
    }
}
