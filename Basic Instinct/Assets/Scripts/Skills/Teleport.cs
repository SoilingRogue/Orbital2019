using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Skill {
    // Constructor
    public Teleport() {
        name = "Teleport";
        damage = 0;
        cooldown = 5f;
        previousUseTime = 0f;
    }

    protected override void use(GameObject character) {
        CharacterStats stats = character.GetComponent<CharacterStats>();
        // stats.takeDamage(damage);

        display(character);
    }

    private void display(GameObject character) {
        character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, character.transform.position.z + 30);
    }
}