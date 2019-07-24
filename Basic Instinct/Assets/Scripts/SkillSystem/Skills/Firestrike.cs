using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firestrike : Skill {
    public Vector3 displacement;

    protected override void initialise() {
        skillName = "Firestrike";
        cooldown = 10;
        displacement = new Vector3(0, 0, 0);
    }

    protected override void use() {
        Vector3 spawnPosition = transform.position + displacement;
        Quaternion spawnRotation = transform.rotation;
        GameObject.Instantiate(visualPrefab, spawnPosition, spawnRotation);
    }

    protected override void review() {

    }
}
