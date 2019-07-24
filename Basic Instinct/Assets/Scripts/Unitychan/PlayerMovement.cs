using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Animator animator;
    public Rigidbody body;
    public float turnRate;
    void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput < 0) {
            transform.Rotate(Vector3.up, horizontalInput / -1 * -90 * Time.deltaTime * turnRate);
        }
        else if (horizontalInput > 0) {
            transform.Rotate(Vector3.up, horizontalInput / 1 * 90 * Time.deltaTime * turnRate);
        }

        float verticalInput = Input.GetAxis("Vertical");

        // if (horizontalInput != 0 || verticalInput != 0) {
        //     animator.SetBool("moving", true);
        // }

        // if (verticalInput < 0) {
        //     transform.Rotate(Vector3.up, 180);
        // }
        animator.SetFloat("inputV", Mathf.Abs(verticalInput));
    }
}
