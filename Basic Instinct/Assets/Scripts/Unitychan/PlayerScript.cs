using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Things left to do:
 1) running in different directions (still wonky)
 2) "Shift"-ing
 3) sliding -> running/walking slide velocity increase + directional slides + jumping slides
 4) hitbox -> hitbox has to change when jumping/sliding/moving + detection
 add on more if you can think of any
     */
public class PlayerScript : MonoBehaviour
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
    void Update()
    {
        /* for movement */
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        // multiplier for horizontal and vertical movement
        float moveX = inputH * 500f * Time.deltaTime;
        float moveZ = inputV * 500f * Time.deltaTime;

        // if (moveZ == 0f) // if we are not moving foward, disallow sideway movement
        // {
        //     // Debug.Log("moveZ == 0");
        //     moveX = 0f;
        // }
        // else if (run) // if running, increase speed
        if (anim.GetBool("run"))
        {
            moveX *= runSpeed;
            moveZ *= runSpeed;
        }
        else
        {
            moveX *= walkSpeed;
            moveZ *= walkSpeed;
        }
        if (anim.GetBool("slide"))
        {

        }
        else
        {

        }
        
        // Debug.Log("moveZ: " + moveZ);

        // setting velocity for rigidbody
        rBody.velocity = new Vector3(moveX, 0f, moveZ);
    }
}
