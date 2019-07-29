using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class MainMenu : MonoBehaviour {
    public AudioMixer audioMixer;

    void Start() {
        // Use settings

        // Fullscreen
        bool fullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1 ? true : false;
        Screen.fullScreen = fullscreen;

        // Quality
        int qualityIndex = PlayerPrefs.GetInt("Quality", 0);
        QualitySettings.SetQualityLevel(qualityIndex);

        // Volume
        float volume = PlayerPrefs.GetFloat("Volume", 0);
        audioMixer.SetFloat("volume", volume);

        startBackgroundMusic();
    }

    private int getHighscore() {
        return PlayerPrefs.GetInt("Highscore");
    }

    public void exitGame() {
        Debug.Log("Quit Game.");
        Application.Quit();
    }

    public void writeAllDefaultValues() {
       Animator[] anims = GameObject.FindObjectsOfType<Animator>();
       foreach (Animator anim in anims) {
           anim.WriteDefaultValues();
       }
    }

    public void startBackgroundMusic() {
        AudioManager audioManager = GameObject.FindObjectOfType<AudioManager>();
        if (audioManager != null) {
            audioManager.Play("ActionTime");
        }
    }
}
