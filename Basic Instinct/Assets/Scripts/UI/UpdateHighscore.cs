using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateHighscore : MonoBehaviour {
    public GameManager gameManager;
    void Start() {
        int highscore = gameManager.getHighscore();
        TMP_Text highScoreText = gameObject.GetComponent<TMP_Text>();
        highScoreText.text = "Highscore: " + highscore.ToString();
    }
}
