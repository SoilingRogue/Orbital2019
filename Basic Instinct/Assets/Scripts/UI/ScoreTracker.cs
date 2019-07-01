using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {
    private Text scoreText;

    void Start() {
        scoreText = GetComponent<Text>();
        scoreText.text = "0";
    }

    void Update() {
        updateScore(Time.deltaTime);
    }

    void updateScore(float d) {
        float curr = float.Parse(scoreText.text);
        float next = curr + d;
        scoreText.text = "" + next;
    }
}
