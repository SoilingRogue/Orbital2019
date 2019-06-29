using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : Skill {
    private int damage;
    private float duration;
    // Constructor
    public Shockwave() {
        name = "Shockwave";
        cooldown = 3f;
        // previousUseTime = -cooldown;
        damage = 50;
        duration = 10f;
    }

    protected override void use(GameObject character) {
        CharacterStats stats = character.GetComponent<CharacterStats>();

        display(character);
    }

    private void display(GameObject character) {
        GameObject waveObject = new GameObject("Wave");
        Component o = waveObject.AddComponent(typeof(WaveObject));
        WaveObject obj = (WaveObject)o;
        obj.character = character;
        GameObject.Destroy(waveObject, duration);
    }
}
