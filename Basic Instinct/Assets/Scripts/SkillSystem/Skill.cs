using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {
    public float cooldown;
    public float previousUseTime;

    void Start() {
        previousUseTime = 0f;
    }

    protected bool isOnCooldown(float timeNow) {
        return !(timeNow - previousUseTime > cooldown || previousUseTime == 0);
    }

    public float getPercentageCD() {
        float timeNow = Time.time;
        if (!isOnCooldown(timeNow)) {
            return 0;
        }
        else {
            float cd = (timeNow - previousUseTime) / cooldown;
            return 1 - cd;
        }
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

    protected virtual void use(GameObject character) {
        Debug.Log("This skill did not implement \'use\' method");
    }
}
