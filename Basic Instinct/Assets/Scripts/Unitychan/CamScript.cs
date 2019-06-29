using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{   
public Transform camPivot, cam;
float heading = 0;
    Vector2 input;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        heading += Input.GetAxis("Mouse X")*Time.deltaTime*180;
        camPivot.rotation = Quaternion.Euler(0, heading, 0);

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        Vector3 camF = cam.forward;

        Vector3 camR = cam.right;

// zeroing cam angles for y & normalizing
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

                // transform.position += new Vector3(input.x, 0, input.y)* Time.deltaTime* 5;
        transform.position += (camF * input.y + camR * input.x) * Time.deltaTime * 5;
        
        
        // transform.position += input.y * Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized * 5 * Time.deltaTime;
    // transform.position += input.x * Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up).normalized * 5 * Time.deltaTime;  
    }
}
