using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Skill {
    public float duration;
    public Vector3 diffVector;
    private GameObject visual;

    protected override void initialise() {
        skillName = "Shield";
        cooldown = 5f;
        duration = 1.5f;
        diffVector = Vector3.up;
    }

    protected override void use() {
        CharacterStats stats = gameObject.GetComponent<CharacterStats>();
        if (stats != null) {
            stats.setInvulnerable(duration);
        }
        resetCooldown();
        display();
    }

    private void display() {
        visual = Instantiate(visualPrefabs[0], gameObject.transform.position, gameObject.transform.rotation);
        Destroy(visual, duration);
    }

    protected override void review() {
        if (visual != null) {
            visual.transform.position = gameObject.transform.position + diffVector;
        }
    }
}
