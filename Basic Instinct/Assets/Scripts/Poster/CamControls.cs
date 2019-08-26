using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControls : MonoBehaviour
{
    private float inputH, inputV, distToGround;
    public float walkSpeed = 1f, runSpeed = 10f;
    private float moveSpeed;
    private Rigidbody rBody;
    private bool run;
    private Vector3 movementVector;
    public Camera cam;
    private int poseIndex = 0, currentPose = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {   
        /* for movement */
        inputH = Input.GetAxis("Horizontal"); // set this based on camera angle
        inputV = Input.GetAxis("Vertical"); // set this based on camera angl
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {

                // Running
                run =  Input.GetKey(KeyCode.LeftShift);
            
                if (run)
                {
                    moveSpeed = runSpeed;
                }
                else
                {
                    moveSpeed = walkSpeed;
                }

                movementVector = new Vector3(inputH, 0 , inputV);
                Quaternion camTurn = GetCameraTurn();
                movementVector = camTurn * movementVector;

                transform.rotation = Quaternion.LookRotation(movementVector);
                transform.position += movementVector.normalized * moveSpeed;
            }
        if (Input.GetKeyDown(KeyCode.Space))
        {
                transform.position += new Vector3(0, moveSpeed, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.position -= new Vector3(0, moveSpeed, 0);
        }
    }

    private Quaternion GetCameraTurn()
    {
        return Quaternion.AngleAxis(cam.transform.rotation.eulerAngles.y, Vector3.up);
    }
}