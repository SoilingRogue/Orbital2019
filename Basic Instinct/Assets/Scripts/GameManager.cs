using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject gameUI;
    public GameObject pauseMenu;
    public GameObject loseMenu;
    public ScoreSystem scoreSystem;
    public SpawningSystem spawningSystem;

    [HideInInspector]
    public float timer;
    [HideInInspector]
    public bool isPaused;
    [HideInInspector]
    public bool gameOver;

    void Start() {
        startBackgroundMusic();
        timer = 0f;
        
        // Hide mouse cursor
        Cursor.visible = false;
    }

    public void loseGame() {
        // Freeze game
        Time.timeScale = 0f;
        // Hide Game UI
        gameUI.SetActive(false);
        // Bring up pause panel
        loseMenu.SetActive(true);
        // Set variable for other scripts
        isPaused = true;
        // Game is over
        gameOver = true;
        // Show mouse cursor
        Cursor.visible = true;
    }

    public void pauseGame() {
        // Freeze game
        Time.timeScale = 0f;
        // Hide Game UI
        gameUI.SetActive(false);
        // Bring up pause panel
        pauseMenu.SetActive(true);
        // Set variable for other scripts
        isPaused = true;
        // Show mouse cursor
        Cursor.visible = true;
    }

    public void resumeGame() {
        // Unfreeze game
        Time.timeScale = 1f;
        // Bring up Game UI
        gameUI.SetActive(true);
        // Hide pause panel
        pauseMenu.SetActive(false);
        // Set variable
        isPaused = false;
        // Hide mouse cursor
        Cursor.visible = false;
    }

    public void loadMenu() {
        // Unfreeze game
        Time.timeScale = 1f;
        // Set variable
        isPaused = false;
        // Load start screen
        SceneManager.LoadScene("StartScreen");
    }

    public void quitGame() {
        Debug.Log("Exiting game.");
        Application.Quit();
    }

    public void restartGame() {
        // Unfreeze game
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void lose() {
        loseGame();
        // Save highscore
        scoreSystem.saveHighScore();
        // Save wave count
        spawningSystem.saveWaveCount();
        // Save time
        saveTime();
    }

    void Update() {
        if (!gameOver) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (isPaused) {
                    resumeGame();
                }
                else {
                    pauseGame();
                }
            }
        }
    }

    public void startBackgroundMusic() {
        AudioManager audioManager = GameObject.FindObjectOfType<AudioManager>();
        if (audioManager != null) {
            audioManager.Play("BattleLoop");
        }
    }

    public void stopBackgroundMusic() {
        AudioManager audioManager = GameObject.FindObjectOfType<AudioManager>();
        if (audioManager != null) {
            audioManager.Stop("BattleLoop");
        }
    }

    private void saveTime() {
        PlayerPrefs.SetFloat("SurvivalTime", gameUI.GetComponentInChildren<TimeTracker>().time);
    }
}
