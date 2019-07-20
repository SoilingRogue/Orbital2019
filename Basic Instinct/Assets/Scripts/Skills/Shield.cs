using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Skill {
    private float duration;
    private GameObject user;
    public GameObject visualPrefab;

    // protected override void initialise() {
    //     Debug.Log("Executing Start in Shield");
    //     cooldown = 5f;
    //     duration = 1.5f;
    //     user = GameObject.FindGameObjectWithTag("Player");
    // }

    void Start() {
        Debug.Log("Executing Start in Shield");
        cooldown = 5f;
        duration = 1.5f;
        user = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void use() {
        if (user != null) {
            Debug.Log("User is not null");
            // CharacterStats stats = user.GetComponent<CharacterStats>();
            // if (stats != null) {
            //     stats.setInvulnerable(duration);
            // }
        }

        display();
    }

    private void display() {
        GameObject visual = Instantiate(visualPrefab, user.transform.position, user.transform.rotation);
        Destroy(visual, duration);
        // GameObject bubble = new GameObject("Bubble");
        // bubble.AddComponent(typeof(ShieldBubble));
        // bubble.GetComponent<ShieldBubble>().character = character;
        // GameObject.Destroy(bubble, duration);
    }
}
