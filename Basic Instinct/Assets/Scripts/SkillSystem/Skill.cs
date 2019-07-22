using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour {
    [HideInInspector]
    public GameObject visualPrefab;
    public string skillName;
    public float cooldown;
    public float cooldownTimer;

    void Start() {
        cooldownTimer = 0f;
        initialise();
    }

    public bool isOnCooldown() {
        return cooldownTimer > 0;
    }

    public void useSkill() {
        if (!isOnCooldown()) {
            Debug.Log(skillName + " used.");
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
    protected abstract void initialise();
    protected abstract void review();

    void Update() {
        cooldownTimer -= Time.deltaTime;
        cooldownTimer = Mathf.Clamp(cooldownTimer, 0f, cooldown);
        review();
    }
}
