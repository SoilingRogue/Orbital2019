using UnityEngine;
/*
 Things left to do:
 1) running in different directions (still wonky)
 2) "Shift"-ing
 3) sliding -> running/walking slide velocity increase + directional slides + jumping slides
 4) hitbox -> hitbox has to change when jumping/sliding/moving + detection
 add on more if you can think of any
     */
public class PlayerScriptTwo : MonoBehaviour {
    private Animator anim;
    private float inputH, inputV;
    private Rigidbody rBody;
    private bool run;
    public float force;

    void Start() {
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody>();
        run = false;
    }

    void Update() {
        // for damaged/killed
        if (Input.GetKeyDown("0")) {
            anim.Play("DAMAGED00", -1, 0f);
        }
        if (Input.GetKeyDown("1")) {
            anim.Play("DAMAGED01", -1, 0f);
        }

        // for running
        if (Input.GetKey(KeyCode.LeftShift)) {
            run = true;
        }
        else {
            run = false;
        }

        // for jumping
        if (Input.GetKeyDown(KeyCode.Space)) {
            anim.SetBool("jump", true);
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            anim.SetBool("jump", false);
        }
        // else {
        //     anim.SetBool("jump", false);
        // }

        /* for movement */
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        // Set animations
        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        anim.SetBool("run", run);
        
        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 50f * Time.deltaTime;

        // Set movement
        if (inputV > 0) { // if walking forward
            
            if (run) {
                moveX *= 3f;
                moveZ *= 3f;
            }
        }

        else {
            moveX = 0f;
        }
    
        // setting velocity for rigidbody
        rBody.velocity = new Vector3(moveX, 0f, moveZ);
    }
}
