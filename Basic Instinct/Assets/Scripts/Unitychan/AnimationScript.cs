using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator anim;
    private PlayerScript4 script4;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        script4 = GetComponent<PlayerScript4>();
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

        if (script4.IsGrounded())
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
    }
}