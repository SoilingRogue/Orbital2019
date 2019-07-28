using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour {
    [HideInInspector]
    public GameObject[] visualPrefabs;
    public string skillName;
    public float cooldown;
    public float cooldownTimer;
    public KeyCode key;
    // private Animator anim;

    void Start() {
        // anim = gameObject.GetComponent<Animator>();
        cooldownTimer = 0f;
        initialise();
    }

    public bool isOnCooldown() {
        return cooldownTimer > 0;
    }

    public void useSkill() {
        if (!isOnCooldown()) {
            Debug.Log(skillName + " used.");
            // gameObject.GetComponent<Animator>().SetBool("skill", true);
            use();
            // gameObject.GetComponent<Animator>().SetBool("skill", false);
        }
        else {
            printCooldownMessage();
        }
    }

    protected void resetCooldown() {
        cooldownTimer = cooldown;
    }
    
    private void printCooldownMessage() {
        Debug.Log(name + " on cooldown for " + cooldownTimer + "s.");
    }

    protected abstract void use();
    protected abstract void initialise();
    protected abstract void review();

    void Update() {
        cooldownTimer -= Time.deltaTime;
        cooldownTimer = Mathf.Clamp(cooldownTimer, 0f, cooldown);
        review();
    }
}
