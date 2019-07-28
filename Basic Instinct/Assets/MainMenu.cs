using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    void Start() {
        startBackgroundMusic();
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
