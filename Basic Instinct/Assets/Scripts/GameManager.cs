using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public SpawningSystem spawningSystem;
    public GameObject player;
    public Canvas UI;

    public int getCurrentWave() {
        return spawningSystem.currentWave;
    }

    public float getTimeToNextWave() {
        return spawningSystem.timeToNextSpawn;
    }

    void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
