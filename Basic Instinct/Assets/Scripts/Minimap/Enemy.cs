using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject fireboltPrefab;
    private float timeToNextAttack;
    public float attackCooldown;
    private GameObject player;
    private Vector3 direction;
    public bool isAggressive;
    void Start() {
        // Find player to target
        // This only works assuming the scene has only 1 player.
        player = GameObject.FindWithTag("Player");

        // After spawning, attack only after 2s
        timeToNextAttack = 2f;
    }

    void Update() {
        if (player != null) {
            // Calculate the direction to face the player
            direction = player.transform.position - transform.position;
        }
        else {
            direction = transform.forward;
        }
        // Make the enemy face the player
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;

        timeToNextAttack -= Time.deltaTime;
        if (timeToNextAttack <= 0) {
            if (isAggressive) {
                attack();
            }
            timeToNextAttack = attackCooldown;
        }
    }

    void attack() {
        // Spawn a sphere
        GameObject fireball = spawnFireball();
        if (fireball != null) {
            fireball.SetActive(true);
        }
    }

    GameObject spawnFireball() {
        if (fireboltPrefab != null) {
            float enemyHeight = GetComponent<Collider>().bounds.extents.y;
            Vector3 scale = new Vector3(2, 2, 2);
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + enemyHeight, transform.position.z);
            Vector3 buffer = transform.forward.normalized;
            Quaternion spawnRotation = transform.rotation;
            return Instantiate(fireboltPrefab, spawnPosition + buffer, spawnRotation);
        }
        else {
            Debug.LogWarning("Enemy has no fireball prefab.");
            return null;
        }
    }
}
