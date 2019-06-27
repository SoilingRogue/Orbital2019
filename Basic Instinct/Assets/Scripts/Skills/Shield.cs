using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Skill {
    private float duration;
    // Constructor
    public Shield() {
        name = "Shield";
        damage = 0;
        cooldown = 5f;
        previousUseTime = 0f;
        duration = 1.5f;
    }

    protected override void use(GameObject character) {
        CharacterStats stats = character.GetComponent<CharacterStats>();
        stats.setInvulnerable(duration);

        display(character);
    }

    private void display(GameObject character) {
        GameObject bubble = new GameObject("Bubble");
        bubble.AddComponent(typeof(ShieldBubble));
        bubble.GetComponent<ShieldBubble>().character = character;
        GameObject.Destroy(bubble, duration);
    }
}
