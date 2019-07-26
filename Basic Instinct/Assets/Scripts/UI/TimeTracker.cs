using UnityEngine;
using TMPro;

public class TimeTracker : MonoBehaviour {
    public TextMeshProUGUI timeText;
    [HideInInspector]
    public float time;

    void Start() {
        time = 0f;
    }

    void Update() {
        time += Time.deltaTime;
        timeText.text = "Time " + time.ToString("F");
    }
}
