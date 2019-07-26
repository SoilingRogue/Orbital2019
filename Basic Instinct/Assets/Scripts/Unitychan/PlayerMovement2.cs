using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    private Animator anim;
    private float inputH, inputV, distToGround;
    private Rigidbody rBody;
    public float walkSpeed = 1f, runSpeed = 3f, slideSpeed = 0.3f, jumpHeight = 18f;
    private float moveSpeed;
    private Vector3 movementVector;
    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody>();
        // distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        /* for movement */
        inputH = Input.GetAxis("Horizontal"); // set this based on camera angle
        inputV = Input.GetAxis("Vertical"); // set this based on camera angle
        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        // Set emote bool to true to disable camera following while idle in FollowPosition.cs
        anim.SetBool("emote", true);

        if (!anim.GetBool("jump") && !anim.GetBool("slide"))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                // Set emote bool to false for camera following in FollowPosition.cs
                anim.SetBool("emote", false);
                
                // Running
                anim.SetBool("run", Input.GetKey(KeyCode.LeftShift));
            
                if (anim.GetBool("run"))
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
                rBody.rotation = Quaternion.LookRotation(movementVector);
                rBody.velocity += movementVector.normalized * moveSpeed;
                // Debug.Log("moving");
                // Debug.Log("Moving velocity" + rBody.velocity);
            }

            // Emotes
            if (Input.GetKeyDown("g")) {
                anim.Play("Gangnam Style", -1, 0f);
            }
            if (Input.GetKeyDown("t")) {
                anim.Play("Thriller Part 2", -1, 0f);
            }
        }
    }

    // AddForce is instantaneous, not frame dependent
    void Update()
    {
        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && !anim.GetBool("jump"))
        {
            StartCoroutine(Jump());
        }
    
        // Sliding
        if (Input.GetKeyDown(KeyCode.LeftControl) && !anim.GetBool("emote"))
        {
            StartCoroutine(Slide());
        }

        if (anim.GetBool("slide")) {
            Debug.Log("Velocity: " + rBody.velocity);
        }
    }

    private IEnumerator Jump()
    {
        anim.SetBool("jump", true);
        Debug.Log("jumping");
        anim.Play("JUMP00B_F", -1, 0f);
        // Delay adding of force to rBody to sync the animations
        yield return new WaitForSeconds(0.3f);
        rBody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        yield return new WaitForSeconds(1.45f);
        anim.SetBool("jump", false);
    }

    private IEnumerator Slide()
    {
        // Sliding
        anim.SetBool("slide", true);
        Debug.Log("sliding");
        anim.Play("SLIDE00_F", -1, 0f);

        float time = 1.3f;
        while (time > 0) {
            Vector3 addedVel = transform.forward.normalized * (moveSpeed + slideSpeed);
            Debug.Log("Added velocity: " + addedVel);
            rBody.velocity = addedVel;

            time -= Time.deltaTime;
            yield return null;
        }
        // Vector3 addedVel = transform.forward.normalized * (moveSpeed + slideSpeed);
        // rBody.velocity += addedVel * 10000;
        // Delay adding of force to rBody to sync the animations
        // yield return new WaitForSeconds(1.3f);
        anim.SetBool("slide", false);
    }

    private Quaternion GetCameraTurn()
    {
        return Quaternion.AngleAxis(cam.transform.rotation.eulerAngles.y, Vector3.up);
    }

    // private bool IsGrounded()
    // {
    //     return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    // }
}
