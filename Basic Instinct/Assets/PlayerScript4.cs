using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript4 : MonoBehaviour
{
    private Animator anim;
    private float inputH, inputV;
    private Rigidbody rBody;
    public float walkSpeed = 1f, runSpeed = 3f, runSlideSpeed = 3f, walkSlideSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        /* for movement */
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        Vector3 tempVect = new Vector3(inputH, 0, inputV);
        tempVect = tempVect.normalized * runSpeed * Time.deltaTime;
        // rBody.MovePosition(transform.position + tempVect); // Use velocity instead
        Debug.Log(transform.position);

        // Setting boolean value for moving - for other scripts to access moving boolean
        if (inputV != 0 || inputH != 0)
        {
            anim.SetBool("moving", true);
        }
        else 
        {
            anim.SetBool("moving", false);
        }

        // // multiplier for horizontal and vertical movement
        // float moveX = inputH * 500f * Time.deltaTime;
        // float moveZ = inputV * 500f * Time.deltaTime;

        // // if (moveZ == 0f) // if we are not moving foward, disallow sideway movement
        // // {
        // //     // Debug.Log("moveZ == 0");
        // //     moveX = 0f;
        // // }
        // // else if (run) // if running, increase speed
        // if (anim.GetBool("run"))
        // {
        //     moveX *= runSpeed;
        //     moveZ *= runSpeed;
        // }
        // else
        // {
        //     moveX *= walkSpeed;
        //     moveZ *= walkSpeed;
        // }
        // if (anim.GetBool("slide"))
        // {

        // }
        // else
        // {

        // }
        
        // // Debug.Log("moveZ: " + moveZ);

        // // setting velocity for rigidbody
        // // rBody.velocity = new Vector3(moveX, 0f, moveZ);
        // rBody.velocity = transform.forward.normalized * walkSpeed;
    }
}
