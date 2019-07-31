using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseSelection : MonoBehaviour
{
    private Animator anim;
    private float timer = 0f, duration = 15f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!anim.GetBool("idle")) 
        {
            anim.SetFloat("poseIndex", timer);
            timer += 1 / duration * Time.deltaTime;
            if (timer >= 1)
            {
                timer = 0;
                anim.SetBool("idle", true);
            }
        }
    }
}
