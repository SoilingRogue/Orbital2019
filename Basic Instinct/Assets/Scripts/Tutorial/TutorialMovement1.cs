using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovement1 : MonoBehaviour
{
    private Animator anim;
    private float inputH, inputV;
    private Rigidbody rBody;
    public float walkSpeed = 1f;
    private float moveSpeed;
    private Vector3 movementVector;
    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    void FixedUpdate()
    {   
        /* for movement */
        inputH = Input.GetAxis("Horizontal"); // set this based on camera angle
        inputV = Input.GetAxis("Vertical"); // set this based on camera angle
            anim.SetFloat("inputH", inputH);
            anim.SetFloat("inputV", inputV);

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                // Set follow bool to true for camera following in FollowPosition.cs
                anim.SetBool("move", true);
                moveSpeed = walkSpeed;

                movementVector = new Vector3(inputH, 0 , inputV);
                Quaternion camTurn = GetCameraTurn();
                movementVector = camTurn * movementVector;
                rBody.rotation = Quaternion.LookRotation(movementVector);
                rBody.velocity += movementVector.normalized * moveSpeed;
                // Debug.Log("moving");
                // Debug.Log("Moving velocity" + rBody.velocity);
            }
            else
            {
                anim.SetBool("move", false);
            }

        // Setting follow bool to true when moving, sliding or using skill
        if (anim.GetBool("move"))
        {
            anim.SetBool("follow", true);
        }
        else 
        {
            anim.SetBool("follow", false);
        }
    }

    private Quaternion GetCameraTurn()
    {
        return Quaternion.AngleAxis(cam.transform.rotation.eulerAngles.y, Vector3.up);
    }
}
