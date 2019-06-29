using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill {
    public string name;
    public float cooldown;
    public float previousUseTime;

    protected Skill() {
        previousUseTime = 0f;
    }

    protected bool isOnCooldown(float timeNow) {
        return !(timeNow - previousUseTime > cooldown || previousUseTime == 0);
    }

    public void useSkill(GameObject character) {
        float timeNow = Time.time;
        if (!isOnCooldown(timeNow)) {
            Debug.Log(name + " used.");
            use(character);
            previousUseTime = timeNow;
        }
        else {
            printCooldownMessage(timeNow);
        }
    }
    
    protected void printCooldownMessage(float timeNow) {
        float cooldownTimer = cooldown - (timeNow - previousUseTime);
        Debug.Log(name + " on cooldown for " + cooldownTimer + "s.");
    }

    protected abstract void use(GameObject character);
}
