using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject fireboltPrefab;
    public int maxHealth = 100;
    private int currentHealth;
    private float timeToNextAttack;
    public float attackCooldown = 3f;
    private GameObject player;
    private Vector3 direction;
    void Start() {
        // Find player to target
        // This only works assuming the scene has only 1 player.
        Object[] temp = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject o in temp) {
            if (o.CompareTag("Player")) {
                player = o;
                break;
            }
        }

        currentHealth = maxHealth;
        // After spawning, 
        timeToNextAttack = 2f;
    }

    void Update() {
        // Calculate the direction to face the player
        direction = player.transform.position - transform.position;
        // Make the enemy face the player
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;

        timeToNextAttack -= Time.deltaTime;
        if (timeToNextAttack <= 0) {
            attack();
            timeToNextAttack = attackCooldown;
        }
    }

    void attack() {
        // Spawn a sphere
        GameObject fireball = spawnFireball();
        fireball.SetActive(true);
        Destroy(fireball, 6f);
    }

    GameObject spawnFireball() {
        float enemyHeight = GetComponent<Collider>().bounds.extents.y;
        Vector3 scale = new Vector3(2, 2, 2);
        return Instantiate(fireboltPrefab, new Vector3(transform.position.x, transform.position.y + enemyHeight, transform.position.z) + transform.forward.normalized, transform.rotation);
        // GameObject fireball = new GameObject("Fireball");
        // // Set fireball location to enemy location at the start
        // fireball.transform.position = transform.position;
        // // Use a script to handle projectile movement
        // Fireball fb = (Fireball)fireball.AddComponent<Fireball>();
        // fb.setDirection(direction);
        // return fireball;
    }
}
