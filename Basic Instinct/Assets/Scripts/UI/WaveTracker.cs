using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTracker : MonoBehaviour {
    public GameManager gameManager;
    private Text text;

    void Start() {
        text = GetComponent<Text>();
    }

    void Update() {
        int currentWave = gameManager.getCurrentWave();
        text.text = "Wave: " + currentWave;
    }
}
