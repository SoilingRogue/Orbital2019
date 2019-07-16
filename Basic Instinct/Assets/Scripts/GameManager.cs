using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public SpawningSystem spawningSystem;
    public PauseMenu pauseMenu;
    // public GameObject player;
    // public Canvas UI;

    public int getCurrentWave() {
        return spawningSystem.currentWave;
    }

    public float getTimeToNextWave() {
        return spawningSystem.timeToNextSpawn;
    }

    public void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void unhideLoseMenu() {
        pauseMenu.pauseGame();
        pauseMenu.transform.GetChild(1).gameObject.SetActive(true);
    }
}
