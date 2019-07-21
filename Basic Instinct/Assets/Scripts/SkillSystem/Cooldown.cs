using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add the TextMesh Pro namespace to access the various functions.
public class Cooldown : MonoBehaviour
{
    public Skill skill;
    public TextMeshProUGUI key;
    public Image imageCooldown;
    public TextMeshProUGUI timer;
    public string button;

    void Start() {
        Debug.Log("Button: " + button);
        key.text = button;
    }

    void Update() {
        if (key.text == "") {
            key.text = button;
        }

        if (skill != null) {
            if (!skill.isOnCooldown()) {
                imageCooldown.fillAmount = 0;
                timer.text = "";
            }
            else {
                imageCooldown.fillAmount -= 1 / skill.cooldown * Time.deltaTime;
                timer.text = skill.cooldownTimer.ToString("F");
            }
        }
    }
}