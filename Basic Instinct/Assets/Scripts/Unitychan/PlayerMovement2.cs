using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    private Animator anim;
    private float inputH, inputV, distToGround;
    private Rigidbody rBody;
    public float walkSpeed = 1f, runSpeed = 3f, runSlideSpeed = 3.3f, walkSlideSpeed = 1.3f, jumpHeight = 8f; 
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
        /* for movement */
        inputH = Input.GetAxis("Horizontal"); // set this based on camera angle
        inputV = Input.GetAxis("Vertical"); // set this based on camera angle
        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        float moveSpeed;

        // Set emote bool to true to disable camera following while idle in FollowPosition.cs
        anim.SetBool("emote", true);

        if (IsGrounded())
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                // Set emote bool to false for camera following in FollowPosition.cs
                anim.SetBool("emote", false);
                
                // Running
                anim.SetBool("run", Input.GetKey(KeyCode.LeftShift));

                // Sliding
                anim.SetBool("slide", Input.GetKey(KeyCode.LeftControl));
            
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
                Vector3 movementVector = new Vector3(inputH, 0 , inputV);
                Quaternion camTurn = GetCameraTurn();
                movementVector = camTurn * movementVector;
                rBody.rotation = Quaternion.LookRotation(movementVector);
                rBody.velocity += movementVector.normalized * moveSpeed;
                Debug.Log("moving");

                // rBody.velocity += inputH * Vector3.ProjectOnPlane(cam.transform.right, Vector3.up).normalized * moveSpeed * Time.deltaTime;            
                // rBody.velocity += new Vector3(inputH, 0, inputV) * moveSpeed; // for debugging
                // Debug.Log(rBody.position); // for debugging
            }

            // Damaged/killed
            if (Input.GetKeyDown("0"))
            {
                anim.Play("DAMAGED00", -1, 0f);
            }
            if (Input.GetKeyDown("1")) {
                anim.Play("DAMAGED01", -1, 0f);
            }

            // Emotes
            if (Input.GetKeyDown("g")) {
                anim.Play("Gangnam Style", -1, 0f);
            }
            if (Input.GetKeyDown("t")) {
                anim.Play("Thriller Part 2", -1, 0f);
            }
        }

        // GetComponent<Collider>().transform.position = gameObject.transform.position;
    }

    // AddForce is instantaneous, not frame dependent
    void Update()
    {
        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            // Vector3 jumpVector = new Vector3(0, Mathf.Sqrt(jumpHeight * -2f * gravity), 0);
            // rBody.velocity = jumpVector;
            Debug.Log("jumping");
            anim.Play("JUMP00B_F", -1, 0f);
            // Delay adding of force to rBody to sync the animations
            Invoke("Jump", 0.3f);
        }
    }

    private void Jump()
    {
        rBody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
    }

    private Quaternion GetCameraTurn()
    {
        return Quaternion.AngleAxis(cam.transform.rotation.eulerAngles.y, Vector3.up);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
