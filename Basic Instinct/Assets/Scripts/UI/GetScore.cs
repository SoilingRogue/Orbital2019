using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetScore : MonoBehaviour {
    public ScoreSystem scoreSystem;
    public TextMeshProUGUI scoreText;

    void Start() {
        scoreText.text = "You scored " + scoreSystem.score;
    }
}
