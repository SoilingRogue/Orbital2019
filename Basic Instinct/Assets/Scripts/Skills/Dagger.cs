using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Skill {
    private int damage;
    private float duration;

    void Start() {
        name = "Dagger";
        cooldown = 3f;
        // previousUseTime = -cooldown;
        damage = 20;
        duration = 5f;
    }

    protected override void use(GameObject character) {
        CharacterStats stats = character.GetComponent<CharacterStats>();
        stats.takeDamage(damage);

        display(character);
    }

    private void display(GameObject character) {
        GameObject dagger = new GameObject("Dagger");
        Component o = dagger.AddComponent(typeof(DaggerObject));
        DaggerObject obj = (DaggerObject)o;
        obj.character = character;
        GameObject.Destroy(dagger, duration);
    }
}
