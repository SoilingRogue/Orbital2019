using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour {
    public TextMeshProUGUI killsText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI waveText;

    void Start() {
        killsText.text = "Highest kill count is " + PlayerPrefs.GetInt("Highscore", 0);
        timeText.text = "Longest survival time is " + PlayerPrefs.GetFloat("SurvivalTime", 0);
        waveText.text = "Highest wave encountered is " + PlayerPrefs.GetInt("WaveCount", 0);
    }

    public void writeAllDefaultValues() {
       Animator[] anims = GameObject.FindObjectsOfType<Animator>();
       foreach (Animator anim in anims) {
           anim.WriteDefaultValues();
       }
    }
}
