using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private float inputH, inputV, distToGround;
    private Rigidbody rBody;
    public float walkSpeed = 1f, runSpeed = 3f, runSlideSpeed = 3.3f, walkSlideSpeed = 1.3f, jumpHeight = 1f; 
    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        // Damaged/killed
        if (Input.GetKeyDown("0"))
        {
            anim.Play("DAMAGED00", -1, 0f);
        }
        if (Input.GetKeyDown("1")) {
            anim.Play("DAMAGED01", -1, 0f);
        }

        if (IsGrounded())
        {
            // Movement
            if (anim.GetBool("moving"))
            {
                // Running
                anim.SetBool("run", Input.GetKey(KeyCode.LeftShift));

                // Sliding
                anim.SetBool("slide", Input.GetKey(KeyCode.LeftControl));

            }

            // Emotes
            if (Input.GetKeyDown("g")) {
                anim.Play("Gangnam Style", -1, 0f);
            }
            if (Input.GetKeyDown("t")) {
                anim.Play("Thriller Part 2", -1, 0f);
            }

            // Jumping
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // anim.SetBool("jump", true);
                anim.Play("Jump", -1, 0f);
            }
        }



        /* for movement */
        inputH = Input.GetAxis("Horizontal"); // set this based on camera angle
        inputV = Input.GetAxis("Vertical"); // set this based on camera angle
        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        float moveSpeed;

        // Setting boolean value for moving - for other scripts to access moving boolean
        // if (inputV != 0 || inputH != 0)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("moving", true);
            if (anim.GetBool("run"))
            {
                if (anim.GetBool("slide"))
                {
                    moveSpeed = runSlideSpeed;
                }
                else
                {
                    moveSpeed = runSpeed;
                }
            }
            else
            {
                if (anim.GetBool("slide"))
                {
                    moveSpeed = walkSlideSpeed;
                }
                else
                {
                    moveSpeed = walkSpeed;
                }
            }

            // if (anim.GetBool("jump") && IsGrounded())
            if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))

            {
                // Vector3 jumpVector = new Vector3(0, Mathf.Sqrt(jumpHeight * -2f * gravity), 0);
                // rBody.velocity = jumpVector;
                Debug.Log("jumping");
                rBody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
                // anim.SetBool("jump", false);
            }

            Vector3 movementVector = new Vector3(inputH, 0 , inputV);
            Quaternion camTurn = GetCameraTurn();
            movementVector = camTurn * movementVector;
            rBody.rotation = camTurn;
            rBody.velocity += movementVector.normalized * moveSpeed;

            // rBody.velocity += inputH * Vector3.ProjectOnPlane(cam.transform.right, Vector3.up).normalized * moveSpeed * Time.deltaTime;            
            // rBody.velocity += new Vector3(inputH, 0, inputV) * moveSpeed; // for debugging
            // Debug.Log(rBody.position); // for debugging
        }
        else 
        {
            anim.SetBool("moving", false);
        }

        GetComponent<Collider>().transform.position = gameObject.transform.position;

    }

    private Quaternion GetCameraTurn()
    {
        return Quaternion.AngleAxis(cam.transform.rotation.eulerAngles.y, Vector3.up);
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
