using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour {
    private string sceneName;
    public TMP_Dropdown sceneDropdown;
    public TextMeshProUGUI skillDescriptionText;
    private GameObject selectedSkillButton;

    private List<string> validSceneNames;
    private List<string> sceneOptions;

    void Start() {
        sceneOptions = new List<string>() {
            "Volcano",
            "Plane"
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

    public void selectSkillButton(GameObject button) {
        selectedSkillButton = button;
    }

    public void displaySkillDescription() {
        skillDescriptionText.text = selectedSkillButton.GetComponentInChildren<Text>().text;
    }
}
