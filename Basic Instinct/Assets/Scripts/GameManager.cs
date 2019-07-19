using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public SpawningSystem spawningSystem;
    public ScoreSystem scoreSystem;
    public PauseMenu pauseMenu;
    // public GameObject player;
    // public Canvas UI;
    public float timer;

    void Start() {
        timer = 0f;
    }

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
        pauseMenu.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void lose() {
        pauseMenu.pauseGame();
        // Save highscore
        scoreSystem.saveHighScore();
        unhideLoseMenu();
    }

    public int getHighscore() {
        return scoreSystem.loadHighScore();
    }

    void Update() {
        int score = (int)(Time.time - timer);
        scoreSystem.score = score;
    }
}
