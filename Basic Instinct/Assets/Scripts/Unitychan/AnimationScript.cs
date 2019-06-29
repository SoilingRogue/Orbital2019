using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Damaged/killed
        if (Input.GetKeyDown("0"))
        {
            anim.Play("DAMAGED00", -1, 0f);
        }
        if (Input.GetKeyDown("1")) {
            anim.Play("DAMAGED01", -1, 0f);
        }

        // Running
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }

        // Jumping
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }

        // Sliding
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetBool("slide", true);
        }
        else
        {
            anim.SetBool("slide", false);
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
