using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill {
    public string name;
    protected int damage;
    public float cooldown;
    public float previousUseTime;

    protected bool isOnCooldown(float timeNow) {
        return !(timeNow - previousUseTime > cooldown || previousUseTime == 0f);
    }

    protected void printCooldownMessage(float timeNow) {
        float cooldownTimer = cooldown - (timeNow - previousUseTime);
        Debug.Log(name + " on cooldown for " + cooldownTimer + "s.");
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

    protected abstract void use(GameObject character);
}
