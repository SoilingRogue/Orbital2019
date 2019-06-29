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
    private bool run;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody>();
        run = false;
    }
    // Update is called once per frame
    void Update()
    {
        /* for movement */
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        anim.SetBool("run", run);

        // multiplier for horizontal and vertical movement
        float moveX = inputH * 200f * Time.deltaTime;
        float moveZ = inputV * 500f * Time.deltaTime;

        if (moveZ == 0f) // if we are not moving foward, disallow sideway movement
        {
            // Debug.Log("moveZ == 0");
            moveX = 0f;
        }
        else if (run) // if running, increase speed
        {
            moveX *= 3f;
            moveZ *= 3f;
        }
        // Debug.Log("moveZ: " + moveZ);

        // setting velocity for rigidbody
        rBody.velocity = new Vector3(moveX, 0f, moveZ);
    }
}
