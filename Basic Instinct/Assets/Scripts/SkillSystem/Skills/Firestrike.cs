using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firestrike : Skill {
    public Vector3 displacement;
    public float scale;

    protected override void initialise() {
        skillName = "Firestrike";
        cooldown = 10;
        scale = 10;
        displacement = transform.forward.normalized * scale;
    }

    protected override void use() {
        Vector3 spawnPosition = transform.position + displacement;
        Quaternion spawnRotation = transform.rotation;
        GameObject.Instantiate(visualPrefabs[0], spawnPosition, spawnRotation);
        resetCooldown();
    }

    protected override void review() {

    }
}
