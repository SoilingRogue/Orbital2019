using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour {
    // public bool initialised;
    public float cooldown;
    public float cooldownTimer;

    void Start() {
        cooldownTimer = 0f;
    }

    public bool isOnCooldown() {
        return cooldownTimer > 0;
    }

    public void useSkill() {
        if (!isOnCooldown()) {
            Debug.Log(name + " used.");
            use();
            cooldownTimer = cooldown;
        }
        else {
            printCooldownMessage();
        }
    }
    
    private void printCooldownMessage() {
        Debug.Log(name + " on cooldown for " + cooldownTimer + "s.");
    }

    protected abstract void use();

    void Update() {
        Debug.Log(cooldownTimer);
        cooldownTimer -= Time.deltaTime;
    }
}
