using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Skill {
    // Constructor
    public Dagger() {
        name = "Dagger";
        damage = 20;
        cooldown = 3f;
        previousUseTime = 0f;
    }

    protected override void use(GameObject character) {
        CharacterStats stats = character.GetComponent<CharacterStats>();
        stats.takeDamage(damage);

        display(character);
    }

    private void display(GameObject character) {
        GameObject dagger = new GameObject("Dagger");
        dagger.AddComponent(typeof(DaggerObject));
        dagger.GetComponent<DaggerObject>().character = character;
        GameObject.Destroy(dagger, 5f);
    }
}
