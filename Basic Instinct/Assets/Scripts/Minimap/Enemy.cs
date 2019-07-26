using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject fireboltPrefab;
    private float timeToNextAttack;
    public float attackCooldown;
    public float fireballSpeed;
    public float fireballDuration;
    private GameObject player;
    private Vector3 direction;
    public bool isAggressive;
    private GameObject fireball;
    

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
        // Make the enemy face the player without tilting
        direction.y = 0;
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

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Hit by player.");

            GameObject.Destroy(gameObject, 0.1f);
        }
    }

    void attack() {
        // Spawn a sphere
        fireball = spawnFireball();
        if (fireball != null) {
            fireball.SetActive(true);
            SmallFireball script = fireball.GetComponent<SmallFireball>();
            script.direction = direction;
            script.duration = fireballDuration;
            script.speed = fireballSpeed;
        }
    }

    GameObject spawnFireball() {
        if (fireboltPrefab != null) {
            float enemyHeight = GetComponent<Collider>().bounds.extents.y;
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + enemyHeight * 0.75f, transform.position.z);
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
