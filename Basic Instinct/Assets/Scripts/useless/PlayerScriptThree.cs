using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptThree : MonoBehaviour {
    public Camera playerCamera;
    private Animator anim;
    private Rigidbody body;
    public float walkingSpeed;
    public float runningSpeed;
    public float turnRate;
    private bool running;

    void Start() {
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        // Setting boolean value for moving - for other scripts to access moving boolean
        if (horizontalInput != 0 || verticalInput != 0)
        {
            anim.SetBool("moving", true);
        }
        else 
        {
            anim.SetBool("moving", false);
        }

        // Set running
        if (Input.GetKey(KeyCode.LeftShift)) {
            running = true;
        }
        else {
            running = false;
        }

        // Set transform
        if (verticalInput > 0) {
            if (running) {
                run();
            }
            else {
                walk();
            }
        }
        
        else if (verticalInput < 0) {
            // TO ADD
        }
        else {
            body.velocity *= 0;
        }

        // Set Animations
        anim.SetFloat("inputV", verticalInput);
        anim.SetBool("run", running);

        if (horizontalInput > 0) {
            Vector3 cameraFront = Vector3.Project(playerCamera.transform.forward, transform.forward);
            Vector3 rightLimit = playerCamera.transform.right;
            float angleBetween = Vector3.Angle(transform.forward, cameraFront);
            Debug.Log(angleBetween);
            if (angleBetween >= 90) {
                Debug.Log("hori >= 90");
                walk();
            }
            else {
                Debug.Log("hori < 90");
                transform.LookAt(rightLimit);
                // body.AddTorque(transform.up * (1 / turnRate) * horizontalInput);
                // Vector3.RotateTowards(transform.forward, rightLimit, float.MaxValue, float.MaxValue);
            }
        }
        else if (horizontalInput < 0) {
            
        }
        else {

        }
    }

    void walk() {
        body.velocity = transform.forward.normalized * walkingSpeed;
    }

    void run() {
        body.velocity = transform.forward.normalized * runningSpeed;
    }
}
