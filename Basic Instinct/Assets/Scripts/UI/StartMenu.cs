using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour {
    private string sceneName;
    public TMP_Dropdown sceneDropdown;

    private List<string> validSceneNames;
    private List<string> sceneOptions;

    void Start() {
        sceneOptions = new List<string>() {
            "Game Scene 1",
            "Game Scene 2"
        };
        validSceneNames = new List<string>() {
            "GameScene1",
            "GameScene2"
        };
        sceneDropdown.ClearOptions();
        sceneDropdown.AddOptions(sceneOptions);
        // Default scene
        sceneName = validSceneNames[0];
    }

    public void loadNextScene() {
        SceneManager.LoadScene(sceneName);
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

    public void stopBackgroundMusic() {
        AudioManager audioManager = GameManager.FindObjectOfType<AudioManager>();
        if (audioManager != null) {
            audioManager.Stop("ActionTime");
        }
    }

    public void setSceneName(int sceneNameIndex) {
        sceneName = validSceneNames[sceneNameIndex];
    }
}
