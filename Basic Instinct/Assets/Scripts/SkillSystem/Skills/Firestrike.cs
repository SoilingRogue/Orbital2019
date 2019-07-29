using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firestrike : Skill {
    public float scale;
    public int count;

    protected override void initialise() {
        skillName = "Firestrike";
        cooldown = 10;
        scale = 10;
        count = 3;
    }

    protected override void use() {
        for (int i = 0; i < count; i++) {
            Vector3 displacement = transform.forward.normalized * (scale * (i + 1));
            Vector3 spawnPosition = transform.position + displacement;
            Quaternion spawnRotation = transform.rotation;
            GameObject fireStrike = GameObject.Instantiate(visualPrefabs[0], spawnPosition, spawnRotation);

            // Remove collision between user and firestrike
            Collider strikeCollider = fireStrike.GetComponentInChildren<Collider>();
            Collider userCollider = gameObject.GetComponent<Collider>();
            if (userCollider != null) {
                Physics.IgnoreCollision(strikeCollider, userCollider);
            }
        }

        resetCooldown();
    }

    protected override void review() {

    }
}
