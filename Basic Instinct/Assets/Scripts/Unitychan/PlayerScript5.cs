﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript5 : MonoBehaviour
{
    private Animator anim;
    private float inputH, inputV;
    private Rigidbody rBody;
    public float walkSpeed = 1f, runSpeed = 3f, runSlideSpeed = 3.3f, walkSlideSpeed = 1.3f;
    public Camera cam;
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
        inputH = Input.GetAxis("Horizontal"); // set this based on camera angle
        inputV = Input.GetAxis("Vertical"); // set this based on camera angle
        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        float moveSpeed;

        // Setting boolean value for moving - for other scripts to access moving boolean
        if (Input.GetKey("w") || Input.GetKey("a") ||Input.GetKey("s") || Input.GetKey("d"))
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
    }

    private Quaternion GetCameraTurn()
    {
        return Quaternion.AngleAxis(cam.transform.rotation.eulerAngles.y, Vector3.up);
    }
}
