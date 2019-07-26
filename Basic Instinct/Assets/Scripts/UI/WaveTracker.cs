using UnityEngine;
using TMPro;

public class WaveTracker : MonoBehaviour {
    public SpawningSystem spawningSystem;
    public TextMeshProUGUI waveText;

    void Update() {
        waveText.text = "Wave " + spawningSystem.currentWave;
    }
}
