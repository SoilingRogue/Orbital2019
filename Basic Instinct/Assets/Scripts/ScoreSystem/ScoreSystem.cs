using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour {
    [HideInInspector]
    public int score;

    void Start() {
        score = 0;
    }
    
    public void saveHighScore() {
        Debug.Log("Saving high score of " + score);
        int currentHighScore = PlayerPrefs.GetInt("Highscore");
        if (score > currentHighScore) {
            PlayerPrefs.SetInt("Highscore", score);
        }
    }

    public int loadHighScore() {
        int highScore = PlayerPrefs.GetInt("Highscore");
        Debug.Log("Loading high score of " + highScore);
        return highScore;
    }
}
