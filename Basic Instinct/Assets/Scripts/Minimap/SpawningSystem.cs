using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSystem : MonoBehaviour {
    [HideInInspector]
    public int currentWave;
    [HideInInspector]
    public float timeToNextSpawn;
    public GameObject enemyPrefab;
    public GameObject spawnPlane;
    private GameObject player;
    
    private int nextSpawnCount;

    void Start() {
        // First wave is wave 0
        currentWave = 0;

        // Get a reference to the player
        player = GameObject.FindGameObjectWithTag("Player");

        // Spawn first enemy 2 seconds after starting the game
        timeToNextSpawn = 2f;
        // First wave has 1 enemy
        nextSpawnCount = 1;
    }

    void Update() {
        timeToNextSpawn -= Time.deltaTime;
        if (timeToNextSpawn <= 0) {
            // Increase current wave number
            currentWave++;

            spawnEnemies();
            increaseSpawnCount();
            // 10 sec delay between waves
            timeToNextSpawn = 10f;
        }
    }

    // Enemy count increases exponentially
    void increaseSpawnCount() {
        nextSpawnCount ++;
    }

    void spawnEnemies() {
        for (int i = 0; i < nextSpawnCount; i++) {
            // Get random spawn location
            Vector3 position = getRandomSpawnLocation();
            spawnEnemyAt(position);
        }
    }

    Vector3 getRandomSpawnLocation() {
        Bounds planeBounds = spawnPlane.GetComponent<Collider>().bounds;
        float randomX = Random.Range(planeBounds.min.x, planeBounds.max.x);
        float randomZ = Random.Range(planeBounds.min.z, planeBounds.max.z);
        Vector3 result = new Vector3(randomX, spawnPlane.transform.position.y, randomZ);
        // Check if spawning location is too close to player
        if (Vector3.Distance(result, player.transform.position) <= 5) {
            Debug.Log("Randomizing spawn location again.");
            return getRandomSpawnLocation();
        }
        else {
            return result;
        }
    }

    void spawnEnemyAt(Vector3 position) {
        // Dummy rotation, doesn't matter as it will get updated every frame
        Quaternion dummyRotation = Quaternion.identity;
        GameObject enemyClone = Instantiate(enemyPrefab, position, dummyRotation);
        enemyClone.SetActive(true);
    }
}
