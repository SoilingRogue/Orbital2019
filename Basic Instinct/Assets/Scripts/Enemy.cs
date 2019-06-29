using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int maxHealth = 100;
    private int currentHealth;
    private float timeToNextAttack;
    public float attackCooldown = 3f;
    private GameObject player;
    void Start() {
        currentHealth = maxHealth;
        // After spawning, 
        timeToNextAttack = 2f;
    }

    void Update() {
        timeToNextAttack -= Time.deltaTime;
        if (timeToNextAttack <= 0) {
            attack();
            timeToNextAttack = attackCooldown;
        }
    }

    void attack() {
        // Find player to target
        // This only works assuming the scene has only 1 player.
        Object[] temp = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject o in temp) {
            if (o.CompareTag("Player")) {
                player = o;
                break;
            }
        }

        // Cast a sphere projectile in towards player
        // Calculate the direction to shoot
        Vector3 direction = player.transform.position - transform.position;
        // Spawn a sphere
        GameObject fireball = spawnFireball(direction);
        Destroy(fireball, 6f);
    }

    GameObject spawnFireball(Vector3 direction) {
        GameObject fireball = new GameObject("Fireball");
        // Set fireball location to enemy location at the start
        fireball.transform.position = transform.position;
        // Use a script to handle projectile movement
        Fireball fb = (Fireball)fireball.AddComponent<Fireball>();
        fb.setDirection(direction);
        return fireball;
    }
}
