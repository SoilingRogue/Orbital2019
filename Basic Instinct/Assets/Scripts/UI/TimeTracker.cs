using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTracker : MonoBehaviour {
    public GameManager gameManager;
    private Text text;

    void Start() {
        text = GetComponent<Text>();
    }

    void Update() {
        float t = gameManager.getTimeToNextWave();
        text.text = "Next wave in " + (int)t;
    }
}
