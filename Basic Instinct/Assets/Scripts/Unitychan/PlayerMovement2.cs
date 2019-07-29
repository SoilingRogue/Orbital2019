﻿using System.Collections;
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
        cam = Camera.main;
    }

    void FixedUpdate()
    {   
        /* for movement */
        inputH = Input.GetAxis("Horizontal"); // set this based on camera angle
        inputV = Input.GetAxis("Vertical"); // set this based on camera angle
        if (!anim.GetBool("slide")) {
            anim.SetFloat("inputH", inputH);
            anim.SetFloat("inputV", inputV);
        }

        if (!anim.GetBool("jump") && !anim.GetBool("slide"))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                // Set follow bool to true for camera following in FollowPosition.cs
                anim.SetBool("move", true);
                
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
            else
            {
                anim.SetBool("move", false);
            }

            // Emotes
            if (Input.GetKeyDown("g")) {
                anim.Play("Gangnam Style", -1, 0f);
            }
            if (Input.GetKeyDown("t")) {
                anim.Play("Thriller Part 2", -1, 0f);
            }
            if (Input.GetKeyDown("p")) {
                anim.Play("POSE01", -1, 0f);
            }
        }

        // Setting follow bool to true when moving, sliding or using skill
        if (anim.GetBool("move") || anim.GetBool("skill") || anim.GetBool("slide"))
        {
            anim.SetBool("follow", true);
        }
        else 
        {
            anim.SetBool("follow", false);
        }

        // Jumping - must not be jumping currently and space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && !anim.GetBool("jump"))
        {
            StartCoroutine(Jump());
        }
    
        // Sliding - must be moving and control is pressed
        if (Input.GetKeyDown(KeyCode.LeftControl) && anim.GetBool("move"))
        {
            StartCoroutine(Slide());
        }
    }

    private void help() {
        anim.SetBool("slide", false);
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
        Vector3 addedVel = transform.forward.normalized * (moveSpeed + slideSpeed);
        rBody.velocity += addedVel;

        // Delay adding of force to rBody to sync the animations
        yield return new WaitForSeconds(1.3f);
        anim.SetBool("slide", false);
    }

    private Quaternion GetCameraTurn()
    {
        return Quaternion.AngleAxis(cam.transform.rotation.eulerAngles.y, Vector3.up);
    }
}
