using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public Scrollbar healthBar;
    private CharacterStats stats;

    void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            stats = player.GetComponent<CharacterStats>();
        }
    }

    void Update() {
        if (stats != null) {
            float healthFraction = (float)stats.currentHealth / (float)stats.maxHealth;
            healthBar.size = healthFraction;
        }
    }
}
