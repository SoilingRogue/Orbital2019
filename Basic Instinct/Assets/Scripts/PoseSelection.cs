using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseSelection : MonoBehaviour
{
    private Animator anim;
    private float cooldown = 4f, duration = 4f;

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
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                cooldown = duration;
                anim.SetBool("idle", true);
            }
        }
    }
}
