using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTracker : MonoBehaviour {
    public TextMeshProUGUI scoreText;
    public ScoreSystem scoreSystem;

    void Update() {
        scoreText.text = "Score " + scoreSystem.score;
    }
}
