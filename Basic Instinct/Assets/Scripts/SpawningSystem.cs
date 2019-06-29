using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSystem : MonoBehaviour {
    public GameObject enemyPrefab;
    private float timeToNextSpawn;
    private int nextSpawnCount;

    void Start() {
        // How long it takes after game start to spawn enemies
        timeToNextSpawn = 2f;
        // First wave has 1 enemy
        nextSpawnCount = 1;
    }

    void Update() {
        timeToNextSpawn -= Time.deltaTime;
        if (timeToNextSpawn <= 0) {
            spawnEnemies();
            nextSpawnCount = getNextSpawnCount();
            // 10 sec delay between waves
            timeToNextSpawn = 10f;
        }
    }

    // Enemy count increases exponentially
    int getNextSpawnCount() {
        return 2 * nextSpawnCount;
    }

    void spawnEnemies() {
        for (int i = 0; i < nextSpawnCount; i++) {
            // Temporary position
            Vector3 position = enemyPrefab.transform.position;
            spawnEnemyAt(position);
        }
    }

    void spawnEnemyAt(Vector3 position) {
        // Temporary rotation
        Quaternion rotation = Quaternion.identity;
        GameObject enemyClone = Instantiate(enemyPrefab, position, rotation);
        enemyClone.SetActive(true);
    }
}
