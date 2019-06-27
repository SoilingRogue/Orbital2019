using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : Skill {
    // Constructor
    public Shockwave() {
        name = "Shockwave";
        damage = 50;
        cooldown = 3f;
        previousUseTime = 0f;
    }

    protected override void use(GameObject character) {
        CharacterStats stats = character.GetComponent<CharacterStats>();

        display(character);
    }

    private void display(GameObject character) {

    }
}
